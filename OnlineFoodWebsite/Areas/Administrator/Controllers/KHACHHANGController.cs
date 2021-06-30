using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using OnlineFoodWebsite.Model;

namespace OnlineFoodWebsite.Areas.Administrator.Controllers
{
    public class KHACHHANGController : Controller
    {
        private OnlineFoodWebsiteDbContext db = new OnlineFoodWebsiteDbContext();

        // GET: Administrator/KHACHHANG
        public ActionResult Index()
        {
            if (TempData["result15"] != null)
            {
                ViewBag.Message15 = TempData["result15"].ToString();
            }
            return View(db.KHACHHANGs.ToList());
        }

        // GET: Administrator/KHACHHANG/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.MAKH = id;
            return View(db.HOADONs.Where(x=>x.MAKH==id).ToList());
        }

        // GET: Administrator/KHACHHANG/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/KHACHHANG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAKH,TENTK,HOTEN,NGAYSINH,DIACHI,GIOITINH,SDT")] KHACHHANG kHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.KHACHHANGs.Add(kHACHHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kHACHHANG);
        }

        // GET: Administrator/KHACHHANG/Edit/5
        public ActionResult Edit(string id)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Text = "Nam",
                Value = "Nam"
            });
            list.Add(new SelectListItem()
            {
                Text = "Nữ",
                Value = "Nữ"
            });

            ViewBag.ListSex = new SelectList(list, "Value", "Text");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // POST: Administrator/KHACHHANG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id,[Bind(Include = "TENKH,NGAYSINH,DIACHI,GIOITINH,SDT,EMAIL,MATKHAU")] KHACHHANG kHACHHANG)
        {
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(x => x.MAKH==id);
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Text = "Nam",
                Value = "Nam"
            });
            list.Add(new SelectListItem()
            {
                Text = "Nữ",
                Value = "Nữ"
            });

            ViewBag.ListSex = new SelectList(list, "Value", "Text");
            if (ModelState.IsValid)
            {
                kh.MATKHAU = CalculateMD5Hash(kHACHHANG.MATKHAU);
                kh.TENKH = kHACHHANG.TENKH;
                kh.NGAYSINH = kHACHHANG.NGAYSINH;
                kh.DIACHI = kHACHHANG.DIACHI;
                kh.GIOITINH = kHACHHANG.GIOITINH;
                kh.SDT = kHACHHANG.SDT;
                kh.EMAIL = kHACHHANG.EMAIL;
                db.SaveChanges();
                TempData["result15"] = "Cap nhat thong tin thanh cong!";
                
                return RedirectToAction("Index");
                
            }
            return View(kHACHHANG);
        }

        // GET: Administrator/KHACHHANG/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // POST: Administrator/KHACHHANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            db.KHACHHANGs.Remove(kHACHHANG);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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
