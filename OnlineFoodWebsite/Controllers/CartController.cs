using Newtonsoft.Json;
using OnlineFoodWebsite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodWebsite.Controllers
{
    public class CartController : Controller
    {
        private static Random random = new Random();
        OnlineFoodWebsiteDbContext db = new OnlineFoodWebsiteDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session["cart"];
            var list = new List<CTHD>();
            if(cart!=null)
            {
                list = (List<CTHD>)cart;
            }
            return View(list);
        }

        public ActionResult AddItem(string idMon, int soluong)
        {

            var product = db.MONs.Find(idMon);
            var cart = Session["cart"];
            if(cart!=null)
            {
                var list=(List<CTHD>)cart;
                if(list.Exists(x=>x.MAMON==idMon))
                {
                    foreach (var item in list)
                    {
                        if (item.MAMON == idMon)
                        {
                            item.SOLUONG += soluong;
                        }
                    }

                }
                else
                {
                    var item = new CTHD();
                    item.MON = product;
                    item.MAMON = idMon;
                    item.SOLUONG = soluong;
                    list.Add(item);

                }
                Session["cart"] = list;
            }
            else
            {
                var item = new CTHD();
                item.MAMON = idMon;
                item.MON = product;
                item.SOLUONG = soluong;
                var list = new List<CTHD>();
                list.Add(item);
                Session["cart"] = list; 
            }
            return RedirectToAction("Index");
        }

        public JsonResult Update(string cartModel1,string cartModel2)
        {
            var jsonCart1 = JsonConvert.DeserializeObject<List<CTHD>>(cartModel1);
            var jsonCart2 = JsonConvert.DeserializeObject<List<CTHD>>(cartModel2);
            var sessionCart = (List<CTHD>)Session["cart"];
            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart1.SingleOrDefault(x => x.MAMON == item.MAMON);
                if (jsonItem != null)
                {
                    item.SOLUONG = jsonItem.SOLUONG;
                
                }
                   
            }
            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart2.SingleOrDefault(x => x.MAMON == item.MAMON);
                if (jsonItem != null)
                {
                   
                    item.GHICHU = jsonItem.GHICHU;
                }

            }
            Session["cart"] = sessionCart;
            return Json(new
            {
                status = true
            });

        }

        public JsonResult DeleteAll()
        {
            Session["cart"] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(string id)
        {
            var sessionCart = (List<CTHD>)Session["cart"];
            sessionCart.RemoveAll(x => x.MAMON == id);
            Session["cart"] = sessionCart;
            return Json(new
            {
                status = true
            });
        }


        public ActionResult Confirm()
        {
            var list = (List<CTHD>)Session["cart"];
            int money = 0;
            int num = 0;
            
            foreach(var item in list)
            {
                money += (int)item.MON.GIA * (int)item.SOLUONG;
                num += (int)item.SOLUONG;
            }
            Session["money"] = money;
            ViewBag.TongMon = num;
            ViewBag.TongTien = money;
            return View(db.KHACHHANGs.Find(Session["cusid"]));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirm(FormCollection form)
        {
            string ghichu = form["ghichu"];
            HOADON hoadon = new HOADON();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            hoadon.MAHD = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            hoadon.MAKH = (string)Session["cusid"];
            hoadon.NGAYLAP = DateTime.Now;
            hoadon.TRANGTHAI = "Confirming";
            hoadon.GHICHUKHACH = ghichu;
            hoadon.TONGTIEN = (int)Session["money"];
            
            db.HOADONs.Add(hoadon);
            var list = (List<CTHD>)Session["cart"];
            int i = 0;
            foreach(var item in list)
            {
                
                CTHD cthd = new CTHD();
                //  Random random1 = new Random();
                //  cthd.MACTHD= new string(Enumerable.Repeat(chars, 8)
                //.Select(s => s[random1.Next(s.Length)]).ToArray());
                cthd.MACTHD = (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()+i).ToString();
                cthd.MAHD = hoadon.MAHD;
                cthd.GHICHU = item.GHICHU;
                cthd.MAMON = item.MAMON;
                cthd.SOLUONG = item.SOLUONG;
                i++;
                db.CTHDs.Add(cthd);

            }
            db.SaveChanges();
            Session["money"] = null;
            Session["cart"] = null;
            //HOADON hoadon = db.HOADONs.Find(id);
            //if (ModelState.IsValid)
            //{

            //    hoadon.TRANGTHAI = hOADON.TRANGTHAI;
            //    db.Entry(hoadon).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            return RedirectToAction("Index");
        }
    }
}