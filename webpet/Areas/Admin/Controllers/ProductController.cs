using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpet.Context;
using static webpet.Commom;

namespace webpet.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        webpetEntities dbObj = new webpetEntities();

        // GET: Admin/Product
        public ActionResult Index()
        {
            var lstProduct = dbObj.Products.ToList();
            return View(lstProduct);
        }
        public ActionResult Details(int id)
        {
            var objProduct = dbObj.Products.Where(n => n.id == id).FirstOrDefault();
            return View(objProduct);
            
        }
        [HttpGet]
        public ActionResult Create()
        {
            Commom objCommom = new Commom();
            var lstCat = dbObj.Categories.ToList();
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommom.ToSelectList(dtCategory, "Id", "Name");
            var lstBrand = dbObj.Brands.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            ViewBag.ListBrand = objCommom.ToSelectList(dtBrand, "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product objProduct)
         {
            if(ModelState.IsValid)
            {
                try
                {
                    if(objProduct.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                        string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objProduct.Avatar = fileName;
                        objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                    }
                    objProduct.CreatedOnUtc = DateTime.Now;
                    dbObj.Product.Add(objProduct);
                }
            }    
            return View();
        }
        
        public ActionResult Delete(int id)
        {
            var objProduct = dbObj.Products.Where(n => n.id == id).FirstOrDefault();
            return View(objProduct);
        }
        public ActionResult Edit(int id)
        {
            var objProduct = dbObj.Products.Where(n => n.id == id).FirstOrDefault();
            return View(objProduct);
        }
       
    }
}