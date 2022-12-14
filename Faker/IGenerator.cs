namespace FakerLib
{
    public interface IGenerator
    {
        object Generate(Type typeToGenerate, GeneratorContext context);
        bool TryGenerate(Type type);
    }
}
