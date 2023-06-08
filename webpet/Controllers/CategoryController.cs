using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpet.Context;

namespace webpet.Controllers
{
    public class CategoryController : Controller
    {
        webpetEntities objwebpetEntities = new webpetEntities();
        // GET: Category
        public ActionResult Index()
        {
            var IstCategory = objwebpetEntities.Categories.ToList();
            return View(IstCategory);
        }
        public ActionResult ProductCategory(int id)
        {
            var listProduct = objwebpetEntities.Products.Where(n => n.CategoryId == id).ToList();
            return View(listProduct);
        }
    }
} 