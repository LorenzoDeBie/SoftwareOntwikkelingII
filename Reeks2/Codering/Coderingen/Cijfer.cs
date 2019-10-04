namespace Codering
{
    public class Cijfer : Codering
    {
        public Cijfer(ICodeerbareString codeerbareString)
        {
            _codeerbareString = codeerbareString;
        }

        public override string GecodeerdeString(string codeString)
        {
            string temp = _codeerbareString.GecodeerdeString(codeString);
            string result = "";
            foreach (char c in temp)
            {
                result += (int) c;
            }
            return result;
        }
    }
}