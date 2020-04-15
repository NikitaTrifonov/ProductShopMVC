using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductShopMVC.Services.Models.Products.Types;
namespace ProductShopMVC.Services.Models.Products
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public ProductCategory ProductType { get; set; }
        public string CategoryString { get { return CategoryConverter.EnumToRusString(this.ProductType); }}
        public string ProductImageRes { get; set; }

        public Product(string id, string name, string price, ProductCategory type, string imageRes)
        {
            ProductId = id;
            ProductName = name;
            ProductPrice = price;
            ProductType = type;
            ProductImageRes = imageRes;
        }
        public Product() { }
    }
}
