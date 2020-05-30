using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace PFEMaster.Models
{
    public class ShoppingCart
    {
        public Products Products { get; set; }
        public int Qte { get; set; }

        public ApplicationUser User { get; set; }
        public Addresses ShippingAddress { get; set; }

        public ShoppingCart(Products products, int qte)
        {
            Products = products;
            Qte = qte;
            }
    }
}