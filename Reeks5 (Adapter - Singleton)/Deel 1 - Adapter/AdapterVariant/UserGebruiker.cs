using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDatabase;

using GebruikersPortaal;

namespace Bibliotheek.Pattern
{
    public class UserGebruiker:User
    {
        

        public UserGebruiker(Gebruiker gebruiker)
        {
            LastName = gebruiker.Achternaam;
            FirstName = gebruiker.VoorNaam;
            ID = gebruiker.GebruikersCode;
        }
    }
}
