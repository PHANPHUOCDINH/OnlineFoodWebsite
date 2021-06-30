using OnlineFoodWebsite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodWebsite.Controllers
{
    public class HomeController : Controller
    {
        OnlineFoodWebsiteDbContext db = new OnlineFoodWebsiteDbContext();
        public ActionResult Index()
        {
            if (TempData["result8"] != null)
            {
                ViewBag.Message8 = TempData["result8"].ToString();
            }
            ViewBag.MonBanChay = db.MONs.OrderBy(r => Guid.NewGuid()).Take(4).ToList();
            return View();
        }
        public ActionResult SanPhamBanChay()
        {
            ViewBag.MonBanChay = db.MONs.OrderBy(r => Guid.NewGuid()).Take(4).ToList();
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Detail(string id)
        {
            MON mon = db.MONs.SingleOrDefault(x => x.MAMON == id);
            if (mon == null)
                return HttpNotFound();
            return View(mon);
        }

        public ActionResult Menu()
        {
            var listLoaiMon = db.LOAIMONs.ToList();
            
            ViewBag.DanhMuc = listLoaiMon;
          
            return View();
        }
        [HttpGet]
        public ActionResult MenuBy(string id)
        {
            var listLoaiMon = db.LOAIMONs.ToList();
            ViewBag.DanhMuc = listLoaiMon;
            if (id == null)
                return HttpNotFound();
            else
            {
                LOAIMON loaimon = db.LOAIMONs.SingleOrDefault(x=>x.MALOAI==id);
                ViewBag.TenLoai = loaimon.TENLOAI;
                return View(db.MONs.Where(x=>x.MALOAI==id).ToList());
            }
            
        }

        [HttpPost]
        public ActionResult Search(string product)
        {
            return RedirectToAction("SearchResult", "Home", new { name=product});
        }
        [HttpGet]
        public ActionResult SearchResult(string name)
        {
            var listLoaiMon = db.LOAIMONs.ToList();
            ViewBag.DanhMuc = listLoaiMon;
            var listMon = db.MONs.Where(x => x.TENMON.Contains(name)).ToList();
            return View(listMon);
        }
    }
}