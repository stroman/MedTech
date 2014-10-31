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
        public ActionResult Users()
        {
            return View();
        }

        public ActionResult TextResources()
        {
            return View();
        }
	}
}