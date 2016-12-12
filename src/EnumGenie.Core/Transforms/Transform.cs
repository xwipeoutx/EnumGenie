namespace EnumGenie.Transforms
{
    /// <summary>
    /// Entry configurator for transforms. Use extension methods for better readability
    /// </summary>
    public class Transform
    {
        private readonly EnumGenie _enumGenie;

        public Transform(EnumGenie enumGenie)
        {
            _enumGenie = enumGenie;
        }

        public EnumGenie Custom(ITransform transform)
        {
            _enumGenie.AddTransform(transform);
            return _enumGenie;
        }
    }
}