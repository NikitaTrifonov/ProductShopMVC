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
            new Product(Guid.NewGuid().ToString(), "Orange", "15.00"),
            new Product(Guid.NewGuid().ToString(), "Lime", "30.00"),
            new Product(Guid.NewGuid().ToString(), "Apple", "8.30"),
            new Product(Guid.NewGuid().ToString(), "Lime", "40.00")};

        public static Product GetProductById(string id)
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
            Product oldProduct = ProductRepository.GetProductById(changedProduct.ProductId);
            int indexProduct = ProductsList.IndexOf(oldProduct);
            ProductsList.Remove(oldProduct);
            ProductsList.Insert(indexProduct, changedProduct);
        }
    }
}
