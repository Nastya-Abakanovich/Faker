namespace FakerLibrary.Generators
{
    public class UshortGenerator: IGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(ushort);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return (ushort)context.Random.Next(ushort.MaxValue + 1);
        }
    }
}
