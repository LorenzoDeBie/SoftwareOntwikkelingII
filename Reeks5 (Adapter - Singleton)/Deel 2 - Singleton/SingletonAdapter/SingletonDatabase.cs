using System;
using System.Collections.Generic;
using UserDatabase;

namespace Bibliotheek.PatternSingleton
{
    public class SingletonDatabase : IDatabase
    {
        private static SingletonDatabase instance;
        private readonly IDatabase db;

        private SingletonDatabase()
        {
            db = new MySQLDatabase();
            db.OpenConnection();
        }
        ~SingletonDatabase()
        {
            db.CloseConnection();   // Destructor!!
        }

        public static IDatabase Instance
        {
            get
            { //lazy singleton
                if (instance == null)
                {
                    instance = new SingletonDatabase();
                }
                return instance;
            }
        }

        public void DeleteUser(User user)
        {
            db.DeleteUser(user);
        }

        public void InsertUser(User user)
        {
            db.InsertUser(user);
        }

        public List<User> SelectAllUsers()
        {
            return db.SelectAllUsers();
        }

        public void UpdateUser(User user)
        {
            db.UpdateUser(user);
        }

        public void CloseConnection()
        {
            //Niets doen - sluiten gebeurt pas bij destructor            
        }

        public bool IsConnected
        {
            get { return db.IsConnected; }
        }

        public void OpenConnection()
        {
            //Niets doen - openen in constructor     
        }


    }
}
