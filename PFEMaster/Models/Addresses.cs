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
        [StringLength(100, ErrorMessage = "Minimum 6 and maximum 100 charaters are allwed", MinimumLength = 6)]
        public string ContactName { get; set; }
        [StringLength(8, ErrorMessage = "Minimum 4 and maximum 8 charaters are allwed", MinimumLength = 4)]
        public string Country { get; set; }
        [StringLength(100, ErrorMessage = "Minimum 6 and maximum 100 charaters are allwed", MinimumLength = 6)]
        public string Address { get; set; }
        [StringLength(8, ErrorMessage = "8 charaters are allwed", MinimumLength = 5)]
        public string ZipCode { get; set; }
        [StringLength(10, ErrorMessage = "10 charaters are allwed", MinimumLength = 10)]
        public string Mobile { get; set; }
        public string UserId { get; set; }
        public bool IsDefault { get; set; }

    }
}