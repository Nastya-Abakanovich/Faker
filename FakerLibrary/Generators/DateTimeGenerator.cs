using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary.Generators
{
    public class DateTimeGenerator: IGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(DateTime);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            DateTime start = new DateTime(1950, 1, 1);
            return start.AddSeconds(context.Random.NextInt64((long)(DateTime.Today - start).TotalSeconds));
        }
    }
}
