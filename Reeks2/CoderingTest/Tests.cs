using System;
using Codering;
using Codering.UML;
using NUnit.Framework;

namespace CoderingTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestWissel()
        {
            Codering.Codering codering = new Wissel(new PlainText());
            Assert.AreEqual("iD tsie neo feneni gpoD segi naPttresn", codering.GecodeerdeString("Dit is een oefening op Design Patterns"));
        }

        [Test]
        public void TestCijfer()
        {
            Codering.Codering codering = new Cijfer(new PlainText());
            Assert.AreEqual("68105116321051153210110111032111101102101110105110103321111123268101115105103110328097116116101114110115", codering.GecodeerdeString("Dit is een oefening op Design Patterns"));
        }

        [Test]
        public void TestBlok()
        {
            Codering.Codering codering = new Blok(new PlainText());
            Assert.AreEqual("4pzvu4xzrhvyahrhni0gpob3seyngc21ttreh4", codering.GecodeerdeString("Dit is een oefening op Design Patterns"));
            
        }
    }
}