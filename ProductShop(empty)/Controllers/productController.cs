using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductShopMVC.Services.Services;
using ProductShopMVC.Services.Models;
using ProductShopMVC.Tools.Response;

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
        public ActionResult EditProductView(string id)
        {
            var product = productServices.GetProductById(id);
            return View("~/Views/Product/AddEditProduct.cshtml", product);
        }


        [HttpPost]
        public JsonResult EditProduct(AddEditProductModel product)
        {
            productServices.EditProduct(product, out DefaultError outError);
            ResultHandler<Object> result = new ResultHandler<object>(outError.errorMessage);
            return Json(result, JsonRequestBehavior.AllowGet);            
        }


        public ActionResult Home()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetAllProducts()
        {
            ResultHandler<List<Product>> result = new ResultHandler<List<Product>>(productServices.GetAllProducts(out DefaultError outError), outError.errorMessage);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetProductByName(string name)
        {
            ResultHandler<List<Product>> result = new ResultHandler<List<Product>>(productServices.GetProductsByName(name, out DefaultError outError), outError.errorMessage);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }

}