namespace FakerLib.Generators
{
    public class IntGenerator : IGenerator
    {
        public bool TryGenerate(Type type)
        {
            return type == typeof(int);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (int)context.Random.Next();
        }
    }
}
