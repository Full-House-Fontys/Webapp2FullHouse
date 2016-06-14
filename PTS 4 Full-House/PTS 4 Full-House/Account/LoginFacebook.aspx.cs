using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using PTS_4_Full_House.Models;
using System.Collections.Generic;
using ASPSnippets.FaceBookAPI;
using System.Web.Script.Serialization;

namespace PTS_4_Full_House.Account
{
    public partial class LoginFacebook : System.Web.UI.Page
    {
        private DatabaseConnection dbConnection;
        protected void Page_Load(object sender, EventArgs e)
        {
            FaceBookConnect.API_Key = "1062297970483328";
            FaceBookConnect.API_Secret = "98c8cb8507322c4416957c41cf3a8855";
            if (!IsPostBack)
            {
                if (Request.QueryString["error"] == "access_denied")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User has denied access.')", true);
                    return;
                }

                string code = Request.QueryString["code"];
                if (!string.IsNullOrEmpty(code))
                {
                    string data = FaceBookConnect.Fetch(code, "me");
                    FaceBookUser faceBookUser = new JavaScriptSerializer().Deserialize<FaceBookUser>(data);
                    faceBookUser.PictureUrl = string.Format("https://graph.facebook.com/{0}/picture", faceBookUser.Id);
                    pnlFaceBookUser.Visible = true;
                    lblId.Text = faceBookUser.Id;
                    lblUserName.Text = faceBookUser.UserName;
                    lblName.Text = faceBookUser.Name;
                    lblEmail.Text = faceBookUser.Email;
                    ProfileImage.ImageUrl = faceBookUser.PictureUrl;
                    btnLogin.Enabled = false;
                }
            }
        }

        protected void LogInWithFacebook(object sender, EventArgs e)
        {
            FaceBookConnect.Authorize("user_photos,email", Request.Url.AbsoluteUri.Split('?')[0]);
        }

        protected void LogInWithTwitter(object sender, EventArgs e)
        {
            return;
        }

    }
}