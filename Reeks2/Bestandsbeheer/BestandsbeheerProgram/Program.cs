using System;
using System.Collections.Generic;
using System.IO;
using Bestandsbeheer;

namespace BestandsbeheerProgram
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine();

            Dictionary<string,IFile> files = new Dictionary<string,IFile>();
            string fileName = "";
            while (true)
            {
                Console.WriteLine("Enter file name or STOP to exit");
                while (string.IsNullOrEmpty(fileName))
                {
                    fileName = Console.ReadLine();
                }

                if (fileName.Equals("STOP")) return;
                
                if (!files.ContainsKey(fileName))
                {
                    IFile file = new FileProxy(username, fileName);
                    files.Add(file.FileName, file);
                }

                Console.WriteLine();
                try
                {
                    files[fileName].WriteContent();
                    
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found! Please try again.");
                }
                Console.WriteLine();
                fileName = "";
            }
        }
    }
}