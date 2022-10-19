using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary.Generators
{
    public class BoolGenerator: IGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(bool);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return context.Random.Next(2) == 1;
        }
    }
}
