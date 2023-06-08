using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpet.Context;

namespace webpet.Controllers
{
    public class ProductController : Controller
    {
        webpetEntities objwebpetEntities = new webpetEntities();
        // GET: Product
        public ActionResult Detail(int id)
        {
            var objProduct = objwebpetEntities.Products.Where(n => n.id == id).FirstOrDefault();
            return View(objProduct);
        }
       
    }
}