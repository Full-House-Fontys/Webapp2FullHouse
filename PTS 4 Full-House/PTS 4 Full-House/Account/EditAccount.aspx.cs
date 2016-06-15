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
                    dbConnection.editUserInDatabase((string)Session["UserId"], (string)Session["Username"], newUser);
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