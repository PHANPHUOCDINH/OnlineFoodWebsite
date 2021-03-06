using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineFoodWebsite.Model;

namespace OnlineFoodWebsite.Areas.Administrator.Controllers
{
    public class MONController : Controller
    {
        private static readonly DateTime Jan1st1970 = new DateTime
    (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        
        private OnlineFoodWebsiteDbContext db = new OnlineFoodWebsiteDbContext();

        // GET: Administrator/MON
        public ActionResult Index()
        {
            if (TempData["result"] != null)
            {
                ViewBag.Message = TempData["result"].ToString();
            }
            if (TempData["result1"] != null)
            {
                ViewBag.Message1 = TempData["result1"].ToString();
            }
            if (TempData["result2"] != null)
            {
                ViewBag.Message2 = TempData["result2"].ToString();
            }
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
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Text = "Hết hàng",
                Value = "Hết hàng"
            });
            list.Add(new SelectListItem()
            {
                Text = "Còn hàng",
                Value = "Còn hàng"
            });
            ViewBag.ListTT = new SelectList(list, "Value", "Text");
            ViewBag.MALOAI = new SelectList(db.LOAIMONs, "MALOAI", "TENLOAI");
            return View();
        }

        // POST: Administrator/MON/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAMON,TENMON,MOTA,GIA,TINHTRANG,MALOAI,DONVITINH")] MON mON,HttpPostedFileBase file)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Text = "Hết hàng",
                Value = "Hết hàng"
            });
            list.Add(new SelectListItem()
            {
                Text = "Còn hàng",
                Value = "Còn hàng"
            });
            ViewBag.ListTT = new SelectList(list, "Value", "Text");
            if (file != null)
            {
               
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Areas/Administrator/Content/images/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);

                if (ModelState.IsValid)
                {
                    string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    mON.MAMON = CurrentTimeMillis().ToString();
                    mON.HINHANH = ImageName;
                    mON.SOLUONGBAN = 0;
                    db.MONs.Add(mON);
                    db.SaveChanges();
                    TempData["result"] = "Tao moi thanh cong!";
                    return RedirectToAction("Index");
                    
                }
                ViewBag.MALOAI = new SelectList(db.LOAIMONs, "MALOAI", "TENLOAI");
                return View(mON);
            }
            else
            {
                
                ViewBag.MALOAI = new SelectList(db.LOAIMONs, "MALOAI", "TENLOAI");
                return View(mON);
            }
            
        }

        // GET: Administrator/MON/Edit/5
        public ActionResult Edit(string id)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Text = "Hết hàng",
                Value = "Hết hàng"
            });
            list.Add(new SelectListItem()
            {
                Text = "Còn hàng",
                Value = "Còn hàng"
            });
            ViewBag.ListTT = new SelectList(list, "Value", "Text");
            ViewBag.MALOAI = new SelectList(db.LOAIMONs, "MALOAI", "TENLOAI");
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
        public ActionResult Edit(string id,[Bind(Include = "TENMON,MOTA,GIA,TINHTRANG,MALOAI,DONVITINH")] MON mON, HttpPostedFileBase file)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Text = "Hết hàng",
                Value = "Hết hàng"
            });
            list.Add(new SelectListItem()
            {
                Text = "Còn hàng",
                Value = "Còn hàng"
            });
            ViewBag.ListTT = new SelectList(list, "Value", "Text");
            MON mon = db.MONs.Find(id);
            if (file != null)
            {

                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Areas/Administrator/Content/images/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);
                if (ModelState.IsValid)
                {
                    mon.TENMON = mON.TENMON;
                    mon.MALOAI = mON.MALOAI;
                    mon.GIA = mON.GIA;
                    mon.DONVITINH = mON.DONVITINH;
                    mon.TINHTRANG = mON.TINHTRANG;
                    mon.MOTA = mON.MOTA;

                    mon.HINHANH = ImageName;
                    db.Entry(mon).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["result1"] = "Cap nhat thanh cong!";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    mon.TENMON = mON.TENMON;
                    mon.MALOAI = mON.MALOAI;
                    mon.GIA = mON.GIA;
                    mon.DONVITINH = mON.DONVITINH;
                    mon.TINHTRANG = mON.TINHTRANG;
                    mon.MOTA = mON.MOTA;
                    db.Entry(mon).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["result1"] = "Cap nhat thanh cong!";
                    return RedirectToAction("Index");
                }
            }
            ViewBag.MALOAI = new SelectList(db.LOAIMONs, "MALOAI", "TENLOAI");
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
            TempData["result2"] = "Xoa thanh cong!";
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
       

        public static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }
    }
   
   
}
