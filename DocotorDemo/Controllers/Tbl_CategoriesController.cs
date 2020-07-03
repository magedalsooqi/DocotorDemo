using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DocotorDemo.Models;

namespace DocotorDemo.Controllers
{
    public class Tbl_CategoriesController : Controller
    {
        private OnlineBookingEntities db = new OnlineBookingEntities();

        // GET: Tbl_Categories
        public ActionResult Index()
        {
            return View(db.Tbl_Categories.ToList());
        }
        // GET: Tbl_CategoriesName to show to Patients
        public ActionResult GetCategoriesByName()
        {
            return View(db.Tbl_Categories.ToList());
        }

        // GET: Tbl_Categories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Categories tbl_Categories = db.Tbl_Categories.Find(id);
            if (tbl_Categories == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Categories);
        }

        // GET: Tbl_Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CategoryName")] Tbl_Categories tbl_Categories)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Categories.Add(tbl_Categories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Categories);
        }

        // GET: Tbl_Categories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Categories tbl_Categories = db.Tbl_Categories.Find(id);
            if (tbl_Categories == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Categories);
        }

        // POST: Tbl_Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CategoryName")] Tbl_Categories tbl_Categories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Categories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Categories);
        }

        // GET: Tbl_Categories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Categories tbl_Categories = db.Tbl_Categories.Find(id);
            if (tbl_Categories == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Categories);
        }

        // POST: Tbl_Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tbl_Categories tbl_Categories = db.Tbl_Categories.Find(id);
            db.Tbl_Categories.Remove(tbl_Categories);
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
