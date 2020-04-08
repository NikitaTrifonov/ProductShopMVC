using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductShopMVC.Services.Repositories.Products;
using ProductShopMVC.Services.Models.Products;
using ProductShopMVC.Tools.Errors;
using ProductShopMVC.Tools.Generate;
using ProductShopMVC.Services.Models.Products.Types;
using ProductShopMVC.Services.Models.Products.DbModels;



namespace ProductShopMVC.Services.Services.Products
{
    public class ProductServices
    {
        public Product GetProductById(string id)
        {
            return ConverDbProductToProduct(ProductRepository.GetProductById(id));
        }

        public void DelProduct(string id, out DefaultError outError)
        {
            outError = new DefaultError();
            if (ProductRepository.GetProductById(id) == null)
            {
                outError.ErrorMessage = "Ошибка удаления! Товар отсутствует в базе данных!";
                return;
            }
            ProductRepository.DelProduct(id);
        }
        public List<Product> GetProductsByCategory(string filter, out DefaultError outError)
        {
            outError = new DefaultError();
            int category = (int)CategoryConverter.RusStringToEnum(filter);

            if (category == 1)
                return GetAllProducts(out DefaultError error);

            List<Product> result = ConvertDbProductListToProductList(ProductRepository.GetProductsByCategory(category));
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
            if (name == null)
            {
                outError.ErrorMessage = "Ошибка ввода названия. Пустое значение!";
                return new List<Product>();
            }
            List<Product> result = ConvertDbProductListToProductList(ProductRepository.GetProductsByName(name));
            if (result == null || !result.Any())
            {
                outError.ErrorMessage = "Продукт с данным название отсутствует!";
                return new List<Product>();
            }
            return result;
        }

        public List<Product> GetAllProducts(out DefaultError outError)
        {
            outError = new DefaultError();
            List<Product> result = ConvertDbProductListToProductList(ProductRepository.GetAllProducts());

            if (result == null || !result.Any())
                outError.ErrorMessage = "Список продуктов пуст!!!";

            return result;
        }

        public void AddProduct(AddEditProduct newProductFromView, out DefaultError outError)
        {
            outError = new DefaultError();

            if (!String.IsNullOrEmpty(outError.ErrorMessage = CheckProductNullFromView(newProductFromView)))
                return;

            if (!String.IsNullOrEmpty(outError.ErrorMessage = CheckProductDataFromView(newProductFromView)))
                return;

            ProductRepository.AddProductInBD(SetProductData(newProductFromView));

        }

        public void EditProduct(AddEditProduct productFromView, out DefaultError outError)
        {
            outError = new DefaultError();

            if (!String.IsNullOrEmpty(outError.ErrorMessage = CheckProductNullFromView(productFromView)))
                return;

            if (ProductRepository.GetProductById(productFromView.ProductId) == null)
            {
                outError.ErrorMessage = "Продукт с таким Id отсутствует в базе!";
                return;
            }
            if (!String.IsNullOrEmpty(outError.ErrorMessage = CheckProductDataFromView(productFromView)))
                return;

            ProductRepository.EditProduct(SetProductData(productFromView));
        }


        private DbProduct SetProductData(AddEditProduct productFromView)
        {
            DbProduct newDbProduct = new DbProduct();
            newDbProduct.DbProductId = String.IsNullOrEmpty(productFromView.ProductId) ? GeneratorId.GenerateId() : productFromView.ProductId;
            newDbProduct.DbProductName = productFromView.ProductName;
            newDbProduct.DbProductPrice = Decimal.Parse(productFromView.ProductPrice.Replace(".", ","));
            newDbProduct.DbProductCategory = (int)CategoryConverter.RusStringToEnum(productFromView.ProductCategory);
            return newDbProduct;
        }
        private string CheckProductDataFromView(AddEditProduct productFromView)
        {
            decimal price;
            if (String.IsNullOrEmpty(productFromView.ProductName))
                return "Ошибка ввода данных. Пустое значение названия продукта!";

            if (String.IsNullOrEmpty(productFromView.ProductPrice))
                return "Ошибка ввода данных. Пустое значение цены продукта!";

            if (Decimal.TryParse(productFromView.ProductPrice, out price))
                return "Ошибка ввода данных. Значение цены продукта не  может быть меньше или равна нулю!";

            return null;
        }
        private string CheckProductNullFromView(AddEditProduct productFromView)
        {
            if (productFromView == null)
                return "Ошибка данных. Пустая форма с клиенита!";

            return null;
        }
        private List<Product> ConvertDbProductListToProductList(List<DbProduct> dbProductList)
        {
            List<Product> result = new List<Product>();
            foreach (DbProduct dbProduct in dbProductList)
            {
                result.Add(ConverDbProductToProduct(dbProduct));
            }
            return result;
        }

        private Product ConverDbProductToProduct(DbProduct dbProduct)
        {
            return new Product(dbProduct.DbProductId, dbProduct.DbProductName, dbProduct.DbProductPrice.ToString(), (ProductCategory)dbProduct.DbProductCategory);
        }
    }
}

