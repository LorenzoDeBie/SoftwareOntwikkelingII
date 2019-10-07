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
            FileName = fileName;
            StreamReader streamReader = new StreamReader(FileName);
            _content = streamReader.ReadToEndAsync().Result;
        }
        
        public void WriteContent()
        {
            Console.WriteLine(_content);
        }
    }
}