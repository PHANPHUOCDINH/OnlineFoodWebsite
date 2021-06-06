using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodWebsite.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Administrator/Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            return View();
        }
    }
}