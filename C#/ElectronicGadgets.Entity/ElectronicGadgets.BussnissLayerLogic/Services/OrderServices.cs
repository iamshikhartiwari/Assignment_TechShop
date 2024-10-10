using ElectronicGadgets.BussnissLayerLogic.Repository;
using ElectronicGadgets.Models;
using ElectronicGadgets.BussnissLayerLogic.Services;

namespace ElectronicGadgets.BussnissLayerLogic.Repository;

public class OrderServices(IOrderService orderService)
{
    private readonly IOrderRepository orderRepository;

    public decimal CalculateTotalAmount(Orders orderId)
    {
        return orderRepository.CalculateTotalAmount(orderId);
    }

    public void GetOrderDetails(Orders order)
    {
        orderRepository.GetOrderDetails(order);
    }

    public void UpdateOrderStatus(Orders orderId, string newStatus)
    {
        orderRepository.UpdateOrderStatus(orderId, newStatus);
    }

    public void CancelOrder(int orderId)
    {
        orderRepository.CancelOrder(orderId);
    }
}
