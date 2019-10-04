using System;

namespace FileSystem.Model
{
    public abstract class File
    {
        public Folder Parent { get; set; }
        
        public string Name { get; }

        public bool IsRoot => Parent == null;

        public string PathName
        {
            get
            {
                if(!IsRoot)
                    return Parent.PathName + "/" + Name;
                return "";
            }
        }

        public virtual string ListName { get; }

        public File(string name)
        {
            if (name == null)
            {
                throw new FileSystemException("Filename cannot be null!");
            }
            if (name.Contains("/"))
            {
                throw new FileSystemException("Filename cannot contain the '/' character!");
            }

            this.Name = name;
        }
        
        

        public virtual void PrintTree(int indent = 0)
        {
            for (int i = 0; i < indent; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(Name);
        }
    }
}