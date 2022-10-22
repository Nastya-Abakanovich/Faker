using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary.Generators
{
    public class SbyteGenerator: IGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(sbyte);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return (sbyte)context.Random.Next(sbyte.MinValue, sbyte.MaxValue + 1);
        }
    }
}
