using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public class OrderBillRepository : IOrderBillRepository
    {
        private readonly EFContext context;
        public OrderBillRepository(EFContext context)
        {
            this.context = context;
        }

        public void createOrderBill(OrderBill OrderBill)
        {
            context.OrderBills.Add(OrderBill);
            context.SaveChanges();
        }

        public void editOrderBill(OrderBill OrderBill)
        {
            context.OrderBills.Update(OrderBill);
            context.SaveChanges();
        }

        public OrderBill findByID(int id)
        {
            return context.OrderBills.Find(id);
        }

        // =========================================================

        public IEnumerable<OrderBill> OrderBills()
        {
            return context.OrderBills.ToList();
        }

        public void removeOrderBill(int id)
        {
            var OrderBill = context.OrderBills.Find(id);
            context.OrderBills.Remove(OrderBill);
            context.SaveChanges();
        }
    }
}