using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductShopMVC.Services.Models.Products;

namespace ProductShopMVC.Services.Models.ShopMenu
{
    public class MenuItem
    {
        public Product Product { get; set; }
        public String MenuItemPrice { get; set; }

        public MenuItem(Product product, string menuItemPrice)
        {
            Product = product;
            MenuItemPrice = menuItemPrice;
        }
        public MenuItem()
        {
        }
    }
}
