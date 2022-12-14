using System.Text;

namespace FakerLib.Generators
{
    public class CharGenerator : IGenerator
    {
        private readonly char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public bool TryGenerate(Type type)
        {
            return type == typeof(char);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (char)chars[context.Random.Next(chars.Length)];
        }
    }
}
