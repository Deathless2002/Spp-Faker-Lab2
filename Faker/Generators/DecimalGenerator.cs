namespace FakerLib.Generators
{
    public class DecimalGenerator : IGenerator
    {
        public bool TryGenerate(Type type)
        {
            return type == typeof(decimal);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (decimal)(context.Random.NextSingle() + context.Random.NextInt64());
        }
    }
}
