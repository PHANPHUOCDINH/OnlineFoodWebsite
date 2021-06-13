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
    public class MONController : Controller
    {
        private FoodOnlineWebsiteDbContext db = new FoodOnlineWebsiteDbContext();

        // GET: Administrator/MON
        public ActionResult Index()
        {
            return View(db.MONs.ToList());
        }

        // GET: Administrator/MON/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MON mON = db.MONs.Find(id);
            if (mON == null)
            {
                return HttpNotFound();
            }
            return View(mON);
        }

        // GET: Administrator/MON/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/MON/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAMON,TENMON,MOTA,GIA,TINHTRANG,LOAIMON")] MON mON)
        {
            if (ModelState.IsValid)
            {
                db.MONs.Add(mON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mON);
        }

        // GET: Administrator/MON/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MON mON = db.MONs.Find(id);
            if (mON == null)
            {
                return HttpNotFound();
            }
            return View(mON);
        }

        // POST: Administrator/MON/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAMON,TENMON,MOTA,GIA,TINHTRANG,LOAIMON")] MON mON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mON);
        }

        // GET: Administrator/MON/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MON mON = db.MONs.Find(id);
            if (mON == null)
            {
                return HttpNotFound();
            }
            return View(mON);
        }

        // POST: Administrator/MON/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MON mON = db.MONs.Find(id);
            db.MONs.Remove(mON);
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
