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
        public decimal DbProductWeight { get; set; }
        public int DbProductCategory { get; set; }
        public string DbImageRes { get; set; }

        public DbProduct(string dbProductId, string dbProductName, decimal dbProductPrice, int dbProductType, string dbImageRes)
        {
            DbProductId = dbProductId;
            DbProductName = dbProductName;
            DbProductWeight = dbProductPrice;
            DbProductCategory = dbProductType;
            DbImageRes = dbImageRes;
        }

        public DbProduct()
        {
        }
    }
}
