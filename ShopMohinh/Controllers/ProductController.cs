using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopMohinh.Models;
using ShopMohinh.Models.IRepository;
using ShopMohinh.ViewModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopMohinh.Service;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using MimeKit;

namespace ShopMohinh.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository ProductRepository;
        private readonly ICategoryRepository CategoryRepository;
        private readonly ISupplierRepository SupplierRepository;
        private EFContext _db;
        private readonly IMapper _mapper;
        private readonly IMailService mailService; // mới nè, của mail nè
        private readonly IWebHostEnvironment _env; // mới nè
        private readonly IOrderBillRepository orderBillRepository;
        public ProductController(IMapper mapper, IProductRepository ProductRepository,
            ISupplierRepository SupplierRepository, ICategoryRepository CategoryRepository,
            EFContext dbcontext, IMailService mailService, IWebHostEnvironment env, IOrderBillRepository orderBillRepository)
        {
            this.ProductRepository = ProductRepository;
            this.SupplierRepository = SupplierRepository;
            this.CategoryRepository = CategoryRepository;
            this._db = dbcontext;
            this._mapper = mapper;
            this.mailService = mailService; // đưa nó vào hàm khởi tạo đó nha
            _env = env;
            this.orderBillRepository = orderBillRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> Products = ProductRepository.Products();
            IEnumerable<Category> Categories = CategoryRepository.Categories();
            IEnumerable<Supplier> Suppliers = SupplierRepository.Suppliers();
            ModelView modelView = new ModelView()
            {
                Products = Products,
                Categories = Categories,
                Suppliers = Suppliers
            };


            ///Send Emaill
            ///


            //View Thanks 

            return View(modelView);
        }

        public string CreatOderDetailHTML(List<OrderDetail> lstorderdetail, double? total, double? ship) // total là tổng số tiền đơn hàng
        {
            // làm 1 html động bằng cách cộng chuỗi
            double sumorder = total.Value + ship.Value;
            string body = "<table width='650' cellspacing='0' cellpadding='0' border='0' style='border: 1px solid #eaeaea'>";
            body += "<thead>";
            body += "<tr>";
            body += "<th bgcolor='#CE4646' align='left' style='font-size: 13px; color:#fff; padding: 3px 9px'>Mặt hàng</th>";
            body += " <th bgcolor='#CE4646' align='left' style='font-size:13px;padding:3px 9px'></th>";
            body += "<th bgcolor='#CE4646' align='center' style='font-size: 13px; color:#fff; padding: 3px 9px'>Số lượng</th>";
            body += " <th bgcolor='#CE4646' align='right' style='font-size: 13px; color:#fff; padding: 3px 9px'>Tổng tiền</th>";
            body += "</tr>";
            body += "</thead>";
            foreach (var item in lstorderdetail)
            {

                //var product = _db.Products.Where(x => x.ID == item.ProductId).FirstOrDefault();

                body += "<tr>";
                body += " <td valign='top' align='left' style='font-size: 11px; padding: 3px 9px; border-bottom: 1px dotted #cccccc'>";
                body += "<strong style='font-size: 11px'>" + item.ProductName + "</strong>";
                body += "<dl style='margin: 0; padding: 0'>";
                body += "<dt><strong><em>Màu sắc hoặc kiểu dáng</em></strong></dt>";

                body += "<dd style='margin: 0; padding: 0 0 0 9px'>" + item.ColorSize + "</dd>";

                body += "</dl>";
                body += "</td>";
                body += "<td valign='top' align='left' style='font-size:11px;padding:3px 9px;border-bottom:1px dotted #cccccc'></td>";
                body += "<td valign='top' align='center' style='font-size: 11px; padding: 3px 9px; border-bottom: 1px dotted #cccccc'>" + item.Number + "</td>";
                body += "<td valign='top' align='right' style='font-size: 11px; padding: 3px 9px; border-bottom: 1px dotted #cccccc'>";
                body += "<span>" + string.Format("{0:0,0 đ}", item.Price) + "</span>";
                body += "</td>";
                body += "</tr>";
            }
            body += "<tr>";
            body += "<td align='right' style='padding: 3px 9px' colspan='3'>Tổng tiền</td>";
            body += "<td align='right' style='padding: 3px 9px'>";
            body += "<span>" + string.Format("{0:0,0 đ}", total) + "</span></td>";
            body += "</tr>";
            body += "<tr>";
            // khúc dưới làm khi nếu đơn hàng có phí vận chuyển
            //body += "<td align='right' style='padding: 3px 9px' colspan='3'>Phí vận chuyển</td>";
            //body += "<td align='right' style='padding: 3px 9px'>";
            //body += "<span>" + string.Format("{0:0,0 đ}", ship) + "</span>                    </td>";
            //body += "</tr>";
            //body += "<tr>";
            //body += "<td align='right' style='padding: 3px 9px' colspan='3'>";
            //body += "<strong>Tổng cộng</strong>";
            //body += "</td>";
            //body += "<td align='right' style='padding: 3px 9px'>";
            //body += "<strong><span>" + string.Format("{0:0,0 đ}", sumorder) + "</span></strong>";
            //body += "</td>";
            //body += "</tr>";
            body += " </table>";
            return body;
        }
       
        public IActionResult Detail(int id)
        {
            Product P = ProductRepository.findByID(id); //getDetailProduct(id);
            var C = CategoryRepository.Categories();
            var S = SupplierRepository.Suppliers();
            ModelView m = new ModelView()
            {
                getProduct = P,
                Categories = C,
                Suppliers = S
            };
            return View(m);
        }

        public IActionResult Sort(int id)
        {
            var l = CategoryRepository.Categories();
            var c = CategoryRepository.findByID(id);
            var p = ProductRepository.Products();

            ModelView m = new ModelView()
            {
                getCategory = c,
                Products = p,
                Categories = l
            };

            return View(m);
        }

        #region Cart
        //Danh sách giỏ hàng
        public IActionResult ListCart()
        {
            var C = CategoryRepository.Categories();
            var cart = HttpContext.Session.GetString("cart"); //HttpContext lấy được các thông tin session từ người dùng 
            if (cart != null)
            {
                List<CartModel> dataCart = JsonConvert.DeserializeObject<List<CartModel>>(cart); // DeserializeObject : chuyển json -> object
                if (dataCart.Count > 0)
                {
                    ViewBag.carts = dataCart;
                }
            }
            ModelView m = new ModelView()
            {
                Categories = C
            };
            return View(m);
        }

        //Thêm 1 item vào giỏ hàng
        //Khi thêm vào check sản phẩm có tồn tại chưa? có thì tăng số lượng, không có thì thêm mới (action 
        public IActionResult addCart(int id) // id product 
        {
            var cart = HttpContext.Session.GetString("cart");//get key cart
            if (cart == null)
            {
                var product = getDetailProduct(id);
                List<CartModel> listCart = new List<CartModel>()
                {
                    new CartModel
                    {
                        Product = product,
                        Number = 1
                    }
                };
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(listCart)); // gán dữ liệu cho nó, SerializeObject : chuyển object -> json string (có định dạng là key:value)
            }
            else
            {
                //todo something
                List<CartModel> dataCart = JsonConvert.DeserializeObject<List<CartModel>>(cart); // DeserializeObject : chuyển json -> object
                bool check = true;
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Product.IDProduct == id) // nếu chọn sp đó thêm vào giỏ quài thì nó cứ tăng số lượng lên 1
                    {
                        dataCart[i].Number++;
                        check = false;
                        break;
                    }
                }

                if (check == true) // 1 sản phẩm mà được thêm mới k trùng sản phẩm cũ
                {
                    dataCart.Add(new CartModel // khởi tạo gán giá trị cho nó
                    {
                        Product = getDetailProduct(id),
                        Number = 1

                    });
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
            }
            return RedirectToAction(nameof(ListCart));
        }

        private Product getDetailProduct(int id)
        {
            var product = _db.Products.Find(id);
            return product;
        }

        //Update số lượng sản phẩm đã đưa vào giỏ hàng (Ajax request) 
        // ví dụ :  iphone 8 số lương 1 -->  2 sau đó update
        [HttpPost]
        public IActionResult updateCart(int Id, int Quantity)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<CartModel> dataCart = JsonConvert.DeserializeObject<List<CartModel>>(cart);

                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Product.IDProduct == Id)
                    {
                        if (Quantity == 0)  // nếu số lượng cập nhật = 0  thì xóa sp khỏi giỏ hàng
                        {
                            dataCart.Remove(dataCart[i]);
                        }
                        else
                        {
                            var numberProduct = ProductRepository.findByID(Id).Number;
                            if (Quantity > numberProduct)
                            {
                                dataCart[i].Number = numberProduct;
                            }
                            else
                            {
                                dataCart[i].Number = Quantity; // cập nhật gán lại số lượng mới
                            }
                        }

                        
                    }
                }

                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                return Ok(Quantity);
            }
            return BadRequest();
        }

        //Xóa sản phẩm trong giỏ hàng đi (link)
        public IActionResult deleteCart(int id)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<CartModel> dataCart = JsonConvert.DeserializeObject<List<CartModel>>(cart);
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Product.IDProduct == id)
                    {
                        dataCart.RemoveAt(i);
                    }
                }

                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
            }
            return RedirectToAction(nameof(ListCart));
        }
        #endregion

        [Route("/Checkout")]
        public IActionResult Checkout()
        {
            //Get CustomerInfo từ trong session ra
            //CustomerInfo
            //var C = CategoryRepository.Categories();
            //ModelView m = new ModelView()
            //{
            //    Categories = C
            //};
            //return View(m);
            var customerinfor = new CustomerInfo();
            var lstCT_Provinces = _db.CT_Provinces.ToList();
            var lstCT_Districts = _db.CT_Districts.ToList();
            var lstWards = _db.CT_Wards.ToList();
            if (this.User.Identity.IsAuthenticated) // có đăng nhập, có login
            {
                customerinfor = _db.CustomerInfo.Where(x => x.UserName == this.User.Identity.Name).First();

                ViewBag.Provices = new SelectList(lstCT_Provinces, "ID", "Name", customerinfor.ProviceID != null ? customerinfor.ProviceID : 0);

                if (customerinfor.ProviceID != null)
                {
                    ViewBag.Districts = new SelectList(lstCT_Districts.Where(m => m.ProvinceID == customerinfor.ProviceID.ToString()).ToList(), "ID", "Name",
                                customerinfor.DistrictID);
                }
                else
                {
                    ViewBag.Districts = new SelectList(lstCT_Districts.ToList(), "ID", "Name", 0);
                }

                if (customerinfor.DistrictID != null)
                {
                    ViewBag.Wards = new SelectList(lstWards.Where(m => m.ID == customerinfor.DistrictID).ToList(), "ID", "Name", customerinfor.WardID);
                }
                else
                {
                    ViewBag.Wards = new SelectList(lstWards.Where(m => m.ID == customerinfor.DistrictID).ToList(), "ID", "Name", 0);
                }
            }
            else // trường hợp không login thì danh sách sẽ như này, m sửa cái này nè Thiên
            {
                //AddRange có thể kiểm tra nơi giá trị được truyền cho nó thực hiện IList hoặc . Nếu có, nó có thể tìm ra bao nhiêu giá trị trong phạm vi và do đó nó cần cấp phát bao nhiêu không gian ... trong khi vòng lặp có thể cần phân bổ lại nhiều lần.IList<T>foreach
                var lstPr = new List<CT_Province>();
                lstPr.Add(new CT_Province { ID = 0, Name = "-- Chọn tỉnh thành -- " });
                lstPr.AddRange(lstCT_Provinces);
                ViewBag.Provices = new SelectList(lstPr.ToList(), "ID", "Name", 0);

                var lstDis = new List<CT_District>();
                lstDis.Add(new CT_District { ID = 0, Name = "-- Chọn quận huyện -- " });
                ViewBag.Districts = new SelectList(lstDis.ToList(), "ID", "Name", 0);

                var lstW = new List<CT_Ward>();
                lstW.Add(new CT_Ward { ID = 0, Name = "-- Chọn phường xã -- " });
                ViewBag.Wards = new SelectList(lstW.ToList(), "ID", "Name", 0);
            }
            var model = _mapper.Map<CustomerInfoModel>(customerinfor);
            return View(model);
        }

        [HttpPost]
        //[Route("/ToOrder")]
        public IActionResult ToOrder(CustomerInfoModel model)
        {
            //Get cart get from Session
            var cart = HttpContext.Session.GetString("cart");
            if (cart == null)
            {
                return View("DatHangLoi");
            }

            List<CartModel> dataCart = JsonConvert.DeserializeObject<List<CartModel>>(cart);

            //Get request info of customer
            var customerinfor = _db.CustomerInfo.Where(x => x.UserName == this.User.Identity.Name).FirstOrDefault();
            //CustomerInfoModel ở đây là thông tin đặt hàng
            var OrdersModel = new OrderBill();

            if (ModelState.IsValid)
            {
                string nameClientNotLogin = "UserClient"; // m sửa thêm cái này
                if (customerinfor != null)
                {
                    customerinfor.Address = model.Address;
                    customerinfor.PhoneNumber = model.PhoneNumber;
                    customerinfor.ProviceID = model.ProviceID;
                    customerinfor.WardID = model.WardID;
                    customerinfor.Note = model.Note; // Giao nhanh nha!
                    _db.SaveChanges(); /// lưu thông tin xuống db
                }
                else
                {
                    customerinfor = new CustomerInfo(); // m sửa thêm cái này

                    customerinfor.Address = model.Address;
                    customerinfor.UserName = nameClientNotLogin;
                    customerinfor.PhoneNumber = model.PhoneNumber;
                    customerinfor.ProviceID = model.ProviceID;
                    customerinfor.WardID = model.WardID;
                    customerinfor.Note = model.Note; // Giao nhanh nha má
                    _db.SaveChanges(); /// luu thong tin xuong db
                }
                int Index;

                if (orderBillRepository.OrderBills().LastOrDefault() == null)
                {
                    Index = 1;
                }
                else
                {
                    Index = orderBillRepository.OrderBills().LastOrDefault().IDOrder + 1;
                }
                //Create order
                float TOTAL = 0;
                // m sửa thêm cái này
                OrdersModel.UserName = customerinfor.UserName; //nếu ko có login thì username  = empty thì mình ko gán  - khách vãng lai (tức khách không có login vào hệ thống mình)
                OrdersModel.FullName = model.FullName; //nếu ko có login thì username  = empty thì mình ko gán  - khách vãng lai (tức khách không có login vào hệ thống mình)
                OrdersModel.Address = model.Address; //nếu ko có login thì username  = empty thì mình ko gán  - khách vãng lai (tức khách không có login vào hệ thống mình)
                OrdersModel.Phone = model.PhoneNumber;
                OrdersModel.ProviceID = model.ProviceID;
                OrdersModel.WardID = model.WardID;
                OrdersModel.OrderDate = DateTime.Now.Date;
                //OrdersModel.ShipFee = 0;
                OrdersModel.Trangthai = "Đang xử lý";

                bool sl = true;
                for (int i = 0; i < dataCart.Count; i++)
                {

                    var OrdersDetailModel = new OrderDetail();
                    OrdersDetailModel.IDOrder = Index;
                    OrdersDetailModel.IDProduct = dataCart[i].Product.IDProduct;
                    OrdersDetailModel.ProductName = dataCart[i].Product.ProductName;
                    OrdersDetailModel.Number = dataCart[i].Number;
                    OrdersDetailModel.Price = dataCart[i].Product.Price;
                    OrdersDetailModel.ColorSize = "";
                    OrdersDetailModel.TotalPrice = dataCart[i].Number * dataCart[i].Product.Price;
                    _db.OrderDetails.Add(OrdersDetailModel);
                    TOTAL = (float)(TOTAL + OrdersDetailModel.TotalPrice);
                    if (TOTAL >= 500000)
                    {
                        OrdersModel.ShipFee = 0;
                    }
                    else
                    {
                        OrdersModel.ShipFee = 50000;
                    }
                    OrdersModel.Total = TOTAL;

                    /*
                     sp = 5
                    giỏ = 3
                    giảm = 0
                    dataCart[i] ==0 
                     */
                }
              
                    _db.OrderBills.Add(OrdersModel);
                    _db.SaveChanges(); /// lưu thông tin xuống db
                    HttpContext.Session.Remove("cart");
              
            }
            //Clear Cart
            // xoá session

            return View();
        }

        public JsonResult AjaxDistrictList(int Id)
        {
            var data = _db.CT_Districts.Where(m => m.ProvinceID == Id.ToString()).ToList();
            return Json(data);
        }

        public JsonResult AjaxWardList(int Id)
        {
            var data = _db.CT_Wards.Where(m => m.DistrictID == Id.ToString()).ToList();
            return Json(data);
        }
    }
}
