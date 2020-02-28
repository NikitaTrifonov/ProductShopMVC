using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopMVC.Services.Models
{
    public class AddEditProductModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductCategory { get; set; }


        public AddEditProductModel(string id, string name, string price, string category)
        {
            ProductId = id;
            ProductName = name;
            ProductPrice = price;
            ProductCategory = category;
        }

        public AddEditProductModel() { }

    }
}
