using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductShopMVC.Services.Models.Products;
using ProductShopMVC.Services.Models.Products.Types;




namespace ProductShopMVC.Services.Repositories.Products
{
    public static class ProductRepository
    {

        private static List<Product> ProductsList = new List<Product>
        {
            new Product(Guid.NewGuid().ToString(), "Апельсин", "15.00", ProductCategory.Fruits ),
            new Product(Guid.NewGuid().ToString(), "Лайм", "30.00",ProductCategory.Fruits ),
            new Product(Guid.NewGuid().ToString(), "Огурец", "8.30", ProductCategory.Vegetables),
            new Product(Guid.NewGuid().ToString(), "Малина", "250.00", ProductCategory.Berries),
            new Product(Guid.NewGuid().ToString(), "Ананасовый сок","390.00", ProductCategory.Juices),
            new Product(Guid.NewGuid().ToString(), "Арахис", "78.00", ProductCategory.Nuts),
        };

        public static List<Product> GetProductsByCategory(ProductCategory category)
        {
            List<Product> result = ProductsList.Where(product => product.ProductType == category).ToList();
            return result;
        }
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
        public static void AddProduct(Product newProduct)
        {
            ProductsList.Add(newProduct);
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
