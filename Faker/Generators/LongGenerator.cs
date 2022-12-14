namespace FakerLib.Generators
{
    public class LongGenerator : IGenerator
    {
        public bool TryGenerate(Type type)
        {
            return type == typeof(long);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (long)context.Random.NextInt64(1, long.MaxValue);
        }
    }
}
