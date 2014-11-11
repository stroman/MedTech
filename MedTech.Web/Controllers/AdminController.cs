using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedTech.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Users()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult CreateUser()
        {
            return View();
        }        
        [Authorize(Roles="Admin")]
        public ActionResult TextResources()
        {
            return View();        
        }
        [Authorize(Roles = "Admin")]
        public ActionResult EditCompanyInfo()
        {
            return View();
        }        
	}
}