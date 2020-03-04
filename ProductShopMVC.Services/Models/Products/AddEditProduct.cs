using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopMVC.Services.Models.Products
{
    public class AddEditProduct
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductCategory { get; set; }


        public AddEditProduct(string id, string name, string price, string category)
        {
            ProductId = id;
            ProductName = name;
            ProductPrice = price;
            ProductCategory = category;
        }

        public AddEditProduct() { }

    }
}
