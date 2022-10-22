using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary.Generators
{
    public class UintGenerator: IGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(uint);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return (uint)context.Random.Next(int.MaxValue);
        }
    }
}
