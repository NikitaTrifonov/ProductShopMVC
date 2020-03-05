using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopMVC.Services.Models.Clients
{
    public class AddEditClient
    {
        public string ClientId { get; set; }
        public string ClientLastName { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientMiddleName { get; set; }
        public string ClientBirthdayString { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string ClientEmail { get; set; }

        public AddEditClient(string clientId, string clientLastName, string clientFirstName, string clientMiddleName, string clientBirthdayString, string clientPhoneNumber, string clientEmail)
        {
            ClientId = clientId;
            ClientLastName = clientLastName;
            ClientFirstName = clientFirstName;
            ClientMiddleName = clientMiddleName;
            ClientBirthdayString = clientBirthdayString;
            ClientPhoneNumber = clientPhoneNumber;
            ClientEmail = clientEmail;
        }
        public AddEditClient() { }
    }
}
