using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopMVC.Services.Models.Clients
{
    public class Client
    {
        public string ClientId { get; set; }
        public string ClientLastName { get; set; }
        public string ClientFirstName { get; set; }

        public string ClientMiddleName { get; set; }
        public DateTime ClientBirthday { get; set; }
        public string ClientBirthdayString { get { return ClientBirthday.ToShortDateString(); } }
        public string ClientPhoneNumber { get; set; }
        public string ClientEmail { get; set; }


        public Client()
        {

        }

        public Client(string clientId, string clientLastName, string clientFirstName, string clientMiddleName, DateTime clientBirthday, string clientPhoneNumber, string clientEmail)
        {
            ClientId = clientId;           
            ClientLastName = clientLastName;
            ClientFirstName = clientFirstName;
            ClientMiddleName = clientMiddleName;
            ClientBirthday = clientBirthday;
            ClientPhoneNumber = clientPhoneNumber;
            ClientEmail = clientEmail;
        }
    }


}
