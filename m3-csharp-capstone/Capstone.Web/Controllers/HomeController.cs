using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAL parkDAL;

        public HomeController(IParkDAL parkDAL)
        {
            this.parkDAL = parkDAL;
        }

        public ActionResult Index()
        {
            List<Park> parks = parkDAL.GetAllParks();
            return View("Index", parks);
        }


        public ActionResult Detail(string id)
        {
            var park = parkDAL.GetOnePark(id);
            if (park == null)
            {
                return new HttpNotFoundResult();
            }
            return View("Detail", park);
        }
    }
}