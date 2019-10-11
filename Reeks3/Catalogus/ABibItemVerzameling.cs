using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogus
{
    public abstract class ABibItemVerzameling : ABibItem
    {
        protected ICollection<IBibItem> Items { get; set; }

        protected ABibItemVerzameling()
        {
            
        }

        protected ABibItemVerzameling(string id) : base(id)
        {
        }

        public override void VoegToe(IBibItem bibItem)
        {
            Items.Add(bibItem);
            bibItem.Ouder = this;
        }

        public override void Verwijder(IBibItem bibItem)
        {
            Items.Remove(bibItem);
            bibItem.Ouder = null;
        }

        public override IBibItem Zoek(string id)
        {
            if (this.Id.Equals(id)) return this;
            foreach (IBibItem bibItem in Items)
            {
                if (bibItem.Zoek(id) != null) return bibItem;
            }
            return null;
        }

        public override ISet<IBibItem> ZoekTrefwoord(string trefwoord)
        {
            var result = new SortedSet<IBibItem>(new Sorteer());
            if (Id.Contains(trefwoord)) result.Add(this);
            foreach (IBibItem bibItem in Items)
            {
                var temp = bibItem.ZoekTrefwoord(trefwoord);
                if (temp == null) continue;
                foreach (IBibItem item in temp)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        protected string ToonKinderen(int insprong)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (IBibItem bibItem in Items)
            {
                stringBuilder.Append(bibItem.Toon(insprong));
                stringBuilder.Append(" \n");
            }
            return stringBuilder.ToString();
        }
    }
}