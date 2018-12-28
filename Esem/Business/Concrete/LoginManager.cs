using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LoginManager : ILoginService
    {
        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Register(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
