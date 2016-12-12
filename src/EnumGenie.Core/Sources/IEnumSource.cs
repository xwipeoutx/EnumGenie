using System;
using System.Collections.Generic;

namespace EnumGenie.Sources
{
    public interface IEnumSource
    {
        IEnumerable<Type> EnumTypes { get; }
    }
}