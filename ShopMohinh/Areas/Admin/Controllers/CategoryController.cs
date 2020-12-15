using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMohinh.Models;
using ShopMohinh.ViewModel;

namespace ShopMohinh.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Sale,Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository CategoryRepository;

        public CategoryController(ICategoryRepository CategoryRepository)
        {
            this.CategoryRepository = CategoryRepository;


        }
       
        public IActionResult Danhsachtheloai()
        {
            IEnumerable<Category> C = CategoryRepository.Categories();
            ModelView modelView = new ModelView()
            {
                Categories = C
            };
            return View(modelView);
        }

        
        public IActionResult Edit(int id)
        {
            var C = CategoryRepository.Categories();
            var c = CategoryRepository.findByID(id);
            var modelView = new ModelView()
            {
                Categories = C,
                getCategory = c
            };
            return View(modelView);
        }
        [HttpPost]
        
        public void EditCategory(string IDCategory,string CategoryName,string Number,string Describe,IFormFile ImagePath,string ParentCategory)
        {
            var C = CategoryRepository.findByID(int.Parse(IDCategory));
            C.CategoryName = CategoryName;
            C.Number = int.Parse(Number);
            C.Describe = Describe;
            if (ImagePath.Length > 0)
            {
                C.ImagePath = ImagePath.FileName;
            }
            else
            {
                C.ImagePath = "none";
            }
            foreach(var i in CategoryRepository.Categories())
            {
                if (i.CategoryName.Equals(ParentCategory))
                {
                    C.ParentIDCategory = i.IDCategory;
                }
            }
            CategoryRepository.editCategory(C);
            Response.Redirect("/Admin/Category/Danhsachtheloai");
        }
        
        public IActionResult Create()
        {
            var C = CategoryRepository.Categories();
            ModelView m = new ModelView()
            {
                Categories = C
            };
            return View(m);
        }
        [HttpPost]
      
        public void CreateCategory(string IDCategory,string CategoryName,string Number,string Describe,IFormFile ImagePath,string ParentCategory)
        {
            var c = new Category();
            c.IDCategory = int.Parse(IDCategory);
            c.CategoryName = CategoryName;
            c.Number = int.Parse(Number);
            c.Describe = Describe;
            if (ImagePath.Length > 0)
            {
                c.ImagePath = ImagePath.FileName;
            }
            if (ParentCategory.Equals("null"))
            {
                c.ParentIDCategory = 0;
            }
            else
            {
                foreach (var i in CategoryRepository.Categories())
                {
                    if (i.CategoryName.Equals(ParentCategory))
                    {
                        c.ParentIDCategory = i.IDCategory;
                    }
                }
            }
            
            CategoryRepository.createCategory(c);
            Response.Redirect("/Admin/Category/Danhsachtheloai");
        }
    }
}
