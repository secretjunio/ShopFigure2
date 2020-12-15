using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMohinh.Models.IRepository;

namespace ShopMohinh.Models
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly EFContext context;
        public SupplierRepository(EFContext context)
        {
            this.context = context;
        }

        //tạo sản phẩm
        public void createSupplier(Supplier Supplier)
        {
            context.Suppliers.Add(Supplier);
            context.SaveChanges();
        }

        //chỉnh sửa sản phẩm
        public void editSupplier(Supplier Supplier)
        {
            context.Suppliers.Update(Supplier);
            context.SaveChanges();
        }

        //tìm kiếm nhà cung câos theo ID
        public Supplier findByID(int id)
        {
            return(context.Suppliers.Find(id));
        }

        //loại bỏ nhà cung cấp
        public void removeSupplier(int id)
        {
            context.Suppliers.Remove(findByID(id));
        }

        // =========================================================
        //trả về 1 danh sách nhà cung cấp
        public IEnumerable<Supplier> Suppliers()
        {
            return context.Suppliers.ToList();
        }
    }
}
