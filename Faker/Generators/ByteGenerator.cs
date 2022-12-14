namespace FakerLib.Generators
{
    public class ByteGenerator : IGenerator
    {
        public bool TryGenerate(Type type)
        {
            return type == typeof(byte);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (byte)context.Random.Next(1, byte.MaxValue);
        }
    }
}
