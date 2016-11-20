using Chat.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Web.DataAccess
{
    public interface IRoomDAL
    {
        List<RoomModel> GetOpenRooms();
        RoomModel GetChatRoom(int id);
        RoomModel GetChatRoom(string name);
        RoomModel CreateChatRoom(RoomModel newChatRoom);
        List<string> GetRoomMembers(int id);
        void JoinChatRoom(int id, string username);
        void LeaveChatRooms(string username);
        bool IsUserInRoom(int id, string username);
    }
}
