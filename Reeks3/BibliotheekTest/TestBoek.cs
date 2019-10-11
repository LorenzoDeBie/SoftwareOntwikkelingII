using Catalogus;
using NUnit.Framework;

namespace CatalogusTest
{
    [TestFixture]
    public class TestBoek
    {
        [Test]
        public void TestToon()
        {
            Boek boek = new Boek { Id = "ID01", Titel = "Ik ben Pelgrim", Auteur = "Terry Hayes", Uitgeverij = "Bruna", Jaartal = 2014 };
            string toon = boek.Toon(2);
            string resultaat = "--ID01: \"Ik ben Pelgrim\", Terry Hayes, Bruna, 2014";
            Assert.AreEqual(resultaat, toon);
        }

        [Test]
        public void TestZoekId()
        {
            Boek boek = new Boek();
            boek.Id = "ID01";
            Assert.AreEqual(boek, boek.Zoek("ID01"));
        }
    }
}
