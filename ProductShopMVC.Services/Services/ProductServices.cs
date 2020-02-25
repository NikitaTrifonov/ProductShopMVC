using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductShopMVC.Services.Repositories;
using ProductShopMVC.Services.Models;
using ProductShopMVC.Tools.Errors;
using ProductShopMVC.Tools.Generate;
using ProductShopMVC.Services.Types;



namespace ProductShopMVC.Services.Services
{
    public class ProductServices
    {
        public Product GetProductById(string id)
        {
            return ProductRepository.GetProductById(id);
        }

        public List<Product> GetProductsByCategory(string filter, out DefaultError outError)
        {
            outError = new DefaultError();
            ProductCategory category = CategoryConverter.RusStringToEnum(filter);

            if (category == ProductCategory.Unknow)
            {
                outError.ErrorMessage = "Ошибка! Неизвестная категория!";
                return new List<Product>();
            }

            List<Product> result = ProductRepository.GetProductsByCategory(category);
            if (result == null)
            {
                outError.ErrorMessage = "Ошибка формирования результата фильтрации по категории!";
                return new List<Product>();
            }
            if (!result.Any())
            {
                outError.ErrorMessage = "Нет продуктов в данной категории!";
                return new List<Product>();
            }
            return result;

        }

        public List<Product> GetProductsByName(string name, out DefaultError outError)
        {
            outError = new DefaultError();
            List<Product> result = ProductRepository.GetProductsByName(name);

            if (name == null)
            {
                outError.ErrorMessage = "Ошибка ввода названия. Пустое значение!";
                return new List<Product>();
            }
            if (result == null || !result.Any())
            {
                outError.ErrorMessage = "Продукт с данным название отсутствует!";
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
                outError.ErrorMessage = "Список продуктов пуст!!!";
            }
            return result;
        }


        public void AddProduct(AddEditProductModel newProductFromView, out DefaultError outError)
        {
            outError = new DefaultError();

            if (!String.IsNullOrEmpty(outError.ErrorMessage = CheckProductNullFromView(newProductFromView)))
            {
                return;
            }
            if (!String.IsNullOrEmpty(outError.ErrorMessage = CheckProductDataFromView(newProductFromView)))
            {
                return;
            }

            ProductRepository.AddProduct(SetProductData(newProductFromView));
        }

        public void EditProduct(AddEditProductModel productFromView, out DefaultError outError)
        {
            outError = new DefaultError();

            if (!String.IsNullOrEmpty(outError.ErrorMessage = CheckProductNullFromView(productFromView)))
            {
                return;
            }
            if (ProductRepository.GetProductById(productFromView.ProductId) == null)
            {
                outError.ErrorMessage = "Продукт с таким Id отсутствует в базе!";
                return;
            }
            if (!String.IsNullOrEmpty(outError.ErrorMessage = CheckProductDataFromView(productFromView)))
            {
                return;
            }

            ProductRepository.EditProduct(SetProductData(productFromView));
        }

        private Product SetProductData(AddEditProductModel productFromView)
        {
            Product newProduct = new Product();
            newProduct.ProductId = String.IsNullOrEmpty(productFromView.ProductId) ? GeneratorId.GenerateId() : productFromView.ProductId;
            newProduct.ProductName = productFromView.ProductName;
            newProduct.ProductPrice = productFromView.ProductPrice;
            return newProduct;
        }

        private string CheckProductDataFromView(AddEditProductModel productFromView)
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
        private string CheckProductNullFromView(AddEditProductModel productFromView)
        {
            if (productFromView == null)
            {
                return "Ошибка данных. Пустая форма с клиенита!";
            }
            else return null;
        }
    }
}

