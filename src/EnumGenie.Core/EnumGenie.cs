using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using EnumGenie.Filters;
using EnumGenie.Sources;
using EnumGenie.Transforms;
using EnumGenie.Writers;

namespace EnumGenie
{
    public class EnumGenie
    {
        private readonly List<IEnumSource> _sources = new List<IEnumSource>();
        private readonly List<IEnumFilter> _filters = new List<IEnumFilter>();
        private readonly List<IWriter> _writers = new List<IWriter>();
        private readonly List<ITransform> _transforms = new List<ITransform>();

        public Source SourceFrom => new Source(this);
        public Filter FilterBy => new Filter(this);
        public Writer WriteTo => new Writer(this);
        public Transform TransformBy => new Transform(this);

        internal void AddSource(IEnumSource enumSource)
        {
            _sources.Add(enumSource);
        }

        internal void AddFilter(IEnumFilter filter)
        {
            _filters.Add(filter);
        }

        internal void AddWriter(IWriter writer)
        {
            _writers.Add(writer);
        }

        public void AddTransform(ITransform transform)
        {
            _transforms.Add(transform);
        }

        public void Write()
        {
            var enumTypes = _sources.SelectMany(s => s.EnumTypes)
                .Where(t => _filters.All(f => f.ShouldEmit(t)))
                .Distinct()
                .ToList();

            var nonEnumTypes = enumTypes.Where(e => !e.IsEnum).ToList();

            if (nonEnumTypes.Any())
                throw new InvalidOperationException($"Can only write enum types. Fail on: {string.Join(",", nonEnumTypes.Select(e => e.Name))}");

            var definitions = enumTypes
                .Select(EnumDefinition)
                .Select(def => _transforms.Aggregate(def, (old, transform) => transform.Transform(old)))
                .ToList();

            foreach (var writer in _writers)
            {
                writer.Write(definitions.ToList());
            }
        }

        private static EnumDefinition EnumDefinition(Type enumType)
        {
            var memberDefinitions = enumType.GetEnumValues()
                .Cast<int>()
                .Select(value => MemberDefinition(enumType, value))
                .ToList();

            return new EnumDefinition(enumType, enumType.Name, memberDefinitions);
        }

        private static EnumMemberDefinition MemberDefinition(Type enumType, int value)
        {
            var name = Enum.GetName(enumType, value);
            var member = enumType.GetMember(name)[0];
            var descriptionAttribute = member.GetCustomAttributes(false).OfType<DescriptionAttribute>().FirstOrDefault();
            var description = descriptionAttribute?.Description ?? name;

            return new EnumMemberDefinition(member, value, name, description);
        }
    }
}