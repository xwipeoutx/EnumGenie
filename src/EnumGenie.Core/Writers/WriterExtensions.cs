using System;

namespace EnumGenie.Writers
{
    public static class WriterExtensions
    {
        public static EnumGenie File(this Writer writer, string file, Action<WriterConfig> configure)
        {
            var config = new WriterConfig();
            configure(config);

            return writer.Custom(new FileWriter(file, config.Writer));
        }

        public static EnumGenie Console(this Writer writer, Action<WriterConfig> configure)
        {
            var config = new WriterConfig();
            configure(config);

            return writer.Custom(new ConsoleWriter(config.Writer));
        }
    }
}