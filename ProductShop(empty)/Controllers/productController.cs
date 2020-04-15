﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductShopMVC.Services.Services.Products;
using ProductShopMVC.Services.Services.Files;
using ProductShopMVC.Services.Models.Products;
using ProductShopMVC.Tools.Response;
using ProductShopMVC.Tools.Errors;
using ProductShop_empty_.Models.Products;
using ProductShopMVC.Tools.Generate;

namespace ProductShop_empty_.Controllers
{

    public class ProductController : Controller
    {
        private ProductServices productServices = new ProductServices();
        [HttpPost]
        public JsonResult DelProduct(string id)
        {
            productServices.DelProduct(id, out DefaultError outError);
            ResultHandler<Object> result = new ResultHandler<object>(outError.ErrorMessage);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddProductView()
        {
            ProductForEdit product = new ProductForEdit();
            return View("~/Views/Product/AddEditProduct.cshtml", product);
        }
        [HttpPost]
        public JsonResult AddProduct(AddEditProduct product)
        {
            productServices.AddProduct(product, out DefaultError outError);
            ResultHandler<Object> result = new ResultHandler<object>(outError.ErrorMessage);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditProductView(string id)
        {
            ProductForEdit product = new ProductForEdit(productServices.GetProductById(id));
            return View("~/Views/Product/AddEditProduct.cshtml", product);
        }

        [HttpPost]
        public JsonResult EditProduct(AddEditProduct product)
        {
            productServices.EditProduct(product, out DefaultError outError);
            ResultHandler<Object> result = new ResultHandler<object>(outError.ErrorMessage);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ProductList()
        {
            return View();
        }

        [HttpGet]

        public JsonResult GetProductsCategory()
        {
            ProductCategories productFilter = new ProductCategories();
            ResultHandler<List<string>> result = new ResultHandler<List<string>>(productFilter.ProductCategory, "");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetProductsByCategory(string filter)
        {
            ResultHandler<List<Product>> result = new ResultHandler<List<Product>>(productServices.GetProductsByCategory(filter, out DefaultError outError), outError.ErrorMessage);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllProducts()
        {
            ResultHandler<List<Product>> result = new ResultHandler<List<Product>>(productServices.GetAllProducts(out DefaultError outError), outError.ErrorMessage);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProductByName(string name)
        {
            ResultHandler<List<Product>> result = new ResultHandler<List<Product>>(productServices.GetProductsByName(name, out DefaultError outError), outError.ErrorMessage);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UploadImg()
        {
            ResultHandler<String> result = new ResultHandler<string>(FileService.UploadProductImg(Request, out DefaultError outError), outError.ErrorMessage);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetImg(string id)
        {          
            return base.File(FileService.GetProductImg(id), "image/jpeg");
        }
    }

}