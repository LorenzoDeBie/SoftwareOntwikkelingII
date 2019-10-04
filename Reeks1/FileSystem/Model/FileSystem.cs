using System;

namespace FileSystem.Model
{
    public class FileSystem
    {
        private Folder root;
        private Folder currentDir;

        public FileSystem()
        {
            root = new Folder("");
            currentDir = root;
        }

        public void cd(string path)
        {
            if (path.Equals("/"))
            {
                currentDir = root;
            }
            else if (path.Equals(".."))
            {
                currentDir = currentDir.Parent;
            }
            else if(path.Contains("/"))
            {
                Console.WriteLine("Invalid path!");
                return;
            }
            else if (currentDir[path].GetType() == typeof(Folder))
            {
                currentDir = (Folder)currentDir[path];
                
            }
            else
            {
                Console.WriteLine("Path is not a Directory or doesn't exist!");
                return;
            }
            
            pwd();
        }

        public void pwd()
        {
            Console.WriteLine(currentDir.PathName + ">");
        }

        public void dir()
        {
            currentDir.PrintList();
            pwd();
        }

        public void tree()
        {
            currentDir.PrintTree();
            pwd();
        }

        public void mktext(string name)
        {
            try
            {
                File newText = currentDir.CreateTextFile(name);
                newText.Parent = currentDir;
            }
            catch (FileSystemException e)
            {
                Console.WriteLine(e.Message);
            }
            pwd();
        }

        public void mkdir(string name)
        {
            try
            {
                File newFolder = currentDir.CreateFolder(name);
                newFolder.Parent = currentDir;
            }
            catch (FileSystemException e)
            {
                Console.WriteLine(e.Message);
            }

            pwd();
        }
    }
}