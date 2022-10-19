using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary.Generators
{
    public interface IGenerator
    {
        bool CanGenerate(Type type);
        object Generate(Type type, GeneratorContext context);        

    }
}
