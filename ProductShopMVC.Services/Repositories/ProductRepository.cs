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
        private static List<Product> ProductsList = new List<Product> {
            new Product(1, "Orange", "15.00"),
            new Product(2, "Lime", "30.00"),
            new Product(3, "Apple", "8.30"),
            new Product(4, "Lime", "40.00")};

        public static Product GetProductById(int id)
        {
            return ProductsList.FirstOrDefault(product => product.ProductId == id);
        }
        public static List<Product> GetProductsByName(string name)
        {
            List<Product> resault = ProductsList.Where(product => product.ProductName.ToLower() == name.ToLower()).ToList();
            return resault;
        }

        public static List<Product> GetAllProducts()
        {
            return ProductsList;
        }

        public static void EditProduct(Product changedProduct)
        {
            ProductsList.RemoveAt(changedProduct.ProductId - 1);
            ProductsList.Insert(changedProduct.ProductId - 1, changedProduct);
        }
    }
}
