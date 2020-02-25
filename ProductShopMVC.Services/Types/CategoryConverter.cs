using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopMVC.Services.Types
{
    public static class CategoryConverter
    {
        public static string EnumToRusString(ProductCategory category)
        {
            switch (category)
            {
                case ProductCategory.Berries:
                    return "Ягоды";

                case ProductCategory.Fruits:
                    return "Фрукты";

                case ProductCategory.Juices:
                    return "Соки";

                case ProductCategory.Nuts:
                    return "Орехи";

                case ProductCategory.Vegetables:
                    return "Овощи";
            }
            return "Все продукты";
        }

        public static ProductCategory RusStringToEnum(string filter)
        {
            ProductCategory outCategory = ProductCategory.Unknow;
            switch (filter)
            {
                case "Ягоды":
                    outCategory = ProductCategory.Berries;
                    break;
                case "Фрукты":
                    outCategory = ProductCategory.Fruits;
                    break;
                case "Соки":
                    outCategory = ProductCategory.Juices;
                    break;
                case "Орехи":
                    outCategory = ProductCategory.Nuts;
                    break;
                case "Овощи":
                    outCategory = ProductCategory.Vegetables;
                    break;
            }
            return outCategory;
        }
    }
}
