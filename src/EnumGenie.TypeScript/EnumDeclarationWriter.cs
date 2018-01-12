using System;
using System.IO;
using System.Linq;
using EnumGenie.Writers;

namespace EnumGenie.TypeScript
{
    public class EnumDeclarationWriter : IEnumWriter
    {
        private readonly bool _const;

        public EnumDeclarationWriter(EnumDeclarationWriterConfig config)
        {
            _const = config?.Const ?? false;
        }

        public void WriteTo(Stream stream, EnumDefinition enumDefinition)
        {
            var writer = new StreamWriter(stream);
            var writeConst = _const ? "const " : string.Empty;
            writer.WriteLine($"export {writeConst}enum {enumDefinition.Name} {{");

            writer.Write(string.Join($",{Environment.NewLine}", enumDefinition.Members.Select(MemberValueAssignment)));
            writer.WriteLine();

            writer.WriteLine("}");
            writer.Flush();
        }

        private static string MemberValueAssignment(EnumMemberDefinition member)
        {
            return $"    {member.Name} = {member.Value}";
        }
    }
}
