﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PTS_4_Full_House
{
    public class DatabaseConnection
    {
        private SqlConnection connString = new SqlConnection();
        private List<User> users = new List<User>();

        public DatabaseConnection()
        {
            connString.ConnectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTION"].ConnectionString;
            if (connString != null)
            {
                Console.WriteLine("There is a connection");
            }

        }

        private void getUsersFromDatabase()
        {
            try
            {
                connString.Open();
                String Command = "Select * FROM Gebruiker;";
                SqlCommand sqlCommand = new SqlCommand(Command, connString);
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    users.Add(new User(sqlReader["Achternaam"].ToString(), sqlReader["Tussenvoegsel"].ToString(), sqlReader["Voornaam"].ToString(), sqlReader["Gebruikersnaam"].ToString(), sqlReader["Wachtwoord"].ToString(), sqlReader["Facebook"].ToString(), sqlReader["Twitter"].ToString()));
                }
            }
            catch (Exception exception)
            {
                Console.Write("Exception has been thrown");
            }
            finally
            {
                connString.Close();
            }
        }

        public List<User> getUsers()
        {
            getUsersFromDatabase();
            return users;
        }
    }
}