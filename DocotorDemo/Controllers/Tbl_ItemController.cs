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
    public class Tbl_ItemController : Controller
    {
        private OnlineBookingEntities db = new OnlineBookingEntities();

        // GET: Tbl_Item
        public ActionResult Index()
        {
            var tbl_Item = db.Tbl_Item.Include(t => t.Tbl_Categories).Include(t => t.Tbl_Users);
            return View(tbl_Item.ToList());
        }
        //public ActionResult GetItemsByName()
        //{
        //    // var jobs = db.ApplyForJobs.Where(a => a.UserId == UserId);
        //    //var tbl_Item = db.Tbl_Item.Where(item => item.;
        //    return View(tbl_Item.ToList());
        //}

        // GET: Tbl_Item/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Item tbl_Item = db.Tbl_Item.Find(id);
            if (tbl_Item == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Item);
        }

        // GET: Tbl_Item/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Tbl_Categories, "ID", "CategoryName");
            ViewBag.UserID = new SelectList(db.Tbl_Users, "ID", "UserName");
            return View();
        }

        // POST: Tbl_Item/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Item_Name,Item_Description,Item_Image,Item_Location,CategoryID,UserID")] Tbl_Item tbl_Item)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Item.Add(tbl_Item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Tbl_Categories, "ID", "CategoryName", tbl_Item.CategoryID);
            ViewBag.UserID = new SelectList(db.Tbl_Users, "ID", "UserName", tbl_Item.UserID);
            return View(tbl_Item);
        }

        // GET: Tbl_Item/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Item tbl_Item = db.Tbl_Item.Find(id);
            if (tbl_Item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Tbl_Categories, "ID", "CategoryName", tbl_Item.CategoryID);
            ViewBag.UserID = new SelectList(db.Tbl_Users, "ID", "UserName", tbl_Item.UserID);
            return View(tbl_Item);
        }

        // POST: Tbl_Item/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Item_Name,Item_Description,Item_Image,Item_Location,CategoryID,UserID")] Tbl_Item tbl_Item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Tbl_Categories, "ID", "CategoryName", tbl_Item.CategoryID);
            ViewBag.UserID = new SelectList(db.Tbl_Users, "ID", "UserName", tbl_Item.UserID);
            return View(tbl_Item);
        }

        // GET: Tbl_Item/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Item tbl_Item = db.Tbl_Item.Find(id);
            if (tbl_Item == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Item);
        }

        // POST: Tbl_Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tbl_Item tbl_Item = db.Tbl_Item.Find(id);
            db.Tbl_Item.Remove(tbl_Item);
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
