using System;
using Sorteren;

namespace SorteerBestanden
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Type invoer: ");
            string typeString = Console.ReadLine();

            Console.WriteLine("Sorteermethode: ");
            string sorteerString = Console.ReadLine();
            
            Console.Write("Geef invoerbestand: ");
            string invoerbestand = Console.ReadLine();
            
            Console.Write("Geef uitvoerbestand: ");
            string uitvoerbestand = Console.ReadLine();

            Vergelijker vergelijker = new Vergelijker();
            if (typeString.Equals("School"))
            {
                if (sorteerString.Equals("bubble"))
                {
                    new BestandSorteerder<School>(SchoolLezer.LeesSchool, SorteerBib<School>.BubbleSorteer, vergelijker).Parse(invoerbestand, uitvoerbestand);
                }
                else if (sorteerString.Equals("selectie"))
                {
                    new BestandSorteerder<School>(SchoolLezer.LeesSchool, SorteerBib<School>.SelectieSorteer, vergelijker).Parse(invoerbestand, uitvoerbestand);
                }
                else
                {
                    Console.WriteLine("Sorteermethode ongekend!");
                }
            }
            else if (typeString.Equals("Park"))
            {
                if (sorteerString.Equals("bubble"))
                {
                    new BestandSorteerder<Park>(ParkLezer.LeesPark, SorteerBib<Park>.BubbleSorteer, vergelijker).Parse(invoerbestand, uitvoerbestand);
                }
                else if (sorteerString.Equals("selectie"))
                {
                    new BestandSorteerder<Park>(ParkLezer.LeesPark, SorteerBib<Park>.SelectieSorteer, vergelijker).Parse(invoerbestand, uitvoerbestand);
                }
                else
                {
                    Console.WriteLine("Sorteermethode ongekend!");
                }
            }
            else
            {
                Console.WriteLine("Type ongekend!");
            }
        }
    }
}