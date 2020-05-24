using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PFEMaster.Models
{
    public partial class Products
    {
        public int ProductsId { get; set; }
        [Required(ErrorMessage = "Product Name is Required")]
        [StringLength(100, ErrorMessage = "Minimum 3 and minimum 5 and maximum 100 charaters are allwed", MinimumLength = 3)]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
        [DataType(DataType.Upload)]
        HttpPostedFileBase ImageUpload { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [Required]
        [Range(typeof(int), "1", "500", ErrorMessage = "Invalid Quantity")]
        public int Quantity { get; set; }
        [Required]
        [Range(typeof(float), "1", "200000", ErrorMessage = "invalid Price")]
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}