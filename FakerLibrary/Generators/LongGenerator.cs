using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary.Generators
{
    public class LongGenerator: IGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(long);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return context.Random.NextInt64(long.MinValue, long.MaxValue);
        }
    }
}
