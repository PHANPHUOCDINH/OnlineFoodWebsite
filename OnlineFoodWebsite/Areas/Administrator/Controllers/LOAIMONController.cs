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
    public class LOAIMONController : Controller
    {
        private FoodOnlineWebsiteDbContext db = new FoodOnlineWebsiteDbContext();

        // GET: Administrator/LOAIMON
        public ActionResult Index()
        {
            return View(db.LOAIMONs.ToList());
        }

        // GET: Administrator/LOAIMON/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIMON lOAIMON = db.LOAIMONs.Find(id);
            if (lOAIMON == null)
            {
                return HttpNotFound();
            }
            return View(lOAIMON);
        }

        // GET: Administrator/LOAIMON/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/LOAIMON/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MALOAI,TENLOAI")] LOAIMON lOAIMON)
        {
            if (ModelState.IsValid)
            {
                db.LOAIMONs.Add(lOAIMON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAIMON);
        }

        // GET: Administrator/LOAIMON/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIMON lOAIMON = db.LOAIMONs.Find(id);
            if (lOAIMON == null)
            {
                return HttpNotFound();
            }
            return View(lOAIMON);
        }

        // POST: Administrator/LOAIMON/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MALOAI,TENLOAI")] LOAIMON lOAIMON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAIMON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAIMON);
        }

        // GET: Administrator/LOAIMON/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIMON lOAIMON = db.LOAIMONs.Find(id);
            if (lOAIMON == null)
            {
                return HttpNotFound();
            }
            return View(lOAIMON);
        }

        // POST: Administrator/LOAIMON/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LOAIMON lOAIMON = db.LOAIMONs.Find(id);
            db.LOAIMONs.Remove(lOAIMON);
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
