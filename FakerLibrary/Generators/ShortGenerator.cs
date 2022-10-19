using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary.Generators
{
    public class ShortGenerator: IGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(short);
        }

        public object Generate(Type type, GeneratorContext context)
        {            
            return (short)context.Random.Next(short.MinValue, short.MaxValue + 1);
        }
    }
}
