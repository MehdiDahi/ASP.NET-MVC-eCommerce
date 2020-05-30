using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using PFEMaster.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PFEMaster.Controllers
{
    [Authorize(Roles = "buyer")]
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private string cartSession = "cartSession";
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShoppingCart/OrderNow
        public ActionResult OrderNow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (Session[cartSession] == null)
            {
                List<ShoppingCart> CartList = new List<ShoppingCart> {
                    new ShoppingCart(db.Products.Find(id),1)
                };
                Session[cartSession] = CartList;
            }

            else
            {
                List<ShoppingCart> CartList = (List<ShoppingCart>)Session[cartSession];
                int check = IsExistingCheck(id);
                if (check == -1)
                    CartList.Add(new ShoppingCart(db.Products.Find(id), 1));
                else
                    CartList[check].Qte++;
                Session[cartSession] = CartList;
            }
            
            return View("Index");
        }

        private int IsExistingCheck(int? id)
        {
            List<ShoppingCart> CartList = (List<ShoppingCart>)Session[cartSession];
            for(int i = 0; i < CartList.Count(); i++)
            {
                if (CartList[i].Products.ProductsId == id)
                    return i;
            }
            return -1;
        }

        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int check = IsExistingCheck(id);
            List<ShoppingCart> CartList = (List<ShoppingCart>)Session[cartSession];
            CartList.RemoveAt(check);
            return View("Index");
        }

    
        
        public ActionResult Update(FormCollection fc)
        {
            string[] qte = fc.GetValues("qte");
            List<ShoppingCart> CartList = (List<ShoppingCart>)Session[cartSession];
            for(int i = 0; i < CartList.Count; i++)
            {
                if (Convert.ToInt32(qte[i]) > CartList[i].Products.Quantity)
                {
                   ModelState.AddModelError("","Max Qte for * " + CartList[i].Products.ProductName + " * "+ CartList[i].Products.Quantity + " Items.");
                }

                CartList[i].Qte = Convert.ToInt32(qte[i]);
                
            }
            Session[cartSession] = CartList;
            return View("Index");
        }

        
        public ActionResult CheckOut(FormCollection fc)
        {
            
            return View("CheckOut");
        }

        public ActionResult ProcessOrder(FormCollection fc)
        {
            List<ShoppingCart> CartList = (List<ShoppingCart>)Session[cartSession];
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var emailuser = userManager.FindByEmail(fc["Email"]);
            string email = emailuser.Email;
            if(emailuser != null)
            {
                    Addresses adr = new Addresses();
                    adr.ContactName = fc["ContactName"];
                    adr.Country = fc["Country"];
                    adr.Address = fc["Address"];
                    adr.ZipCode = fc["ZipCode"];
                    adr.Mobile = fc["Mobile"];
                    adr.UserId = emailuser.Id;
                    db.Addresses.Add(adr);
                    db.SaveChanges();

                    Order ord = new Order();
                    ord.User = emailuser;
                ord.ShippingAddress = adr;
                    db.Orders.Add(ord);
                    db.SaveChanges();

                foreach (ShoppingCart cart in CartList)
                {
                    OrderDetails dtord = new OrderDetails();
                    dtord.Order = ord;
                    dtord.Products = cart.Products;
                    dtord.Qte = cart.Qte;
                    dtord.Price = cart.Products.Price;
                    db.OrderDetails.Add(dtord);
                    db.SaveChanges();
                }
                Session.Remove(cartSession);

            }
            else
            {
                ModelState.AddModelError("", "Enter A Valid Email");
                return View("CheckOut");
            }
            

            return View("OrderSuccess");
        }
    }
}