using MedTech.Application.Services.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedTech.Web.Controllers
{
    public class HomeController : Controller
    {
              
        public ActionResult Index()
        {            
            return View();
        }
        
        public ActionResult CompanyInfo()
        {
            return View();
        }
	}
}