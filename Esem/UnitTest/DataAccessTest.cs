using System;
using Business;
using DataAccess.Abstract;
using DataAccess.Concrete;
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
            ac2.Username = "etoraman";
            ac2.Firstname = "Ersoy";
            ac2.Lastname = "Toraman";
            ac2.Password = "123";
            ac2.Mail = "iletisim@etoraman.com";

            Account ac3 = new Account();
            ac3.Username = "merttg";
            ac3.Firstname = "Mert";
            ac3.Lastname = "Geren";
            ac3.Password = "123";
            ac3.Mail = "iletisim@mertg.com";

            Product pr1 = new Product();
            if (pr1.AccountId == ac1.Id)
            {
                pr1.Name = "Iphone6";
                pr1.City = "manisa";
                pr1.Description = "Sıfır sayılır.";
                
            }
            

            IAccountDal accountDal = IocUtil.Resolve<IAccountDal>();
            IProductDal producttDal = IocUtil.Resolve<IProductDal>();
            ICategoryDal categoryDal = IocUtil.Resolve<ICategoryDal>();

            accountDal.Add(ac1);
            accountDal.Add(ac2);
            accountDal.Add(ac3);

            
            producttDal.GetList(x => x.Id == ac1.Id);


            
            
        }
    }
}
