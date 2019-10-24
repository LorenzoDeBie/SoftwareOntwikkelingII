using System.Collections.Generic;

namespace Sorteren
{
    public class SorteerBib<T>
    {
        public static void SelectieSorteer(IList<T> lijst)
        {
            SelectieSorteer(lijst, Comparer<T>.Default);
        }

        public static void SelectieSorteer(IList<T> lijst, IComparer<T> comparer)
        {
            int currentIndex;
            int lowestIndex;
            for (int length = 0; length < lijst.Count; length++)
            {
                lowestIndex = length;
                for (int index = length; index < lijst.Count; index++)
                {
                    currentIndex = index;
                    if (comparer.Compare(lijst[currentIndex], lijst[lowestIndex]) == -1) //current < lowest
                    {
                        lowestIndex = currentIndex;
                    }
                }
                //swap lowest with length
                if(length == lowestIndex) continue;
                T temp = lijst[length];
                lijst[length] = lijst[lowestIndex];
                lijst[lowestIndex] = temp;
            }
        }

        public static void BubbleSorteer(IList<T> lijst)
        {
            BubbleSorteer(lijst, Comparer<T>.Default);
        }

        public static void BubbleSorteer(IList<T> lijst, IComparer<T> comparer)
        {
            for (int length = lijst.Count; length > 0; length--)
            {
                bool swapped = false;
                for (int index = 1; index < length; index++)
                {
                    if (comparer.Compare(lijst[index], lijst[index - 1]) != 1) // y > x?
                    {
                        swapped = true;
                        T temp = lijst[index - 1];
                        lijst[index - 1] = lijst[index];
                        lijst[index] = temp;
                    }
                }
                if (!swapped) return; // return early if array is already sorted
            }
        }
    }
}