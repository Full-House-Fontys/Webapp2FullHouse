using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTS_4_Full_House.Account
{
    public partial class EditAccount : System.Web.UI.Page
    {
        DatabaseConnection dbConnection;

        /// <summary>
        /// When the page load, it will check if an user is logged in.
        /// If there is none logged in or the databaseConnection failed, the site will redirect to the Login page.
        /// If an user is logged in, this page will load correctly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            dbConnection = new DatabaseConnection();
            try
            {
                if (Convert.ToInt32(Session["UserId"]) <= 0)
                {
                    Response.Redirect("/Account/Login.aspx");
                }
            }
            catch (NullReferenceException)
            {
                Response.Redirect("/Account/Login.aspx");
            }
        }
    
        /// <summary>
        /// With this method, the current logged in user can change his account info.
        /// A new User object will be created witch all values filled in the web form.
        /// First the username will be checked if it already occures in the database, if it does, an error will be displayd.
        /// However, the username may be identical to the current logged in users account.
        /// Last, the methode editUserInDatabase() will be called with te new User as parameter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ChangeUser_Click(object sender, EventArgs e)
        {
            User newUser = new User(0, LastName.Text, Prefix.Text, FirstName.Text, Username.Text, Password.Text, null, null);
            Boolean validUser = true;
            foreach (User user in dbConnection.getUsers())
            {
                if (user.Username.Equals(newUser.Username) && !user.Username.Equals(Session["Username"]))
                {
                    validUser = false;
                }
            }
            if (validUser)
            {
                try
                {
                    dbConnection.editUserInDatabase((Int32)Session["UserId"], (string)Session["Username"], newUser);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                catch (Exception exception)
                {
                    ErrorMessage.Text = "Lost connection";
                    Console.Write(exception.Message);
                }
            }
            else
            {
                ErrorMessage.Text = "This username is already in use";
            }
        }
    }
}