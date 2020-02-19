using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductShopMVC.Services.Repositories;
using ProductShopMVC.Services.Models;
using ProductShopMVC.Tools.Response;
using ProductShopMVC.Tools.Errors;



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
        public string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }

        public void AddProduct(AddEditProductModel newProductFromView, out DefaultError outError)
        {
            outError = new DefaultError();

            if (!String.IsNullOrEmpty(outError.errorMessage = CheckProductNullFromView(newProductFromView)))
            {
                return;
            }
            if (!String.IsNullOrEmpty(outError.errorMessage = CheckProductDataFromView(newProductFromView)))
            {
                return;
            }

            ProductRepository.AddProduct(SetProductData(newProductFromView));
        }

        public void EditProduct(AddEditProductModel productFromView, out DefaultError outError)
        {
            outError = new DefaultError();

            if (!String.IsNullOrEmpty(outError.errorMessage = CheckProductNullFromView(productFromView)))
            {
                return;
            }
            if (ProductRepository.GetProductById(productFromView.ProductId) == null)
            {
                outError.errorMessage = "Продукт с таким Id отсутствует в базе!";
                return;
            }
            if (!String.IsNullOrEmpty(outError.errorMessage = CheckProductDataFromView(productFromView)))
            {
                return;
            }

            ProductRepository.EditProduct(SetProductData(productFromView));
        }

        public Product SetProductData(AddEditProductModel productFromView)
        {
            Product newProduct = new Product();
            newProduct.ProductId = String.IsNullOrEmpty(productFromView.ProductId) ? GenerateId() : productFromView.ProductId;
            newProduct.ProductName = productFromView.ProductName;
            newProduct.ProductPrice = productFromView.ProductPrice;
            return newProduct;
        }

        public string CheckProductDataFromView(AddEditProductModel productFromView)
        {
            decimal price;
            if (String.IsNullOrEmpty(productFromView.ProductName))
            {
                return "Ошибка ввода данных. Пустое значение названия продукта!";
            }
            if (String.IsNullOrEmpty(productFromView.ProductPrice))
            {
                return "Ошибка ввода данных. Пустое значение цены продукта!";
            }
            if (Decimal.TryParse(productFromView.ProductPrice, out price))
            {
                return "Ошибка ввода данных. Значение цены продукта не  может быть меньше или равна нулю!";
            }
            return null;
        }
        public string CheckProductNullFromView(AddEditProductModel productFromView)
        {
            if (productFromView == null)
            {
                return "Ошибка данных. Пустая форма с клиенита!";
            }
            else return null;
        }
    }
}

