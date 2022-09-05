using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcECommerceWebSite.Models.InputModel
{
    public class Brand
    {
        public int Id { get; set; }
        [ForeignKey("Category"), Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("SubCategory"), Display(Name = "Sub Category")]
        public int SubCategoryId { get; set; }
        public string BrandName { get; set; }

        //nev
        public virtual Category Category { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}