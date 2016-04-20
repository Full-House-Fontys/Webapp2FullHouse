using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MessageApplication
{
    public partial class SendMessageWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbConn = ConfigurationManager.ConnectionStrings["SQLCONNECTION"].ToString();
            using (SqlConnection cn = new SqlConnection(dbConn))
            {
                SqlCommand cmd = new SqlCommand("SELECT NAAM FROM MATERIAAL", cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Label1.Text += rdr[0].ToString();
                }
                cn.Close();
            }
        }
    }
}