namespace Codering
{
    public abstract class Codering : ICodeerbareString
    {
        protected ICodeerbareString _codeerbareString;
        
        public abstract string GecodeerdeString(string codeString);
    }
}