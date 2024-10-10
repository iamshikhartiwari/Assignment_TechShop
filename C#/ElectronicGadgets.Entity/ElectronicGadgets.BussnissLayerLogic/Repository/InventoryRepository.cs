
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using ElectronicGadgets.Models;
using ElectronicGadgets.BussnissLayerLogic.Repository;
namespace ElectronicGadgets.BussnissLayerLogic.Repository
{
    public class InventoryRepository
    {
        private SqlConnection _connection;

        public InventoryRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        // 1. GetProduct(): Retrieve the product associated with this inventory item from the database
        public Products GetProduct(int productId)
        {
            Products product = null;
            string query = "SELECT * FROM Products WHERE ProductId = @ProductId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@ProductId", productId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product = new Products
                        {
                            ProductID = reader.GetInt32(0),
                            ProductName = reader.GetString(1),
                            Price = reader.GetDecimal(2)
                        };
                    }
                }
            }

            return product;
        }

        // 2. GetQuantityInStock(): Get the current quantity of the product in stock
        public int GetQuantityInStock(int productId)
        {
            int quantityInStock = 0;
            string query = "SELECT QuantityInStock FROM Inventory WHERE ProductId = @ProductId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@ProductId", productId);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    quantityInStock = Convert.ToInt32(result);
                }
            }

            return quantityInStock;
        }

        // 3. AddToInventory(): Add a specified quantity to the inventory
        public void AddToInventory(int productId, int quantity)
        {
            string query = "UPDATE Inventory SET QuantityInStock = QuantityInStock + @Quantity WHERE ProductId = @ProductId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                cmd.ExecuteNonQuery();
            }
        }

        // 4. RemoveFromInventory(): Remove a specified quantity from the inventory
        public void RemoveFromInventory(int productId, int quantity)
        {
            string query = "UPDATE Inventory SET QuantityInStock = QuantityInStock - @Quantity WHERE ProductId = @ProductId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                cmd.ExecuteNonQuery();
            }
        }

        // 5. UpdateStockQuantity(): Update the stock quantity to a new value
        public void UpdateStockQuantity(int productId, int newQuantity)
        {
            string query = "UPDATE Inventory SET QuantityInStock = @NewQuantity WHERE ProductId = @ProductId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@NewQuantity", newQuantity);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                cmd.ExecuteNonQuery();
            }
        }

        // 6. IsProductAvailable(): Check if a specified quantity of the product is available
        public bool IsProductAvailable(int productId, int quantityToCheck)
        {
            int quantityInStock = GetQuantityInStock(productId);
            return quantityInStock >= quantityToCheck;
        }

        // 7. GetInventoryValue(): Calculate the total value of the products in the inventory
        public decimal GetInventoryValue(int productId)
        {
            Products product = GetProduct(productId);
            int quantityInStock = GetQuantityInStock(productId);

            return product.Price * quantityInStock;
        }
    }

    public class Inventory
    {
        private SqlConnection _connection;

        public Inventory(SqlConnection connection)
        {
            _connection = connection;
        }

        // 8. ListLowStockProducts(): List products with quantities below a threshold
        public List<Products> ListLowStockProducts(int threshold)
        {
            List<Products> lowStockProducts = new List<Products>();

            string query = @"
                SELECT p.ProductId, p.ProductName, p.Price 
                FROM Products p 
                INNER JOIN Inventory i ON p.ProductId = i.ProductId 
                WHERE i.QuantityInStock < @Threshold";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Threshold", threshold);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Products product = new Products
                        {
                            ProductID = reader.GetInt32(0),
                            ProductName = reader.GetString(1),
                            Price = reader.GetDecimal(2)
                        };

                        lowStockProducts.Add(product);
                    }
                }
            }

            return lowStockProducts;
        }

        // 9. ListOutOfStockProducts(): List products that are out of stock
        public List<Products> ListOutOfStockProducts()
        {
            List<Products> outOfStockProducts = new List<Products>();

            string query = @"
                SELECT p.ProductId, p.ProductName, p.Price 
                FROM Products p 
                INNER JOIN Inventory i ON p.ProductId = i.ProductId 
                WHERE i.QuantityInStock = 0";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Products product = new Products
                        {
                            ProductID = reader.GetInt32(0),
                            ProductName = reader.GetString(1),
                            Price = reader.GetDecimal(2)
                        };

                        outOfStockProducts.Add(product);
                    }
                }
            }

            return outOfStockProducts;
        }

        // 10. ListAllProducts(): List all products in the inventory with their quantities
        public void ListAllProducts()
        {
            string query = @"
                SELECT p.ProductName, i.QuantityInStock, p.Price 
                FROM Products p 
                INNER JOIN Inventory i ON p.ProductId = i.ProductId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("Product Name\tQuantity\tPrice");

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["ProductName"]}\t{reader["QuantityInStock"]}\t{reader["Price"]:C}");
                    }
                }
            }
        }
    }
}
