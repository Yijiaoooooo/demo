using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Domain.User;

namespace WEB.UI.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View(new User());
        }

        public ActionResult SaveUser(User u)
        {
            return View();
        }
    }
}