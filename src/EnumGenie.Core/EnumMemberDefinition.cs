using System.Reflection;

namespace EnumGenie
{
    public class EnumMemberDefinition
    {
        public EnumMemberDefinition(MemberInfo member, object value, string name, string description)
        {
            Value = value;
            Name = name;
            Description = description;
            Member = member;
        }

        public MemberInfo Member { get; }
        public object Value { get; }
        public string Name { get; }
        public string Description { get; }
    }
}