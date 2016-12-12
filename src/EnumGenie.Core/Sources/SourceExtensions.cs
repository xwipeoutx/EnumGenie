using System;
using System.Collections.Generic;
using System.Reflection;

namespace EnumGenie.Sources
{
    public static class SourceExtensions
    {
        /// <summary>
        /// Manually specify the enums
        /// </summary>
        public static EnumGenie List(this Source source, IEnumerable<Type> enums)
        {
            return source.Custom(new StaticEnumSource(enums));
        }

        /// <summary>
        /// Reads all enums in an assembly
        /// </summary>
        public static EnumGenie Assembly(this Source source, Assembly assembly)
        {
            return source.Custom(new AssemblyEnumSource(assembly));
        }
    }
}