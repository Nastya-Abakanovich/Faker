using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TestObjectGeneration
    {
        private Faker _faker;

        [OneTimeSetUp]
        public void Setup()
        {
            _faker = new Faker();
        }

        [Test]
        public void Create_ClassWithoutConstructor_ReturnsObject()
        {
            var person1 = _faker.Create<PersonWithoutConstructor>();
            var person2 = _faker.Create<PersonWithoutConstructor>();
            Assert.AreNotEqual(person1, null, "Person1 == null");
            Assert.AreNotEqual(person2, null, "Person2 == null");
            Assert.AreNotEqual(person1.Id, person2.Id, "Person1.Id == Person2.Id");
            Assert.AreNotEqual(person1.Name, person2.Name, "Person1.Name == Person2.Name");
            Assert.AreNotEqual(person1.Surname, person2.Surname, "Person1.Surname == Person2.Surname");
            Assert.AreNotEqual(person1.BirthDateTime, person2.BirthDateTime, "Person1.BirthDateTime == Person2.BirthDateTime");
        }

        [Test]
        public void Create_ClassWithOneConstructor_ReturnsObject()
        {
            var person1 = _faker.Create<PersonWithOneConstructor>();
            var person2 = _faker.Create<PersonWithOneConstructor>();
            Assert.AreNotEqual(person1, null, "Person1 == null");
            Assert.AreNotEqual(person2, null, "Person2 == null");
            Assert.AreNotEqual(person1.Id, person2.Id, "Person1.Id == Person2.Id");
            Assert.AreNotEqual(person1.Name, person2.Name, "Person1.Name == Person2.Name");
            Assert.AreNotEqual(person1.Surname, person2.Surname, "Person1.Surname == Person2.Surname");
            Assert.AreNotEqual(person1.BirthDateTime, person2.BirthDateTime, "Person1.BirthDateTime == Person2.BirthDateTime");
        }

        [Test]
        public void Create_ClassWithPrivateConstructor_ReturnsObject()
        {
            var person1 = _faker.Create<PersonWithPrivateConstructor>();
            var person2 = _faker.Create<PersonWithPrivateConstructor>();
            Assert.AreNotEqual(person1, null, "Person1 == null");
            Assert.AreNotEqual(person2, null, "Person2 == null");
            Assert.AreNotEqual(person1.Id, person2.Id, "Person1.Id == Person2.Id");
            Assert.AreNotEqual(person1.Name, person2.Name, "Person1.Name == Person2.Name");
            Assert.AreNotEqual(person1.Surname, person2.Surname, "Person1.Surname == Person2.Surname");
            Assert.AreNotEqual(person1.BirthDateTime, person2.BirthDateTime, "Person1.BirthDateTime == Person2.BirthDateTime");
        }

        [Test]
        public void Create_ClassWithThreeConstructors_ReturnsObject()
        {
            var person1 = _faker.Create<PersonWithThreeConstructors>();
            var person2 = _faker.Create<PersonWithThreeConstructors>();
            Assert.AreNotEqual(person1, null, "Person1 == null");
            Assert.AreNotEqual(person2, null, "Person2 == null");
            Assert.AreNotEqual(person1.Id, person2.Id, "Person1.Id == Person2.Id");
            Assert.AreNotEqual(person1.Name, person2.Name, "Person1.Name == Person2.Name");
            Assert.AreNotEqual(person1.Surname, person2.Surname, "Person1.Surname == Person2.Surname");
            Assert.AreNotEqual(person1.BirthDateTime, person2.BirthDateTime, "Person1.BirthDateTime == Person2.BirthDateTime");
        }

        [Test]
        public void Create_ClassWithConstructorsFieldsProperties_ReturnsObject()
        {
            var person1 = _faker.Create<PersonWithConstructorsFieldsProperties>();
            var person2 = _faker.Create<PersonWithConstructorsFieldsProperties>();
            Assert.AreNotEqual(person1, null, "Person1 == null");
            Assert.AreNotEqual(person2, null, "Person2 == null");
            Assert.AreNotEqual(person1.Id, person2.Id, "Person1.Id == Person2.Id");
            Assert.AreEqual(person1.Name, "Name", "Person1.Name != \"Name\"");
            Assert.AreEqual(person2.Name, "Name", "Person2.Name != \"Name\"");
            Assert.AreNotEqual(person1.GetPersonSurname(), person2.GetPersonSurname(), "Person1.Surname == Person2.Surname");
            Assert.AreNotEqual(person1.BirthDateTime, person2.BirthDateTime, "Person1.BirthDateTime == Person2.BirthDateTime");
            Assert.AreNotEqual(person1.Height, person2.Height, "Person1.Height == Person2.Height");
            Assert.AreNotEqual(person1.Weight, person2.Weight, "Person1.Weight == Person2.Weight");
        }

        [Test]
        public void Create_CycleLevelThree_ReturnsObject()
        {
            var A = _faker.Create<CycleLevelThree>();

            Assert.AreNotEqual(A.one, null, "one == null");
            Assert.AreNotEqual(A.one.two, null, "two == null");
            Assert.AreEqual(A.one.two.three, null, "three != null");
        }

        [Test]
        public void Create_TypeWithoutGenerator_ReturnsNull()
        {
            var enumerable = _faker.Create<IEnumerable<int>>();

            Assert.AreEqual(enumerable, null);
        }
    }
}
