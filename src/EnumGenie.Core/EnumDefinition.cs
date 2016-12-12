using System;
using System.Collections.Generic;

namespace EnumGenie
{
    public class EnumDefinition
    {
        public EnumDefinition(Type enumType, string name, IReadOnlyCollection<EnumMemberDefinition> members)
        {
            EnumType = enumType;
            Name = name;
            Members = members;
        }

        public Type EnumType { get; }
        public string Name { get; }

        public IReadOnlyCollection<EnumMemberDefinition> Members { get; }
    }
}