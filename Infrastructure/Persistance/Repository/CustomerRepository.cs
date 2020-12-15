using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMohinh.Models.IRepository;

namespace ShopMohinh.Models.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly EFContext context;
        public CustomerRepository(EFContext context)
        {
            this.context = context;
        }

        public void createCustomer(Customer Customer)
        {
            context.Customers.Add(Customer);
            context.SaveChanges();
        }

        public void editCustomer(Customer Customer)
        {
            context.Customers.Update(Customer);
            context.SaveChanges();
        }

        public Customer findByID(int id)
        {
            return context.Customers.Find(id);
        }

        // =========================================================

        public IEnumerable<Customer> Customers()
        {
            return context.Customers.ToList();
        }

        public void removeCustomer(int id)
        {
            var Customer = context.Customers.Find(id);
            context.Customers.Remove(Customer);
            context.SaveChanges();
        }
    }
}
