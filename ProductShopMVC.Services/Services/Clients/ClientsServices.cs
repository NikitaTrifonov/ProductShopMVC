using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductShopMVC.Services.Models.Clients;
using ProductShopMVC.Services.Repositories.Clients;
using ProductShopMVC.Tools.Errors;

namespace ProductShopMVC.Services.Services.Clients
{
    public class ClientsServices
    {
        public List<Client> GetAllClients(out DefaultError outError)
        {
            outError = new DefaultError();
            List<Client> result = ClientsRepository.GetAllClients();

            if (result == null || !result.Any())
            {
                outError.ErrorMessage = "Список клиентов пуст!";
                return new List<Client>();
            }
            return result;
        }
    }
}
