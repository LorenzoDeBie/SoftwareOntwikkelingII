using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GebruikersPortaal;
using UserDatabase;

namespace Reeks5
{
    class Adapter : GebruikersPortaal.IGebruikersLijst, UserDatabase.IDatabase
    {
        private readonly IDatabase _database = new MySQLDatabase();

        private List<Gebruiker> _gebruikers = new List<Gebruiker>();

        public Gebruiker[] Gebruikers => _gebruikers.ToArray();

        public bool IsConnected => _database.IsConnected;


        public void CloseConnection()
        {
            _database.CloseConnection();
        }

        public void DeleteUser(User user)
        {
            Gebruiker gebruiker = VindGebruikerMetID(user.ID);
            if(gebruiker != null)
            {
                _gebruikers.Remove(gebruiker);
            }
            else
            {
                _database.DeleteUser(user);
            }
            
        }

        public void InsertUser(User user)
        {
            _database.InsertUser(user);
        }

        public void OpenConnection()
        {
            _database.OpenConnection();
        }

        public void PasAan(Gebruiker gebruiker)
        {
            User user = VindUserMetID(gebruiker.GebruikersCode);
            if(user != null)
            {
                _database.
            }

        }

        public List<User> SelectAllUsers()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void Verwijder(Gebruiker gebruiker)
        {
            throw new NotImplementedException();
        }

        public void VoegToe(Gebruiker gebruiker)
        {
            throw new NotImplementedException();
        }

        //helper functions
        private Gebruiker UserToGebruiker(User user) {
            return new Gebruiker()
            {
                Achternaam = user.LastName,
                GebruikersCode = user.ID,
                VoorNaam = user.FirstName
            };
        }

        private User GebruikerToUser(Gebruiker gebruiker)
        {
            return new User()
            {
                FirstName = gebruiker.VoorNaam,
                ID = gebruiker.GebruikersCode,
                LastName = gebruiker.Achternaam
            };
        }

        private Gebruiker VindGebruikerMetID(int ID)
        {
            foreach(Gebruiker gebruiker in _gebruikers)
            {
                if (gebruiker.GebruikersCode == ID) return gebruiker;
            }
            return null;
        }

        private User VindUserMetID(int ID)
        {
            foreach(User user in _database.SelectAllUsers())
            {
                if (user.ID == ID) return user;
            }
            return null;
        }
    }
}
