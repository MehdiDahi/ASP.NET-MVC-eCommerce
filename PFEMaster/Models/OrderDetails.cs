using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFEMaster.Models
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set;}
        public Order Order { get; set; }
        public Products Products { get; set; }
        public int Qte { get; set; }
        public float Price { get; set; }
    }
}