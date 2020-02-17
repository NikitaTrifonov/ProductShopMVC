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
            List<Product> result = ProductRepository.GetProductsByName(name);

            if (name == null)
            {
                outError.errorMessage = "Ошибка ввода названия. Пустое значение!";
                return new List<Product>();
            }
            if (result == null || !result.Any())
            {
                outError.errorMessage = "Продукт с данным название отсутствует!";
                return new List<Product>();
            }
            return ProductRepository.GetProductsByName(name);
        }

        public List<Product> GetAllProducts(out DefaultError outError)
        {
            outError = new DefaultError();
            List<Product> result = ProductRepository.GetAllProducts();

            if (result == null || !result.Any())
            {
                outError.errorMessage = "Список продуктов пуст!!!";
            }
            return result;
        }

        public void EditProduct(AddEditProductModel productFromView, out DefaultError outError)
        {
            decimal price;
            outError = new DefaultError();

            if (productFromView == null)
            {
                outError.errorMessage = "Ошибка данных. Пустая фйорма с клиенита!";
                return;
            }
            Product changedproduct = ProductRepository.GetProductById(productFromView.ProductId);

            if (changedproduct == null)
            {
                outError.errorMessage = "Продукт с таким Id отсутствует в базе!";
                return;
            }
            if (String.IsNullOrEmpty(productFromView.ProductName))
            {
                outError.errorMessage = "Ошибка ввода данных. Пустое значение названия продукта!";
                return;
            }
            if (String.IsNullOrEmpty(productFromView.ProductPrice))
            {
                outError.errorMessage = "Ошибка ввода данных. Пустое значение цены продукта!";
                return;
            }
            if (Decimal.TryParse(productFromView.ProductPrice, out price))
            {
                outError.errorMessage = "Ошибка ввода данных. Значение цены продукта не  может быть меньше или равна нулю!";
                return;
            }
            changedproduct.ProductName = productFromView?.ProductName;
            changedproduct.ProductPrice = productFromView?.ProductPrice;
            ProductRepository.EditProduct(changedproduct);
        }
    }
}

