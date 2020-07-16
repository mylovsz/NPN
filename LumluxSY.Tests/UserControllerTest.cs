using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LumluxSY.Areas.Lamp.Controllers;
using Moq;
using System.Web;
using System.Collections.Specialized;
using System.Web.Mvc;
using LumluxSY.Base;

namespace LumluxSY.Tests
{
    [TestClass]
    public class UserControllerTest 
    {
        [TestMethod]
        public void UserInfoTest()
        {
           
            UserController controller = new UserController();
            var httpContext = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            NameValueCollection queryString = new NameValueCollection();
            queryString.Add("WW", "WW");
            request.Setup(r => r.QueryString).Returns(queryString);
            httpContext.Setup(ht => ht.Request).Returns(request.Object);
            ControllerContext controllerContext = new ControllerContext();
            controllerContext.HttpContext = httpContext.Object;
            controller.ControllerContext = controllerContext;
            ViewResult result = controller.Index() as ViewResult;
            ViewDataDictionary viewData = result.ViewData;
            Assert.AreEqual("WW", viewData["Message"]);
        }
    }
}
