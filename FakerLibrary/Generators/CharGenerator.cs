using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary.Generators
{
    public class CharGenerator : IGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(char);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return (char)context.Random.Next();
        }
    }
}
