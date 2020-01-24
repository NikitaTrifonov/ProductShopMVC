using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductShopMVC.Services.Services;

namespace ProductShop_empty_.Controllers
{
    public class productController : Controller
    {
        private ProductServices productServices = new ProductServices();
        // GET: product
        public ActionResult Home()
        {
            return View();
        }
    }
}