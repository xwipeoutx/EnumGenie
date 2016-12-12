using System;

namespace EnumGenie.Filters
{
    public interface IEnumFilter
    {
        bool ShouldEmit(Type type);
    }
}