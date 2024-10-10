namespace ElectronicGadgets.Models
{
    // entity of Customer
    
    public class Customers
    {
        public int CustomerId { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        // Method to calculate total number of orders
        public int CalculateTotalOrders()
        {
            return 0; // Placeholder logic
        }

        // Method to get customer details
        public void GetCustomerDetails()
        {
            Console.WriteLine($"Customer ID: {CustomerId}");
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone: {Phone}");
            Console.WriteLine($"Address: {Address}");
        }

        // Method to update customer info
        public void UpdateCustomerInfo(string email, string phone, string address)
        {
            Email = email;
            Phone = phone;
            Address = address;
        }
    }

}