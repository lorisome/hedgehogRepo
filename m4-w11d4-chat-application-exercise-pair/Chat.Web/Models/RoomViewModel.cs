using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Web.Models
{
    public class RoomViewModel
    {
        public RoomModel Room { get; set; }
        public List<string> Members { get; set; }
        public List<MessageModel> Messages { get; set; }
        
    }
}