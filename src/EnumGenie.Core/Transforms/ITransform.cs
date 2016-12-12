namespace EnumGenie.Transforms
{
    public interface ITransform
    {
        EnumDefinition Transform(EnumDefinition other);
    }
}