using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductShopMVC.Services.Services.Clients;
using ProductShopMVC.Services.Models.Clients;
using ProductShopMVC.Tools.Response;
using ProductShopMVC.Tools.Errors;

namespace ProductShop_empty_.Controllers.Clients
{
    public class ClientsController : Controller
    {
        private ClientsServices clientsServices = new ClientsServices();

        public ActionResult ClientsList()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllClients()
        {
            ResultHandler<List<Client>> result = new ResultHandler<List<Client>>(clientsServices.GetAllClients(out DefaultError outError), outError.ErrorMessage);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddClientView()
        {
            return View("~/Views/Clients/AddEditClient.cshtml");
        }

        [HttpPost]
        public JsonResult AddClient(AddEditClient clientFromView)
        {
            clientsServices.AddClient(clientFromView, out DefaultError outError);
            ResultHandler<Object> result = new ResultHandler<object>(outError.ErrorMessage);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditClientView(string id)
        {
            Client clientForEdit = clientsServices.GetClientById(id);
            return View("~/Views/Clients/AddEditClient.cshtml", clientForEdit);
        }

        [HttpPost]
        public JsonResult EditClient(AddEditClient clientFromView)
        {
            clientsServices.EditClient(clientFromView, out DefaultError outError);
            ResultHandler<Object> result = new ResultHandler<object>(outError.ErrorMessage);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SearchClientsByLastName(string lastName)
        {
            ResultHandler<List<Client>> result = new ResultHandler<List<Client>>(clientsServices.SearchClientsByLastName(lastName, out DefaultError outError), outError.ErrorMessage);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SearchClientsByEmail(string email)
        {
            ResultHandler<List<Client>> result = new ResultHandler<List<Client>>(clientsServices.SearchClientsByEmail(email, out DefaultError outError), outError.ErrorMessage);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DelClient(string id)
        {
            clientsServices.DelClient(id, out DefaultError outError);
            ResultHandler<object> result = new ResultHandler<object>(outError.ErrorMessage);
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}