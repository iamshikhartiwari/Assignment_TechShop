using System;
using ElectronicGadgets.BussnissLayerLogic;
using DBUtils;
using ElectronicGadgetShop.BuisnessLayer;
using ElectronicGadgetShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicGadget.App
{
   public class Program
    {
        static void Main(string[] args)
        {

           
            Customers customer = new Customers();
            customer.CustomerID = 101 ;
            customer.FirstName = "Sejal";
            customer.LastName = "Sihare";
            customer.Email = "sejal22@gmail.com";
            customer.Phone = "99925555";
            customer.Address = "Indore";
            CustomerBuisness customerbuisness = new CustomerBuisness();
            Console.WriteLine("Welcome To Customers");
            customerbuisness.CalculateTotalOrders();
            customerbuisness.GetCustomerDetails(customer);
           customerbuisness.UpdateCustomerInfo(customer, "ss@gmail.com", "8878908876", "Inore");
            customerbuisness.GetCustomerDetails(customer);
            Console.WriteLine("           ");

            Products product = new Products();
            product.ProductID = 1001;
            product.ProductName = "Hp Laptop";
            product.Description = "Electronic Gadget";
            product.Price = 500000M;

            Console.WriteLine(" Welcome To Products Details");

            ProductService productService = new ProductService();
            productService.GetProductDetails(product);
            Console.WriteLine("The Details of Products after Updation");
            productService.UpdateProductInfo(product, "NewGenHp Laptop", 550000M);
            productService.GetProductDetails(product);

            Console.WriteLine("           ");

            Orders order = new Orders();
            order.OrderID = 1002;
            order.Customer = customer;
            order.OrderDate = Convert.ToDateTime("01/01/2024");
            order.TotalAmount = 23000M;

            Console.WriteLine("Welcome to Orders Details");

            OrderService orderservice = new OrderService();
            orderservice.GetOrderDetails(order,customer);
            orderservice.UpdateOrderStatus(order);
            orderservice.CalculateTotalAmount(order);
            orderservice.CancelOrder();
            Console.WriteLine("           ");


            OrderDetails orderdetail = new OrderDetails();
            orderdetail.OrderDetailID = 50001;
            orderdetail.Order = order;
            orderdetail.Product = product;
            orderdetail.Quantity = 2;

            Console.WriteLine("Welcome to Orderdetail Details ");

            OrdeeDetailService orderdetailservice = new OrdeeDetailService();
            orderdetailservice.GetOrderDetailInfo(orderdetail);
            orderdetailservice.UpdateQuantity(orderdetail, 5);
          
            Console.WriteLine("           ");

            Inventory inventory = new Inventory();
            inventory.InventoryID = 200;
            inventory.Product = product;
            inventory.QuantityInStock = 500;
            inventory.LastStockUpdate = DateTime.Now;
            Console.WriteLine("Welcome to Inventory Details");

            InventoryService inventoryService = new InventoryService();
            inventoryService.AddToInventory(inventory, 5);
            Console.WriteLine("The Quantity of Inventory is {0}",inventory.QuantityInStock);
            inventoryService.RemoveFromInventory(inventory, 2);
            Console.WriteLine("The Quantity of Inventory is {0}", inventory.QuantityInStock);
            inventoryService.UpdateStockQuantity(inventory, 10);
            Console.WriteLine("The Quantity of Inventory is {0}", inventory.QuantityInStock);
            if (inventoryService.IsProductAvailable(inventory, 4))
            {
                Console.WriteLine("The Inventory is Available");
            }
            else
            {
                Console.WriteLine("The inventory is out of Stock ");
            }


            Decimal result = inventoryService.GetInventoryValue(inventory, product);
            Console.WriteLine("The value for Inventory is {0}",result);



            Console.WriteLine("Thank You for Visiting TechShop");
            Console.ReadKey();



        }
    }
}