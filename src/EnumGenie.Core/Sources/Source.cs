namespace EnumGenie.Sources
{
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