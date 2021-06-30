using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineFoodWebsite.Model;

namespace OnlineFoodWebsite.Areas.Administrator.Controllers
{
    public class HOADONsController : Controller
    {
        private OnlineFoodWebsiteDbContext db = new OnlineFoodWebsiteDbContext();

        // GET: Administrator/HOADONs
        public ActionResult Index()
        {
            if (TempData["result3"] != null)
            {
                ViewBag.Message3 = TempData["result3"].ToString();
            }
            return View(db.HOADONs.ToList());
        }

        // GET: Administrator/HOADONs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            return View(db.CTHDs.Where(x=>x.MAHD==id).ToList());
        }

        // GET: Administrator/HOADONs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/HOADONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAHD,MAKH,NGAYLAP,THANHTIEN,GIAMGIA,GHICHU,TRANGTHAI")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                db.HOADONs.Add(hOADON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hOADON);
        }

        // GET: Administrator/HOADONs/Edit/5
        public ActionResult Edit(string id)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Text = "Confirming",
                Value = "Confirming"
            });
            list.Add(new SelectListItem()
            {
                Text = "Confirmed",
                Value = "Confirmed"
            });
            list.Add(new SelectListItem()
            {
                Text = "Cooking",
                Value = "Cooking"
            });
            list.Add(new SelectListItem()
            {
                Text = "Packaged",
                Value = "Packaged"
            });
            list.Add(new SelectListItem()
            {
                Text = "Delivering",
                Value = "Delivering"
            });
            list.Add(new SelectListItem()
            {
                Text = "Finished",
                Value = "Finished"
            });
            ViewBag.ListTT = new SelectList(list, "Value", "Text");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // POST: Administrator/HOADONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id,[Bind(Include = "TRANGTHAI,GHICHU")] HOADON hOADON)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Text = "Confirming",
                Value = "Confirming"
            });
            list.Add(new SelectListItem()
            {
                Text = "Confirmed",
                Value = "Confirmed"
            });
            list.Add(new SelectListItem()
            {
                Text = "Cooking",
                Value = "Cooking"
            });
            list.Add(new SelectListItem()
            {
                Text = "Packaged",
                Value = "Packaged"
            });
            list.Add(new SelectListItem()
            {
                Text = "Delivering",
                Value = "Delivering"
            });
            list.Add(new SelectListItem()
            {
                Text = "Finished",
                Value = "Finished"
            });
            ViewBag.ListTT = new SelectList(list, "Value", "Text");
            HOADON hoadon = db.HOADONs.Find(id);
            if (ModelState.IsValid)
            {
                hoadon.GHICHU = hOADON.GHICHU;
                hoadon.TRANGTHAI = hOADON.TRANGTHAI;
                hoadon.NVPHUTRACH = Session["username"].ToString();
                db.Entry(hoadon).State = EntityState.Modified;
                db.SaveChanges();
                TempData["result3"] = "Cap nhat thanh cong trang thai don hang "+id+"!";
                return RedirectToAction("Index");
            }
            return View(hOADON);
        }

        // GET: Administrator/HOADONs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // POST: Administrator/HOADONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOADON hOADON = db.HOADONs.Find(id);
            db.HOADONs.Remove(hOADON);
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
    }
}
