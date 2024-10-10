using ElectronicGadgets.Models;

namespace ElectronicGadgets.BussnissLayerLogic.Repository;

public interface IOrderRepository
{
    int CalculateTotalAmount(Orders order);
    void GetOrderDetails(Orders order);
    void UpdateOrderStatus(Orders order, string newStatus);
    void CancelOrder(Orders order);
}