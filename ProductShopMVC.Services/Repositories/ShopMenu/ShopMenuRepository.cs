using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Npgsql;
using ProductShopMVC.Services.Models.ShopMenu.DbModels;

namespace ProductShopMVC.Services.Repositories.ShopMenu
{
    public static class ShopMenuRepository
    {
        public static List<DbMenuItem> GetDbShopMenu()
        {
            List<DbMenuItem> dbShopMenu = new List<DbMenuItem>();
            using (NpgsqlConnection connection = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["ProductContext"].ConnectionString))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM shopMenu", connection))
                using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                    {
                        dbShopMenu.Add(setDbMenuItem(reader));
                    }
            }
            return dbShopMenu;
        }

        private static DbMenuItem setDbMenuItem(NpgsqlDataReader reader)
        {
            return new DbMenuItem(reader.GetString(0), reader.GetDecimal(1));
        }

    }
}
