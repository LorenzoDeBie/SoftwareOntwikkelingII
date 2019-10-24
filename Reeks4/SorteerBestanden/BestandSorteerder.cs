using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace SorteerBestanden
{
    public delegate T LeesLijn<T>(string lijn);

    public delegate void SorteerLijst<T>(IList<T> lijst, IComparer<T> comparer);
    
    public class BestandSorteerder<T>
    {
        public LeesLijn<T> Lezer;
        public SorteerLijst<T> Sorteerder;
        public IComparer<T> Vergelijker;

        public BestandSorteerder(LeesLijn<T> lezer, SorteerLijst<T> sorteerder, IComparer<T> vergelijker)
        {
            Lezer = lezer;
            Sorteerder = sorteerder;
            Vergelijker = vergelijker;
        }

        public void Parse(string invoer, string uitvoer)
        {
            IList<T> lijst = new List<T>();
            using (StreamReader streamReader = new StreamReader(invoer))
            {
                while (!streamReader.EndOfStream)
                {
                    //voeg stuff toe aan lijst
                    lijst.Add(Lezer(streamReader.ReadLine()));
                }
            }
            //sorteer stuff in de lijst
            Sorteerder(lijst, Vergelijker);
            //write stuff to new file
            using (StreamWriter streamWriter = new StreamWriter(uitvoer))
            {
                foreach (T item in lijst)
                {
                    streamWriter.WriteLine(item);
                }
            }
        }
    }
}