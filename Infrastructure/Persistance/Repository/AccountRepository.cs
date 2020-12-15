using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EFContext context;
        public AccountRepository(EFContext context)
        {
            this.context = context;
        }

        // =========================================================

        public IEnumerable<Account> Accounts()
        {
            return context.Accounts.ToList();
        }

        public void createAccount(Account Account)
        {
            context.Accounts.Add(Account);
            context.SaveChanges();
        }

        public void editAccount(Account Account)
        {
            context.Accounts.Update(Account);
            context.SaveChanges();
        }

        public Account findByID(int id)
        {
            return context.Accounts.Find(id);
        }

        public void removeAccount(int id)
        {
            context.Accounts.Remove(context.Accounts.Find(id));
            context.SaveChanges();
        }
    }
}
