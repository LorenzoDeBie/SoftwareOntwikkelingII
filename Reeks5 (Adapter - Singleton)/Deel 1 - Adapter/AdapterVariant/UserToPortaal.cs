using GebruikersPortaal;
using System.Collections.Generic;
using UserDatabase;

namespace Bibliotheek.Pattern
{
    public class UserToPortaal : IGebruikersLijst
    {
        //Geen Singleton
        IDatabase db;//Niet vastleggen in deze klasse         
        public UserToPortaal(IDatabase db)  //Wijzig dit naar public UserPortaal(SingletonDatabase db) in deel2
        {
            this.db = db;
          
        }

        /*. In het eerste gedeelte wordt nog niet met een Singleton gewerkt, 
        * en is het heel gevaarlijk om de connectie niet af te sluiten. 
        * De voorbije jaren hebben we hier vaak problemen mee gehad bij VOP/BP: 
        * studenten openen constant connecties naar een MySQL DB,
        * en vergeten die in hun code te sluiten waardoor de connectie open blijft staan 
        * (tot aan de time-out).
        * Een DB heeft typisch een aantal connecties dat maximum toegelaten is
        */


        public Gebruiker[] Gebruikers
        {
            get
            {
                checkConnection();
                List<UserDatabase.User> users = db.SelectAllUsers();
                Gebruiker[] gebruikers = new Gebruiker[users.Count];
                int i = 0;
                foreach (User user in users)
                {
                    gebruikers[i] = new GebruikerUser(user);
                    i++;
                }
                db.CloseConnection();
                return gebruikers;

            }
        }

        private void checkConnection()
        {
            db.OpenConnection();
            if (!db.IsConnected)
                throw new NotConnected();
            
        }


        public void PasAan(Gebruiker gebruiker)
        {
            checkConnection();
            db.UpdateUser(new UserGebruiker(gebruiker)); 
            db.CloseConnection();
        }

        public void Verwijder(Gebruiker gebruiker)
        {
            checkConnection();
            db.DeleteUser(new UserGebruiker(gebruiker)); 
            db.CloseConnection();
        }

        public void VoegToe(Gebruiker gebruiker)
        {
            checkConnection();
            db.InsertUser(new UserGebruiker(gebruiker)); 
            db.CloseConnection();
        }

        
    }
}
