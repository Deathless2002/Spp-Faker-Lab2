using System.Text;

namespace FakerLib.Generators
{
    public class StringGenerator : IGenerator
    {
        private readonly char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        public int Limit { get; set; } = 100;

        public bool TryGenerate(Type type)
        {
            return type == typeof(string);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            int len = context.Random.Next(1, Limit);
            var result = new StringBuilder(len);

            for (int i = 0; i < len; i++) 
                result.Append(chars[context.Random.Next(chars.Length)]);
            return result.ToString();
        }
    }
}
