using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductShopMVC.Services.Models.Clients;

namespace ProductShopMVC.Services.Repositories.Clients
{
    public static class ClientsRepository
    {
        private static List<Client> ClientsList = new List<Client>()
        {
            new Client(Guid.NewGuid().ToString(),"Иванов","Петр","Андреевич", new DateTime(1990,1,12),"+7(916)370-15-41","ivanov1990@gmail.com"),
            new Client(Guid.NewGuid().ToString(),"Шумова","Елена","Александровна", new DateTime(1984,10,8),"+7(985)171-47-61","shum111@gmail.com"),
            new Client(Guid.NewGuid().ToString(),"Клюев","Егор","Павлович", new DateTime(1992,5,29),"+7(926)111-56-96","CluevEP1992@gmail.com")
        };

        public static List<Client> GetAllClients()
        {
            return ClientsList;
        }
        public static void AddClient(Client newClient)
        {
            ClientsList.Add(newClient);
        }
        public static Client GetClientById(string id)
        {
            return ClientsList.FirstOrDefault(client => client.ClientId == id);
        }
        public static Client GetClientByEmail(string email)
        {
            return ClientsList.FirstOrDefault(client => (String.Compare(client.ClientEmail, email) == 0));
        }

        public static List<Client> SearchClientsByEmail(string email)
        {
            List<Client> result = ClientsList.Where(client => client.ClientEmail == email).ToList();
            return result;
        }
        public static void EditClient(Client changedClient)
        {
            Client oldClient = ClientsRepository.GetClientById(changedClient.ClientId);
            int index = ClientsList.IndexOf(oldClient);
            ClientsList.Remove(oldClient);
            ClientsList.Insert(index, changedClient);
        }
        public static List<Client> GetClientsByLastName(string lastName)
        {
            List<Client> result = ClientsList.Where(client => client.ClientLastName == lastName).ToList();
            return result;
        }
       
    }
}
