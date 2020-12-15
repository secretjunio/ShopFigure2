using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public interface IOrderBillRepository
    {
        IEnumerable<OrderBill> OrderBills();
        OrderBill findByID(int id);
        void createOrderBill(OrderBill OrderBill);
        void editOrderBill(OrderBill OrderBill);
        void removeOrderBill(int id);
    }
}
