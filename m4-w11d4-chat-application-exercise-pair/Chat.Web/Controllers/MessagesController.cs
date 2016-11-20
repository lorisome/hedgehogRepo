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
    public class MessagesController : Controller
    {
        private readonly IMessageDAL messageDal;
        private readonly IRoomDAL roomDal;

        public MessagesController(IMessageDAL messageDal, IRoomDAL roomDal)
        {
            this.messageDal = messageDal;
            this.roomDal = roomDal;
        }

        // GET: Messages/Since?roomId={roomId}&sinceDate={sinceDate}
        public ActionResult Since(int roomId, DateTime sinceDate)
        {
            var messages = messageDal.GetMessages(roomId, sinceDate);

            return Json(messages, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult NewMessages(int id, DateTime sinceDate)
        {
            RoomModel room = roomDal.GetChatRoom(id);

            if (room != null)
            {
                List<MessageModel> messages = messageDal.GetMessages(id, sinceDate);
                List<string> members = roomDal.GetRoomMembers(id);

                RoomViewModel roomVm = new RoomViewModel();
                roomVm.Room = room;
                roomVm.Messages = messages;
                roomVm.Members = members;

                return PartialView("_PartialChatMessageView", roomVm);
            }

            return new HttpNotFoundResult();
        }

        // POST: Messages/New
        [HttpPost]
        public ActionResult New(MessageModel model)
        {
            if (ModelState.IsValid)
            {
                var room = roomDal.GetChatRoom(model.RoomId);
                if (room != null)
                {
                    if (roomDal.IsUserInRoom(model.RoomId, model.Username))
                    {
                        messageDal.AddMessage(model);

                        return RedirectToAction("View", "Rooms", new { id = model.RoomId });
                    }
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


    }
}