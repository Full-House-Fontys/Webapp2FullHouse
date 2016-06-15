using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using PTS_4_Full_House.Models;
using System.Collections.Generic;

namespace PTS_4_Full_House.Account
{
    public partial class Login : Page
    {
        private DatabaseConnection dbConnection;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbConnection = new DatabaseConnection();
            RegisterHyperLink.NavigateUrl = "Register";
        
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl)) 
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        /// <summary>
        /// If all fields are validated, this method will try to log in.
        /// For each account in the database there will be checked if there is an match with the given username.
        /// If there is a match, Session userId and Username will be assigned and the page will redirect to the Notification page.
        /// If there is none match, an error will be displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                List<User> users = dbConnection.getUsers();
              
                int SignInId = checkUser(users);
                if (SignInId > 0){
                    Session["UserId"] = SignInId;
                    Session["Username"] = Username.Text;
                    Response.Redirect("../Webpages/Notification.aspx");
                }
                else {
                    FailureText.Text = "Invalid login attempt";
                    ErrorMessage.Visible = true;
                }
              
            }
        }

        /// <summary>
        /// This will check if the values form Username.Text and Password.Text have a match in the database.
        /// If there is a match, the userId will be retured, else, 0 will be returned.
        /// </summary>
        /// <param name="users"></param>
        /// <returns>0 if none match, userId if there is a match</returns>
        private int checkUser(List<User> users) {
            int status = 0;
            foreach (User user in users) {
                if (user.Username.Equals(Username.Text) && user.Password.Equals(Password.Text)) {
                    status = user.Id;
                }
            }
            return status;
        }
    }
}