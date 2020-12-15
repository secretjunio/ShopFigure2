using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly EFContext context;
        public ProductRepository(EFContext context)
        {
            this.context = context;
        }

        public void createProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void editProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        public Product findByID(int id)
        {
            return context.Products.Find(id);
        }

        // =========================================================

        public IEnumerable<Product> Products()
        {
            return context.Products.ToList();
        }

        public void removeProduct(int id)
        {
            var product = context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
        }
       
    }
}
