using UserDatabase;

using GebruikersPortaal;

namespace Bibliotheek.Pattern
{
    public class GebruikerUser:Gebruiker
    {
        public GebruikerUser( User user)
        {
            Achternaam = user.LastName;
            VoorNaam = user.FirstName;
            GebruikersCode = user.ID;
        }
    }
}
