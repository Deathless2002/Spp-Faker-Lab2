using System.Collections;

namespace FakerLib.Generators
{
    public class ListGenerator : IGenerator
    {
        public int Limit { get; set; } = 10;

        public bool TryGenerate(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            int len = context.Random.Next(1, Limit);
            IList? list = (IList?)Activator.CreateInstance(typeToGenerate, len);
            if (list != null)
            {
                for (int i = 0; i < len; i++)
                    list.Add(context.Faker.Create(typeToGenerate.GetGenericArguments()[0]));
                return list;
            }
            throw new FakerException($"Unable to create list of type {typeToGenerate}");
        }

    }
}
