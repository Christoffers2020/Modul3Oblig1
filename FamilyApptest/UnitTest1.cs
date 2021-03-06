using Modul3Oblig1;
using NUnit.Framework;

namespace FamilyApptest
{
    public class Tests
    {
        [Test]
        public void Test()
        {
                var sverreMagnus = new Person {Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005};
                var ingridAlexandra = new Person {Id = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004};
                var haakon = new Person {Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973};
                var harald = new Person {Id = 6, FirstName = "Harald", BirthYear = 1937};
                sverreMagnus.Father = haakon;
                ingridAlexandra.Father = haakon;
                haakon.Father = harald;

                var app = new FamilyApp(sverreMagnus, ingridAlexandra, haakon);
                var actualResponse = app.HandleCommand("vis 3");
                var expectedResponse = "Haakon Magnus (Id=3) F?dt: 1973 Far: Harald (Id=6)\n"
                                       + "  Barn:\n"
                                       + "    Sverre Magnus (Id=1) F?dt: 2005\n"
                                       + "    Ingrid Alexandra (Id=2) F?dt: 2004\n";
                Assert.AreEqual(expectedResponse, actualResponse);
         }

        [Test]
         public void NoChildrenTest()
            {
                var sverreMagnus = new Person {Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005};
                var ingridAlexandra = new Person {Id = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004};
                var haakon = new Person {Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973};
                var harald = new Person {Id = 6, FirstName = "Harald", BirthYear = 1937};
                sverreMagnus.Father = haakon;
                ingridAlexandra.Father = haakon;
                haakon.Father = harald;

                var app = new FamilyApp(sverreMagnus, ingridAlexandra, haakon);
                var actualResponse = app.HandleCommand("vis 1");
                var expectedResponse = "Sverre Magnus (Id=1) F?dt: 2005 Far: Haakon Magnus (Id=3)";
                Assert.AreEqual(expectedResponse, actualResponse);
            }
    }
}

