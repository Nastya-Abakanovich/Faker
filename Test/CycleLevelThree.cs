using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class CycleLevelThree
    {
        public B one { get; set; }
    }

    public class B
    {
        public C two { get; set; }
    }

    public class C
    {
        public CycleLevelThree three { get; set; }
    }
}
