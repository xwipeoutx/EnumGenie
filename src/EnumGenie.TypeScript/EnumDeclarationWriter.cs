using System;
using System.IO;
using System.Linq;
using EnumGenie.Writers;

namespace EnumGenie.TypeScript
{
    public class EnumDeclarationWriter : IEnumWriter
    {
        public EnumDeclarationWriter(EnumDeclarationWriterConfig config)
        {
            Const = config?.Const ?? false;
        }

        private bool Const { get; set; }

        public void WriteTo(Stream stream, EnumDefinition enumDefinition)
        {
            var writer = new StreamWriter(stream);
            var writeConst = Const ? "const " : string.Empty;
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
