namespace FakerLib.Generators
{
    public class ShortGenerator : IGenerator
    {
        public bool TryGenerate(Type type)
        {
            return type == typeof(short);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (short)context.Random.Next(1, short.MaxValue);
        }
    }
}
