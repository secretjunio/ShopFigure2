
using System.Collections.Generic;

namespace ShopMohinh.Models.IRepository
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> Suppliers();
        Supplier findByID(int id);
        void createSupplier(Supplier Supplier);
        void editSupplier(Supplier Supplier);
        void removeSupplier(int id);
    }
}
