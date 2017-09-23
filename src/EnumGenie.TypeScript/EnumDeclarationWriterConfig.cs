namespace EnumGenie.TypeScript
{
    public class EnumDeclarationWriterConfig
    {
        public bool Const { get; private set; }

        public EnumDeclarationWriterConfig AsConst() { Const = true; return this; }
    }
}