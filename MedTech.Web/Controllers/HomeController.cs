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
        //
        // GET: /Home/       
        public ActionResult Index()
        {            
            return View();
        }        
	}
}