using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductShopMVC.Services.Services;
using ProductShopMVC.Services.Models;
using ProductShop_empty_.Models;

namespace ProductShop_empty_.Controllers
{
    public class ProductController : Controller
    {
        private ProductServices productServices = new ProductServices();
       
        [HttpGet]
        public ActionResult AddProductView()
        {
            return View("~/Views/Product/AddEditProduct.cshtml");
        }


        [HttpGet]
        public ActionResult EditProductView(int id)
        {
            var product = productServices.GetProductById(id);
            return View("~/Views/Product/AddEditProduct.cshtml",product);
        }
        [HttpPost]
        public string EditProduct(Prod prod)
        {
            
            return "ok";
            
        }

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