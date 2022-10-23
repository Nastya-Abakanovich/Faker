namespace FakerLibrary.Generators
{
    public class SbyteGenerator: IGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(sbyte);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return (sbyte)context.Random.Next(sbyte.MinValue, sbyte.MaxValue + 1);
        }
    }
}
