namespace FakerLib.Generators
{
    public class FloatGenerator : IGenerator
    {
        public bool TryGenerate(Type type)
        {
            return type == typeof(float);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (float)(context.Random.NextSingle() + context.Random.NextInt64());
        }
    }
}
