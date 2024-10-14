using ElectronicGadgets.Models;

namespace ElectronicGadgets.BussnissLayerLogic.Repository;

public interface IInventoryService
{

    void AddToInventory(Inventory inventory, int quantity);
    void RemoveFromInventory(Inventory inventory, int quantity);
    void UpdateStockQuantity(Inventory inventory, int newQuantity);
    bool IsProductAvailable(Inventory inventory, int quantityToCheck);
    decimal GetInventoryValue(Inventory inventory);
    List<Products> ListLowStockProducts(List<Inventory> inventories, int threshold);
    List<Products> ListOutOfStockProducts(List<Inventory> inventories);
    List<Products> ListAllProducts(List<Inventory> inventories);
}