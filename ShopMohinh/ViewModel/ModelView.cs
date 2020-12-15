using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using ShopMohinh.Models;

namespace ShopMohinh.ViewModel
{
    public class ModelView//tao doi tuong chung cho cac modelde truy van nhieu model
    {
        public IEnumerable<Product> Products { get; set; }
        public Product getProduct { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
        public Customer getCustomer { get; set; }

        //public CustomerInfoModel GetCustomerInfoModel { get; set; }

        public IEnumerable<Account> Accounts { get; set; }
        public Account getAccount { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public Category getCategory { get; set; }

        public IEnumerable<OrderBill> OrderBills { get; set; }
        public OrderBill getOrderBill { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }
        public OrderDetail getOrderDetail { get; set; }

        public IEnumerable<Staff> Staffs { get; set; }
        public Staff getStaff { get; set; }

        public IEnumerable<Position> Positions { get; set; }
        public Position GetPosition { get; set; }

        public IEnumerable<New> News { get; set; }
        public New GetNew { get; set; }

        public IEnumerable<Supplier> Suppliers { get; set; }
        public Supplier getSupplier { get; set; }

        public IEnumerable<ProductDto> Ps { get; set; }
        public ProductDto P { get; set; }
       
    }
}
