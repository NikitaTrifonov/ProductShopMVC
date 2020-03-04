﻿using System;
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
    }
    
}