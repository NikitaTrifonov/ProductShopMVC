using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopMVC.Services.Models.Clients.DbModels
{
    public class DbClient
    {
        public string DbClientId { get; set; }
        public string DbClientLastName { get; set; }
        public string DbClientFirstName { get; set; }
        public string DbClientMiddleName { get; set; }
        public DateTime DbClientBirthday { get; set; }       
        public string DbClientPhoneNumber { get; set; }
        public string DbClientEmail { get; set; }

        public DbClient(string dbClientId, string dbClientLastName, string dbClientFirstName, string dbClientMiddleName, DateTime dbClientBirthday, string dbClientPhoneNumber, string dbClientEmail)
        {
            DbClientId = dbClientId;
            DbClientLastName = dbClientLastName;
            DbClientFirstName = dbClientFirstName;
            DbClientMiddleName = dbClientMiddleName;
            DbClientBirthday = dbClientBirthday;
            DbClientPhoneNumber = dbClientPhoneNumber;
            DbClientEmail = dbClientEmail;
        }

        public DbClient()
        {
        }
    }
}
