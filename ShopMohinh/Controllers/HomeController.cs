using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopMohinh.Models;
using ShopMohinh.ViewModel;

namespace ShopMohinh.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository ProductRepository;
        private readonly ICategoryRepository CategoryRepository;
      
        public HomeController(IProductRepository ProductRepository,
                                ICategoryRepository CategoryRepository )
        {
            this.ProductRepository = ProductRepository;
            this.CategoryRepository = CategoryRepository;

        }

        public IActionResult Index()
        {
            IEnumerable<Product> Products = ProductRepository.Products();
            IEnumerable<Category> Categories = CategoryRepository.Categories();
            ModelView modelView = new ModelView()
            {
                Products = Products,
                Categories=Categories
                
            };
            return View(modelView);
        }

        public IActionResult Advertiserment()
        {
            var C = CategoryRepository.Categories();
            ModelView m = new ModelView()
            {
                Categories = C
            };
            return View(m);
        }

        public IActionResult Privacy()
        {
            var C = CategoryRepository.Categories();
            ModelView m = new ModelView()
            {
                Categories = C
            };
            return View(m);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Intro()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Find(string search)
        {
            var P = new List<Product>();
            if (search != null)
            {
                
                foreach (var i in ProductRepository.Products())
                {
                    if (((i.ProductName).ToLower()).Contains(search.ToLower()))
                    {
                        P.Add(i);
                    }
                }
               
            }
            ModelView m = new ModelView()
            {
                Products = P,
                
            };
            return View(m);
        } 
    }
}
