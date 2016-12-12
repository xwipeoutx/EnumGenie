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
    /// <summary>
    /// Entry point to describe how to read and outputs enums.  Configure by using
    /// <c>SourceFrom</c>, <c>FilterBy</c>, <c>WriteTo</c> and <c>TransformBy</c> properties.
    /// 
    /// The configurations here mutate the genie, so don't expect to be able to stack them.
    /// </summary>
    public class EnumGenie
    {
        private readonly List<IEnumSource> _sources = new List<IEnumSource>();
        private readonly List<IEnumFilter> _filters = new List<IEnumFilter>();
        private readonly List<IWriter> _writers = new List<IWriter>();
        private readonly List<ITransform> _transforms = new List<ITransform>();

        /// <summary>
        /// Configures from where the enums can be read
        /// </summary>
        public Source SourceFrom => new Source(this);

        /// <summary>
        /// Allows removal of unwanted enums.
        /// </summary>
        public Filter FilterBy => new Filter(this);

        /// <summary>
        /// Describes where to write the generated enums.  Each writer has its 
        /// own configuration for the output type.
        /// </summary>
        public Writer WriteTo => new Writer(this);

        /// <summary>
        /// Allows a transform over a given enum definition.  Allows hefty customisation
        /// of the enum descriptions
        /// </summary>
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

        internal void AddTransform(ITransform transform)
        {
            _transforms.Add(transform);
        }

        /// <summary>
        /// Writes all the enums from the sources to the specified writers
        /// </summary>
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
                .Select(value => EnumMemberDefinition(enumType, value))
                .ToList();

            return new EnumDefinition(enumType, enumType.Name, memberDefinitions);
        }

        private static EnumMemberDefinition EnumMemberDefinition(Type enumType, int value)
        {
            var name = Enum.GetName(enumType, value);
            var member = enumType.GetMember(name)[0];
            var descriptionAttribute = member.GetCustomAttributes(false).OfType<DescriptionAttribute>().FirstOrDefault();
            var description = descriptionAttribute?.Description ?? name;

            return new EnumMemberDefinition(member, value, name, description);
        }
    }
}