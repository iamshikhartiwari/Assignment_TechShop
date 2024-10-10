using ElectronicGadgets.Models;
using ElectronicGadgets.BussnissLayerLogic.Repository;
using System.Data.SqlClient;
using DBUtils;


namespace ElectronicGadgets.BussnissLayerLogic.Repository{
    
public class CustomerRepository : ICustomerRepository {
 
        public int CalculateTotalOrders(Customers customer)
        {
            int customer_id = customer.CustomerId;
            string query = "SELECT COUNT(*) AS TotalOrders FROM Orders WHERE CustomerID = @customer_id";
            int totalOrders = 0;

            var conn = DBUtils.DBUtils.getDBConnection();

            try
            {
                conn.Open();
                
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@CustomerID", customer_id);
                    totalOrders = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
            
            
            return totalOrders;
        }

        public void GetCustomerDetails(Customers customer)
        {
            int customer_id = customer.CustomerId;
            string query =
                "SELECT CustomerID, FirstName, LastName, Email, Phone, Address FROM Customers WHERE CustomerID = @Customer_id";


            using (var connection = DBUtils.DBUtils.getDBConnection())
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customer_id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    int customerID = reader.GetInt32(0);
                                    string firstName = reader.GetString(1);
                                    string lastName = reader.GetString(2);
                                    string email = reader.GetString(3);
                                    string phone = reader.GetString(4);
                                    string address = reader.GetString(5);

                                    Console.WriteLine($"Customer ID: {customerID}");
                                    Console.WriteLine($"Name: {firstName} {lastName}");
                                    Console.WriteLine($"Email: {email}");
                                    Console.WriteLine($"Phone: {phone}");
                                    Console.WriteLine($"Address: {address}");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No customer found with the provided CustomerID.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }

            }
        }
        
        public void UpdateCustomerInfo(Customers customer, string newEmail, string newPhone, string newAddress)
        {
            int customer_id = customer.CustomerId;
            
            var conn = DBUtils.DBUtils.getDBConnection();

            string query = "SELECT CustomerID, FirstName, LastName, Email, Phone, Address FROM Customers WHERE CustomerID = @CustomerID";

            try
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@CustomerID", customer_id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int customerID = reader.GetInt32(0);
                                string firstName = reader.GetString(1);
                                string lastName = reader.GetString(2);
                                string email = reader.GetString(3);
                                string phone = reader.GetString(4);
                                string address = reader.GetString(5);

                                Console.WriteLine($"Customer ID: {customerID}");
                                Console.WriteLine($"Name: {firstName} {lastName}");
                                Console.WriteLine($"Email: {email}");
                                Console.WriteLine($"Phone: {phone}");
                                Console.WriteLine($"Address: {address}");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No customer found with the provided CustomerID.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
            
            
        }
        
        
    }
}