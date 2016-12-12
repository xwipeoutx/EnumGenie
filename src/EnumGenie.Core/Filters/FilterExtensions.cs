using System;

namespace EnumGenie.Filters
{
    public static class FilterExtensions
    {
        public static EnumGenie Predicate(this Filter filter, Func<Type, bool> predicate)
        {
            return filter.Custom(new PredicateFilter(predicate));
        }
    }
}