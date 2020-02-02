using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductShopMVC.Services.Services;
using ProductShopMVC.Services.Models;

namespace ProductShop_empty_.Controllers
{
    public class ProductController : Controller
    {
        private ProductServices productServices = new ProductServices();
        // GET: product
        public ActionResult Home()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAllProducts()
        {
            List<Product> products = productServices.GetAllProducts();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetProductByName(string name)
        {
            List<Product> requiredProduct = productServices.GetProductsByName(name);
            return Json(requiredProduct, JsonRequestBehavior.AllowGet); 
        }
    }
}