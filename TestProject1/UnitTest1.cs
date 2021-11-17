using System.ComponentModel;
using Modul3Oblig1;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAllFields()
       
            {
                var p = new Person
                {
                    Id = 17,
                    FirstName = "Ola",
                    LastName = "Nordmann",
                    BirthYear = 2000,
                    DeathYear = 3000,
                    Father = new Person() {Id = 23, FirstName = "Per"},
                    Mother = new Person() {Id = 29, FirstName = "Lise"},
                };

                var actualDescription = p.GetDescription();
                var expectedDescription =
                    "Ola Nordmann (Id=17) F�dt: 2000 D�d: 3000 Far: Per (Id=23) Mor: Lise (Id=29) ";

                Assert.AreEqual(expectedDescription, actualDescription);
            }
        [Test]
        public void TestNoFields()
        {
            var p = new Person
            {
                Id = 1,
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "(Id=1) ";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
        [Test]
        public void MyTest()
        {
            var p = new Person
            {
                Id = 5,
                FirstName = "Marius",
                LastName = "Borg H�iby"

            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "(Id=5) Marius Borg H�iby ";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}