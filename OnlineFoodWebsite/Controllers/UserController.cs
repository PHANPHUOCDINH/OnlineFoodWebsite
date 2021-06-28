using OnlineFoodWebsite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodWebsite.Controllers
{
    public class UserController : Controller
    {
        private static Random random = new Random();
        OnlineFoodWebsiteDbContext db = new OnlineFoodWebsiteDbContext();
        // GET: User
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
        public ActionResult Login(KHACHHANG kh)
        {
            if(ModelState.IsValid)
            {
                string hashpw = CalculateMD5Hash(kh.MATKHAU);
                if(db.KHACHHANGs.Count(x => x.TAIKHOAN == kh.TAIKHOAN && x.MATKHAU == hashpw) > 0)
                {
                    KHACHHANG k = db.KHACHHANGs.SingleOrDefault(x => x.TAIKHOAN == kh.TAIKHOAN && x.MATKHAU == hashpw);
                    Session["cusname"] = k.TENKH;
                    Session["cusid"] = k.MAKH;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kiểm tra lại tài khoản, mật khẩu");
                }
            }
            else
            {

            }
            return View(kh);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Register(KHACHHANG kh)
        {
            if(ModelState.IsValid)
            {
                if(checkUserName(kh.TAIKHOAN))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    kh.MAKH = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
                    kh.MATKHAU = CalculateMD5Hash(kh.MATKHAU);
                    db.KHACHHANGs.Add(kh);
                    if(db.SaveChanges()>0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                    }
                    else
                    {
                        
                    }
                }
            }
            return View();
        }

        private bool checkUserName(string username)
        {
            return db.KHACHHANGs.Count(x=>x.TAIKHOAN==username)>0;
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
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
        [HttpGet]
        public ActionResult Logout()
        {
            Session["cusid"] = null;
            Session["cusname"] = null;
            return RedirectToAction("Index","Home");
        }

        public ActionResult MyOrders()
        {
            string makh = Session["cusid"].ToString();
            return View(db.HOADONs.Where(x=>x.MAKH==makh).ToList());
        }

        [HttpGet]
        public ActionResult MyOrderDetail(string id)
        {
           
            return View(db.CTHDs.Where(x => x.MAHD == id).ToList());
        }
        [HttpGet]
        public ActionResult DeleteOrder(string id)
        {
            var all = db.CTHDs.Where(x => x.MAHD == id);
            var hd = db.HOADONs.Find(id);
            db.CTHDs.RemoveRange(all);
            db.HOADONs.Remove(hd);
            db.SaveChanges();
            return RedirectToAction("MyOrders", "User");
        }
    }
}