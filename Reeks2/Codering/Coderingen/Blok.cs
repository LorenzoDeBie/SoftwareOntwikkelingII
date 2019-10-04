using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Text;

namespace Codering
{
    public class Blok : Codering
    {
        private static char[][] _blok = new char[][]
        {
            new char[] {'a', 'z', 'e', 'r', 't', '1'},
            new char[] {'2', 'y', 'u', 'i', 'o', 'p'},
            new char[] {'q', '3', 's', '4', '8', 'd'},
            new char[] {'f', 'g', 'h', 'n', 'j', 'k'},
            new char[] {'9', '7', 'l', 'm', '6', 'w'},
            new char[] {'5', '0', 'x', 'c', 'v', 'b'}
        };
        public Blok(ICodeerbareString codeerbareString)
        {
            _codeerbareString = codeerbareString;
        }

        public override string GecodeerdeString(string codeString)
        {
            //lowercase
            string result = _codeerbareString.GecodeerdeString(codeString).ToLower();
            //replace all spaces with 0
            result = result.Replace(' ', '0');
            //make number of chars even
            if (result.Length % 2 != 0)
            {
                result += "0";
            }
            //split in char array
            char[] resultCharArr = result.ToCharArray();
            //loop over them 2 at a time
            for (int i = 0; i < resultCharArr.Length; i += 2)
            {
                char c1 = resultCharArr[i];
                char c2 = resultCharArr[i + 1];
                if (c1 == c2) continue;
                int c1Row = getRow(c1);
                int c2Row = getRow(c2);
                int c1Col = getCol(c1);
                int c2Col = getCol(c2);
                if (c1Row == c2Row || c1Col == c2Col)
                {
                    char temp = c1;
                    c1 = c2;
                    c2 = temp;
                }
                else
                {
                    c1 = _blok[c1Row][c2Col];
                    c2 = _blok[c2Row][c1Col];

                }

                resultCharArr[i] = c1;
                resultCharArr[i + 1] = c2;
            }

            return new string(resultCharArr);
        }

        private int getRow(char c)
        {
            for(int i = 0; i < _blok.Length; i++)
            {
                char[] row = _blok[i];
                if (row.Contains(c))
                {
                    return i;
                }
            }
            throw new ArgumentException("Given character "+ c +" was not found in block!");
        }

        private int getCol(char c)
        {
            for (int col = 0; col < _blok[0].Length; col++)
            {
                foreach (var t in _blok)
                {
                    if (c == t[col]) return col;
                }
            }
            throw new ArgumentException("Given character " + c + " was not found in block!");
        }
    }
}