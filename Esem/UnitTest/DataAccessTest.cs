using System;
using Business;
using DataAccess.Abstract;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class DataAccessTest
    {
        [TestMethod]
        public void FillDatabase()
        {
            Account ac = new Account();
            ac.Username = "eecelik";
            ac.Firstname = "Enes";
            ac.Lastname = "Celik";
            ac.Password = "123";
            ac.Mail = "iletisim@eecelik.com";

            IAccountDal accountDal = IocUtil.Resolve<IAccountDal>();

            accountDal.Add(ac);
            
            
        }
    }
}
