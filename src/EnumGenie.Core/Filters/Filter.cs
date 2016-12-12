namespace EnumGenie.Filters
{
    public class Filter
    {
        private readonly EnumGenie _enumGenie;

        public Filter(EnumGenie enumGenie)
        {
            _enumGenie = enumGenie;
        }

        internal EnumGenie Custom(IEnumFilter filter)
        {
            _enumGenie.AddFilter(filter);
            return _enumGenie;
        }
    }
}