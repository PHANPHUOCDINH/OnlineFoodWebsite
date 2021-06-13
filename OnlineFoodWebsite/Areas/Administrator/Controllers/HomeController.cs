using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFoodWebsite.Model;
namespace OnlineFoodWebsite.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        FoodOnlineWebsiteDbContext db = new FoodOnlineWebsiteDbContext();
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
            TAIKHOAN user = db.TAIKHOANs.SingleOrDefault(x => x.TENTK == username && x.MK == password);
            if(user!=null)
            {
                NHANVIEN nv = db.NHANVIENs.SingleOrDefault(x => x.TENTK == user.TENTK);
                Session["UserId"] = nv.MANV;
                Session["UserName"] = nv.HOTEN;
                return RedirectToAction("Index");
            }
            ViewBag.error = "Sai username,password!";
            return View();
        }
    }
}