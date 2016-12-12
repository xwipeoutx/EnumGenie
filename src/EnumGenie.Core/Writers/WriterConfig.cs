using System;

namespace EnumGenie.Writers
{
    /// <summary>
    /// Entry configurator for writer configuration. Use extension methods for better readability
    /// </summary>
    public class WriterConfig
    {
        private IEnumWriter _writer;

        public void Custom(IEnumWriter writer)
        {
            _writer = writer;
        }

        internal IEnumWriter Writer
        {
            get
            {
                if (_writer == null)
                    throw new InvalidOperationException("Writer configuration must be specified");

                return _writer;
            }
        }
    }
}