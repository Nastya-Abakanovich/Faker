namespace FakerLibrary.Generators
{
    public interface IGenerator
    {
        bool CanGenerate(Type type);
        object Generate(Type type, GeneratorContext context);        

    }
}
