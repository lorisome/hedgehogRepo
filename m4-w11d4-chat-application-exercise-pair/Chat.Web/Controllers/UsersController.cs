using Chat.Web.DataAccess;
using Chat.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserDAL userDal;

        public UsersController(IUserDAL userDal)
        {
            this.userDal = userDal;
        }

        // GET: Users/Register
        public ActionResult Register()
        {
            return View("Register", new UserModel());
        }

        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                Session.Abandon();

                UserModel newUser = userDal.CreateUser(model);
                Session["Username"] = newUser.Username;
                return RedirectToAction("Login", "Users");
            }
            else
            {
                return View("Register", model);
            }
        }


        // GET: Users/Login
        public ActionResult Login()
        {
            return View("Login", new UserModel());
        }

        [HttpPost]
        // Get: Users/Login
        public ActionResult Login(UserModel model)
        {            
            if (ModelState.IsValid)
            {
                UserModel user = userDal.GetUser(model.Username, model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("invalid-login", "The username or password is invalid");
                    return View("Login", model);
                }
                else
                {
                    Session["Username"] = user.Username;
                    return RedirectToAction("Index", "Rooms");
                }
            }
            else
            {
                return View("Login", model);
            }            
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}