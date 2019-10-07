using System;

namespace Bestandsbeheer
{
    public class FileProxy : IFile
    {
        private File _file;
        
        private readonly string _userName;
        public string FileName { get; }
        private bool IsSecret => FileName[0] == '.';

        public FileProxy(string userName, string fileName)
        {
            _userName = userName;
            FileName = fileName;
            _file = null;
        }
        
        public void WriteContent()
        {
            //access control
            if (IsSecret && !checkAccess())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[ERR]");
                Console.ResetColor();
                Console.WriteLine(" User " + _userName + " has no access to this file.");
                return;
            }
            
            //virtual proxy
            if (_file == null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[INF]");
                Console.ResetColor();
                Console.WriteLine("Loading file " + FileName + " from disk...");
                Console.WriteLine();
                _file = new File(FileName);
            }
            
            Console.WriteLine("====== "+ FileName +" ======");
            _file.WriteContent();
            Console.WriteLine("============================");
        }

        private bool checkAccess()
        {
            return _userName.Equals("admin");
        }
    }
}