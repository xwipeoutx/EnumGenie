using System.IO;

namespace EnumGenie.Writers
{
    public interface IEnumWriter
    {
        void WriteTo(Stream stream, EnumDefinition enumDefinition);
    }
}
