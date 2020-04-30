using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductShopMVC.Services.Services.Files;
using ProductShopMVC.Tools.Errors;
using ProductShopMVC.Tools.Response;

namespace ProductShop_empty_.Controllers.Infrastructure
{
    public class ImagesController : Controller
    {
        // GET: Images
        [HttpPost]
        public JsonResult UploadImg()
        {
            ResultHandler<String> result = new ResultHandler<string>(FileService.UploadImg(Request, "product", out DefaultError outError), outError.ErrorMessage);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetImg(string id)
        {
            return base.File(FileService.GetImgPath(id), "image/jpeg");
        }
    }
}