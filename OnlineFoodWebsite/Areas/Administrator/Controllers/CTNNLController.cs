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
        private OnlineFoodWebsiteDbContext db = new OnlineFoodWebsiteDbContext();
        private static Random random = new Random();
        // GET: Administrator/CTNNL
        public ActionResult Index()
        {
            return View(db.NGUYENLIEUx.ToList());
        }

        // GET: Administrator/CTNNL/Details/5
        public ActionResult Details(string id)
        {
            NGUYENLIEU nl = db.NGUYENLIEUx.Find(id);
            ViewBag.TENNL = nl.TENNL;
            return View(db.CTNNLs.Where(x=>x.MANL==id).ToList());
        }

        // GET: Administrator/CTNNL/Create
        public ActionResult Create(string id)
        {
            NGUYENLIEU nl = db.NGUYENLIEUx.Find(id);
            ViewBag.TENNL = nl.TENNL;
            return View();
        }

        // POST: Administrator/CTNNL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string id,[Bind(Include = "SOLUONG,DONVITINH,CHIPHI,GHICHU")] CTNNL cTNNL)
        {
            if (ModelState.IsValid)
            {
               
                cTNNL.MACTN = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
                cTNNL.MANL = id;
                cTNNL.NGAYNHAP = DateTime.Now;
                db.CTNNLs.Add(cTNNL);
                var nl = db.NGUYENLIEUx.SingleOrDefault(b => b.MANL == id);
                nl.LASTUPDATE = cTNNL.NGAYNHAP;
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
            NGUYENLIEU nl = db.NGUYENLIEUx.Find(id);
            if (nl == null)
            {
                return HttpNotFound();
            }
            return View(nl);
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

     
        public ActionResult TaoMoiNL(string id)
        {
            //NGUYENLIEU nl = db.NGUYENLIEUx.Find(id);
            //ViewBag.TENNL = nl.TENNL;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoMoiNL([Bind(Include = "TENNL,MOTA")] NGUYENLIEU nl, HttpPostedFileBase file)
        {

            if (file != null)
            {

                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Areas/Administrator/Content/images/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);

                if (ModelState.IsValid)
                {
                    string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    nl.MANL = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
                    nl.HINHANH = ImageName;
                    
                    db.NGUYENLIEUx.Add(nl);
                   
                        db.SaveChanges();
                   
                    return RedirectToAction("Index");

                }

            }

           
            return View();
        }

    }
}
