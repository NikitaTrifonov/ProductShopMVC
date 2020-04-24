using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductShopMVC.Services.Services.ShopMenu;
using ProductShopMVC.Services.Models.ShopMenu;
using ProductShopMVC.Tools.Response;
using ProductShopMVC.Tools.Errors;


namespace ProductShop_empty_.Controllers.ShopMenu
{
    public class ShopMenuController : Controller
    {
        ShopMenuService shopMenuService = new ShopMenuService();
        // GET: ShopMenu
        public ActionResult ShopMenuList()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetShopMenu()
        {
            ResultHandler<List<MenuItem>> result = new ResultHandler<List<MenuItem>>(shopMenuService.GetShopMenu(out DefaultError outError), outError.ErrorMessage);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}