using System;
using System.Collections.Generic;

namespace FileSystem.Model
{
    public class Folder : File
    {
        private readonly HashSet<File> _files;

        public override string ListName => Name + "/";

        public Folder(string name) : base(name)
        {
            _files = new HashSet<File>();
        }

        public File this[string name]
        {
            get
            {
                foreach (File file in _files)
                {
                    if (file.Name.Equals(name))
                    {
                        return file;
                    }
                }

                return null;
            }
        }

        public File GetFile(string name)
        {
            return this[name];
        }

        public TextFile CreateTextFile(string name)
        {
            CheckFileName(name);
            TextFile textFile = new TextFile(name, "");
            _files.Add(textFile);
            return textFile;
        }

        public Folder CreateFolder(string name)
        {
            CheckFileName(name);
            Folder folder = new Folder(name);
            _files.Add(folder);
            return folder;
        }

        public void PrintList()
        {
            foreach (File file in _files)
            {
                Console.WriteLine(file.ListName);
            }
        }

        public override void PrintTree(int indent = 0)
        {
            base.PrintTree(indent);
            foreach (File file in _files)
            {
                file.PrintTree(indent + 2);
            }
        }

        private void CheckFileName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new FileSystemException("Invalid Filename!");
            }
            if(this[name] != null) throw new FileSystemException("File already exists!");
        }
    }
}