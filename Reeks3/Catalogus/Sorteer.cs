using System;
using System.Collections;
using System.Collections.Generic;

namespace Catalogus
{
    public class Sorteer : IComparer<IBibItem>
    {
       
        public int Compare(IBibItem x, IBibItem y)
        {
            //check for nulls
            if (x == null) return y == null ? 1 : 0;
            if (y == null) return -1;
            
            //check if the same
            if (x.Equals(y)) return 0;

            //same type
            if (x.GetType() == y.GetType())
            {
                //afdeling
                if (x.GetType() == typeof(Afdeling))
                {
                    Afdeling a = (Afdeling) x;
                    Afdeling b = (Afdeling) y;
                    //sort op naam
                    return Compare(a, b);
                }
                //boek
                if (x.GetType() == typeof(Boek))
                {
                    Boek a = (Boek) x;
                    Boek b = (Boek) y;
                    //sort op auteur
                    return Compare(a, b);
                }
                //tijdschrift
                if (x.GetType() == typeof(TijdSchrift))
                {
                    TijdSchrift a = (TijdSchrift) x;
                    TijdSchrift b = (TijdSchrift) y;
                    return Compare(a, b);
                }
            }
            if (x.GetType() == typeof(Afdeling)) return -1;
            if (y.GetType() == typeof(Afdeling)) return +1;
            if (x.GetType() == typeof(Boek)) return -1;
            return +1;
        }

        private static int Compare(Afdeling x, Afdeling y)
        {
            return (new CaseInsensitiveComparer()).Compare(x.Naam, y.Naam);
        }

        private static int Compare(Boek x, Boek y)
        {
            CaseInsensitiveComparer cIP = new CaseInsensitiveComparer();
            int temp = cIP.Compare(x.Auteur, y.Auteur);
            if (temp == 0) temp = cIP.Compare(x.Titel, y.Titel);
            if (temp == 0) temp = cIP.Compare(x.Id, y.Id);
            return temp;
        }

        private static int Compare(TijdSchrift x, TijdSchrift y)
        {
            CaseInsensitiveComparer cIP = new CaseInsensitiveComparer();
            int temp = cIP.Compare(x.Titel, y.Titel);
            if (temp == 0) temp = cIP.Compare(x.Id, y.Id);
            return temp;
        }
    }
}