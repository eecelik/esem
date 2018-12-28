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
            Account ac1 = new Account();
            ac1.Username = "eecelik";
            ac1.Firstname = "Enes";
            ac1.Lastname = "Celik";
            ac1.Password = "123";
            ac1.Mail = "iletisim@eecelik.com";

            Account ac2 = new Account();
            ac2.Username = "eToraman";
            ac2.Firstname = "Ersoy";
            ac2.Lastname = "Toraman";
            ac2.Password = "123";
            ac2.Mail = "iletisim@etoraman.com";

            Account ac3 = new Account();
            ac3.Username = "merttg";
            ac3.Firstname = "Mert";
            ac3.Lastname = "Geren";
            ac3.Password = "123";
            ac3.Mail = "iletisim@merttg.com";

            IAccountDal accountDal = IocUtil.Resolve<IAccountDal>();
            IProductDal producttDal = IocUtil.Resolve<IProductDal>();
            ICategoryDal categoryDal = IocUtil.Resolve<ICategoryDal>();

            accountDal.Add(ac1);
            accountDal.Add(ac2);
            accountDal.Add(ac3);

            


        }
    }
}
