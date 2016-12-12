namespace EnumGenie.Writers
{
    /// <summary>
    /// Entry configurator for writers. Use extension methods for better readability
    /// </summary>
    public class Writer
    {
        private readonly EnumGenie _enumGenie;

        public Writer(EnumGenie enumGenie)
        {
            _enumGenie = enumGenie;
        }

        internal EnumGenie Custom(IWriter writer)
        {
            _enumGenie.AddWriter(writer);
            return _enumGenie;
        }
    }
}