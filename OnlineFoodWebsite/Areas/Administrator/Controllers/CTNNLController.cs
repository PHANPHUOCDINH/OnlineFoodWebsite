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
    public class CTNNLController : Controller
    {
        private FoodOnlineWebsiteDbContext db = new FoodOnlineWebsiteDbContext();

        // GET: Administrator/CTNNL
        public ActionResult Index()
        {
            return View(db.CTNNLs.ToList());
        }

        // GET: Administrator/CTNNL/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTNNL cTNNL = db.CTNNLs.Find(id);
            if (cTNNL == null)
            {
                return HttpNotFound();
            }
            return View(cTNNL);
        }

        // GET: Administrator/CTNNL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/CTNNL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MACTN,MANL,SOLUONG,DONVI,NGAYNHAP")] CTNNL cTNNL)
        {
            if (ModelState.IsValid)
            {
                db.CTNNLs.Add(cTNNL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cTNNL);
        }

        // GET: Administrator/CTNNL/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTNNL cTNNL = db.CTNNLs.Find(id);
            if (cTNNL == null)
            {
                return HttpNotFound();
            }
            return View(cTNNL);
        }

        // POST: Administrator/CTNNL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MACTN,MANL,SOLUONG,DONVI,NGAYNHAP")] CTNNL cTNNL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTNNL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cTNNL);
        }

        // GET: Administrator/CTNNL/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTNNL cTNNL = db.CTNNLs.Find(id);
            if (cTNNL == null)
            {
                return HttpNotFound();
            }
            return View(cTNNL);
        }

        // POST: Administrator/CTNNL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CTNNL cTNNL = db.CTNNLs.Find(id);
            db.CTNNLs.Remove(cTNNL);
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
