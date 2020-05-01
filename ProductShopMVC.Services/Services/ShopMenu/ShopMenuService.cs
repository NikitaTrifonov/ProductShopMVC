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
            shopMenu = setShopMenu(dbShopMenu, shopMenuProduct);
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

        private List<MenuItem> setShopMenu(List<DbMenuItem> dbShopMenu, List<Product> shopMenuProduct)
        {
            List<MenuItem> shopMenu = new List<MenuItem>();
            foreach (DbMenuItem dbMenuItem in dbShopMenu)
            {
                Product checkNullProduct = shopMenuProduct.FirstOrDefault(product => product.ProductId == dbMenuItem.DbMenuItemProductId);
                if (checkNullProduct == null)
                    continue;
                shopMenu.Add(setMuneItem(dbMenuItem, checkNullProduct));
            }
            return shopMenu;
        }

        private MenuItem setMuneItem(DbMenuItem dbMenuItem, Product product)
        {
            return new MenuItem(product, dbMenuItem.DbMenuItemPrice.ToString());
        }

    }
}
