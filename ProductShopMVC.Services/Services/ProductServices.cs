using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductShopMVC.Services.Repositories;
using ProductShopMVC.Services.Models;
using ProductShopMVC.Tools.Response;



namespace ProductShopMVC.Services.Services
{
    public class ProductServices
    {

        public Product GetProductById(string id)
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
        public void EditProduct(AddEditProductModel productFromView)
        {
            if (productFromView != null)
            {
                Product changedProduct = ProductRepository.GetProductById(productFromView.ProductId);
                changedProduct.ProductName = productFromView?.ProductName;
                changedProduct.ProductPrice = productFromView?.ProductPrice;
                ProductRepository.EditProduct(changedProduct);
            }
        }
    }
}
