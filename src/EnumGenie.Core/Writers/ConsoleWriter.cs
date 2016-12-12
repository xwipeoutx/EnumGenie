using System;
using System.Collections.Generic;

namespace EnumGenie.Writers
{
    public class ConsoleWriter : IWriter
    {
        private readonly IEnumWriter _enumWriter;

        public ConsoleWriter(IEnumWriter enumWriter)
        {
            _enumWriter = enumWriter;
        }

        public void Write(IReadOnlyCollection<EnumDefinition> enumDefinitions)
        {
            using (var stream = Console.OpenStandardOutput())
            {
                foreach (var definition in enumDefinitions)
                {
                    _enumWriter.WriteTo(stream, definition);
                }
            }
        }
    }
}