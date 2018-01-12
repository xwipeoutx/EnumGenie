using System;
using EnumGenie.Writers;

namespace EnumGenie.TypeScript
{
    public static class TypeScriptWriterExtensions
    {
        /// <summary>
        /// Generate TypeScript representations of the enums
        /// </summary>
        public static void TypeScript(this WriterConfig config, Action<TypeScriptWriterConfig> configure = null)
        {
            var tsConfig = new TypeScriptWriterConfig();
            if (configure == null)
                tsConfig.Everything();
            else
                configure(tsConfig);

            config.Custom(tsConfig.CreateWriter());
        }

        /// <summary>
        /// Output declarations, descriptions and descriptors. Default.
        /// </summary>
        public static TypeScriptWriterConfig Everything(this TypeScriptWriterConfig config)
        {
            return config.Declaration().Description().Descriptor();
        }

        /// <summary>
        /// Outputs just the enum
        /// </summary>
        public static TypeScriptWriterConfig Declaration(this TypeScriptWriterConfig config, Action<EnumDeclarationWriterConfig> configureDeclaration = null)
        {
            var declarationConfig = new EnumDeclarationWriterConfig();
            configureDeclaration?.Invoke(declarationConfig);

            var writer = new EnumDeclarationWriter(declarationConfig);
            config.AddTypeScriptWriter(writer);
            return config;
        }

        /// <summary>
        /// Outputs functions to get the descriptions of the enums
        /// </summary>
        public static TypeScriptWriterConfig Description(this TypeScriptWriterConfig config)
        {
            config.AddTypeScriptWriter(new EnumDescriptionFunctionWriter());
            return config;
        }

        /// <summary>
        /// Outputs full descriptors, which include the name, value and description
        /// </summary>
        public static TypeScriptWriterConfig Descriptor(this TypeScriptWriterConfig config)
        {
            config.AddTypeScriptWriter(new EnumDescriptorWriter());
            return config;
        }
    }
}