using FakerLib.Generators;
using System.Text;

namespace FakerLib
{
    public class Faker : IFaker
    {
        private readonly Dictionary<Type, IGenerator> generators;
        private GeneratorContext generatorContext;

        public Faker()
        {
            generators = GetGenerators();
            generatorContext = new GeneratorContext(new Random(), this);
        }

        private Dictionary<Type, IGenerator> GetGenerators()
        {
            return new Dictionary<Type, IGenerator>() {
                { typeof(bool),new BoolGenerator() },
                { typeof(int),new IntGenerator() },
                { typeof(string),new StringGenerator() },
                { typeof(byte),new ByteGenerator() },
                { typeof(char),new CharGenerator() },
                { typeof(decimal),new DecimalGenerator() },
                { typeof(double),new DoubleGenerator()},
                { typeof(float),new FloatGenerator() },
                { typeof(long),new LongGenerator()},
                { typeof(short),new ShortGenerator() },
                { typeof(object),new ObjectCreator() }
                 };
        }

        public bool AddGenerator(KeyValuePair<Type,IGenerator> generator)
        {
            if (generators.ContainsKey(generator.Key))
                return false;
            generators.Add(generator.Key, generator.Value);
            return true;
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        public object Create(Type t)
        {
            generators.TryGetValue(t, out var generator);
            if (generator == null)
            {
                generator = (t.IsGenericType) ? generators[typeof(List<>)] : generators[typeof(object)];
            }
            if (!generator.TryGenerate(t))
                throw new FakerException($"Cannot generate for type {t.Name}");
            return generator.Generate(t, generatorContext);
        }
    }
}