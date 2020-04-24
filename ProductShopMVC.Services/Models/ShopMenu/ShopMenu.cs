using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductShopMVC.Services.Models.Products;

namespace ProductShopMVC.Services.Models.ShopMenu
{
    class ShopMenu
    {
        public List<Product> shopMenu = new List<Product>();

        public ShopMenu(List<Product> shopMenu)
        {
            this.shopMenu = shopMenu;
        }
    }
}
