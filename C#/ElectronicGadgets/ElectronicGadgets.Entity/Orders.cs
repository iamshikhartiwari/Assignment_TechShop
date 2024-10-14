namespace ElectronicGadgets.Models;

// entity of order

    
    
    public class Orders
    {
        public int OrderID { get; set; }
        public Customers Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

       
    }

