using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTS_4_Full_House
{
    public class User
    {
        public int Id { get; set; }
        public String LastName { get; set; }
        public String Prefix { get; set; }
        public String FirstName { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Facebook { get; set; }
        public String Twitter { get; set; }

        public User(int Id,String lastName, String prefix, String firstName, String userName, String password, String facebook, String twitter)
        {
            this.Id = Id;
            LastName = lastName;
            Prefix = prefix;
            FirstName = firstName;
            Username = userName;
            Password = password;
            Facebook = facebook;
            Twitter = twitter;
        }

        override
        public String ToString()
        {
            return "Naam : " + FirstName + "  Achternaam : " + LastName;
        }
    }
}