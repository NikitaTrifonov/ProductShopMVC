using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductShopMVC.Services.Models.Clients;
using ProductShopMVC.Services.Repositories.Clients;
using ProductShopMVC.Tools.Errors;
using ProductShopMVC.Tools.Generate;
using ProductShopMVC.Tools.Conversion.ConverseDate;

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
        public void AddClient(AddEditClient clientFromView, out DefaultError outError)
        {
            outError = new DefaultError();

            ClientsRepository.AddClient(SetClientData(clientFromView));


        }

        private Client SetClientData(AddEditClient clientFromView)
        {
            Client newClient = new Client();
            newClient.ClientId = String.IsNullOrEmpty(clientFromView.ClientId) ? GeneratorId.GenerateId() : clientFromView.ClientId;
            newClient.ClientLastName = clientFromView.ClientLastName;
            newClient.ClientFirstName = clientFromView.ClientFirstName;
            newClient.ClientMiddleName = clientFromView.ClientMiddleName;
            newClient.ClientBirthday = ConverseDateFromView.DateStringToDateTime(clientFromView.ClientBirthdayString);
            newClient.ClientPhoneNumber = clientFromView.ClientPhoneNumber;
            newClient.ClientEmail = clientFromView.ClientEmail;
            return newClient;
        }
    }
}
