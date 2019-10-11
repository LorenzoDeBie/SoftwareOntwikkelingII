using System.Collections.Generic;
using System.Text;

namespace Catalogus
{
    public class Afdeling : ABibItemVerzameling
    {
        public string Naam { get; set; }

        public Afdeling() : base()
        {
            Items = new SortedSet<IBibItem>(new Sorteer());
        }

        public Afdeling(string id, string naam) : base(id)
        {
            Naam = naam;
            Items = new SortedSet<IBibItem>(new Sorteer());
        }
        public override string Toon(int insprong)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < insprong; i++)
            {
                result.Append("-");
            }

            result.Append(Naam);
            result.Append(": \n");
            result.Append(ToonKinderen(insprong + 2));
            return result.ToString();
        }
    }
}