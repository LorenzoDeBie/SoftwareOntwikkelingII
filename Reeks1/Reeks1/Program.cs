using System;

namespace Reeks1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Geef je naam in:");
            var naam = Console.ReadLine();
            Console.WriteLine("Geef je studentennummer in:");
            int.TryParse(Console.ReadLine(), out var number);
            var s = new Student(naam, number);
            Console.WriteLine(s.WelcomeMessage);
            Person p2 = new Student(naam, number);
            Console.WriteLine(p2.WelcomeMessage);
            if (p2 is Student)
            {
                Console.WriteLine(p2.WelcomeMessage);
            }

            Console.WriteLine("naam van klasse: " + p2.GetType().Name);
        }
    }
}