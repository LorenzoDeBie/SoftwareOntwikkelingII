using System;
using NUnit.Framework;
using Sorteren;

namespace TestSorteren
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            int[] getallen = new[] {6, 5, 3, 1, 8, 7, 2, 4};
            int[] getallengesorteerd = new[] {1, 2, 3, 4, 5, 6, 7, 8};
            
            SorteerBib<int>.BubbleSorteer(getallen);
            CollectionAssert.AreEqual(getallengesorteerd, getallen);
        }

        [Test]
        public void Test2()
        {
            int[] getallen = new[] {6, 5, 3, 1, 8, 7, 2, 4};
            int[] getallengesorteerd = new[] {1, 2, 3, 4, 5, 6, 7, 8};
            
            SorteerBib<int>.SelectieSorteer(getallen);
            CollectionAssert.AreEqual(getallengesorteerd, getallen);
        }
    }
}