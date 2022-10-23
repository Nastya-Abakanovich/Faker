namespace FakerLibrary.Generators
{
    public class UlongGenerator: IGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(ulong);
        }

        public object Generate(Type type, GeneratorContext context)
        {            
            return (ulong)context.Random.NextInt64(long.MaxValue);
        }
    }
}
