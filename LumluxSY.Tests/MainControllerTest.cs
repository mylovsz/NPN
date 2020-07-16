using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LumluxSY.Areas.Lamp.Controllers;
using System.Web.Mvc;
using System.Web;
using System.Collections.Specialized;
using Moq;
using LumluxSY.Base;

namespace LumluxSY.Tests
{
    [TestClass]
    public class MainControllerTest 
    {
        [TestMethod]
        public void MainController()
        {
            LumluxSY.Tests.PublicClass.TestHttpContext mock = new LumluxSY.Tests.PublicClass.TestHttpContext(false);
            //System.Web.HttpContext context = mock.Context;
            CookieHelper.Save("PrjGUID", "56410585-b02a-4565-bb8f-3b06466e5efd", 1);
            CookieHelper.Save("UserID", "23ac7f54-3df7-4a5d-a821-7a249567385e,1");
            CookieHelper.Save("UserName", "admin", 1);
            MainController controller = new MainController();
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
            Assert.IsNotNull(result);
            ViewDataDictionary viewData = result.ViewData;
            Assert.AreEqual("WW", viewData["Message"]);
            JsonResult result1 = controller.MapInitLeftMenu() as JsonResult;
            Assert.IsNotNull(result1);
            JsonResult result2 = controller.AllMarker() as JsonResult;
            Assert.IsNotNull(result2);
            //Assert.IsNull(result);
            JsonResult result3 = controller.AllMarkerLights() as JsonResult;
            Assert.IsNotNull(result3);
            JsonResult result4 = controller.curHostAllLights() as JsonResult;
            Assert.IsNotNull(result4);
            JsonResult result5 = controller.SeachData() as JsonResult;
            Assert.IsNotNull(result5);
            JsonResult result6= controller.ReloadState() as JsonResult;
            Assert.IsNotNull(result6);
            JsonResult result7 = controller.AlarmDemoInfo() as JsonResult;
            Assert.IsNotNull(result7);
            JsonResult result8 = controller.RealTimeAlarmDemoInfo() as JsonResult;
            Assert.IsNotNull(result8);
            
        }
        [TestMethod]
        public void AlarmPageController()
        {
            LumluxSY.Tests.PublicClass.TestHttpContext mock = new LumluxSY.Tests.PublicClass.TestHttpContext(false);
            //System.Web.HttpContext context = mock.Context;
            CookieHelper.Save("PrjGUID", "56410585-b02a-4565-bb8f-3b06466e5efd", 1);
            CookieHelper.Save("UserID", "23ac7f54-3df7-4a5d-a821-7a249567385e,1");
            CookieHelper.Save("UserName", "admin", 1);
            AlarmPageController controller = new AlarmPageController();
            var httpContext = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            NameValueCollection queryString = new NameValueCollection();
            queryString.Add("WW", "WW");
            request.Setup(r => r.QueryString).Returns(queryString);
            httpContext.Setup(ht => ht.Request).Returns(request.Object);
            ControllerContext controllerContext = new ControllerContext();
            controllerContext.HttpContext = httpContext.Object;
            controller.ControllerContext = controllerContext;
            
            JsonResult result = controller.Index("", "131", "321", 1, "", "","") as JsonResult;
            Assert.IsNotNull(result);
            JsonResult jsonresult = controller.GetDateWhrer("", "123", "321", 1, "", "","") as JsonResult;
            Assert.IsNotNull(jsonresult);
        }

        [TestMethod]
        public void TimeControlController()
        {
            LumluxSY.Tests.PublicClass.TestHttpContext mock = new LumluxSY.Tests.PublicClass.TestHttpContext(false);
            //System.Web.HttpContext context = mock.Context;
            CookieHelper.Save("PrjGUID", "56410585-b02a-4565-bb8f-3b06466e5efd", 1);
            CookieHelper.Save("UserID", "23ac7f54-3df7-4a5d-a821-7a249567385e,1");
            CookieHelper.Save("UserName", "admin", 1);
            TimeControlController controller = new TimeControlController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            JsonResult result1 = controller.ReturnLightGroup("131231") as JsonResult;
            Assert.IsNotNull(result1);
            JsonResult result2 = controller.GetLoopControl("","") as JsonResult;
            Assert.IsNotNull(result2);
            JsonResult result3 = controller.SaveSets("","","","mr","","","","","","") as JsonResult;
            Assert.IsNotNull(result3);
            JsonResult result4 = controller.GetSets("") as JsonResult;
            Assert.IsNotNull(result3);
            
        }

        [TestMethod]
        public void FailureRateController()
        {
            LumluxSY.Tests.PublicClass.TestHttpContext mock = new LumluxSY.Tests.PublicClass.TestHttpContext(false);
            //System.Web.HttpContext context = mock.Context;
            CookieHelper.Save("PrjGUID", "21", 1);
            CookieHelper.Save("UserID", "23ac7f54-3df7-4a5d-a821-7a249567385e,1");
            CookieHelper.Save("UserName", "admin", 1);
            FailureRateController controller = new FailureRateController();
            JsonResult result1 = controller.Index("", "", "", "","") as JsonResult;
            Assert.IsNotNull(result1);
        }
    }
}
