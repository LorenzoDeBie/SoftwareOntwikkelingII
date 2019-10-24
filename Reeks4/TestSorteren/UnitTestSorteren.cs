using System;
using System.Linq;
using Sorteren;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestSorteren
{
    [TestFixture]
    public class UnitTestSorteren
    {
        [Test]
        public void TestBublesorteerMethodesInt()
        {
            int[] getallen = { 5, 1, -10, 667, 4 };
            int[] resultaat = { -10, 1, 4, 5, 667 };
            IList<int> reeks = new List<int>(getallen);

            SorteerBib<int>.BubbleSorteer(getallen);
            CollectionAssert.AreEqual(resultaat, getallen);

            SorteerBib<int>.BubbleSorteer(reeks);
            CollectionAssert.AreEqual(resultaat, reeks.ToArray<int>());

        }

        [Test]
        public void TestGegevenInt()
        {

            int[] start = { 5, 1, -10, 667, 4 };
            int[] getallen = { 5, 1, -10, 667, 4 };
            SorteerBib<int>.SelectieSorteer(getallen);
            int[] resultaat = { -10, 1, 4, 5, 667 };
            CollectionAssert.AreEqual(resultaat, getallen);
            getallen = start;
            
            SorteerBib<int>.BubbleSorteer(getallen);
            CollectionAssert.AreEqual(resultaat, getallen);
            
        }


        [Test]
        public void TestSorteerMethodesString()
        {
            string[] namen = { "Jeroen", "Ann", "Els", "Veerle", "Thomas"};
            SorteerBib<string>.SelectieSorteer(namen);
            string[] resultaat = { "Ann", "Els", "Jeroen", "Thomas", "Veerle" };
            CollectionAssert.AreEqual(resultaat, namen);
            namen = new string[] { "Jeroen", "Ann", "Els", "Veerle", "Thomas"};
            SorteerBib<string>.BubbleSorteer(namen);
            CollectionAssert.AreEqual(resultaat, namen);
        }
    }
}
