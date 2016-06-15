using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using PTS_4_Full_House.Models;

namespace PTS_4_Full_House.Account
{
    public partial class Register : Page
    {
        DatabaseConnection dbConnection;

        /// <summary>
        /// Creates a new DatabaseConnection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            dbConnection = new DatabaseConnection();
        }

        /// <summary>
        /// If all fields are validated, this method will try to register a new user.
        /// A new User object will be created witch all values filled in the web form.
        /// First the username will be checked if it already occures in the database, if it does, an error will be displayd.
        /// Last, the methode createNewUser() will be called with te new User as parameter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            User newUser = new User(0, LastName.Text, Prefix.Text, FirstName.Text, Username.Text, Password.Text, null, null);
            Boolean validUser = true;
            foreach (User user in dbConnection.getUsers()) {
                if (user.Username.Equals(newUser.Username)) {
                    validUser = false;
                }
            }
            if (validUser) {
                try
                {
                    dbConnection.createNewUser(newUser);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                catch (Exception exception) {
                    ErrorMessage.Text = "Lost connection";
                    Console.Write(exception.Message);
                }
            }
            else
            {
                ErrorMessage.Text = "This username is already in use";
            }
        }

        protected void RegisterWithFacebook(object sender, EventArgs e)
        {
            return;
        }

        protected void RegisterWithTwitter(object sender, EventArgs e)
        {
            return;
        }
    }
}