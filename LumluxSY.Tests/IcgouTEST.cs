using LumluxSY.Areas.Lamp.Controllers;
using LumluxSY.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LumluxSY.Tests
{
    [TestClass]
    public class IcgouTEST
    {
        
        [TestMethod]
        public void Index()
        {

            LumluxSY.Tests.PublicClass.TestHttpContext mock = new LumluxSY.Tests.PublicClass.TestHttpContext(false);
            //System.Web.HttpContext context = mock.Context;
            CookieHelper.Save("PrjGUID", "56410585-b02a-4565-bb8f-3b06466e5efd", 1);
            CookieHelper.Save("UserID", "23ac7f54-3df7-4a5d-a821-7a249567385e,1");
            CookieHelper.Save("UserName", "admin", 1);
            //Arrange
            var shared = new SharedController();

            //Act
            ViewResult result = shared.ChangePassword() as ViewResult;

            //Assert
            Assert.IsNotNull(result);

        }
    }
}
