using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTS_4_Full_House.Account
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserId"] = null;
            Session["Username"] = null;
            Response.Redirect("../Webpages/Default.aspx");
        }
    }
}