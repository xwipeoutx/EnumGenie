using System.Collections.Generic;

namespace EnumGenie.Writers
{
    public interface IWriter
    {
        void Write(IReadOnlyCollection<EnumDefinition> enumDefinitions);
    }
}