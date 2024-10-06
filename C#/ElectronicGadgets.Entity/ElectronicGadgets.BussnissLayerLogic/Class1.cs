using ElectronicGadgets.Models;

namespace ElectronicGadgets.BussnissLayerLogic
{
public class Class1
{
    public class CustomerLogic
    {
        public void CalculateTotalOrders(Customers customer)
        {
            // Logic for calculating total orders
        }

        public void GetCustomerDetails(Customers customer)
        {
            // Logic to retrieve and display customer details
        }

        public void UpdateCustomerInfo(Customers customer, string newEmail, string newPhone, string newAddress)
        {
            customer.Email = newEmail;
            customer.Phone = newPhone;
            customer.Address = newAddress;
        }
    }

    public class ProductLogic
    {
        public void GetProductDetails(Products product)
        {
            // Logic to retrieve and display product details
        }

        public void UpdateProductInfo(Products product, string newDescription, decimal newPrice)
        {
            product.Description = newDescription;
            product.Price = newPrice;
        }

        public bool IsProductInStock(Products product, Inventory inventory)
        {
            return inventory.QuantityInStock > 0;
        }
    }


    public class OrderLogic
    {
        public decimal CalculateTotalAmount(Orders order)
        {
            // Logic to calculate the total order amount
            return order.TotalAmount;
        }

        public void GetOrderDetails(Orders order)
        {
            // Logic to retrieve and display order details
        }

        public void UpdateOrderStatus(Orders order, string newStatus)
        {
            // Logic to update order status
        }

        public void CancelOrder(Orders order)
        {
            // Logic to cancel an order
        }
    }

    
    public class OrderDetailsLogic
    {
        public decimal CalculateSubtotal(OrderDetail orderDetail)
        {
            return orderDetail.Product.Price * orderDetail.Quantity;
        }

        public void GetOrderDetailInfo(OrderDetail orderDetail)
        {
            // Logic to retrieve and display order detail information
        }

        public void UpdateQuantity(OrderDetail orderDetail, int newQuantity)
        {
            orderDetail.Quantity = newQuantity;
        }

        public void AddDiscount(OrderDetail orderDetail, decimal discountAmount)
        {
            // Logic to apply discount to order detail
        }
    }

    public class InventoryLogic
    {
        public void AddToInventory(Inventory inventory, int quantity)
        {
            inventory.QuantityInStock += quantity;
            inventory.LastStockUpdate = DateTime.Now;
        }

        public void RemoveFromInventory(Inventory inventory, int quantity)
        {
            if (inventory.QuantityInStock >= quantity)
            {
                inventory.QuantityInStock -= quantity;
                inventory.LastStockUpdate = DateTime.Now;
            }
            else
            {
                throw new Exception("Not enough stock to remove the specified quantity.");
            }
        }

        public void UpdateStockQuantity(Inventory inventory, int newQuantity)
        {
            inventory.QuantityInStock = newQuantity;
            inventory.LastStockUpdate = DateTime.Now;
        }

        public bool IsProductAvailable(Inventory inventory, int quantityToCheck)
        {
            return inventory.QuantityInStock >= quantityToCheck;
        }

        public decimal GetInventoryValue(Inventory inventory)
        {
            return inventory.Product.Price * inventory.QuantityInStock;
        }

        public List<Products> ListLowStockProducts(List<Inventory> inventories, int threshold)
        {
            return inventories.Where(i => i.QuantityInStock < threshold).Select(i => i.Product).ToList();
        }

        public List<Products> ListOutOfStockProducts(List<Inventory> inventories)
        {
            return inventories.Where(i => i.QuantityInStock == 0).Select(i => i.Product).ToList();
        }

        public List<Products> ListAllProducts(List<Inventory> inventories)
        {
            return inventories.Select(i => i.Product).ToList();
        }
    }

    
}

}