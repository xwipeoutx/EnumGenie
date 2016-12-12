using System;
using System.IO;
using System.Linq;
using EnumGenie.Writers;

namespace EnumGenie.TypeScript
{
    public class EnumDeclarationWriter : IEnumWriter
    {
        public void WriteTo(Stream stream, EnumDefinition enumDefinition)
        {
            var writer = new StreamWriter(stream);
            writer.WriteLine($"export enum {enumDefinition.Name} {{");

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
