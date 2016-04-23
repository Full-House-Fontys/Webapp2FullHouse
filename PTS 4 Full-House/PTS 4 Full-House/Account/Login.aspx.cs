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

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                List<User> users = dbConnection.getUsers();
              
                int SignInId = checkUser(users);
                if (SignInId > 0){
                    Session["UserId"] = SignInId;
                    Response.Redirect("../Notification.aspx");
                }
                else {
                    FailureText.Text = "Invalid login attempt";
                    ErrorMessage.Visible = true;
                }
              
            }
        }

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