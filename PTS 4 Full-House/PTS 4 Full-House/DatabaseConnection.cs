using System;
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
                    users.Add(new User(Convert.ToInt32(sqlReader["ID"].ToString()),sqlReader["Achternaam"].ToString(), sqlReader["Tussenvoegsel"].ToString(), sqlReader["Voornaam"].ToString(), sqlReader["Gebruikersnaam"].ToString(), sqlReader["Wachtwoord"].ToString(), sqlReader["Facebook"].ToString(), sqlReader["Twitter"].ToString()));
                }
            }
            catch (SqlException exception)
            {
                Console.Write(exception);
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

        public void makeNotification(String title, String Message, int Id) {
            try
            {
                connString.Open();
                String Command = "INSERT INTO MELDING(Titel, Inhoud, Tijdstip, GebruikerID) VALUES (@Titel, @Inhoud, GETDATE(), @GebruikerID)";
                SqlCommand sqlCommand = new SqlCommand(Command, connString);
                sqlCommand.Parameters.AddWithValue("@Titel", title);
                sqlCommand.Parameters.AddWithValue("@Inhoud", Message);
                sqlCommand.Parameters.AddWithValue("@GebruikerID", Id);
          
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                Console.Write(exception);
            }
            finally
            {
                connString.Close();
            }
        }

        public void createNewUser(User newUser) {
           try
            {
                connString.Open();
                String Command = "INSERT INTO Gebruiker(Achternaam, Tussenvoegsel, Voornaam, Gebruikersnaam, Wachtwoord, LocatieX, LocatieY, Emailadres) VALUES (@Achternaam, @Tussenvoegsel, @Voornaam, @Gebruikersnaam, @Wachtwoord, @LocatieX, @LocatieY, @Emailadres)";
                SqlCommand sqlCommand = new SqlCommand(Command, connString);
                sqlCommand.Parameters.AddWithValue("@Achternaam", newUser.LastName);
                sqlCommand.Parameters.AddWithValue("@Tussenvoegsel", newUser.Prefix);
                sqlCommand.Parameters.AddWithValue("@Voornaam", newUser.FirstName);
                sqlCommand.Parameters.AddWithValue("@Gebruikersnaam", newUser.Username);
                sqlCommand.Parameters.AddWithValue("@Wachtwoord", newUser.Password);
                sqlCommand.Parameters.AddWithValue("@LocatieX", 0.0);
                sqlCommand.Parameters.AddWithValue("@LocatieY", 0.0);
                sqlCommand.Parameters.AddWithValue("@Emailadres", null);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new Exception("SQL exception");
            }
            finally
            {
                connString.Close();
            }
        }


    }
}