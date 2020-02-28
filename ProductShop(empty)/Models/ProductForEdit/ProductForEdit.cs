using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductShopMVC.Services.Models;
using ProductShop_empty_.Models.Filtres;

namespace ProductShop_empty_.Models.ProductForEdit
{
    public class ProductForEdit
    {
        public Product Data { get; set; }
        public ProductCategoryFilter Category { get; set; }

        public ProductForEdit(Product data)
        {
            Data = data;
            Category = new ProductCategoryFilter();
        }
        public ProductForEdit()
        {          
            Category = new ProductCategoryFilter();
        }

    }

}