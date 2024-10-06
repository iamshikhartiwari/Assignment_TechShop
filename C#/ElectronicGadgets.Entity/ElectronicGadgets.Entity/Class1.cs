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
    
    // class of orderDetails
    
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public Orders Order { get; set; }
        public Products Product { get; set; }
        public int Quantity { get; set; }

        public decimal CalculateSubtotal()
        {
            return Quantity * Product.Price;
        }

        public void GetOrderDetailInfo()
        {
            Console.WriteLine($"Order Detail ID: {OrderDetailID}");
            Console.WriteLine($"Product: {Product.ProductName}");
            Console.WriteLine($"Quantity: {Quantity}");
            Console.WriteLine($"Subtotal: {CalculateSubtotal():C}"); 
        }

        public void UpdateQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }

        public void AddDiscount(decimal discountPercentage)
        {
            // Logic to apply a discount (not implemented here)
        }
    }
    
    
    // entity of product
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public void GetProductDetails()
        {
            Console.WriteLine($"Product ID: {ProductID}");
            Console.WriteLine($"Name: {ProductName}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Price: {Price:C}"); 
        }

        public void UpdateProductInfo(string description, decimal price)
        {
            Description = description;
            Price = price;
        }

        public bool IsProductInStock()
        {
            return true;
        }
    }
    
    // entity of inventory
    
    public class Inventory
    {
        public int InventoryID { get; set; }
        public Products Product { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime LastStockUpdate { get; set; }

        public Products GetProduct()
        {
            return Product;
        }

        public int GetQuantityInStock()
        {
            return QuantityInStock;
        }

        public void AddToInventory(int quantity)
        {
            QuantityInStock += quantity;
            LastStockUpdate = DateTime.Now;
        }

        public void RemoveFromInventory(int quantity)
        {
            QuantityInStock -= quantity;
            LastStockUpdate = DateTime.Now;
        }

        public void UpdateStockQuantity(int newQuantity)
        {
            QuantityInStock = newQuantity;
            LastStockUpdate = DateTime.Now;
        }

        public bool IsProductAvailable(int quantityToCheck)
        {
            return QuantityInStock >= quantityToCheck;
        }

        public decimal GetInventoryValue()
        {
            return QuantityInStock * Product.Price;
        }

        public void ListLowStockProducts(int threshold)
        {
            if (QuantityInStock < threshold)
            {
                Console.WriteLine($"Low stock for {Product.ProductName}: {QuantityInStock} left.");
            }
        }

        public void ListOutOfStockProducts()
        {
            if (QuantityInStock == 0)
            {
                Console.WriteLine($"Out of stock: {Product.ProductName}");
            }
        }
    }
}