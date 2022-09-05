using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcECommerceWebSite.Models;
using MvcECommerceWebSite.Models.InputModel;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;

namespace MvcECommerceWebSite.Controllers
{
    public class ReportController : Controller
    {
        ProductsDbContext db = new ProductsDbContext();
        RetriveProductView view = new RetriveProductView();
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductsReport()
        {


            try
            {
                string str = "Data Source=.;Initial Catalog=MvcECommerceProjectDb;Integrated Security=true";
                SqlConnection con = new SqlConnection(str);
                SqlDataAdapter ada = new SqlDataAdapter();
                SqlCommand comand = con.CreateCommand();
                comand.CommandText = "Select * from Products p inner join ProductImages pi on p.ProductsId=pi.ProductsId inner join Categories c on p.CategoryId=c.Id inner join SubCategories s on p.SubCategoryId=s.Id inner join Brands b on p.BrandId=b.Id";
                SqlDataAdapter da = new SqlDataAdapter(comand);
                DataSet ds = new DataSet();
                da.Fill(ds, "Products");
                ReportDocument rd = new ReportDocument();
                string rptPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/productsInformation.rpt");
                rd.Load(rptPath);
                rd.SetDataSource(ds);
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Flush();
                rd.Close();
                rd.Dispose();
                return File(stream, System.Net.Mime.MediaTypeNames.Application.Pdf);

            }
            catch (Exception ex)
            {

                return Content("<h2>Error:" + ex.Message + "</h2>", "text/html");
            }

        }
        public ActionResult PrintReport()
        {

            
            try
            {
                string str = "Data Source=.;Initial Catalog=MvcECommerceProjectDb;Integrated Security=true";
                SqlConnection con = new SqlConnection(str);
                SqlDataAdapter ada = new SqlDataAdapter();
                SqlCommand comand = con.CreateCommand();
                comand.CommandText = "Select p.ProductsName,c.CategoryName,pi.Images,p.UnitPrice,pi.QuantityInStock,pi.StoreDate from Products p inner join ProductImages pi on p.ProductsId=pi.ProductsId inner join Categories c on p.CategoryId=c.Id inner join SubCategories s on p.SubCategoryId=s.Id inner join Brands b on p.BrandId=b.Id";
                SqlDataAdapter da = new SqlDataAdapter(comand);
                DataSet ds = new DataSet();
                da.Fill(ds,"Products");
                ReportDocument rd = new ReportDocument();
                string rptPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Products.rpt");
                rd.Load(rptPath);
                rd.SetDataSource(ds);
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Flush();
                rd.Close();
                rd.Dispose();
                return File(stream,System.Net.Mime.MediaTypeNames.Application.Pdf);

            }
            catch (Exception ex)
            {

                return Content("<h2>Error:" + ex.Message + "</h2>", "text/html");
            }
            
        }

        //public ActionResult ExportReportProduct()
        //{
        //    var product = (
        //                   from p in db.Products
        //                   join pi in db.ProductImages on p.ProductsId equals pi.ProductsId
        //                   select new RetriveProductView
        //                   {
        //                       ProductsId = p.ProductsId,
        //                       ProductsName = p.ProductsName,
        //                       CategoryName = p.Category.CategoryName,
        //                       SubCategoryName = p.SubCategory.SubCategoryName,
        //                       BrandName = p.Brand.BrandName,
        //                       QuantityPerUnit = p.QuantityPerUnit,
        //                       UnitPrice = p.UnitPrice,
        //                       QuantityInStock = pi.QuantityInStock,
        //                       StockInStatus = pi.StockInStatus,
        //                       Description = pi.Description,
        //                       StoreDate = pi.StoreDate,
        //                       Images = pi.Images

        //                   }).ToList();
            
        //    ReportDocument rd = new ReportDocument();
        //    rd.Load(Path.Combine(Server.MapPath("~/Reports"), "Products.rpt"));
        //    rd.SetDataSource(ListToDataTable(product));
        //    Response.Buffer = false;
        //    Response.ClearContent();
        //    Response.ClearHeaders();
        //    try
        //    {
        //        Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //        stream.Seek(0, SeekOrigin.Begin);
        //        return File(stream,"application/pdf","ProductList.pdf");
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
            
        //}
        //private DataTable ListToDataTable<T>(List<T> items) 
        //{
        //    DataTable dt = new DataTable(typeof(T).Name);
        //    PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    foreach (PropertyInfo pro in Props)
        //    {
        //        dt.Columns.Add(pro.Name);
        //    }
        //    foreach (T item in items)
        //    {
        //        var values = new object[Props.Length];
        //        for(int i = 0; i < Props.Length; i++)
        //        {
        //            values[i] = Props[i].GetValue(item, null);
        //        }
        //        dt.Rows.Add(values);
        //    }
        //    return dt;
        //}

    }
}