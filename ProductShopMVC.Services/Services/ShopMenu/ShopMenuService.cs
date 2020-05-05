using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductShopMVC.Services.Services.Products;
using ProductShopMVC.Tools.Errors;
using ProductShopMVC.Services.Models.ShopMenu;
using ProductShopMVC.Services.Models.ShopMenu.DbModels;
using ProductShopMVC.Services.Models.Products;
using ProductShopMVC.Services.Models.Products.Types;
using ProductShopMVC.Services.Repositories.ShopMenu;

namespace ProductShopMVC.Services.Services.ShopMenu
{
    public class ShopMenuService
    {
        ProductServices productServices = new ProductServices();

        public List<MenuItem> GetShopMenu(out DefaultError outError)
        {
            List<MenuItem> shopMenu = new List<MenuItem>();
            outError = new DefaultError();
            List<DbMenuItem> dbShopMenu = ShopMenuRepository.GetDbShopMenu();
            List<Product> shopMenuProduct = productServices.GetProductsByIdList(GetMenuItemsIdList(dbShopMenu));
            shopMenu = SetShopMenu(dbShopMenu, shopMenuProduct);
            if (shopMenu == null || !shopMenu.Any())
            {
                outError.ErrorMessage = "Ошибка формирования меню";
                return new List<MenuItem>();
            }
            return shopMenu;
        }

        private List<string> GetMenuItemsIdList(List<DbMenuItem> dbMenuItems)
        {
            List<string> menuItemsIdList = new List<string>();
            foreach (DbMenuItem dbMenuItem in dbMenuItems)
            {
                menuItemsIdList.Add(dbMenuItem.DbMenuItemProductId);
            }
            return menuItemsIdList;
        }

        private List<MenuItem> SetShopMenu(List<DbMenuItem> dbShopMenu, List<Product> shopMenuProducts)
        {
            List<MenuItem> shopMenu = new List<MenuItem>();
            foreach (DbMenuItem dbMenuItem in dbShopMenu)
            {
                Product checkNullProduct = shopMenuProducts.FirstOrDefault(product => product.ProductId == dbMenuItem.DbMenuItemProductId);
                if (checkNullProduct == null)
                    continue;
                shopMenu.Add(SetMuneItem(dbMenuItem, checkNullProduct));
            }
            return shopMenu;
        }

        public List<MenuItem> SortShopMenuByCategories(List<string> comingCategories, out DefaultError outError)
        {
            outError = new DefaultError();
            List<MenuItem> result = new List<MenuItem>();
            List<MenuItem> menuItems = GetShopMenu(out DefaultError error);
            List<int> categories = ConverComingCategories(comingCategories);
            if (menuItems == null)
            {
                outError.ErrorMessage = error.ErrorMessage;
                return new List<MenuItem>();
            }           
            if(categories == null)
            {
                outError.ErrorMessage = "Ошибка сортировки меню";
                return new List<MenuItem>();
            }            
            foreach (MenuItem menuItem in menuItems)
            {
                if (categories.Contains((int)menuItem.Product.ProductType))
                    result.Add(menuItem);
                else
                    continue;
            }
            return result;
        }

        private List<int> ConverComingCategories(List<string> comingCategories)
        {
            List<int> categories = new List<int>();
            foreach (string comingCategory in comingCategories)
            {
                categories.Add((int)CategoryConverter.RusStringToEnum(comingCategory));
            }
            return categories;
        }
        private MenuItem SetMuneItem(DbMenuItem dbMenuItem, Product product)
        {
            return new MenuItem(product, dbMenuItem.DbMenuItemPrice.ToString());
        }

    }
}
