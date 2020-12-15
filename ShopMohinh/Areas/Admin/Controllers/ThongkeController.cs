using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize(Roles = "Admin,Sale")]
    public class ThongkeController : Controller
    {
        private readonly IOrderBillRepository orderBillRepository;
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IProductRepository productRepository;
        public ThongkeController(IProductRepository productRepository,
                                IOrderDetailRepository orderDetailRepository,
                                 IOrderBillRepository orderBillRepository)
        {
            this.orderBillRepository = orderBillRepository;
            this.orderDetailRepository = orderDetailRepository;
            this.productRepository = productRepository;
        }
        [HttpPost]
        public IActionResult LocDoanhthu(string start, string end)
        {
            ViewBag.st = start;
            ViewBag.end = end;
            ModelView m;
            if (!start.Equals("") && !end.Equals(""))
            {
                var Os = new List<OrderBill>();
                foreach (var i in orderBillRepository.OrderBills())
                {
                    if (i.Trangthai.Equals("Đã giao hàng") && i.OrderDate >= DateTime.Parse(start) && i.OrderDate <= DateTime.Parse(end))
                    {
                        Os.Add(i);
                    }
                }
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
                    if (i.Trangthai.Equals("Đã giao hàng") && i.OrderDate >= DateTime.Parse(start) && i.OrderDate >= DateTime.Parse(end))
                    {
                        Os.Add(i);
                    }
                }
                m = new ModelView()
                {
                    OrderBills = Os
                };
            }

            //tk sản phẩm đã bán


            return View(m);

        }
        public IActionResult Doanhthu()
        {
            var Os = new List<OrderBill>();
            foreach (var i in orderBillRepository.OrderBills())
            {
                if (i.Trangthai.Equals("Đã giao hàng"))
                {
                    Os.Add(i);
                }
            }
            ModelView m = new ModelView()
            {
                OrderBills = Os
            };
            return View(m);
        }
        [HttpPost]
        public IActionResult LocDaban(string start, string end)
        {

            var Ps = new List<Product>();
            foreach (var i in orderBillRepository.OrderBills())//duyệt mảng hoá đơn, để tìm các đơn hàng đã thanh toán
            {
                if (i.Trangthai.Equals("Đã giao hàng")&&i.OrderDate>=DateTime.Parse(start)&&i.OrderDate<=DateTime.Parse(end))//-> lấy được mã hoá đơn đã giao hàng
                {
                    foreach (var t in orderDetailRepository.OrderDetails())//->tìm các orderDetail có id hoá đơn đã tìm được
                    {
                        if (t.IDOrder == i.IDOrder)
                        {
                            foreach (var j in productRepository.Products())//với mỗi sản phẩm từ orderDetail ta sẽ lấy thông tin từ sản phẩm                            {
                                if (j.IDProduct == t.IDProduct)
                                {
                                    Ps.Add(j);
                                }
                        }
                    }
                }

            }
            ModelView m = new ModelView()
            {
                Products = Ps

            };
            return View(m);
        }

        public IActionResult Daban()
        {

            var Ps = new List<Product>();
            foreach (var i in orderBillRepository.OrderBills())//duyệt mảng hoá đơn, để tìm các đơn hàng đã thanh toán
            {
                if (i.Trangthai.Equals("Đã giao hàng"))//-> lấy được mã hoá đơn đã giao hàng
                {
                    foreach (var t in orderDetailRepository.OrderDetails())//->tìm các orderDetail có id hoá đơn đã tìm được
                    {
                        if (t.IDOrder == i.IDOrder)
                        {
                            foreach (var j in productRepository.Products())//với mỗi sản phẩm từ orderDetail ta sẽ lấy thông tin từ sản phẩm                            {
                                if (j.IDProduct == t.IDProduct)
                                {
                                    Ps.Add(j);
                                }
                        }
                    }
                }

            }
            ModelView m = new ModelView()
            {
                Products = Ps

            };
            return View(m);
        }


        public IActionResult Conlai()
        {
            ModelView m = new ModelView()
            {
                Products = productRepository.Products()
            };
            return View(m);
        }
    }
}
