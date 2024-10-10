using ElectronicGadgets.BussnissLayerLogic;
using ElectronicGadgets.Models;
using ElectronicGadgets.BussnissLayerLogic.Repository;

namespace ElectronicGadgets.BussnissLayerLogic.Services
{
    public class CustomerService(CustomerService customerService, ICustomerRepository customerRepository)
    {
        public int CalculateTotalOrders(Customers customer)
        {
            return customerRepository.CalculateTotalOrders(customer);
        }

        public void GetCustomerDetails(Customers customer)
        {
            customerRepository.GetCustomerDetails(customer);
        }

        public void UpdateCustomerInfo(Customers customer, string newEmail, string newPhone, string newAddress)
        {
            customerRepository.UpdateCustomerInfo(customer, newEmail, newPhone, newAddress);
        }
    }
}