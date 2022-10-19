using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary.Generators
{
    public class IntGenerator: IGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(int);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return context.Random.Next(int.MinValue, int.MaxValue);
        }
    }
}
