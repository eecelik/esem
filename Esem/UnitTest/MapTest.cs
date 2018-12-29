using System;
using Business;
using Business.Abstract;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class MapTest
    {
        [TestMethod]
        public void MapServiceTest()
        {
            string latLong = ",";

            IMapService mapService = IocUtil.Resolve<IMapService>();

            Product product = new Product();

            product.LongLat = "41.008240,28.978359";

            mapService.FillAddress(product);

        }
    }
}
