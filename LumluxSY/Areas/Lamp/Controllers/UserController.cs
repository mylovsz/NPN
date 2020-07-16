using LumluxSY.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LumluxSY.Attributes;


namespace LumluxSY.Areas.Lamp.Controllers
{
    public class UserController : ControllerBaseHelper
    {

        [AuthorizeIgnoreAttribute]
        public ActionResult Login()
        {
            ViewBag.IsError = false;
            //LumluxSSYDB.BLL.tHostInfo bllhost = new LumluxSSYDB.BLL.tHostInfo();
            //LumluxSSYDB.Model.tHostInfo modhost = new LumluxSSYDB.Model.tHostInfo();
            //Random r = new Random();
            //for (int i = 0; i < 100; i++)
            //{
            //    modhost.sGUID = Guid.NewGuid().ToString();
            //    modhost.sName = "主机" + i;
            //    modhost.fLat = Convert.ToDecimal((31.298886 + r.Next(10) * 0.01).ToString("f8"));
            //    modhost.fLng = Convert.ToDecimal((120.58531600000003 + r.Next(10) * 0.01).ToString("f8"));
            //    modhost.iIDType = 1;
            //    modhost.sID_Addr = "1";
            //    modhost.sID_MAC = "1";
            //    modhost.sID_SIM = "1";
            //    modhost.sProjectInfoGUID = "235c50d1-6cb1-4756-91c8-e8b77d52bb2f";
            //    modhost.dCreateDate = DateTime.Now;
            //    modhost.dUpdateTime = DateTime.Now;
            //    modhost.iState_Alarm = 1;
            //    modhost.iState_Command = 1;
            //    modhost.iState_Enable = 1;
            //    modhost.iState_Online = 1;
            //    modhost.sGroupInfoGUID = "5f32d8f4-4098-4fa1-abce-33605894acef";
            //    bllhost.Add(modhost);
            //}

            return View();
        }
        [HttpPost]
        [AuthorizeIgnoreAttribute]
        public ActionResult Login(string IsCheck,string username, string password)
        {
            if (IsCheck == "on")
            {
                RemPassWord = 24;
            }
            // 身份认证
            LumluxSSYDB.Model.tUserInfoes ui = new LumluxSSYDB.Model.tUserInfoes();
            LumluxSSYDB.BLL.tUserInfoes uiBll = new LumluxSSYDB.BLL.tUserInfoes();
            string passwordMD5 = LumluxSSYDB.DBUtility.Utility.MD5(password);
            if (uiBll.ExistsUserByPassword(username, passwordMD5))
            {
                ui = uiBll.GetUserMode(username, passwordMD5);
                this.UserName = ui.sUserName;
                this.UserID = ui.sGUID;
                this.PrjGUID = ui.sPrjectInfoGUID;
                this.UserAuthority = ui.iAuthorityGUID;
                return RedirectToAction("index", "Main", new { Area = "Lamp" });
            }
            else
            {
                ViewBag.IsError = true;
                ModelState.AddModelError("error", "用户名或密码错误");
                return View();
            }
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult UserInfo()
        {
            ViewData["Message"] = Request.QueryString["WW"];   
            return View();
        }
        //
        // GET: /Lamp/User/

        public ActionResult Index()
        {
            return View();
        }

    }
}
