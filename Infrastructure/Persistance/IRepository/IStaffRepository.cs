using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public interface IStaffRepository
    {
        IEnumerable<Staff> Staffs();
        Staff findByID(int id);
        void createStaff(Staff Staff);
        void editStaff(Staff Staff);
        void removeStaff(int id);
    }
}
