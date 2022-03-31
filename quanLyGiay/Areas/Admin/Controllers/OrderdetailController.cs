using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using quanLyGiay.Models;

namespace quanLyGiay.Areas.Admin.Controllers
{
    public class OrderdetailController : Controller
    {
        private Model1 db = new Model1();

        // GET: Admin/Orderdetail
        public ActionResult Index()
        {
            var list = db.Orderdetails.Where(p => p.Status!=0).ToList();
            return View(list);
        }

        public ActionResult Trash()
        {
            var list = db.Orderdetails.Where(p => p.Status == 0).ToList();
            return View("Trash", list);
        }

        // GET: Admin/Orderdetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderdetail orderdetail = db.Orderdetails.Find(id);
            if(orderdetail.Status != 1)
            {
                ViewBag.TinhTrang = "Chưa thanh toán";
            }   
            else
            {
                ViewBag.TinhTrang = "Đã thanh toán";
            }
            if (orderdetail == null)
            {
                return HttpNotFound();
            }
            return View( orderdetail);
        }

        // GET: Admin/Orderdetail/Create
        public ActionResult Create()
        {
            ViewBag.ListProduct = new SelectList(db.Products.ToList(), "Id", "Name", 0);
            ViewBag.ListOrder = new SelectList(db.Orders.ToList(), "Id", "Name", 0);
            return View();
        }

        // POST: Admin/Orderdetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Orderdetail orderdetail)
        {
            if (ModelState.IsValid)
            {
                orderdetail.Tong = int.Parse((orderdetail.Price * orderdetail.Amount).ToString());
                db.Orderdetails.Add(orderdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ListProduct = new SelectList(db.Products.ToList(), "Id", "Name", 0);
            ViewBag.ListOrder = new SelectList(db.Orders.ToList(), "Id", "Name", 0);
            return View(orderdetail);
        }

        // GET: Admin/Orderdetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderdetail orderdetail = db.Orderdetails.Find(id);
            if (orderdetail == null)
            {
                return HttpNotFound();
            }

            ViewBag.ListProduct = new SelectList(db.Products.ToList(), "Id", "Name", 0);
            return View(orderdetail);
        }

        // POST: Admin/Orderdetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Orderdetail orderdetail)
        {
            if (ModelState.IsValid)
            {
                orderdetail.Tong = int.Parse((orderdetail.Price * orderdetail.Amount).ToString());
                db.Entry(orderdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ListProduct = new SelectList(db.Products.ToList(), "Id", "Name", 0);
            return View(orderdetail);
        }

        // GET: Admin/Orderdetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderdetail orderdetail = db.Orderdetails.Find(id);
            if (orderdetail == null)
            {
                return HttpNotFound();
            }
            return View(orderdetail);
        }

        // POST: Admin/Orderdetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orderdetail orderdetail = db.Orderdetails.Find(id);
            db.Orderdetails.Remove(orderdetail);
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


        public ActionResult Status(int id)
        {
            Orderdetail category = db.Orderdetails.Find(id);
            int x = (category.Status == 1) ? 2 : 1;
            category.Status = x;
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DelTrash(int id)
        {
            Orderdetail category = db.Orderdetails.Find(id);
            category.Status = 0;
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Orderdetail");
        }

        public ActionResult ReTrash(int id)
        {
            Orderdetail category = db.Orderdetails.Find(id);
            category.Status = 1;
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
