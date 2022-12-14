using System.Globalization;

namespace FakerLib.Generators
{
    public class DateTimeGenerator : IGenerator
    {
        public bool TryGenerate(Type type)
        {
            return type == typeof(DateTime);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return new DateTime(context.Random.Next(1, 2100),
                                context.Random.Next(1, 13),
                                context.Random.Next(1, 29),
                                context.Random.Next(24),
                                context.Random.Next(60),
                                context.Random.Next(60),
                                context.Random.Next(1000),
                                CultureInfo.InvariantCulture.Calendar,
                                DateTimeKind.Utc);
        }
    }
}
