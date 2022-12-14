namespace FakerLib.Generators
{
    public class DoubleGenerator : IGenerator
    {
        public bool TryGenerate(Type type)
        {
            return type == typeof(double);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (double)(context.Random.NextDouble() + context.Random.NextInt64());
        }
    }
}
