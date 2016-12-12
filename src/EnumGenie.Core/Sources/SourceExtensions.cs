using System;
using System.Collections.Generic;
using System.Reflection;

namespace EnumGenie.Sources
{
    public static class SourceExtensions
    {
        public static EnumGenie List(this Source source, IEnumerable<Type> enums)
        {
            return source.Custom(new StaticEnumSource(enums));
        }

        public static EnumGenie Assembly(this Source source, Assembly assembly)
        {
            return source.Custom(new AssemblyEnumSource(assembly));
        }
    }
}