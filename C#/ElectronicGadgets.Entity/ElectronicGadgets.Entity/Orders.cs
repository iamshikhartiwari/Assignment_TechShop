namespace ElectronicGadgets.Models;

// entity of order

    
    
    public class Orders
    {
        public int OrderID { get; set; }
        public Customers Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public void CalculateTotalAmount()
        {
            TotalAmount = 0; 
        }

        public void GetOrderDetails()
        {
            Console.WriteLine($"Order ID: {OrderID}");
            Console.WriteLine($"Customer: {Customer.FirstName} {Customer.LastName}");
            Console.WriteLine($"Order Date: {OrderDate}");
            Console.WriteLine($"Total Amount: {TotalAmount:C}"); // Format as currency
        }

        public void UpdateOrderStatus(string status)
        {
            // Update order status logic
        }

        public void CancelOrder()
        {
            // Logic to cancel the order
        }
    }

