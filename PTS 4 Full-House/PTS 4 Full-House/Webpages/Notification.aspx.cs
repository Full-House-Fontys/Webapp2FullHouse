using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTS_4_Full_House
{
    public partial class Notification : Page
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
        /// Creates a new notification and put it in the database.
        /// If the Title.Text or the Messade.Text is empty, it will not send.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MakeNotification(object sender, EventArgs e) {

            if (String.IsNullOrWhiteSpace(NotificationTitle.Text))
            {
            }
            else if (String.IsNullOrWhiteSpace(Message.Text))
            {
            }
            else {
                try
                {
                    dbConnection.makeNotification(NotificationTitle.Text, Message.Text, Convert.ToInt32(Session["UserId"]));
                    Response.Redirect("../Webpages/GetMessagesFromCims.aspx");
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

            }
        }
    }
}