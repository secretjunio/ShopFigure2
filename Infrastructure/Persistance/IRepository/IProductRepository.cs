using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products();
        Product findByID(int id);
        void createProduct(Product product);
        void editProduct(Product product);
        void removeProduct(int id);
    }
}
