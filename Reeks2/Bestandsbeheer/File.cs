using System;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace Bestandsbeheer
{
    internal class File : IFile
    {
        public string FileName { get; }

        private readonly string _content;

        public File(string fileName)
        {
			Console.Out.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.Out.Write("[INF] ");
			Console.ResetColor();
			Console.Out.WriteLine("Loading file " + fileName + " from disk...");
			_content = System.IO.File.ReadAllText(fileName);
		}
        
        public string WriteContent()
        {
			return _content;
        }
    }
}