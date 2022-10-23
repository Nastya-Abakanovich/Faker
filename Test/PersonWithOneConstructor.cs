using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class PersonWithOneConstructor
    {
        public ushort Id;
        public string Name;
        public string Surname;
        public DateTime BirthDateTime;             

        public PersonWithOneConstructor(ushort id, string name, string surname, DateTime birthDateTime)
        {
            Id = id;
            Name = name;
            Surname = surname;
            BirthDateTime = birthDateTime;
        }

    }
}
