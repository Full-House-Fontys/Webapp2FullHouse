using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTS_4_Full_House.ReceiveJavaNotificationsClient;

namespace PTS_4_Full_House.Webpages
{
    public partial class GetMessagesFromCims : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public static void publishOnPage(String title, String Description) {
            Console.WriteLine("Titel : " + title + "  Beschrijving :" + Description);
        }
    }
}