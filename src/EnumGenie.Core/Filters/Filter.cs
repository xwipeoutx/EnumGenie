namespace EnumGenie.Filters
{
    /// <summary>
    /// Entry configurator for filters. Use extension methods for better readability
    /// </summary>
    public class Filter
    {
        private readonly EnumGenie _enumGenie;

        public Filter(EnumGenie enumGenie)
        {
            _enumGenie = enumGenie;
        }

        /// <summary>
        /// Define a custom filter.  It is recommended to use the <c>Custom</c> EXTENSION method
        /// instead, for a simple LINQ-based filter.
        /// </summary>
        public EnumGenie Custom(IEnumFilter filter)
        {
            _enumGenie.AddFilter(filter);
            return _enumGenie;
        }
    }
}