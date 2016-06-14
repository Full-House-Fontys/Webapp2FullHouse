using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTS_4_Full_House
{
    public class Message
    {
        public String Title { get; set; }
        public String Description { get; set; }

        public Message(String title, String description)
        {
            this.Title = title;
            this.Description = description;
        }
    }
}