using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopMohinh.Models;
using ShopMohinh.Models.IRepository;
using ShopMohinh.ViewModel;

namespace ShopMohinh.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Sale,Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository ProductRepository;
        private readonly ICategoryRepository CategoryRepository;
        private readonly ISupplierRepository SupplierRepository;
        private readonly IWebHostEnvironment _env;
        public ProductController(IProductRepository ProductRepository,
                                    ICategoryRepository CategoryRepository,
                                    ISupplierRepository SupplierRepository, IWebHostEnvironment env)
        {
            this.ProductRepository = ProductRepository;
            _env = env;
            this.CategoryRepository = CategoryRepository;
            this.SupplierRepository = SupplierRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> Products = ProductRepository.Products();
            IEnumerable<Category> C = CategoryRepository.Categories();
            IEnumerable<Supplier> S = SupplierRepository.Suppliers();
            ModelView modelView = new ModelView()
            {
                Products = Products,
                Categories = C,
                Suppliers = S

            };
            return View(modelView);
        }


        public IActionResult Edit(int id)
        {
            var product = ProductRepository.findByID(id);
            var categories = CategoryRepository.Categories();
            var supplier = SupplierRepository.Suppliers();

            var modelView = new ModelView()
            {
                getProduct = product,
                Categories = categories,
                Suppliers = supplier,


            };
            return View(modelView);
        }

        [HttpPost]
        public void EditProduct(string IDPro, string ProductName, string ReleaseDate, string Number, IFormFile ImagePath,
                   IFormFile Image1, IFormFile Image2, IFormFile Image3, string Price, string NewPrice, string Describe, string CategoryName, string SupplierName, string isNew,string Phantrang)
        {
            if (IDPro != "")
            {
                if (ModelState.IsValid)
                {
                    int id = int.Parse(IDPro);
                    var p = ProductRepository.findByID(id);
                    p.ProductName = ProductName;
                    p.ReleaseDate = DateTime.Parse(ReleaseDate);
                    p.Describe = Describe;
                    p.Price = float.Parse(Price);
                    p.Price = float.Parse(NewPrice);
                    p.Number = int.Parse(Number);
                    //----
                    string ImageP = setImage(ImagePath);
                    //----
                    if (!string.IsNullOrEmpty(ImageP)) // nếu file name avatar có
                    {
                        p.ImagePath = ImageP; // gán vào db
                    }
                    ImageP = setImage(Image1);
                    if (!string.IsNullOrEmpty(ImageP)) // nếu file name avatar có
                    {
                        p.Image1 = ImageP; // gán vào db
                    }
                    ImageP = setImage(Image2);
                    if (!string.IsNullOrEmpty(ImageP)) // nếu file name avatar có
                    {
                        p.Image2 = ImageP; // gán vào db
                    }
                    ImageP = setImage(Image3);
                    if (!string.IsNullOrEmpty(ImageP)) // nếu file name avatar có
                    {
                        p.Image3 = ImageP; // gán vào db
                    }


                    foreach (Category i in CategoryRepository.Categories())
                    {
                        if (i.CategoryName.Equals(CategoryName))
                        {
                            p.IDCategory = i.IDCategory;
                        }
                    }
                    foreach (var i in SupplierRepository.Suppliers())
                    {
                        if (i.SupplierName.Equals(SupplierName))
                        {
                            p.IDSupplier = i.IDSupplier;
                        }
                    }
                    if (isNew.Equals("có"))
                    {
                        p.isNew = true;
                    }
                    else
                    {
                        p.isNew = false;
                    }
                    ProductRepository.editProduct(p);
                    switch (Phantrang)
                    {
                        case "Thông thường":
                            p.Phantrang = 1;
                            break;
                        case "Phổ biến":
                            p.Phantrang = 2;
                            break;
                        case "Bán chạy nhất":
                            p.Phantrang = 3;
                            break;
                        case "Sản phẩm mới":
                            p.Phantrang = 4;
                            break;
                        case "Sưu tầm":
                            p.Phantrang = 5;
                            break;
                        case "Đề xuất":
                            p.Phantrang = 6;
                            break;
                        case "Giảm giá":
                            p.Phantrang = 7;
                            break;
                    }
                   

                    Response.Redirect("/Admin/Product/Index");

                }
                else
                {
                    ViewBag.Mess = "không tìm thấy sản phẩm cần chỉnh sửa";
                    Response.Redirect("/Admin/Product/Index");
                }

            }
        }

        public IActionResult Delete(int id)
        {
            ProductRepository.removeProduct(id);
            Response.Redirect("/Admin/Product/Index");
            return View();
        }

        public IActionResult Create(int id = 0)
        {
            var s = SupplierRepository.Suppliers();
            var c = CategoryRepository.Categories();

            var mv = new ModelView()
            {
                Suppliers = s,
                Categories = c
            };
            return View(mv);
        }

        //[HttpPost]
        //public IActionResult Create(string IDProduct, string ProductName, IFormFile ImagePath, string Describe, string ReleaseDate, float NewPrice,
        //    int Number, float Price, IFormFile Image1, IFormFile Image2, IFormFile Image3, string CategoryName, string SupplierName, string isNew,string Phantrang)
        //{
        //    var p = new Product();
        //    if (ModelState.IsValid)
        //    {
                
        //        p.IDProduct = int.Parse(IDProduct);
        //        p.ProductName = ProductName;
        //        string ImageP = setImage(ImagePath);
        //        //----
        //        if (!string.IsNullOrEmpty(ImageP)) // nếu file name avatar có
        //        {
        //            p.ImagePath = ImageP; // gán vào db
        //        }
        //        ImageP = setImage(Image1);
        //        //----
        //        if (!string.IsNullOrEmpty(ImageP)) // nếu file name avatar có
        //        {
        //            p.Image1 = ImageP; // gán vào db
        //        }
        //        ImageP = setImage(Image2);
        //        //----
        //        if (!string.IsNullOrEmpty(ImageP)) // nếu file name avatar có
        //        {
        //            p.Image2 = ImageP; // gán vào db
        //        }
        //        ImageP = setImage(Image3);
        //        //----
        //        if (!string.IsNullOrEmpty(ImageP)) // nếu file name avatar có
        //        {
        //            p.Image3 = ImageP; // gán vào db
        //        }
        //        if (ReleaseDate == null)
        //        {
        //            p.ReleaseDate = DateTime.Now.Date;
        //        }
        //        else
        //        {
        //            p.ReleaseDate = DateTime.Parse(ReleaseDate);
        //        }
        //        p.Describe = Describe;
                
        //        p.Price = Price;
        //        p.NewPrice = NewPrice;
        //        p.Number = Number;

        //        foreach (Category i in CategoryRepository.Categories())
        //        {
        //            if (i.CategoryName.Equals(CategoryName))
        //            {
        //                p.IDCategory = i.IDCategory;
        //            }
        //        }
        //        foreach (Supplier i in SupplierRepository.Suppliers())
        //        {
        //            if (i.SupplierName.Equals(SupplierName))
        //            {
        //                p.IDSupplier = i.IDSupplier;
        //            }
        //        }
        //        if (isNew.Equals("có"))
        //        {
        //            p.isNew = true;
        //        }
        //        else
        //        {
        //            p.isNew = false;
        //        }
        //        switch (Phantrang)
        //        {
        //            case "Thông thường":
        //                p.Phantrang = 1;
        //                break;
        //            case "Phổ biến":
        //                p.Phantrang = 2;
        //                break;
        //            case "Bán chạy nhất":
        //                p.Phantrang = 3;
        //                break;
        //            case "Sản phẩm mới":
        //                p.Phantrang = 4;
        //                break;
        //            case "Sưu tầm":
        //                p.Phantrang = 5;
        //                break;
        //            case "Đề xuất":
        //                p.Phantrang = 6;
        //                break;
        //            case "Giảm giá":
        //                p.Phantrang = 7;
        //                break;
        //        }

        //        ProductRepository.createProduct(p);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        [HttpPost]
        public void CreateTest(ProductDto P, Category cat, Supplier sup,
                                                string Phantrang)
        {
            var p = new Product();
            if (ModelState.IsValid)
            {
                
                p.ProductName = P.ProductName;
                string ImageP = setImage(P.ImagePath);
                //----
                if (!string.IsNullOrEmpty(ImageP)) // nếu file name avatar có
                {
                    p.ImagePath = ImageP; // gán vào db
                }
                p.ReleaseDate = P.ReleaseDate;
                p.Describe = P.Describe;

                p.Price = P.Price;
                p.NewPrice = P.NewPrice;
                p.Number = P.Number;

                foreach (Category i in CategoryRepository.Categories())
                {
                    if (i.CategoryName.Equals(cat.CategoryName))
                    {
                        p.IDCategory = i.IDCategory;
                    }
                }
                foreach (Supplier i in SupplierRepository.Suppliers())
                {
                    if (i.SupplierName.Equals(sup.SupplierName))
                    {
                        p.IDSupplier = i.IDSupplier;
                    }
                }
                if (P.isNew.Equals("có"))
                {
                    p.isNew = true;
                }
                else
                {
                    p.isNew = false;
                }
                switch (Phantrang)
                {
                    case "Thông thường":
                        p.Phantrang = 1;
                        break;
                    case "Phổ biến":
                        p.Phantrang = 2;
                        break;
                    case "Bán chạy nhất":
                        p.Phantrang = 3;
                        break;
                    case "Sản phẩm mới":
                        p.Phantrang = 4;
                        break;
                    case "Sưu tầm":
                        p.Phantrang = 5;
                        break;
                    case "Đề xuất":
                        p.Phantrang = 6;
                        break;
                    case "Giảm giá":
                        p.Phantrang = 7;
                        break;
                }

                ProductRepository.createProduct(p);
                Response.Redirect("Index");
            }
        }


        public string setImage(IFormFile img)
        {
            string wwwPath = _env.WebRootPath; // nó tìm đến quả địa cầu www
            string contentPath = _env.ContentRootPath;
            string path = Path.Combine(this._env.WebRootPath, "imagesUser", "Product");

            if (!Directory.Exists(path)) // check folder có tồn tại hay k?, ở đây là nếu k có thì nó tạo mới folder
            {
                Directory.CreateDirectory(path);
            }

            // kiểm tra các ràng buộc

            string ImageP = "";
            if (img != null)
            {
                ImageP = Path.GetFileName(img.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, ImageP), FileMode.Create))
                {
                    img.CopyTo(stream); // lưu file vào folder
                }
            }
            return ImageP;
        }

    }
}
