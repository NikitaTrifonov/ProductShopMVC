using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductShopMVC.Services.Models;

namespace ProductShopMVC.Services.Repositories
{
    public static class ProductRepository
    {
        private static List<Product> ProductsList = new List<Product> { new Product(1, "Orange", "15.00"), new Product(2, "Lime", "30.00"), new Product(3, "Apple", "8.30") };

        public static Product GetProductById(int id)
        {
            return ProductsList.FirstOrDefault(product => product.ProductId == id);
        }
        public static Product GetProductByName(string name)
        {
            return ProductsList.FirstOrDefault(product => product.ProductName == name);
        }

        public static List<Product> GetAllProducts()
        {
            return ProductsList;
        }
    }
}
