using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public class NewRepository : INewRepository
    {
        private readonly EFContext context;
        public NewRepository(EFContext context)
        {
            this.context = context;
        }

        public void createNew(New New)
        {
            context.News.Add(New);
            context.SaveChanges();
        }

        public void editNew(New New)
        {
            context.News.Update(New);
            context.SaveChanges();
        }

        public New findByID(int id)
        {
            return context.News.Find(id);
        }

        // =========================================================

        public IEnumerable<New> News()
        {
            return context.News.ToList();
        }

        public void removeNew(int id)
        {
            var New = context.News.Find(id);
            context.News.Remove(New);
            context.SaveChanges();
        }
    }
}
