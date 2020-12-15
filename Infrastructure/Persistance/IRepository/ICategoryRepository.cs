using System.Collections.Generic;

namespace ShopMohinh.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories();
        Category findByID(int id);
        void createCategory(Category Category);
        void editCategory(Category Category);
        void removeCategory(int id);
    }
}