using OnlineFoodWebsite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodWebsite.Areas.Administrator.Controllers
{
    public class ARTICLEController : Controller
    {
        private static readonly DateTime Jan1st1970 = new DateTime
    (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private OnlineFoodWebsiteDbContext db = new OnlineFoodWebsiteDbContext();
        // GET: Administrator/ARTICLE
        public ActionResult Index()
        {
            return View(db.ARTICLEs.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ARTICLE art)
        {
            art.ArticleId= CurrentTimeMillis().ToString();
            art.ArticleDate = DateTime.Now;
            db.ARTICLEs.Add(art);
            db.SaveChanges();
            return RedirectToAction("Index","ARTICLE");
        }

        public static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }
    }
}