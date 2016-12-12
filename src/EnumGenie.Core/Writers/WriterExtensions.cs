using System;

namespace EnumGenie.Writers
{
    public static class WriterExtensions
    {
        public static EnumGenie File(this Writer writer, string file, Action<WriterConfig> configure)
        {
            WriterConfig config = new WriterConfig();
            configure(config);

            return writer.Custom(new FileWriter(file, config.Writer));
        }
    }
}