namespace FakerLib.Generators
{
    public class BoolGenerator : IGenerator
    {
        bool IGenerator.TryGenerate(Type type)
        {
            return type == typeof(bool);
        }

        object IGenerator.Generate(Type typeToGenerate, GeneratorContext context) => true;
    }
}
