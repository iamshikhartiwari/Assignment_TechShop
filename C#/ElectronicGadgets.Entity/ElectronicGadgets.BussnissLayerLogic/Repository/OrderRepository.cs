using System;
using System.Data.SqlClient;

public class Order
{
    private SqlConnection _connection;

    public Order(SqlConnection connection)
    {
        _connection = connection;
    }

    // 1. CalculateTotalAmount(): Calculates the total amount of the order by summing subtotals of all order details
    public decimal CalculateTotalAmount(int orderId)
    {
        decimal totalAmount = 0;
        try
        {
            string query = "SELECT Price, Quantity, Discount FROM OrderDetails WHERE OrderId = @OrderId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderId", orderId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        decimal price = reader.GetDecimal(0);
                        int quantity = reader.GetInt32(1);
                        decimal discount = reader.GetDecimal(2);

                        decimal subtotal = (price * quantity) - discount;
                        totalAmount += subtotal;
                    }
                }
            }

            UpdateTotalAmountInOrder(orderId, totalAmount);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error calculating total amount: {ex.Message}");
        }

        return totalAmount;
    }

    private void UpdateTotalAmountInOrder(int orderId, decimal totalAmount)
    {
        try
        {
            string updateQuery = "UPDATE Orders SET TotalAmount = @TotalAmount WHERE OrderId = @OrderId";

            using (SqlCommand cmd = new SqlCommand(updateQuery, _connection))
            {
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                cmd.Parameters.AddWithValue("@OrderId", orderId);

                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating total amount in the order: {ex.Message}");
        }
    }

    // 2. GetOrderDetails(): Retrieves and displays the details of the order, including product list and quantities
    public void GetOrderDetails(int orderId)
    {
        try
        {
            string query = @"
                SELECT OD.OrderDetailId, P.ProductName, OD.Quantity, OD.Price, OD.Discount 
                FROM OrderDetails OD
                JOIN Products P ON OD.ProductId = P.ProductId
                WHERE OD.OrderId = @OrderId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderId", orderId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("Order Detail ID\tProduct Name\tQuantity\tPrice\tDiscount");

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["OrderDetailId"]}\t{reader["ProductName"]}\t{reader["Quantity"]}\t{reader["Price"]:C}\t{reader["Discount"]:C}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving order details: {ex.Message}");
        }
    }

    // 3. UpdateOrderStatus(): Allows updating the status of the order
    public void UpdateOrderStatus(int orderId, string newStatus)
    {
        try
        {
            string query = "UPDATE Orders SET Status = @Status WHERE OrderId = @OrderId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Status", newStatus);
                cmd.Parameters.AddWithValue("@OrderId", orderId);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Order status updated successfully.");
                }
                else
                {
                    Console.WriteLine("Order not found or no changes made.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating order status: {ex.Message}");
        }
    }

    // 4. CancelOrder(): Cancels the order and adjusts stock levels for products
    public void CancelOrder(int orderId)
    {
        try
        {
            string selectQuery = "SELECT ProductId, Quantity FROM OrderDetails WHERE OrderId = @OrderId";

            using (SqlCommand cmd = new SqlCommand(selectQuery, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderId", orderId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int productId = reader.GetInt32(0);
                        int quantity = reader.GetInt32(1);
                        AdjustStockLevel(productId, quantity);
                    }
                }
            }

            string cancelQuery = "UPDATE Orders SET Status = 'Cancelled' WHERE OrderId = @OrderId";

            using (SqlCommand cmd = new SqlCommand(cancelQuery, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderId", orderId);
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("Order has been cancelled and stock levels adjusted.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error canceling the order: {ex.Message}");
        }
    }

    private void AdjustStockLevel(int productId, int quantity)
    {
        try
        {
            string updateStockQuery = "UPDATE Inventory SET QuantityInStock = QuantityInStock + @Quantity WHERE ProductId = @ProductId";

            using (SqlCommand cmd = new SqlCommand(updateStockQuery, _connection))
            {
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adjusting stock level: {ex.Message}");
        }
    }
}
