using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductShop_empty_.Models
{
    public class Prod
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }

        public Prod(string id, string name, string price)
        {
            ProductId = id;
            ProductName = name;
            ProductPrice = price;
        }
    }
}
