using System;
using Business;
using Business.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void Login()
        {
            ILoginService loginService = IocUtil.Resolve<ILoginService>();

            bool loggedIn = loginService.Login("etoraman", "123");

            Assert.AreEqual(true, loggedIn);
        }
    }
}
