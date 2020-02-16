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

        public List<Product> GetProductsByName(string name, out DefaultError outError)
        {
            outError = new DefaultError();
            if (name == null)
            {
                outError.errorMessage = "Ошибка ввода названия. Пустое значение!";
            }
            else if (ProductRepository.GetProductsByName(name) == null || !ProductRepository.GetProductsByName(name).Any())
            {
                outError.errorMessage = "Продукт с данным название отсутствует!";
            }
            return ProductRepository.GetProductsByName(name);
        }

        public List<Product> GetAllProducts(out DefaultError outError)
        {
            outError = new DefaultError();
            if (ProductRepository.GetAllProducts() == null || !ProductRepository.GetAllProducts().Any())
            {
                outError.errorMessage = "Список продуктов пуст!!!";
            }
            return ProductRepository.GetAllProducts();
        }

        public void EditProduct(AddEditProductModel productFromView, out DefaultError outError)
        {
            decimal price;
            
            outError = new DefaultError();
            if (productFromView == null)
            {
                outError.errorMessage = "Ошибка данных. Пустая фйорма с клиенита!";
            }
            else if (ProductRepository.GetProductById(productFromView.ProductId) == null)
            {
                outError.errorMessage = "Продукт с таким Id отсутствует в базе!";
            }
            else if (String.IsNullOrEmpty(productFromView.ProductName))
            {
                outError.errorMessage = "Ошибка ввода данных. Пустое значение названия продукта!";
            }
            else if (String.IsNullOrEmpty(productFromView.ProductPrice))
            {
                outError.errorMessage = "Ошибка ввода данных. Пустое значение цены продукта!";
            }
            else if (Decimal.TryParse(productFromView.ProductPrice, out price))
            {
                outError.errorMessage = "Ошибка ввода данных. Значение цены продукта не  может быть меньше или равна нулю!";
            }
            Product changedproduct = ProductRepository.GetProductById(productFromView.ProductId);
            changedproduct.ProductName = productFromView?.ProductName;
            changedproduct.ProductPrice = productFromView?.ProductPrice;
            ProductRepository.EditProduct(changedproduct);
        }
    }
}

