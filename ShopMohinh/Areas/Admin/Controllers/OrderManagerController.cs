using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopMohinh.Models;
using ShopMohinh.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Sale,Admin")]
    public class OrderManagerController : Controller
    {
        private readonly IOrderBillRepository orderBillRepository;
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IProductRepository productRepository;
        public OrderManagerController(IProductRepository productRepository,
                                        IOrderBillRepository orderBillRepository,
                                        IOrderDetailRepository orderDetailRepository)//constructor
        {
            this.orderDetailRepository = orderDetailRepository;
            this.orderBillRepository = orderBillRepository;
            this.productRepository = productRepository;
        }
        public IActionResult Index(string? id)
        {
            ModelView m;
            if (id == null)
            {
                var Os = orderBillRepository.OrderBills();
                m = new ModelView()
                {
                    OrderBills = Os
                };
            }
            else
            {
                var Os = new List<OrderBill>();
                foreach (var i in orderBillRepository.OrderBills())
                {
                    if (i.Trangthai.Equals(id))
                    {
                        Os.Add(i);
                    }
                }
                m = new ModelView()
                {
                    OrderBills = Os
                };
            }


            return View(m);
        }



        [HttpPost]
        public IActionResult OrderManager(string start, string end)
        {
            var Os = new List<OrderBill>();
            //var ODs = orderDetailRepository.OrderDetails();
            //var Ps = productRepository.Products();
            foreach (var i in orderBillRepository.OrderBills())
            {
                if (i.OrderDate >= DateTime.Parse(start) && i.OrderDate <= DateTime.Parse(end))
                {
                    Os.Add(i);
                }
            }
            ModelView m = new ModelView()
            {
                //Products = Ps,
                //OrderDetails = ODs,
                OrderBills = Os
            };

            return View(m);
        }
        public IActionResult OrderDetailManager(int id)
        {
            var O = orderBillRepository.findByID(id);
            var ODs = new List<OrderDetail>();
            foreach (var i in orderDetailRepository.OrderDetails())
            {
                if (i.IDOrder == O.IDOrder)
                {
                    ODs.Add(i);
                }
            }

            ModelView m = new ModelView()
            {

                OrderDetails = ODs,
                getOrderBill = O
            };
            return View(m);
        }
        public IActionResult Dagiaohang(int id)
        {
            var O = orderBillRepository.findByID(id);
            var Os = orderBillRepository.OrderBills();
            O.Trangthai = "Đã giao hàng";
            orderBillRepository.editOrderBill(O);
            ModelView m = new ModelView()
            {
                OrderBills = Os
            };
            Response.Redirect("/Admin/OrderManager/Index");
            return View(m);
        }
        public IActionResult Xacnhan(int id)
        {
            var Os = orderBillRepository.OrderBills();
            var O = orderBillRepository.findByID(id);
            O.Trangthai = "Đang giao hàng";
            orderBillRepository.editOrderBill(O);
            ModelView m = new ModelView()
            {
                OrderBills = Os
            };
            Response.Redirect("/Admin/OrderManager/Index");
            return View(m);
        }
    }
}
