using System.Collections.Generic;
using System.Text;

namespace Catalogus
{
    public abstract class ABibItem : IBibItem
    {
        public string Id { get; set; }
        public IBibItem Ouder { get; set; }

        protected ABibItem()
        {
        }

        protected ABibItem(string id)
        {
            Id = id;
        }
        
        public virtual void VoegToe(IBibItem bibItem) {}

        public virtual void Verwijder(IBibItem bibItem) {}

        public virtual IBibItem Zoek(string id)
        {
            //kan enkel zoeken voor mezelf
            return this.Id.Equals(id) ? this : null;
        }

        public virtual ISet<IBibItem> ZoekTrefwoord(string trefwoord)
        {
            return VoldoetAanTrefwoord(trefwoord) ? new SortedSet<IBibItem>() { this } : null;
        }

        public virtual void VerplaatsNaar(IBibItem bibItem)
        {
            Ouder.Verwijder(this);
            bibItem.VoegToe(this);
        }

        public virtual string Toon(int insprong)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < insprong; i++)
            {
                result.Append("-");
            }
            result.Append(Id);
            return result.ToString();
        }

        protected virtual bool VoldoetAanTrefwoord(string woord)
        {
            return this.Id.Contains(woord);
        }
    }
}