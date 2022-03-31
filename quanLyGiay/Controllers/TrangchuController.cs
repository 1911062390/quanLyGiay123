using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quanLyGiay.Models;
namespace quanLyGiay.Controllers
{
    public class TrangchuController : Controller
    {
        private Model1 db = new Model1();
        // GET: Trangchu
        public ActionResult Index()
        {
            ViewBag.SoMauTin = db.Products.Count();
            return View();
        }

        public ActionResult DangNhap()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendangNhap = collection["Username"];
            var matkhau = collection["Password"];
            User nv = db.Users.SingleOrDefault(n => n.Username == tendangNhap && n.Password == matkhau);
            if (nv != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
                return RedirectToAction("Index", "Trangchu");
        }
    }
}