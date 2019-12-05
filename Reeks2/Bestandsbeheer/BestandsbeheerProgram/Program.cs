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
			User user = new User()
			{
				Username = username,
				isAdmin = username.Equals("admin")
			};
            Console.WriteLine();

            string fileName = "";
            while (true)
            {
                Console.WriteLine("Enter file name or STOP to exit");
                while (string.IsNullOrEmpty(fileName))
                {
                    fileName = Console.ReadLine();
                }

                if (fileName.Equals("STOP")) return;

				try
				{
					IFile current = new FileProtectionProxy(fileName, user);
					string currentContent = current.WriteContent();
					Console.WriteLine("\n====== " + fileName + " ======");
					Console.WriteLine(currentContent);
					Console.WriteLine("============================\n");
				}
				catch(InvalidOperationException ex)
				{
					Console.Out.WriteLine();
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Out.Write("[ERR] ");
					Console.ResetColor();
					Console.WriteLine(ex.Message);
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