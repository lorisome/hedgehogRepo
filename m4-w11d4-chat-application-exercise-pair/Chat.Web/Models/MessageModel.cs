using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chat.Web.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime SentDate { get; set; }
    }
}