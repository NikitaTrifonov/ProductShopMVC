using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductShopMVC.Services.Types;

namespace ProductShop_empty_.Models.Filtres
{
    public class ProductCategoryFilter
    {
        public List<string> ProductCategory
        {
            get
            {
                return Enum.GetValues(typeof(ProductCategory))
  .Cast<ProductCategory>()
  .Select(v => CategoryConverter.EnumToRusString(v))
  .ToList();
            }
        }
    }
}