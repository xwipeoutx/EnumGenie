using System.IO;
using EnumGenie.Writers;

namespace EnumGenie.TypeScript
{
    public class EnumDescriptionFunctionWriter : IEnumWriter
    {
        public void WriteTo(Stream stream, EnumDefinition enumDefinition)
        {
            var writer = new StreamWriter(stream);
            var functionName = char.ToLowerInvariant(enumDefinition.Name[0]) + enumDefinition.Name.Substring(1) + "Description";
            writer.WriteLine($"export function {functionName}(value: {enumDefinition.Name}) {{");
            writer.WriteLine("    switch (value) {");

            foreach (var member in enumDefinition.Members)
            {
                writer.WriteLine($"        case {enumDefinition.Name}.{member.Name}:");
                writer.WriteLine($"            return `{member.Description}`;");
            }

            writer.WriteLine("    }");
            writer.WriteLine("}");
            writer.Flush();
        }
    }
}
