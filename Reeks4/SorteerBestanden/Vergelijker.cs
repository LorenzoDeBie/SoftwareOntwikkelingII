using System;
using System.Collections.Generic;

namespace SorteerBestanden
{
    public class Vergelijker : IComparer<Park>, IComparer<School>
    {
        public int Compare(Park x, Park y)
        {
            int temp = string.Compare(x?.Naam, y?.Naam);
            return temp != 0 ? temp : string.Compare(x?.Id, y?.Id);
        }

        public int Compare(School x, School y)
        {
            int temp = string.Compare(x?.Naam, y?.Naam);
            return temp != 0 ? temp : string.Compare(x?.Id, y?.Id);
        }
    }
}