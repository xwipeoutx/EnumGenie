namespace EnumGenie.Writers
{
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