using System.Reflection;
using FakerLibrary.Generators;

namespace FakerLibrary
{
    public class Faker
    {
        private readonly GeneratorContext _generatorContext;
        private IEnumerable<IGenerator> _generators;
        private Faker _faker;

        public Faker()
        {
            _generators = GetGenerators();
            _generatorContext = new GeneratorContext(new Random(), this);
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }


        // Может быть вызван изнутри Faker, из IValueGenerator (см. ниже) или пользователем
        public object Create(Type t)
        {

            object newObject = _generators.Where(g => g.CanGenerate(t)).
                    Select(g => g.Generate(t, _generatorContext)).FirstOrDefault();

            if (newObject == null)
            {
                _faker =_faker ?? new Faker();

                newObject = CallConstructor(t);
                RandomFields(ref newObject);
                RandomProperties(ref newObject);
            }       
          
            return newObject;
        }

        private object CallConstructor(Type t)
        {
            var constructors = t.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            int currLength, maxLength = 0;
            ConstructorInfo? maxConstructor = null;

            foreach (var constructor in constructors)
            {
                currLength = constructor.GetParameters().Length;
                if (currLength >= maxLength)
                {
                    maxLength = currLength;
                    maxConstructor = constructor;
                }
            }

            object[] parametersValue = new object[maxLength];
            ParameterInfo[] parameters = maxConstructor.GetParameters();
            for (int i = 0; i < maxLength; i++)
            {
                parametersValue[i] = _faker.Create(parameters[i].ParameterType);
            }

            return maxConstructor.Invoke(parametersValue) ?? Activator.CreateInstance(t); //!!!! проверить без этого при приватном конструкторе
        }

        private void RandomFields(ref object currObject)
        {
            var fields = currObject.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            Type fieldType;
            object value;
            foreach (var field in fields)
            {
                try
                {
                    fieldType = field.FieldType;
                    value = field.GetValue(currObject);
                    if (value == null || value.Equals(GetDefaultValue(fieldType)))
                        field.SetValue(currObject, _faker.Create(fieldType));
                }
                catch { }

            }
        }

        private void RandomProperties(ref object currObject)
        {
            var properties = currObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Type propType;
            object value;
            foreach (var prop in properties)
            {
                try
                {
                    propType = prop.PropertyType;
                    value = prop.GetValue(currObject);
                    if (value == null || value.Equals(GetDefaultValue(propType)))
                        prop.SetValue(currObject, _faker.Create(propType));
                }
                catch { }
            }
        }

        private IEnumerable<IGenerator> GetGenerators()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IGenerator)))
                .Select(t => (IGenerator)Activator.CreateInstance(t));
        }


        private static object GetDefaultValue(Type t)
        {
            return t.IsValueType ? Activator.CreateInstance(t) : null;
        }


    }
}