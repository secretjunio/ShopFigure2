using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public interface IAccountRepository
    {
        IEnumerable<Account> Accounts();
        Account findByID(int id);
        void createAccount(Account Account);
        void editAccount(Account Account);
        void removeAccount(int id);
    }
}
