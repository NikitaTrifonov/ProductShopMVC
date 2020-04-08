using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopMVC.Services.Models.Products.DbModels
{
    public class DbProduct
    {        
        public string DbProductId { get; set; }
        public string DbProductName { get; set; }
        public decimal DbProductPrice { get; set; }
        public int DbProductCategory { get; set; }

        public DbProduct(string dbProductId, string dbProductName, decimal dbProductPrice, int dbProductType)
        {
            DbProductId = dbProductId;
            DbProductName = dbProductName;
            DbProductPrice = dbProductPrice;
            DbProductCategory = dbProductType;
        }

        public DbProduct()
        {
        }
    }
}
