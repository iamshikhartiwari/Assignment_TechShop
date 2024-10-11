namespace ElectronicGadgets.Models;

// class of orderDetails
    
public class OrderDetail
{
    public int OrderDetailID { get; set; }
    public Orders Order { get; set; }
    public Products Product { get; set; }
    public int Quantity { get; set; }

  
}
