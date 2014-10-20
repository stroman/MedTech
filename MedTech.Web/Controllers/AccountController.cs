using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedTech.Web.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {

        }

        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Login()
        //{
        //    return RedirectToAction("Index","Home");
        //}

        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
	}
}