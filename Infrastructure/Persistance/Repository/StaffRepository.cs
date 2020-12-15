using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public class StaffRepository : IStaffRepository
    {
        private readonly EFContext context;
        public StaffRepository(EFContext context)
        {
            this.context = context;
        }

        public void createStaff(Staff Staff)
        {
            throw new NotImplementedException();
        }

        public void editStaff(Staff Staff)
        {
            throw new NotImplementedException();
        }

        public Staff findByID(int id)
        {
            throw new NotImplementedException();
        }

        public void removeStaff(int id)
        {
            throw new NotImplementedException();
        }

        // =========================================================

        public IEnumerable<Staff> Staffs()
        {
            return context.Staffs.ToList();
        }
    }
}
