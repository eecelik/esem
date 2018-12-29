using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AccountManager : IAccountService
    {
        IAccountDal accountDal;

        public AccountManager(IAccountDal accountDal)
        {
            this.accountDal = accountDal;
        }

        public Account Get(string username)
        {
            if (string.IsNullOrEmpty(username)) return null;
            return accountDal.Get(x => x.Username == username);
        }

        public List<Account> GetAccountsWithoutMe(int accountId)
        {
            return accountDal.GetList(x => x.Id != accountId);
        }
    }
}
