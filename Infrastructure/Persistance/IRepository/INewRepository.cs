using System.Collections.Generic;

namespace ShopMohinh.Models
{
    public interface INewRepository
    {
        IEnumerable<New> News();
        New findByID(int id);
        void createNew(New New);
        void editNew(New New);
        void removeNew(int id);
    }
}