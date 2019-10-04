namespace FileSystem.Model
{
    public class TextFile : File
    {
        public string Content { get; set; }

        public TextFile(string name, string content) : base(name)
        {
            this.Content = content;
        }

        public override string ListName => base.Name;
    }
}