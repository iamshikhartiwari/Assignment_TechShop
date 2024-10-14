namespace ElectronicGadgets.Models;

public class Inventory
{
    public int InventoryID { get; set; }
    public Products Product { get; set; }
    public int QuantityInStock { get; set; }
    public DateTime LastStockUpdate { get; set; }
    
}