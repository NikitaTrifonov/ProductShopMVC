using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductShopMVC.Services.Models.Products;
using ProductShop_empty_.Models.Products;

namespace ProductShop_empty_.Models.Products
{
    public class ProductForEdit
    {
        public Product Data { get; set; }
        public ProductCategories Category { get; set; }

        public ProductForEdit(Product data)
        {
            Data = data;
            Category = new ProductCategories();
        }
        public ProductForEdit()
        {          
            Category = new ProductCategories();
        }

    }

}