using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace PFEMaster.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.UserRole = new SelectList(db.Roles.ToList(), "Name", "Name");
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(ApplicationUser User)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(User);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(User);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(MultiViewModel model,string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var address = db.Addresses.Include(a => a.UserId).Where(a => a.UserId == id);
            var User =db.Users.Find(id);
            ViewBag.UserRole = new SelectList(db.Roles.ToList(), "Name", "Name");
            if (User == null)
            {
                return HttpNotFound();
            }
            return View(User);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUser User)
        {
            ViewBag.UserRole = new SelectList(db.Roles.ToList(), "Name", "Name");
            if (ModelState.IsValid)
            {
                db.Entry(User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(User);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
