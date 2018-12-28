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
    public class LoginManager : ILoginService
    {
        private IAccountDal accountDal;

        public LoginManager(IAccountDal accountDal)
        {
            this.accountDal = accountDal;
        }

        public bool Login(string username, string password)
        {
            Account account = accountDal.Get(x => x.Username == username);

            if (account == null) return false;

            if (account.Password == password) return true;
            else return false;
        }

        public bool Register(Account account)
        {
            if (string.IsNullOrEmpty(account.Firstname.Trim()) || string.IsNullOrEmpty(account.Lastname.Trim()) || string.IsNullOrEmpty(account.Username.Trim()) || string.IsNullOrEmpty(account.Password.Trim()) || string.IsNullOrEmpty(account.Mail.Trim()))
                return false;
            
            //user kontrolleri yapılacak.

            accountDal.Add(account);
            return true;
        }
    }
}
