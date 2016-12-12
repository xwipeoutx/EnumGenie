namespace EnumGenie.Writers
{
    public class WriterConfig
    {
        private IEnumWriter _writer;

        public void Custom(IEnumWriter writer)
        {
            _writer = writer;
        }

        internal IEnumWriter Writer => _writer;
    }
}