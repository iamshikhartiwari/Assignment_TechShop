using System;
using System.Data.SqlClient;

public class OrderDetail
{
    private SqlConnection _connection;

    public OrderDetail(SqlConnection connection)
    {
        _connection = connection;
    }

    // 1. CalculateSubtotal(): Calculates the subtotal for this order detail (Price * Quantity - Discount)
    public decimal CalculateSubtotal(int orderDetailId)
    {
        decimal subtotal = 0;
        string query = "SELECT Price, Quantity, Discount FROM OrderDetails WHERE OrderDetailId = @OrderDetailId";

        using (SqlCommand cmd = new SqlCommand(query, _connection))
        {
            cmd.Parameters.AddWithValue("@OrderDetailId", orderDetailId);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    decimal price = reader.GetDecimal(0);
                    int quantity = reader.GetInt32(1);
                    decimal discount = reader.GetDecimal(2);

                    subtotal = (price * quantity) - discount;
                }
            }
        }

        return subtotal;
    }

    // 2. GetOrderDetailInfo(): Retrieves and displays information about this order detail
    public void GetOrderDetailInfo(int orderDetailId)
    {
        string query = @"
            SELECT OrderDetailId, OrderId, ProductId, Quantity, Price, Discount 
            FROM OrderDetails 
            WHERE OrderDetailId = @OrderDetailId";

        using (SqlCommand cmd = new SqlCommand(query, _connection))
        {
            cmd.Parameters.AddWithValue("@OrderDetailId", orderDetailId);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine($"OrderDetail ID: {reader["OrderDetailId"]}");
                    Console.WriteLine($"Order ID: {reader["OrderId"]}");
                    Console.WriteLine($"Product ID: {reader["ProductId"]}");
                    Console.WriteLine($"Quantity: {reader["Quantity"]}");
                    Console.WriteLine($"Price: {reader["Price"]:C}");
                    Console.WriteLine($"Discount: {reader["Discount"]:C}");
                }
            }
        }
    }

    // 3. UpdateQuantity(): Allows updating the quantity of the product in this order detail
    public void UpdateQuantity(int orderDetailId, int newQuantity)
    {
        string query = "UPDATE OrderDetails SET Quantity = @NewQuantity WHERE OrderDetailId = @OrderDetailId";

        using (SqlCommand cmd = new SqlCommand(query, _connection))
        {
            cmd.Parameters.AddWithValue("@NewQuantity", newQuantity);
            cmd.Parameters.AddWithValue("@OrderDetailId", orderDetailId);

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Quantity updated successfully.");
            }
            else
            {
                Console.WriteLine("No rows were updated.");
            }
        }
    }

    // 4. AddDiscount(): Applies a discount to this order detail
    public void AddDiscount(int orderDetailId, decimal discount)
    {
        string query = "UPDATE OrderDetails SET Discount = @Discount WHERE OrderDetailId = @OrderDetailId";

        using (SqlCommand cmd = new SqlCommand(query, _connection))
        {
            cmd.Parameters.AddWithValue("@Discount", discount);
            cmd.Parameters.AddWithValue("@OrderDetailId", orderDetailId);

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Discount applied successfully.");
            }
            else
            {
                Console.WriteLine("No rows were updated.");
            }
        }
    }
}
