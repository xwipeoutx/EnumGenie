using System;

namespace EnumGenie.Transforms
{
    public class CustomTransform : ITransform
    {
        private readonly Func<EnumDefinition, EnumDefinition> _doTransform;

        public CustomTransform(Func<EnumDefinition, EnumDefinition> doTransform)
        {
            _doTransform = doTransform;
        }

        public EnumDefinition Transform(EnumDefinition other)
        {
            return _doTransform(other);
        }
    }
}