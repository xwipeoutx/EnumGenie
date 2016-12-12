using System;

namespace EnumGenie.Filters
{
    public class PredicateFilter : IEnumFilter
    {
        private readonly Func<Type, bool> _predicate;

        public PredicateFilter(Func<Type, bool> predicate)
        {
            _predicate = predicate;
        }

        public bool ShouldEmit(Type type)
        {
            return _predicate(type);
        }
    }
}