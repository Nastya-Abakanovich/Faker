namespace FakerLibrary.Generators
{
    public class StringGenerator : IGenerator
    {
        private const string stringSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public bool CanGenerate(Type type)
        {
            return type == typeof(string);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            int length = context.Random.Next(5, 31);
            return new string(Enumerable.Repeat(stringSymbols, length)
                .Select(s => s[context.Random.Next(s.Length)]).ToArray());
        }
    }
}
