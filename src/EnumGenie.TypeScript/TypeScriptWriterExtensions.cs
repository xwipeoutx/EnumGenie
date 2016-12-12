using System;
using EnumGenie.Writers;

namespace EnumGenie.TypeScript
{
    public static class TypeScriptWriterExtensions
    {
        public static void TypeScript(this WriterConfig config, Action<TypeScriptWriterConfig> configure = null)
        {
            var tsConfig = new TypeScriptWriterConfig();
            if (configure == null)
                tsConfig.Everything();
            else
                configure(tsConfig);

            config.Custom(tsConfig.CreateWriter());
        }

        public static TypeScriptWriterConfig Everything(this TypeScriptWriterConfig config)
        {
            return config.Declaration().Description().Descriptor();
        }

        public static TypeScriptWriterConfig Declaration(this TypeScriptWriterConfig config)
        {
            config.AddTypeScriptWriter(new EnumDeclarationWriter());
            return config;
        }

        public static TypeScriptWriterConfig Description(this TypeScriptWriterConfig config)
        {
            config.AddTypeScriptWriter(new EnumDescriptionFunctionWriter());
            return config;
        }

        public static TypeScriptWriterConfig Descriptor(this TypeScriptWriterConfig config)
        {
            config.AddTypeScriptWriter(new EnumDescriptorWriter());
            return config;
        }
    }
}