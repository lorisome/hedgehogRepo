using Chat.Web.DataAccess;
using Chat.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Chat.Web.Controllers
{
    public class ApiController : Controller
    {
        private IRoomDAL roomDal;
        private IMessageDAL messageDal;

        public ApiController(IRoomDAL roomDal, IMessageDAL messageDal)
        {
            this.roomDal = roomDal;
            this.messageDal = messageDal;
        }

        // POST: api/messages/new
        [Route("api/messages")]
        [HttpPost]
        public ActionResult NewMessage(MessageModel model)
        {
            if (ModelState.IsValid)
            {
                var room = roomDal.GetChatRoom(model.RoomId);
                if (room != null)
                {
                    if (roomDal.IsUserInRoom(model.RoomId, model.Username))
                    {
                        messageDal.AddMessage(model);
                        return Json(true);
                    }
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        
        // GET: api/rooms/{id}?sinceDate={sinceDate}
        //[Route("api/rooms/{id}")]
        //public ActionResult Status(int id, DateTime sinceDate)
        //{
        //    RoomModel room = roomDal.GetChatRoom(id);            

        //    if (room != null)
        //    {
        //        List<MessageModel> messages = messageDal.GetMessages(id, sinceDate);
        //        List<string> members = roomDal.GetRoomMembers(id);

        //        RoomViewModel roomVm = new RoomViewModel();
        //        roomVm.Room = room;
        //        roomVm.Messages = messages;
        //        roomVm.Members = members;

        //        return Json(roomVm, JsonRequestBehavior.AllowGet);
        //    }

        //    return new HttpNotFoundResult();
        //}

    }
}