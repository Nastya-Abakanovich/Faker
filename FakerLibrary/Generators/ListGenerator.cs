using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary.Generators
{
    public class ListGenerator: IGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            int length = context.Random.Next(2, 11);
            Type genericType = type.GetGenericArguments().First();
            var values = Array.CreateInstance(genericType, length);

            for (int i = 0; i < length; i++)
            {
                values.SetValue(context.CurrFaker.Create(genericType), i);
            } 

            return Activator.CreateInstance(type, values);
        }
    }
}
