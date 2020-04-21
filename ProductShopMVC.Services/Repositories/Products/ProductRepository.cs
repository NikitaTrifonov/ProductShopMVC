using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Npgsql;
using ProductShopMVC.Services.Models.Products;
using ProductShopMVC.Services.Models.Products.Types;
using ProductShopMVC.Services.Models.Products.DbModels;




namespace ProductShopMVC.Services.Repositories.Products
{
    public static class ProductRepository
    {
        public static void DelProduct(string id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["ProductContext"].ConnectionString))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("DELETE FROM products " +
                                              "WHERE productId = @id", connection))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteReader();
                }
            }
        }

        public static List<DbProduct> GetProductsByCategory(int category)
        {
            List<DbProduct> result = new List<DbProduct>();
            using (NpgsqlConnection connection = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["ProductContext"].ConnectionString))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM products " +
                                                   "WHERE productcategory = @category", connection))
                {
                    cmd.Parameters.AddWithValue("category", category);
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            result.Add(setDbProduct(reader));
                        }
                }
            }
            return result;
        }
        public static DbProduct GetProductById(string id)
        {
            DbProduct result = new DbProduct();
            using (NpgsqlConnection connection = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["ProductContext"].ConnectionString))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM products " +
                                                   "WHERE productid = @productId", connection))
                {
                    cmd.Parameters.AddWithValue("productid", id);
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            result = setDbProduct(reader);
                        }
                }
            }
            return result;
        }
        public static List<DbProduct> GetProductsByName(string name)
        {
            List<DbProduct> result = new List<DbProduct>();
            using (NpgsqlConnection connection = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["ProductContext"].ConnectionString))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM products " +
                                                   "WHERE productname ILIKE @name", connection))
                {
                    cmd.Parameters.AddWithValue("name", name);
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            result.Add(setDbProduct(reader));
                        }
                }
            }
            return result;
        }

        public static List<DbProduct> GetAllProducts()
        {
            List<DbProduct> result = new List<DbProduct>();
            using (NpgsqlConnection connection = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["ProductContext"].ConnectionString))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM products", connection))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        result.Add(setDbProduct(reader));
                    }
            }
            return result;
        }

        public static void EditProduct(DbProduct changedProduct)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["ProductContext"].ConnectionString))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("UPDATE products " +
                                                   "SET productname = @name, productprice = @price, productcategory = @category, imageRes = @res " +
                                                   "WHERE productid = @id", connection))
                {
                    cmd.Parameters.AddWithValue("name", changedProduct.DbProductName);
                    cmd.Parameters.AddWithValue("price", changedProduct.DbProductPrice);
                    cmd.Parameters.AddWithValue("category", changedProduct.DbProductCategory);
                    cmd.Parameters.AddWithValue("res", changedProduct.DbImageRes);
                    cmd.Parameters.AddWithValue("id", changedProduct.DbProductId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddProductInBD(DbProduct newDbProduct)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["ProductContext"].ConnectionString))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO products (productid, productname, productprice, productcategory, imageRes) " +
                                                   "VALUES (@productid, @productname, @productprice, @productcategory, @imageRes)", connection))
                {
                    cmd.Parameters.AddWithValue("productid", newDbProduct.DbProductId);
                    cmd.Parameters.AddWithValue("productname", newDbProduct.DbProductName);
                    cmd.Parameters.AddWithValue("productprice", newDbProduct.DbProductPrice);
                    cmd.Parameters.AddWithValue("productcategory", newDbProduct.DbProductCategory);
                    cmd.Parameters.AddWithValue("imageRes", newDbProduct.DbImageRes);
                    cmd.ExecuteNonQuery();
                }
            }

        }
        private static DbProduct setDbProduct(NpgsqlDataReader reader)
        {
            return new DbProduct(reader.GetString(0), reader.GetString(1), reader.GetDecimal(2), reader.GetInt32(3), reader.GetString(4));
        }
    }
}
