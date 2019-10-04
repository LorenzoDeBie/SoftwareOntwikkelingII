using System;
using NUnit.Framework;
using Reeks1;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestName()
        {
            Person test = new Student("testName", 123);
            Assert.AreEqual("testName", test.Name);
        }

        [Test]
        public void TestWelcomeMessage()
        {
            Person test = new Student("testName", 123);
            Assert.AreEqual("Hello testName, your student number is 123", test.WelcomeMessage);
        }
    }
}