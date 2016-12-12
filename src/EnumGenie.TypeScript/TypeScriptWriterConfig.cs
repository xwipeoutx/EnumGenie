using System.Collections.Generic;
using EnumGenie.Writers;

namespace EnumGenie.TypeScript
{
    public class TypeScriptWriterConfig
    {
        private readonly List<IEnumWriter> _writers = new List<IEnumWriter>();

        public void AddTypeScriptWriter(IEnumWriter writer)
        {
            _writers.Add(writer);
        }

        internal IEnumWriter CreateWriter()
        {
            return new CompositeEnumWriter(_writers);
        }
    }
}