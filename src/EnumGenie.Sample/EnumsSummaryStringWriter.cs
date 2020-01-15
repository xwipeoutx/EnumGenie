using System.Collections.Generic;
using System.IO;
using EnumGenie.Writers;

namespace EnumGenie.Sample
{
    public class EnumsSummaryStringWriter : IWriter
    {
        public string Output { get; private set; }

        public void Write(IReadOnlyCollection<EnumDefinition> enumDefinitions)
        {
            using (var stream = new MemoryStream())
            using (var reader = new StreamReader(stream))
            using (var writer = new StreamWriter(stream))
            {
                foreach (var definition in enumDefinitions)
                {
                    writer.WriteLine($"{definition.EnumType.FullName} ({definition.Members.Count} members)");
                }
                writer.Flush();

                stream.Position = 0;
                Output = reader.ReadToEnd();
            }
        }
    }
}