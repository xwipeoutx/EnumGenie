using System.Collections.Generic;
using System.IO;

namespace EnumGenie.Writers
{
    public class CompositeWriter : IEnumWriter
    {
        private readonly IReadOnlyCollection<IEnumWriter> _writers;

        public CompositeWriter(IReadOnlyCollection<IEnumWriter> writers)
        {
            _writers = writers;
        }

        public void WriteTo(Stream stream, EnumDefinition enumDefinition)
        {
            foreach (var enumWriter in _writers)
            {
                enumWriter.WriteTo(stream, enumDefinition);
            }
        }
    }
}