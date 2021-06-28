using OnlineFoodWebsite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodWebsite.Areas.Administrator.Controllers
{
    public class ThongKeController : Controller
    {
        OnlineFoodWebsiteDbContext db = new OnlineFoodWebsiteDbContext();
        // GET: Administrator/ThongKe
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ThongKeMonAn()
        {
            //if (month != null && year != null)
            //    return RedirectToAction("ThongKeMonAn", "ThongKe", new { month=month,year=year });
            //else
                return View();
        }
        [HttpPost]
        public ActionResult ThongKeMonAn(string month,string year)
        {
            int m = Convert.ToInt32(month);
            int y = Convert.ToInt32(year);
            ViewBag.thang = m;
            ViewBag.nam = y;
            var listMon = db.MONs.ToList();
            foreach(var item in listMon)
            {
                var listTuongUng = db.CTHDs.Where(x => x.HOADON.NGAYLAP.Value.Month == m && x.HOADON.NGAYLAP.Value.Year == y && x.HOADON.TRANGTHAI == "Finished" && x.MAMON == item.MAMON).ToList();
                if (listTuongUng.Count > 0)
                    item.temp = (int)listTuongUng.Sum(x => x.SOLUONG);
                else
                    item.temp = 0;
            }
            return View(listMon);
        }
        [HttpGet]
        public ActionResult ThongKeChiNguyenLieu()
        {
            //if (month != null && year != null)
            //    return RedirectToAction("ThongKeMonAn", "ThongKe", new { month=month,year=year });
            //else
            return View();
        }
        [HttpPost]
        public ActionResult ThongKeChiNguyenLieu(string month, string year)
        {
            int m = Convert.ToInt32(month);
            int y = Convert.ToInt32(year);
            ViewBag.thang = m;
            ViewBag.nam = y;
            var listNL = db.NGUYENLIEUx.ToList();
            foreach (var item in listNL)
            {
                var listTuongUng = db.CTNNLs.Where(x => x.NGAYNHAP.Value.Month == m && x.NGAYNHAP.Value.Year == y).ToList();
                if (listTuongUng.Count > 0)
                    item.temp = (int)listTuongUng.Sum(x => x.CHIPHI);
                else
                    item.temp = 0;
            }
            return View(listNL);
        }
        //[HttpGet]
        //public ActionResult ThongKeDoanhThu()
        //{
        //    //if (month != null && year != null)
        //    //    return RedirectToAction("ThongKeMonAn", "ThongKe", new { month=month,year=year });
        //    //else
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult ThongKeDoanhThu(string month, string year)
        //{
        //    int m = Convert.ToInt32(month);
        //    int y = Convert.ToInt32(year);
        //    ViewBag.thang = m;
        //    ViewBag.nam = y;
        //    var listHD = db.MONs.ToList();
        //    foreach (var item in listMon)
        //    {
        //        var listTuongUng = db.CTHDs.Where(x => x.HOADON.NGAYLAP.Value.Month == m && x.HOADON.NGAYLAP.Value.Year == y && x.HOADON.TRANGTHAI == "Finished" && x.MAMON == item.MAMON).ToList();
        //        if (listTuongUng.Count > 0)
        //            item.temp = (int)listTuongUng.Sum(x => x.SOLUONG);
        //        else
        //            item.temp = 0;
        //    }
        //    return View(listMon);
        //}
    }
}