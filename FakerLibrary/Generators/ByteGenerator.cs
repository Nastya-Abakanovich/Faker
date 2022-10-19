using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary.Generators
{
    public class ByteGenerator: IGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(byte);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return (byte)context.Random.Next(byte.MaxValue + 1);
        }
    }
}
