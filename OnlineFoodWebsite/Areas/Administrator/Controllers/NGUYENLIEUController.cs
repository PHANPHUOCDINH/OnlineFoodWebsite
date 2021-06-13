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
    public class NGUYENLIEUController : Controller
    {
        private FoodOnlineWebsiteDbContext db = new FoodOnlineWebsiteDbContext();

        // GET: Administrator/NGUYENLIEU
        public ActionResult Index()
        {
            return View(db.NGUYENLIEUx.ToList());
        }

        // GET: Administrator/NGUYENLIEU/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUYENLIEU nGUYENLIEU = db.NGUYENLIEUx.Find(id);
            if (nGUYENLIEU == null)
            {
                return HttpNotFound();
            }
            return View(nGUYENLIEU);
        }

        // GET: Administrator/NGUYENLIEU/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/NGUYENLIEU/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MANL,TENNL,MOTA,TINHTRANG")] NGUYENLIEU nGUYENLIEU)
        {
            if (ModelState.IsValid)
            {
                db.NGUYENLIEUx.Add(nGUYENLIEU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nGUYENLIEU);
        }

        // GET: Administrator/NGUYENLIEU/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUYENLIEU nGUYENLIEU = db.NGUYENLIEUx.Find(id);
            if (nGUYENLIEU == null)
            {
                return HttpNotFound();
            }
            return View(nGUYENLIEU);
        }

        // POST: Administrator/NGUYENLIEU/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MANL,TENNL,MOTA,TINHTRANG")] NGUYENLIEU nGUYENLIEU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nGUYENLIEU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nGUYENLIEU);
        }

        // GET: Administrator/NGUYENLIEU/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUYENLIEU nGUYENLIEU = db.NGUYENLIEUx.Find(id);
            if (nGUYENLIEU == null)
            {
                return HttpNotFound();
            }
            return View(nGUYENLIEU);
        }

        // POST: Administrator/NGUYENLIEU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NGUYENLIEU nGUYENLIEU = db.NGUYENLIEUx.Find(id);
            db.NGUYENLIEUx.Remove(nGUYENLIEU);
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
