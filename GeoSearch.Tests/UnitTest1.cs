using System;
using GeoSearch.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeoSearch.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var repo = new GeoRepo();
            repo.GetGeo(50.474680, 30.511010, 1);
        }
    }
}
