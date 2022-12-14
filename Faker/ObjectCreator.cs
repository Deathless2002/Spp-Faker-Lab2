namespace FakerLib
{
    public class ObjectCreator : IGenerator
    {
        private readonly RecursionKiller checker;

        public ObjectCreator()
        {
            checker = new RecursionKiller(3);
        }

        public bool TryGenerate(Type type)
        {
            return type.IsClass || (type.IsValueType && !type.IsEnum);
        }

        public object Generate(Type type, GeneratorContext generatorContext)
        {
            object? obj = null;
            try
            {
                if (checker.Add(type))
                {
                    obj = Create(type, generatorContext);
                    SetFields(type, obj, generatorContext);
                    SetProperties(type, obj, generatorContext);
                    checker.Remove(type);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return obj;
        }

        private object Create(Type type, GeneratorContext context)
        {
            var constructors = type.GetConstructors().OrderByDescending(x => x.GetParameters().Length);
            foreach (var constructor in constructors)
            {
                try
                {
                    var args = constructor.GetParameters().Select(x => context.Faker.Create(x.ParameterType)).ToArray();
                    return constructor.Invoke(args);
                }
                catch { }
            }
            object? obj = GetDefaultValue(type); // if value type
            if (obj == null) // reference type with private constructor
                throw new FakerException($"Cannot create class {type.Name} without public constructors");
            return obj;

        }

        private static void SetFields(Type type, object obj, GeneratorContext context)
        {
            var fields = type.GetFields().Where(f => f.IsPublic);
            foreach (var field in fields)
            {
                try
                {
                    if (Equals(field.GetValue(obj), GetDefaultValue(field.FieldType)))
                    {
                        field.SetValue(obj, context.Faker.Create(field.FieldType));
                    }
                }
                catch { }
            }
        }

        private static void SetProperties(Type type, object obj, GeneratorContext context)
        {
            var properties = type.GetProperties().Where(p => p.CanWrite);
            foreach (var property in properties)
            {
                try
                {
                    if (Equals(property.GetValue(obj), GetDefaultValue(property.PropertyType)))
                    {
                        property.SetValue(obj, context.Faker.Create(property.PropertyType));
                    }
                }
                catch { }
            }
        }

        public static object? GetDefaultValue(Type t)
        {
            if (t.IsValueType)
                return Activator.CreateInstance(t);
            return null;
        }
    }
}
