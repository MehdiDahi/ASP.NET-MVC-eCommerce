using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PFEMaster.Models;
using WebApplication1.Models;

namespace PFEMaster.Controllers
{
    public class AddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Addresses
        public ActionResult Index()
        {
            
            return View(db.Addresses.ToList());
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addresses addresses = db.Addresses.Find(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            return View(addresses);
        }

        // GET: Addresses/Create
        public ActionResult Create(string id)
        {
            
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Addresses addresses, ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                addresses.UserId = user.Id;
                db.Addresses.Add(addresses);
                db.SaveChanges();
                return RedirectToAction("~/Users");
            }
            return View(addresses);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addresses addresses = db.Addresses.Find(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            
            return View(addresses);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddressesId,ContactName,Country,Address,ZipCode,Mobile,UserId")] Addresses addresses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addresses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(addresses);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addresses addresses = db.Addresses.Find(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            return View(addresses);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Addresses addresses = db.Addresses.Find(id);
            db.Addresses.Remove(addresses);
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
