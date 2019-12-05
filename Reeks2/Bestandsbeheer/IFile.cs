namespace Bestandsbeheer
{
    public interface IFile
    {
        //name of the file
        string FileName { get; }
        //gets the content of the file if permitted
        string WriteContent();
    }
}