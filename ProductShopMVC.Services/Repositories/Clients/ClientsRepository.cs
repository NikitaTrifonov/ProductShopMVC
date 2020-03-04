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
            new Client(Guid.NewGuid().ToString(),"Иванов","Петр","Андреевич", new DateTime(1990,1,12),"+79163701541","ivanov1990@gmail.com"),
            new Client(Guid.NewGuid().ToString(),"Шумова","Елена","Александровна", new DateTime(1984,10,8),"+79851714761","shum111@gmail.com"),
            new Client(Guid.NewGuid().ToString(),"Клюев","Егор","Павлович", new DateTime(1992,5,29),"+79261115696","CluevEP1992@gmail.com")
        };

        public static List<Client> GetAllClients()
        {
            return ClientsList;
        }
     }
}
