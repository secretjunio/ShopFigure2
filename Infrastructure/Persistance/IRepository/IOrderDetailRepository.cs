using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> OrderDetails();
        OrderDetail findByID(int id);
        void createOrderDetail(OrderDetail OrderDetail);
        void editOrderDetail(OrderDetail OrderDetail);
        void removeOrderDetail(int id);
    }
}
