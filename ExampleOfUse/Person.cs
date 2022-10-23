using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleOfUse
{    public class Person
    {
        public ushort Id { get; }

        public string Name { get; set; }
        public string Sername { get; set; }
        public DateTime BirthDate { get; set; }

        public Person Child;
        public bool IsFemale;

        public Person()
        {
            BirthDate = DateTime.Now;
            Name = "N";
            Sername = "S";
            Id = 8;
            Child = null;
            IsFemale = true;
        }

        public Person(ushort id)
        {
            Id = id;
            Name = "Const name.";
        }
    }
}
