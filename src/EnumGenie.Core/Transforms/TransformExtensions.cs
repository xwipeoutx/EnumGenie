using System;

namespace EnumGenie.Transforms
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Define a custom transformation.
        /// </summary>
        public static EnumGenie Custom(this Transform transform, Func<EnumDefinition, EnumDefinition> transformFunction)
        {
            var renameTransform = new CustomTransform(transformFunction);
            return transform.Custom(renameTransform);
        }

        /// <summary>
        /// Change the name of the enum by passing in a delegate. This does not affect the members
        /// </summary>
        public static EnumGenie RenamingEnum(this Transform transform, Func<EnumDefinition, string> transformName)
        {
            var renameTransform = new CustomTransform(other => new EnumDefinition(other.EnumType, transformName(other), other.Members));
            return transform.Custom(renameTransform);
        }
    }
}