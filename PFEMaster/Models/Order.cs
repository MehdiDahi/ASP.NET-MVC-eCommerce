using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace PFEMaster.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public ApplicationUser User { get; set; }
        public Addresses ShippingAddress { get; set; }

    }
}