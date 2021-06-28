using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using OnlineFoodWebsite.Model;
namespace OnlineFoodWebsite.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        OnlineFoodWebsiteDbContext db = new OnlineFoodWebsiteDbContext();
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

        [HttpGet]
        public ActionResult Logout()
        {
            Session["userid"] = null;
            Session["username"] = null;
            Session["avatar"] = null;
            Session["role"] = null;
            return View("Index");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            NHANVIEN user = db.NHANVIENs.SingleOrDefault(x => x.TAIKHOAN == username && x.MATKHAU == password);
            if (user != null)
            {
                NHANVIEN nv = db.NHANVIENs.SingleOrDefault(x => x.TAIKHOAN == username && x.MATKHAU == password);
                Session["userid"] = nv.MANV;
                Session["username"] = nv.TENNV;
                Session["avatar"] = nv.HINHANH;
                Session["role"] = nv.CHUCVU;
                nv.LASTACTIVE = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.error = "Sai tên đăng nhập hoặc mật khẩu!";
            return View();
        }

        public static string CalculateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        
    }
}