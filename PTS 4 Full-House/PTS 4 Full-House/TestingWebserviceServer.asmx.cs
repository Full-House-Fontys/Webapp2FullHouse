using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using PTS_4_Full_House.Webpages;

namespace PTS_4_Full_House
{
    /// <summary>
    /// Summary description for TestingWebserviceServer
    /// </summary>
    [WebService(Namespace = "http://localhost/CimsService/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TestingWebserviceServer : System.Web.Services.WebService
    {
        [WebMethod]
        public String PublishEmergencyMessage(String title, String message)
        {
            Webpages.GetMessagesFromCims.publishOnPage(title, message);
            
            return "Dit gaat naar intellij";
        }
    }
}
