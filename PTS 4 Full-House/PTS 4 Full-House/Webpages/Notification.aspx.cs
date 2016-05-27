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
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

            }
        }
    }
}