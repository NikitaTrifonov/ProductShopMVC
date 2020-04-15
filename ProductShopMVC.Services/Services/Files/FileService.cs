using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using ProductShopMVC.Tools.Generate;
using ProductShopMVC.Tools.Errors;

namespace ProductShopMVC.Services.Services.Files
{
    public static class FileService
    {
        public static string UploadProductImg(HttpRequestBase Requst, out DefaultError outError)
        {
            outError = new DefaultError();
            string resultImageRes = "Missing Images";

            foreach (string file in Requst.Files)
            {
                var upload = Requst.Files[file];
                if (upload != null)
                {
                    string fileName = "product" + "_" + GeneratorId.GenerateId() + ".jpg";   /*Path.GetFileName(upload.FileName) Если нужно имя файла*/
                    upload.SaveAs(HttpContext.Current.Server.MapPath("~/Files/" + fileName));
                    resultImageRes = fileName;
                }
                else
                {
                    outError.ErrorMessage = "Ошибка загрузки файла!";
                    return resultImageRes;
                }
            }
            return resultImageRes;
        }

        public static string GetProductImg(string productImgRes)
        {
            var dir = HttpContext.Current.Server.MapPath("/Files");
            var path = Path.Combine(dir, productImgRes);
            return path;
        }
    }
}
