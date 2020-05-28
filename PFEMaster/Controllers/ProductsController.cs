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
using System.IO;

namespace PFEMaster.Controllers
{
   
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

        // GET: Products
        public ActionResult allProducts()
        {
            //var categories = db.Categories;
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

        
        public ActionResult productsByCat(int id)
        {
            var products = db.Products.Include(p => p.Category).Where(p => p.CategoryId == id);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/addOrEdit
        public ActionResult addOrEdit(int id = 0)
        {
            Products products = new Products();
            if (id != 0)
            {
                products = db.Products.Where(p => p.ProductsId == id).FirstOrDefault<Products>();
            }
            

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View(products);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addOrEdit(Products products)
        {

            if (ModelState.IsValid)
            {
                if (products.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(products.ImageUpload.FileName);
                    string extention = Path.GetExtension(products.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                    products.ImageUrl = "~/ProductImg/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/ProductImg/"), fileName);
                    products.ImageUpload.SaveAs(fileName);

                }


                if (products.ProductsId == 0)
                {
                    //products.CreatedDate = DateTime.Parse(DateTime.Today.ToString());
                    db.Products.Add(products);
                    db.SaveChanges();
                }
                else
                {
                    //products.ModifiedDate = DateTime.Parse(DateTime.Today.ToString());
                    db.Entry(products).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");

            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", products.CategoryId);
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
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
