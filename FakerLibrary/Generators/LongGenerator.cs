namespace FakerLibrary.Generators
{
    public class LongGenerator: IGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(long);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return context.Random.NextInt64(long.MinValue, long.MaxValue);
        }
    }
}
