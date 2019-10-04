using System;
using Codering;
using Codering.UML;

namespace CodeerZin
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string input;
            string coderingenString;
            string[] coderingen;
            do
            {
                Console.Write("Geef zin: ");
                input = Console.ReadLine();
            } while (input == null);

            do
            {
                Console.Write("Geef coderingen: ");
                coderingenString = Console.ReadLine();
            } while (coderingenString == null);

            coderingen = coderingenString.Split(' ');
            
            Codering.ICodeerbareString codeerbareString = new PlainText();
            foreach (string codering in coderingen)
            {
                if (codering.Equals("blok"))
                {
                    codeerbareString = new Blok(codeerbareString);
                }
                else if (codering.Equals("cijfer"))
                {
                    codeerbareString = new Cijfer(codeerbareString);
                }
                else if (codering.Equals("wissel"))
                {
                    codeerbareString = new Wissel(codeerbareString);
                }
            }
            Console.WriteLine(codeerbareString.GecodeerdeString(input));
        }
    }
}