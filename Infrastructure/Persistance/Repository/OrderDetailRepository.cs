using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly EFContext context;
        public OrderDetailRepository(EFContext context)
        {
            this.context = context;
        }

        public void createOrderDetail(OrderDetail OrderDetail)
        {
            context.OrderDetails.Add(OrderDetail);
            context.SaveChanges();
        }

        public void editOrderDetail(OrderDetail OrderDetail)
        {
            context.OrderDetails.Update(OrderDetail);
            context.SaveChanges();
        }

        public OrderDetail findByID(int id)
        {
            return context.OrderDetails.Find(id);
        }

        // =========================================================

        public IEnumerable<OrderDetail> OrderDetails()
        {
            return context.OrderDetails.ToList();
        }

        public void removeOrderDetail(int id)
        {
            var OrderDetail = context.OrderDetails.Find(id);
            context.OrderDetails.Remove(OrderDetail);
            context.SaveChanges();
        }
    }
}
