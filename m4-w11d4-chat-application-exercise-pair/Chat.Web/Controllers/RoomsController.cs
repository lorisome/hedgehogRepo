using Chat.Web.DataAccess;
using Chat.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Chat.Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomDAL roomDal;
        private readonly IMessageDAL messageDal;

        public RoomsController(IRoomDAL roomDal, IMessageDAL messageDal)
        {
            this.roomDal = roomDal;
            this.messageDal = messageDal;
        }

        // GET: Rooms
        public ActionResult Index()
        {
            List<RoomModel> rooms = roomDal.GetOpenRooms();
            return View("Index", rooms);
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            return View("Create", new RoomModel());
        }

        // POST: Rooms/Create
        [HttpPost]
        public ActionResult Create(RoomModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedBy = (string)Session["Username"];
                RoomModel room = roomDal.CreateChatRoom(model);
                return RedirectToAction("View", "Rooms", new { id = room.Id });
            }
            else
            {
                return View("Create", model);
            }
        }

        // POST: Rooms/Join
        [HttpPost]
        public ActionResult Join(string roomName, string username)
        {
            RoomModel room = roomDal.GetChatRoom(roomName);
            if (room != null)
            {
                roomDal.LeaveChatRooms(username);
                roomDal.JoinChatRoom(room.Id, username);
                return RedirectToAction("View", "Rooms", new { id = room.Id });
            }

            return RedirectToAction("Index", "Rooms");
        }

        // POST: Rooms/Leave
        [HttpPost]
        public ActionResult Leave(string username)
        {
            roomDal.LeaveChatRooms(username);
            return RedirectToAction("Index", "Rooms");
        }

        // GET: Rooms/View/{id}
        public ActionResult View(int id)
        {            
            RoomModel room = roomDal.GetChatRoom(id);

            if (room != null)
            {
                List<MessageModel> messages = messageDal.GetMessages(id);
                List<string> members = roomDal.GetRoomMembers(id);

                RoomViewModel roomVm = new RoomViewModel();
                roomVm.Room = room;
                roomVm.Messages = messages;
                roomVm.Members = members;

                return View("View", roomVm);
            }

            return new HttpNotFoundResult();
        }

      
    }
}