using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EFContext context;
        public CategoryRepository(EFContext context)
        {
            this.context = context;
        }

        // =========================================================

        public IEnumerable<Category> Categories()
        {
            return context.Categories.ToList();
        }

        public void createCategory(Category Category)
        {
            context.Categories.Add(Category);
            context.SaveChanges();
        }

        public void editCategory(Category Category)
        {
            context.Categories.Update(Category);
            context.SaveChanges();
        }

        public Category findByID(int id)
        {
            var p = context.Categories.Find(id);
            return p;
        }

        public void removeCategory(int id)
        {
            context.Categories.Remove(findByID(id));
            context.SaveChanges();
        }
    }
}
