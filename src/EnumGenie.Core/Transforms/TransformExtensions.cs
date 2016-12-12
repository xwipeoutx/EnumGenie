using System;

namespace EnumGenie.Transforms
{
    public static class TransformExtensions
    {
        public static EnumGenie Custom(this Transform transform, Func<EnumDefinition, EnumDefinition> transformFunction)
        {
            var renameTransform = new CustomTransform(transformFunction);
            return transform.Custom(renameTransform);
        }

        public static EnumGenie RenamingEnum(this Transform transform, Func<EnumDefinition, string> transformName)
        {
            var renameTransform = new CustomTransform(other => new EnumDefinition(other.EnumType, transformName(other), other.Members));
            return transform.Custom(renameTransform);
        }
    }
}