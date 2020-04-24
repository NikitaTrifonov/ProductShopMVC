using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopMVC.Services.Models.ShopMenu.DbModels
{
    public class DbMenuItem
    {
        public String DbMenuItemProductId { get; set; }
        public Decimal DbMenuItemPrice { get; set; }

        public DbMenuItem(string dbMenuItemProduct, decimal dbMenuItemPrice)
        {
            DbMenuItemProductId = dbMenuItemProduct;
            DbMenuItemPrice = dbMenuItemPrice;
        }

        public DbMenuItem()
        {
        }
    }
}
