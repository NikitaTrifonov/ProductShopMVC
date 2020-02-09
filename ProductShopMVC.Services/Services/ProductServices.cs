using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductShopMVC.Services.Repositories;
using ProductShopMVC.Services.Models;

namespace ProductShopMVC.Services.Services
{
    public class ProductServices
    {

        public Product GetProductById(int id)
        {
            return ProductRepository.GetProductById(id);
        }

        public List<Product> GetProductsByName(string name)
        {
            return ProductRepository.GetProductsByName(name);
        }

        public List<Product> GetAllProducts()
        {
            return ProductRepository.GetAllProducts();
        }
         public void EditProduct(Product product)
        {
            ProductRepository.EditProduct(product);
        }
    }
}
