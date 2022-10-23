using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class PersonWithConstructorsFieldsProperties
    {
        private string surname;
        public byte Height;
        public byte Weight;

        public ushort Id { get;}
        public string Name { get; set; }
        public string Surname { set { surname = value; } }
        public DateTime BirthDateTime { get; set; }

        public PersonWithConstructorsFieldsProperties(ushort id, DateTime birthDateTime)
        {
            Id = id;
            Name = "Name";
            BirthDateTime = birthDateTime;
        }

        public PersonWithConstructorsFieldsProperties()
        {
            Id = 1;
            Name = "Bob";
            Surname = "Swift";
            BirthDateTime = new DateTime(1999, 12, 31, 23, 59, 59);
        }

        public string GetPersonSurname()
        {
            return surname;
        }
    }
}
