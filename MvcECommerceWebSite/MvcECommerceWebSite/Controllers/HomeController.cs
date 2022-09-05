using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcECommerceWebSite.Models.ViewModel;
using MvcECommerceWebSite.Models;
using MvcECommerceWebSite.Models.InputModel;

namespace MvcECommerceWebSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ProductsDbContext db =new ProductsDbContext();
        public ActionResult Index()
        {
            var product = (
                           from p in db.Products
                           join pi in db.ProductImages on p.ProductsId equals pi.ProductsId
                           select new RetriveProductView
                           {
                               ProductsId = p.ProductsId,
                               ProductsName = p.ProductsName,
                               CategoryName = p.Category.CategoryName,
                               SubCategoryName = p.SubCategory.SubCategoryName,
                               BrandName = p.Brand.BrandName,
                               QuantityPerUnit = p.QuantityPerUnit,
                               UnitPrice = p.UnitPrice,
                               QuantityInStock = pi.QuantityInStock,
                               StockInStatus = pi.StockInStatus,
                               Description = pi.Description,
                               StoreDate = pi.StoreDate,
                               Images = pi.Images

                           }).ToList();
            return View(product);
        }
        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

    }
}