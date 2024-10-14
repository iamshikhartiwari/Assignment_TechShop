using ElectronicGadgets.BussnissLayerLogic.Repository;
using ElectronicGadgets.Models;
using ElectronicGadgets.BussnissLayerLogic.Services;


namespace ElectronicGadgets.BussnissLayerLogic.Repository;

public class InventoryServices(IInventoryService inventoryService)
{
    private readonly IInventoryService _inventoryService;

    public Products GetProduct(int productId)
    {
        return inventoryService.GetInventoryValue(productId);
    }

    public int GetQuantityInStock(int product)
    {
        return inventoryService.GetInventoryValue(product);
    }

    public void AddToInventory(int productId, int quantity)
    {
        inventoryService.AddToInventory(productId, quantity);
    }

    public void RemoveFromInventory(int productId, int quantity)
    {
        inventoryService.RemoveFromInventory((productId, quantity);
    }
    
    
}
