using ShopMohinh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public class CategoryModelView
    {
        public Category CategoryInfo { get; set; }
        public List<Product> DataList { get; set; }
        public List<Supplier> sl { get; set; }
        public List<Category> ct { get; set; }
        public Product Pr { get; set; }
    }
}
