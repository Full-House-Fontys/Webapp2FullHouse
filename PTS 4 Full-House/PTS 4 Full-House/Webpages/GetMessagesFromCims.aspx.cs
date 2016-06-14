using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using PTS_4_Full_House.ReceiveJavaNotificationsClient;

namespace PTS_4_Full_House.Webpages
{
    public partial class GetMessagesFromCims : System.Web.UI.Page
    {
        static List<Message> messages = new List<Message>();
        protected void Page_Load(object sender, EventArgs e)
        {
            messages.Reverse();
            foreach (Message message in messages) {
                Panel panel = new Panel();
                panel.CssClass = "message";
                Label title = new Label();
                title.Text = "<h4>" + message.Title + "</h4>"+ "<br>";
                panel.Controls.Add(title);
                Label messageA = new Label();
                messageA.Text = message.Description + "<br>";
                panel.Controls.Add(messageA);
                MessagePanel.Controls.Add(panel);
            }
            messages.Reverse();
        }

        public static void publishOnPage(String title, String description) {
            messages.Add(new Message(title, description));
        }
    }
}