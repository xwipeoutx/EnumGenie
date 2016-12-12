namespace EnumGenie.Sources
{
    /// <summary>
    /// Entry configurator for sources. Use extension methods for better readability
    /// </summary>
    public class Source
    {
        private readonly EnumGenie _enumGenie;

        public Source(EnumGenie enumGenie)
        {
            _enumGenie = enumGenie;
        }

        public EnumGenie Custom(IEnumSource source)
        {
            _enumGenie.AddSource(source);
            return _enumGenie;
        }
    }
}