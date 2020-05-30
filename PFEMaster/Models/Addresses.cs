using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace PFEMaster.Models
{
    public class Addresses
    {
        public int AddressesId { get; set; }
        public string ContactName { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        [StringLength(10, ErrorMessage = "10 charaters are allwed", MinimumLength = 10)]
        public string Mobile { get; set; }
        public string UserId { get; set; }
        public bool IsDefault { get; set; }

    }
}