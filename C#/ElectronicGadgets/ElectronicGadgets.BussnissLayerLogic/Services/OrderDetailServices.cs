using ElectronicGadgets.BussnissLayerLogic;
using ElectronicGadgets.Models;
using ElectronicGadgets.BussnissLayerLogic.Repository;
using System.Data.SqlClient;

namespace ElectronicGadgets.BussnissLayerLogic.Repository;

public class OrderDetailServices(OrderDetailServices orderDetailServices, IOrderDetailService orderDetailService)
{
    private readonly IOrderDetailRepository orderDetailRepository;

    public decimal CalculateSubtotal(int orderDetailId)
    {
        return orderDetailRepository.CalculateSubtotal(orderDetailId);
    }

    public void GetOrderDetailInfo(int orderDetailId)
    {
        orderDetailRepository.GetOrderDetailInfo(orderDetailId);
    }

    public void UpdateQuantity(int orderDetailId, int newQuantity)
    {
        orderDetailRepository.UpdateQuantity(orderDetailId, newQuantity);
    }

    public void AddDiscount(int orderDetailId, decimal discount)
    {
        orderDetailRepository.AddDiscount(orderDetailId, discount);
    }

}    