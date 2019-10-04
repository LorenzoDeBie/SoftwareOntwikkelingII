using System;
using System.IO;
using Codering;
using Codering.UML;

namespace CodeerBestand
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string fileIn;
            string fileUit;
            string coderingenString;
            
            StreamReader streamReader = null;
            do
            {
                do
                {
                    Console.WriteLine("Geef bestandsnaam voor input: ");
                    fileIn = Console.ReadLine();

                } while (fileIn == null);
                
                try
                {
                    streamReader = new StreamReader(fileIn);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found! Please try again.");
                }
            } while (streamReader == null);
            
            StreamWriter streamWriter = null;
            do
            {
                do
                {
                    Console.WriteLine("Geef bestandsnaam voor output: ");
                    fileUit = Console.ReadLine();
                } while (fileUit == null);

                try
                {
                    streamWriter = new StreamWriter(fileUit, false);
                }
                catch (IOException)
                {
                    Console.WriteLine("Could not open file for output! Please try again.");
                }
            } while (streamWriter == null);
            
            do
            {
                Console.WriteLine("Geef coderingen: ");
                coderingenString = Console.ReadLine();
            } while (coderingenString == null);

            string[] coderingen = coderingenString.Split(' ');
            
            ICodeerbareString codeerbareString = new PlainText();

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

            try
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine("Found line: " + line);
                    string gecodeerd = codeerbareString.GecodeerdeString(line);
                    streamWriter.WriteLine(gecodeerd);
                    Console.WriteLine("Wrote line: " + gecodeerd);
                }
                streamWriter.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Failed to write to file!");
            }
            
            
        }
    }
}