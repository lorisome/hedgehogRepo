using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Web.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }        
    }
}