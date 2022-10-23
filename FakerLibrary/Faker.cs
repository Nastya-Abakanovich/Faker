using System.Reflection;
using FakerLibrary.Generators;

namespace FakerLibrary
{
    public class Faker
    {
        private readonly GeneratorContext _generatorContext;
        private IEnumerable<IGenerator> _generators;
        private Faker _faker;
        private List<Type> _createTypes;  

        public Faker()
        {
            _generators = GetGenerators();
            try
            {
                Assembly assemblyOne = Assembly.LoadFrom("../../../../GeneratorOne.dll");
                Type typeBoolGenerator = assemblyOne.GetType("GeneratorOne.BoolGenerator");
                _generators = _generators.Append((IGenerator)Activator.CreateInstance(typeBoolGenerator));
            }
            catch { }

            try
            {
                Assembly assemblyTwo = Assembly.LoadFrom("../../../../GeneratorTwo.dll");
                Type typeCharGenerator = assemblyTwo.GetType("GeneratorTwo.CharGenerator");
                _generators = _generators.Append((IGenerator)Activator.CreateInstance(typeCharGenerator));
            }
            catch { }            

            _generatorContext = new GeneratorContext(new Random(), this);
            _createTypes = new List<Type>();
            _faker = this;
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        public object Create(Type t)
        {
            _createTypes.Add(t);
            object newObject = _generators.Where(g => g.CanGenerate(t)).
                    Select(g => g.Generate(t, _generatorContext)).FirstOrDefault();

            if (newObject == null && t.IsClass)
            {
                _faker = _faker ?? new Faker();

                newObject = CallConstructor(t);
                FillFields(ref newObject);
                FillProperties(ref newObject);
            }       
            _createTypes.RemoveAt(_createTypes.Count - 1);
            return newObject ?? GetDefaultValue(t);
        }

        private object CallConstructor(Type t)
        {
            var constructors = t.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            int currParam, maxParam = 0;
            ConstructorInfo? maxConstructor = null;

            if (constructors.Length == 0)
            {
                constructors = t.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            }

            foreach (var constructor in constructors)
            {
                currParam = constructor.GetParameters().Length;
                if (currParam >= maxParam)
                {
                    maxParam = currParam;
                    maxConstructor = constructor;
                }
            }

            object[] parametersValue = new object[maxParam];
            ParameterInfo[] parameters = maxConstructor.GetParameters();
            for (int i = 0; i < maxParam; i++)
            {
                parametersValue[i] = _faker.Create(parameters[i].ParameterType);
            }

            return maxConstructor.Invoke(parametersValue); 
        }

        private void FillFields(ref object currObject)
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
                    if (!_createTypes.Contains(fieldType))
                    {
                        if (value == null || value.Equals(GetDefaultValue(fieldType)))
                            field.SetValue(currObject, _faker.Create(fieldType));
                    }
                    else
                    {
                        field.SetValue(currObject, GetDefaultValue(fieldType));
                    }
                }
                catch { }

            }
        }

        private void FillProperties(ref object currObject)
        {
            var properties = currObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty);
            Type propType;
            object value;
            foreach (var prop in properties)
            {
                try
                {
                    propType = prop.PropertyType;
                    
                    value = prop.GetValue(currObject);
                    if (!_createTypes.Contains(propType))
                    {
                        if (value == null || value.Equals(GetDefaultValue(propType)))
                        prop.SetValue(currObject, _faker.Create(propType));
                    }
                    else
                    {
                        prop.SetValue(currObject, GetDefaultValue(propType));
                    }
                }
                catch (ArgumentException e) 
                {
                    prop.SetValue(currObject, _faker.Create(prop.PropertyType));
                }
            }
        }

        private IEnumerable<IGenerator> GetGenerators()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IGenerator)))
                .Select(t => (IGenerator)Activator.CreateInstance(t));
        }


        public static object GetDefaultValue(Type t)
        {
            return t.IsValueType ? Activator.CreateInstance(t) : null;
        }


    }
}