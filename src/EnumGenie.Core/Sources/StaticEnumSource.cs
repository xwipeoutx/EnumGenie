using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumGenie.Sources
{
    public class StaticEnumSource : IEnumSource
    {
        public StaticEnumSource(IEnumerable<Type> enums)
        {
            EnumTypes = enums.ToArray();
        }

        public IEnumerable<Type> EnumTypes { get; }
    }
}