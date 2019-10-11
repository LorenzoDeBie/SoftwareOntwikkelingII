using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Catalogus
{
    public class TijdSchrift : ABibItemVerzameling
    {
        public string Titel { get; set; }
        public string Uitgeverij { get; set; }
        public DateTime Datum { get; set; }

        public TijdSchrift()
        {
            Items = new List<IBibItem>();
        }

        public TijdSchrift(string id, string uitgeverij, DateTime datum) : base(id)
        {
            Uitgeverij = uitgeverij;
            Datum = datum;
        }

        public override string Toon(int insprong)
        {
            // insprong + id
            StringBuilder result = new StringBuilder(base.Toon(insprong));
            result.Append(": \"");
            result.Append(Titel);
            result.Append("\", ");
            result.Append(Datum.ToString("d/MM/yyyy H:mm:ss"));
            result.Append(", ");
            result.Append(Uitgeverij);
            result.Append(": \n");
            result.Append(ToonKinderen(insprong + 2));
            return result.ToString();
        }

        public override void VoegToe(IBibItem bibItem)
        {
            if (bibItem.GetType() == typeof(Artikel))
            {
                base.VoegToe(bibItem);
            }
        }

        public override ISet<IBibItem> ZoekTrefwoord(string trefwoord)
        {
            var temp = base.ZoekTrefwoord(trefwoord);
            if (Titel.Contains(trefwoord) || Uitgeverij.Contains(trefwoord)) temp.Add(this);
            return temp;
        }
    }
}