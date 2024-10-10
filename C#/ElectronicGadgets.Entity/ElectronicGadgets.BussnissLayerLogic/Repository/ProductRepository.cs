using System;
using System.Data.SqlClient;

public class Product
{
    private SqlConnection _connection;

    public Product(SqlConnection connection)
    {
        _connection = connection;
    }

    // 1. GetProductDetails(): Retrieves and displays detailed information about the product
    public void GetProductDetails(int productId)
    {
        try
        {
            string query = "SELECT * FROM Products WHERE ProductId = @ProductId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@ProductId", productId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Product ID: {reader["ProductId"]}");
                        Console.WriteLine($"Product Name: {reader["ProductName"]}");
                        Console.WriteLine($"Price: {reader["Price"]:C}");
                        Console.WriteLine($"Description: {reader["Description"]}");
                        Console.WriteLine($"Quantity in Stock: {reader["QuantityInStock"]}");
                    }
                    else
                    {
                        Console.WriteLine("Product not found.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving product details: {ex.Message}");
        }
    }

    // 2. UpdateProductInfo(): Allows updates to product details (e.g., price, description)
    public void UpdateProductInfo(int productId, decimal newPrice, string newDescription)
    {
        try
        {
            string updateQuery = "UPDATE Products SET Price = @Price, Description = @Description WHERE ProductId = @ProductId";

            using (SqlCommand cmd = new SqlCommand(updateQuery, _connection))
            {
                cmd.Parameters.AddWithValue("@Price", newPrice);
                cmd.Parameters.AddWithValue("@Description", newDescription);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Product information updated successfully.");
                }
                else
                {
                    Console.WriteLine("Product not found or no changes made.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating product information: {ex.Message}");
        }
    }

    // 3. IsProductInStock(): Checks if the product is currently in stock
    public bool IsProductInStock(int productId)
    {
        try
        {
            string query = "SELECT QuantityInStock FROM Products WHERE ProductId = @ProductId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@ProductId", productId);

                int quantityInStock = (int)cmd.ExecuteScalar();

                return quantityInStock > 0;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error checking product stock: {ex.Message}");
            return false;
        }
    }
}
