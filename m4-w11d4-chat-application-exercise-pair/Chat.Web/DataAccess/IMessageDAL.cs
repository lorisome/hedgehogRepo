using Chat.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Web.DataAccess
{
    public interface IMessageDAL
    {
        List<MessageModel> GetMessages(int roomId);
        List<MessageModel> GetMessages(int roomId, DateTime sinceDate);
        MessageModel AddMessage(MessageModel newMessage);
        bool DeleteMessage(int messageId);
    }
}
