using LumluxSY.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LumluxSY.Areas.Lamp.Controllers
{
    public class LayoutMetronicController : ControllerBaseHelper
    {



        public ActionResult Exit()
        {
            this.UserID = "";
            this.UserName = "";

            // 采用区域重定向
            return RedirectToAction("Login", "User", new { Area = "Lamp" });
        }
        //
        // GET: /Lamp/LayoutMetronic/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AlarmInfos(string sGUID)
        {
            //AlarmSelectedGUID = sGUID;
            return RedirectToAction("Index", "AlarmPage", new { Area = "Lamp", sGUID = sGUID });
        }
    }
}
