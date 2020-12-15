
using System.Collections.Generic;

namespace ShopMohinh.Models.IRepository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Customers();
        Customer findByID(int id);
        void createCustomer(Customer Customer);
        void editCustomer(Customer Customer);
        void removeCustomer(int id);
    }
}
