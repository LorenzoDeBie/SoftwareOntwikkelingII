namespace Codering
{
    public class Wissel : Codering
    {
        public Wissel(ICodeerbareString codeerbareString)
        {
            _codeerbareString = codeerbareString;
        }

        public override string GecodeerdeString(string codeString)
        {
            string temp = _codeerbareString.GecodeerdeString(codeString);
            string result = "";
            for (int i = 0; i < temp.Length; i += 2)
            {
                if (i == temp.Length - 1)
                {
                    result += temp[i];
                    return result;
                }
                result += temp[i + 1];
                result += temp[i];
                
            }

            return result;
        }
    }
}