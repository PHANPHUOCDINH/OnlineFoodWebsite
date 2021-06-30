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
    public class NHANVIENController : Controller
    {
        private OnlineFoodWebsiteDbContext db = new OnlineFoodWebsiteDbContext();
        private static Random random = new Random();
        // GET: Administrator/NHANVIENsontroller
        public ActionResult Index()
        {
            if (TempData["result5"] != null)
            {
                ViewBag.Message5 = TempData["result5"].ToString();
            }
            if (TempData["result6"] != null)
            {
                ViewBag.Message6 = TempData["result6"].ToString();
            }
            if (TempData["result7"] != null)
            {
                ViewBag.Message7 = TempData["result7"].ToString();
            }
            return View(db.NHANVIENs.ToList());
        }

        // GET: Administrator/NHANVIENsontroller/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // GET: Administrator/NHANVIENsontroller/Create
        public ActionResult Create()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Text = "Quản lý",
                Value="Quản lý"
            }) ;
            list.Add(new SelectListItem()
            {
                Text = "Nhân viên bếp",
                Value = "Nhân viên bếp"
            });
            list.Add(new SelectListItem()
            {
                Text = "Nhân viên kho",
                Value = "Nhân viên kho"
            });
            list.Add(new SelectListItem()
            {
                Text = "Nhân viên đơn hàng",
                Value = "Nhân viên đơn hàng"
            });
            ViewBag.ListChucVu = new SelectList(list, "Value", "Text");
            return View();
        }

        // POST: Administrator/NHANVIENsontroller/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TENNV,NGAYSINH,SDT,CHUCVU,TAIKHOAN,MATKHAU")] NHANVIEN nHANVIEN, HttpPostedFileBase file)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Text = "Quản lý",
                Value = "Quản lý"
            });
            list.Add(new SelectListItem()
            {
                Text = "Nhân viên bếp",
                Value = "Nhân viên bếp"
            });
            list.Add(new SelectListItem()
            {
                Text = "Nhân viên kho",
                Value = "Nhân viên kho"
            });
            list.Add(new SelectListItem()
            {
                Text = "Nhân viên đơn hàng",
                Value = "Nhân viên đơn hàng"
            });
            ViewBag.ListChucVu = new SelectList(list, "Value", "Text");
            if (file != null)
            {

                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Areas/Administrator/Content/images/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);

                if (ModelState.IsValid)
                {
                    string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    nHANVIEN.MANV = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
                    nHANVIEN.HINHANH = ImageName;
                    db.NHANVIENs.Add(nHANVIEN);
                    db.SaveChanges();
                    TempData["result5"] = "Them moi nhan vien thanh cong!";
                    return RedirectToAction("Index");

                }

            }

            
            return View();
        }

        // GET: Administrator/NHANVIENsontroller/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: Administrator/NHANVIENsontroller/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id,[Bind(Include = "TENNV,TAIKHOAN,NGAYSINH,SDT,MATKHAU,CHUCVU")] NHANVIEN nHANVIEN, HttpPostedFileBase file)
        {
            NHANVIEN nv = db.NHANVIENs.Find(id);
            if (file != null)
            {

                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Areas/Administrator/Content/images/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);
                if (ModelState.IsValid)
                {
                    nv.TENNV = nHANVIEN.TENNV;
                    nv.TAIKHOAN = nHANVIEN.TAIKHOAN;
                    nv.MATKHAU = nHANVIEN.MATKHAU;
                    nv.NGAYSINH = nHANVIEN.NGAYSINH;
                    nv.SDT = nHANVIEN.SDT;
                    nv.CHUCVU = nHANVIEN.CHUCVU;
                    nv.HINHANH = ImageName;
                    db.Entry(nv).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["result6"] = "Cap nhat thanh cong nhan vien!";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    nv.TENNV = nHANVIEN.TENNV;
                    nv.TAIKHOAN = nHANVIEN.TAIKHOAN;
                    nv.MATKHAU = nHANVIEN.MATKHAU;
                    nv.NGAYSINH = nHANVIEN.NGAYSINH;
                    nv.SDT = nHANVIEN.SDT;
                    nv.CHUCVU = nHANVIEN.CHUCVU;
                    db.Entry(nv).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["result6"] = "Cap nhat thanh cong nhan vien!";
                    return RedirectToAction("Index");
                }
            }
           
            return View(nv);
        }

        // GET: Administrator/NHANVIENsontroller/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: Administrator/NHANVIENsontroller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(nHANVIEN);
            db.SaveChanges();
            TempData["result7"] = "Xoa nhan vien thanh cong!";
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
