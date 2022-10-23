using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class PersonWithThreeConstructors
    {
        public ushort Id;
        public string Name;
        public string Surname;
        public DateTime BirthDateTime;

        public PersonWithThreeConstructors(ushort id, string name, string surname, DateTime birthDateTime)
        {
            Id = id;
            Name = name;
            Surname = surname;
            BirthDateTime = birthDateTime;
        }

        public PersonWithThreeConstructors(string name, string surname)
        {
            Id = 1;
            Name = name;
            Surname = surname;
        }

        public PersonWithThreeConstructors()
        {
            Id = 1;
            Name = "Bob";
            Surname = "Swift";
            BirthDateTime = new DateTime(1999, 12, 31, 23, 59, 59);
        }
    }
}
