using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary.Generators
{
    public class DoubleGenerator: IGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(double);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return context.Random.NextDouble() + context.Random.Next(-1000, 1001);
        }
    }
}
