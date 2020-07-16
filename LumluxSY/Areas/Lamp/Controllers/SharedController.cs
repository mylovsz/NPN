using LumluxSSYDB.Common.DataConverter;
using LumluxSY.Areas.Lamp.Models;
using LumluxSY.Base;
using ProtocolManage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL = LumluxSSYDB.BLL;
using Model = LumluxSSYDB.Model;

namespace LumluxSY.Areas.Lamp.Controllers
{
    public class SharedController : ControllerBaseHelper
    {
        //
        // GET: /Lamp/Shared/

        public ActionResult Index()
        {
           
            return View();
        }

        #region 密码修改

        public ActionResult ChangePassword()
        {
            if ((!string.IsNullOrWhiteSpace(this.UserID))&&(!string.IsNullOrWhiteSpace(this.PrjGUID)))
            {
                ViewBag.Display = "None";
                return View();
            }
            else
            {
                // 采用区域重定向
                return RedirectToAction("Login", "User", new { Area = "Lamp" });
            }
        }

        [HttpPost]
        public ActionResult ChangePassword(string oldpsd, string newpsd1, string newpsd2)
        {
            /*
           result :
            * 0: 请先登录
            * 1: 参数错误
            * 2: 未发现该主机
            * 3：主机原始密码错误
            * 4: 主机修改新密码失败，数据库错误
            * 5：主机修改新密码成功
            */
            if (!string.IsNullOrEmpty(this.UserID))
            {
                if ((!string.IsNullOrWhiteSpace(oldpsd)) && (!string.IsNullOrWhiteSpace(newpsd1)) && (!string.IsNullOrWhiteSpace(newpsd2)))
                {
                    if ((newpsd1.Length>20)||(newpsd2.Length>20))
                    {
                        ViewBag.Display = "Normal";
                        ViewBag.ChangePasswordResult = "密码字数不能超过20！";
                        return View();
                    }
                    if (newpsd1 != newpsd2)
                    {
                        ViewBag.Display = "Normal";
                        ViewBag.ChangePasswordResult = "确认密码与新密码不一致！";
                        return View();
                    }
                    if (oldpsd == newpsd1)
                    {
                        ViewBag.Display = "Normal";
                        ViewBag.ChangePasswordResult = "新密码与原密码不能完全相同！";
                        return View();
                    }
                    // 身份认证
                    LumluxSSYDB.BLL.tUserInfoes uiBll = new LumluxSSYDB.BLL.tUserInfoes();
                    string passwordMD5 = LumluxSSYDB.DBUtility.Utility.MD5(oldpsd);
                    string newpasswordMD5 = LumluxSSYDB.DBUtility.Utility.MD5(newpsd1);
                    switch (uiBll.UpdatePassWord(this.UserID, passwordMD5, newpasswordMD5))
                    {
                        case 0:
                            {
                                ViewBag.Display = "Normal";
                                ViewBag.ChangePasswordResult = "未发现该主机！";
                                return View();
                            }
                        case 1:
                            {
                                ViewBag.Display = "Normal";
                                ViewBag.ChangePasswordResult = "主机原始密码错误！";
                                return View();
                            }
                        case 2:
                            {
                                ViewBag.Display = "Normal";
                                ViewBag.ChangePasswordResult = "主机修改新密码失败，数据库错误！";
                                return View();
                            }
                        case 3:
                            {
                                ViewBag.Display = "Normal";
                                ViewBag.ChangePasswordResult = "主机修改新密码成功！";
                                return View();
                            }
                        default:
                            {
                                ViewBag.Display = "Normal";
                                ViewBag.ChangePasswordResult = "主机修改新密码失败，数据库错误！";
                                return View();
                            }
                    }
                }
                else
                {
                    ViewBag.ChangePasswordResult = "密码不能为空！";
                    return View();
                }
            }
            else
            {
                // 采用区域重定向
                return RedirectToAction("Login", "User", new { Area = "Lamp" });
            }
        }
        //public JsonResult ChangePassWordResult()
        //{
        //    /*
        //    result :
        //     * 0: 请先登录
        //     * 1: 参数错误
        //     * 2: 未发现该主机
        //     * 3：主机原始密码错误
        //     * 4: 主机修改新密码失败，数据库错误
        //     * 5：主机修改新密码成功
        //     */
        //    int Result = 0;
        //    if (!string.IsNullOrEmpty(this.UserID))
        //    {
        //        if ((!string.IsNullOrWhiteSpace(Request.QueryString["sOldpassword"])) && (!string.IsNullOrWhiteSpace(Request.QueryString["sNewpassword"])))
        //        {
        //            string oldpassword=Request.QueryString["sOldpassword"];
        //            string newpassword = Request.QueryString["sNewpassword"];
        //            // 身份认证
        //            LumluxSSYDB.BLL.tUserInfoes uiBll = new LumluxSSYDB.BLL.tUserInfoes();
        //            string passwordMD5 = LumluxSSYDB.DBUtility.Utility.MD5(oldpassword);
        //            string newpasswordMD5 = LumluxSSYDB.DBUtility.Utility.MD5(newpassword);
        //            switch (uiBll.UpdatePassWord(this.UserID,passwordMD5,newpasswordMD5))
        //            {
        //                case 0:
        //                    {
        //                        Result = 2;
        //                        return Json(Result);
        //                    }
        //                case 1:
        //                    {
        //                        Result = 3;
        //                        return Json(Result);
        //                    }
        //                case 2:
        //                    {
        //                        Result = 4;
        //                        return Json(Result);
        //                    }
        //                case 3:
        //                    {
        //                        Result = 5;
        //                        return Json(Result);
        //                    }
        //                default:
        //                    {
        //                        Result = 4;
        //                        return Json(Result);
        //                    }
        //            }
        //        }
        //        else
        //        {
        //            Result = 1;
        //            return Json(Result);
        //        }
        //    }
        //    else
        //    {
        //        Result = 0;
        //        return Json(Result);
        //    }
        //}

        #endregion 密码修改

        #region 用户

        public ActionResult UserInfo()
        {
            if (!string.IsNullOrWhiteSpace(this.UserID))
            {
                LumluxSSYDB.BLL.tUserInfoes bllUser = new LumluxSSYDB.BLL.tUserInfoes();
                LumluxSSYDB.Model.tUserInfoes modelUser = new LumluxSSYDB.Model.tUserInfoes();
                LumluxSSYDB.BLL.tPrjectInfo bllProject = new LumluxSSYDB.BLL.tPrjectInfo();
                LumluxSSYDB.Model.tPrjectInfo modelProject = new LumluxSSYDB.Model.tPrjectInfo();
                modelUser = bllUser.GetModel(this.UserID);
                if ((modelUser != null) && (!string.IsNullOrWhiteSpace(modelUser.sPrjectInfoGUID)))
                {
                    modelProject = bllProject.GetModel(modelUser.sPrjectInfoGUID);
                    if (string.IsNullOrWhiteSpace(modelUser.sUserName))
                    {
                        ViewBag.UserName = "";
                    }
                    else
                    ViewBag.UserName = modelUser.sUserName;

                    if (string.IsNullOrWhiteSpace(modelUser.sAlias))
                    {
                        ViewBag.UserAlias = "";
                    }
                    else
                        ViewBag.UserAlias = modelUser.sAlias;

                    if (string.IsNullOrWhiteSpace(modelUser.sEmail))
                    {
                        ViewBag.UserEmail = "";
                    }
                    else
                    ViewBag.UserEmail = modelUser.sEmail;

                    if (string.IsNullOrWhiteSpace(modelUser.sPhone))
                    {
                        ViewBag.UserPhone = "";
                    }
                    else
                    ViewBag.UserPhone = modelUser.sPhone;

                    if (string.IsNullOrWhiteSpace(modelUser.dCreateDate.ToString()))
                    {
                        ViewBag.UserCreateTime = "";
                    }
                    else
                        ViewBag.UserCreateTime = modelUser.dCreateDate.ToString();

                    if (string.IsNullOrWhiteSpace(modelUser.sRemark))
                    {
                        ViewBag.UserRemark = "";
                    }
                    else
                    ViewBag.UserRemark = modelUser.sRemark;

                    if (string.IsNullOrWhiteSpace(modelProject.sName))
                    {
                        ViewBag.ProName = "";
                    }
                    else
                    ViewBag.ProName = modelProject.sName;

                    if (string.IsNullOrWhiteSpace(modelProject.sAuthor))
                    {
                        ViewBag.ProAuthor = "";
                    }
                    else
                    ViewBag.ProAuthor = modelProject.sAuthor;
                    if (modelProject.fLng == null)
                    {
                        ViewBag.ProLng = "";
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(modelProject.fLng.ToString()))
                        {
                            ViewBag.ProLng = "";
                        }
                        else
                            ViewBag.ProLng = modelProject.fLng.ToString();
                    }

                    if (modelProject.fLat == null)
                    {
                        ViewBag.ProLat = "";
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(modelProject.fLng.ToString()))
                        {
                            ViewBag.ProLat = "";
                        }
                        else
                        ViewBag.ProLat = modelProject.fLat.ToString();
                    }

                    if (modelProject.dCreateDate == null)
                    {
                        ViewBag.ProCreateTime = "";
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(modelProject.dCreateDate.ToString()))
                        {
                            ViewBag.ProCreateTime = "";
                        }
                        else
                        ViewBag.ProCreateTime = modelProject.dCreateDate.ToString();
                    }

                    if (string.IsNullOrWhiteSpace(modelProject.sRemark))
                    {
                        ViewBag.ProRemark = "";
                    }
                    else
                    ViewBag.ProRemark = modelProject.sRemark;

                    return View();
                }
                else
                {
                    // 采用区域重定向
                    return RedirectToAction("Login", "User", new { Area = "Lamp" });
                }

            }
            else
            {
                // 采用区域重定向
                return RedirectToAction("Login", "User", new { Area = "Lamp" });
            }
        }

        #endregion 用户

        #region 回路控制

        public JsonResult ReturnCircuit()
        {
            int a = 0;
            //业务逻辑
            BLL.tHostInfo bllhost = new BLL.tHostInfo();
            Model.tHostInfo modhost = new Model.tHostInfo();
            if (!string.IsNullOrWhiteSpace(Request.QueryString["sGUID"]))
            {
                modhost = bllhost.GetModel(Request.QueryString["sGUID"]);
                if (modhost!=null)
                {
                    if (modhost.iHardware_Type==null)
                    {
                        return Json(a);
                    }
                    else
                    {
                        if (modhost.iHardware_Type==(int)HostHardwareType.Big)
                        {
                            a = 1;
                            return Json(a);
                        }
                        else
                        {
                            return Json(a);
                        }
                    }
                }
                else
                {
                    return Json(a);
                }
            }
            else
            {
                return Json(a);
            }
        }

        public JsonResult ReturnCircuitResult()
        {
            /*
            result :
             * 0:参数错误
             * 1:主机未设置地址
             * 2:写数据库失败
             * 3:写成功
             */
            BLL.tHostInfo bllhost = new BLL.tHostInfo();
            Model.tHostInfo modhost = new Model.tHostInfo();
            BLL.tCMDSends bllsend = new BLL.tCMDSends();
            Model.tCMDSends modsend = new Model.tCMDSends();
            byte[] bt1 = null;
            int result = 0;

            if ((!string.IsNullOrWhiteSpace(Request.QueryString["sGUID"])) && (!string.IsNullOrWhiteSpace(Request.QueryString["sMode"])) && (!string.IsNullOrWhiteSpace(Request.QueryString["sOpen"])))
            {
                Model.tHostInfo dt2 = bllhost.GetModel(Request.QueryString["sGUID"]);
                if (dt2 != null)
                {
                    if (!string.IsNullOrWhiteSpace(dt2.sID_Addr))
                    {

                        int hostID;
                        int lightID;
                        int Switch;
                        byte GroupID;
                        byte PowerValue;
                        byte Cmd;
                        byte ControlMode;

                        try
                        {
                            hostID = int.Parse(dt2.sID_Addr);
                            lightID = int.Parse(Request.QueryString["sMode"]);
                            //Mode = int.Parse(Request.QueryString["sMode"]);
                            Switch = int.Parse(Request.QueryString["sOpen"]);
                            PowerValue = 0x00;
                            GroupID = 0xFF;

                            if (lightID == 0)//全部
                            {
                                if (Switch==0)//关闭
                                {
                                    Cmd = 0x42;
                                    ControlMode = 0x00;
                                    bt1 = LightGPRSProtocol.SetLightStateCMD(hostID, GroupID, lightID, Cmd, ControlMode, PowerValue);
                                }
                                else
                                {
                                    Cmd = 0x41;
                                    ControlMode = 0x00;
                                    bt1 = LightGPRSProtocol.SetLightStateCMD(hostID, GroupID, lightID, Cmd, ControlMode, PowerValue);
                                }
                            }
                            else
                            {
                                if (Switch==0)
                                {
                                    Cmd = 0x1C;
                                    ControlMode = 0x00;
                                    bt1 = LightGPRSProtocol.SetLightStateCMD(hostID, GroupID, lightID, Cmd, ControlMode, PowerValue);
                                }
                                else
                                {
                                    Cmd = 0x1B;
                                    ControlMode = 0x00;
                                    bt1 = LightGPRSProtocol.SetLightStateCMD(hostID, GroupID, lightID, Cmd, ControlMode, PowerValue);
                                }
                            }
                            if (bt1 != null)
                            {
                                modsend.dCreateDate = DateTime.Now;
                                modsend.dUpdateTime = DateTime.Now;
                                modsend.sGUID = Guid.NewGuid().ToString();
                                modsend.iContentType = (int)CMDType.SetLightStateCMD;
                                string str = HexHelper.ByteArrayToHexString(bt1);
                                modsend.sContent = str;
                                modsend.iState = (int)CMDState.NO;
                                if (dt2.iIDType != null)
                                {
                                    modsend.iHostIDType = dt2.iIDType;
                                }
                                if (dt2.iIDType != null)
                                {
                                    modsend.iHostIDType = dt2.iIDType;
                                }
                                if (!string.IsNullOrWhiteSpace(dt2.sID_Addr))
                                {
                                    modsend.sHostIDAddr = dt2.sID_Addr;
                                }
                                if (!string.IsNullOrWhiteSpace(dt2.sID_ID))
                                {
                                    modsend.sHostIDID = dt2.sID_ID;
                                }
                                if (!string.IsNullOrWhiteSpace(dt2.sID_IP))
                                {
                                    modsend.sHostIDIP = dt2.sID_IP;
                                }
                                if (!string.IsNullOrWhiteSpace(dt2.sID_MAC))
                                {
                                    modsend.sHostIDMAC = dt2.sID_MAC;
                                }
                                if (!string.IsNullOrWhiteSpace(dt2.sID_SIM))
                                {
                                    modsend.sHostIDSIM = dt2.sID_SIM;
                                }
                                if (bllsend.Add(modsend) == true)
                                {
                                    result = 3;
                                    return Json(result);
                                }
                                else
                                {
                                    result = 2;
                                    return Json(result);
                                }
                            }
                            else
                            {
                                result = 2;
                                return Json(result);
                            }

                        }
                        catch (Exception)
                        {
                            result = 2;
                            return Json(result);
                        }
                    }
                    else
                    {
                        result = 1;
                        return Json(result);
                    }
                }
                else
                {
                    result = 0;
                    return Json(result);
                }
            }
            else
            {
                result = 0;
                return Json(result);
            }
        }

        public JsonResult ReturnCircuitRevsResult()
        {
            /*
            result :
             * 0:参数错误
             * 1:主机未设置地址
             * 2:未找到返回的命令
             * 3:写数据库失败
             * 4:成功
             */

            BLL.tHostInfo bllhost = new BLL.tHostInfo();
            Model.tHostInfo modhost = new Model.tHostInfo();
            BLL.tCMDRevs bllrevs = new BLL.tCMDRevs();
            Model.tCMDRevs modrevs = new Model.tCMDRevs();

            int result = 0;
            if ((!string.IsNullOrWhiteSpace(Request.QueryString["sGUID"])) && (!string.IsNullOrWhiteSpace(Request.QueryString["sTime"])))
            {

                Model.tHostInfo dt2 = bllhost.GetModel(Request.QueryString["sGUID"]);
                if ((dt2 != null) && (!string.IsNullOrWhiteSpace(dt2.sID_ID)))
                {
                    int ContentType;
                    int Time;
                    try
                    {
                        Time = int.Parse(Request.QueryString["sTime"]);
                        ContentType = (int)CMDType.SetLightStateRev;
                        modrevs = bllrevs.GetCMDRecive(ContentType, dt2.sID_ID, Time);
                        if (modrevs != null)
                        {
                            modrevs.iState = (int)CMDState.Yes;
                            if (bllrevs.Update(modrevs))
                            {
                                result = 4;//成功
                                return Json(result);
                            }
                            else
                            {
                                result = 3;//修改未成功
                                return Json(result);
                            }
                        }
                        else
                        {
                            result = 2;//未找到返回的命令
                            return Json(result);
                        }

                    }
                    catch (Exception)
                    {
                        result = 0;//参数错误
                        return Json(result);
                    }
                }
                else
                {
                    result = 1;//未找到单灯的主机或主机IDID未设置
                    return Json(result);
                }
            }
            else
            {
                result = 0;//未选择单灯组
                return Json(result);
            }
        }

        #endregion 回路控制

        #region 主机组

        public JsonResult ReturnHostGroup()
        {
            //业务逻辑
            BLL.tHostInfo bllhost = new BLL.tHostInfo();
            Model.tHostInfo modhost = new Model.tHostInfo();
            BLL.tGroupInfoes bllgroup = new BLL.tGroupInfoes();
            Model.tGroupInfoes modgroup = new Model.tGroupInfoes();
            BLL.tUserInfoes blluser = new BLL.tUserInfoes();
            Model.tUserInfoes moduser = blluser.GetModel(UserID);

            //变量
            HostGroupViewModel manualControlVM = new HostGroupViewModel();
            //查询主机
            DataTable dt = bllhost.GetHostInfo("dbo.tHostInfo.sProjectInfoGUID='" + PrjGUID + "'");
            if (dt != null)
            {
                HostInfoeVM hvm;

                foreach (DataRow dr in dt.Rows)
                {
                    hvm = new HostInfoeVM();
                    hvm.GUID = dr["sGUID"].ToString();
                    if (dr["sName"] != null)
                    {
                        if (string.IsNullOrWhiteSpace(dr["sName"].ToString()))
                        {
                            hvm.Name = "未命名";
                        }
                        else
                            hvm.Name = dr["sName"].ToString();
                    }
                    else
                    {
                        hvm.Name = "未命名";
                    }
                    if (dr["sGroupInfoGUID"] != null)
                    {
                        if (string.IsNullOrWhiteSpace(dr["sGroupInfoGUID"].ToString()))
                        {
                            hvm.GroupGUID = string.Empty;
                        }
                        else
                            hvm.GroupGUID = dr["sGroupInfoGUID"].ToString();
                    }
                    else
                        hvm.GroupGUID = string.Empty;
                    manualControlVM.HostInfoes.Add(hvm);

                }
            }
            //查询组
            List<Model.tGroupInfoes> dt3 = bllgroup.GetModelListByPrjGUID(PrjGUID);
            if (dt3 != null)
            {
                GroupInfoeVM gvm;
                foreach (var item3 in dt3)
                {
                    gvm = new GroupInfoeVM();
                    gvm.GUID = item3.sGUID;
                    if (string.IsNullOrWhiteSpace(item3.sName))
                    {
                        gvm.Name = "未命名";
                    }
                    else
                        gvm.Name = item3.sName;
                    manualControlVM.GroupInfoes.Add(gvm);
                }
            }
            return Json(manualControlVM);
        }

        #endregion 主机组

        #region 单灯及单灯组
        public JsonResult ReturnLightGroup()
        {
            BLL.tLightGroupInfoes blllightgroup = new BLL.tLightGroupInfoes();
            Model.tLightGroupInfoes modlightgroup = new Model.tLightGroupInfoes();
            LightGroupViewModel lightGroupVM = new LightGroupViewModel();
            LightGroupInfoeVM lgvm;
            if (Request.QueryString["sGUID"] != null)
            {
                //查询单灯分组
                List<Model.tLightGroupInfoes> dt2 = blllightgroup.GetModelListByHostGUID(Request.QueryString["sGUID"]);
                if (dt2 != null)
                {
                    foreach (var item2 in dt2)
                    {
                        lgvm = new LightGroupInfoeVM();
                        lgvm.GUID = item2.sGUID.ToString();
                        if (string.IsNullOrWhiteSpace(item2.sName))
                        {
                            lgvm.Name = "未命名";
                        }
                        else
                            lgvm.Name = item2.sName.ToString();
                        lightGroupVM.LightGroupInfoes.Add(lgvm);
                    }
                }
                return Json(lightGroupVM);
            }
            else
            {
                return Json("");
            }
        }

        public JsonResult ReturnLight()
        {
            BLL.tLightInfoes blllight = new BLL.tLightInfoes();
            Model.tLightInfoes modlight = new Model.tLightInfoes();
            LightViewModel lightVM = new LightViewModel();
            LightInfoeVM lvm;
            if (Request.QueryString["sGUID"] != null)
            {
                //查询单灯
                List<Model.tLightInfoes> dt1 = blllight.GetModelListByHostGUID(Request.QueryString["sGUID"]);
                if (dt1 != null)
                {
                    foreach (var item1 in dt1)
                    {
                        lvm = new LightInfoeVM();
                        lvm.GUID = item1.sGUID.ToString();
                        if (string.IsNullOrWhiteSpace(item1.sName))
                        {
                            lvm.Name = "未命名";
                        }
                        else
                            lvm.Name = item1.sName.ToString();
                        lightVM.LightInfoes.Add(lvm);
                    }
                }
                return Json(lightVM);
            }
            else
            {
                return Json("");
            }
        }

        public JsonResult ReturnLightResult()
        {
            /*
            result :
             * 0:参数错误
             * 1:主机未设置地址
             * 2:写数据库失败
             * 3:写成功
             */
            BLL.tLightInfoes blllight = new BLL.tLightInfoes();
            Model.tLightInfoes modlight = new Model.tLightInfoes();
            BLL.tHostInfo bllhost = new BLL.tHostInfo();
            Model.tHostInfo modhost = new Model.tHostInfo();
            BLL.tCMDSends bllsend = new BLL.tCMDSends();
            Model.tCMDSends modsend = new Model.tCMDSends();
            LightViewModel lightVM = new LightViewModel();
            BLL.tLightGroupInfoes blllightgroup = new BLL.tLightGroupInfoes();
            Model.tLightGroupInfoes modlightgroup = new Model.tLightGroupInfoes();
            byte[] bt1 = null;
            int Type;//1为单灯，2为组
            int result = 0;

            if ((!string.IsNullOrWhiteSpace(Request.QueryString["sGUID"])) && (!string.IsNullOrWhiteSpace(Request.QueryString["sMode"])) && (!string.IsNullOrWhiteSpace(Request.QueryString["sSwitch"])) && (!string.IsNullOrWhiteSpace(Request.QueryString["sValue"])) && (!string.IsNullOrWhiteSpace(Request.QueryString["sType"])))
            {
                Type = int.Parse(Request.QueryString["sType"]);
                if (Type == 1)
                {

                    //查询单灯
                    Model.tLightInfoes dt1 = blllight.GetModel(Request.QueryString["sGUID"]);
                    if ((dt1 != null) && (!string.IsNullOrWhiteSpace(dt1.sHostInfoGUID)))
                    {
                        Model.tHostInfo dt2 = bllhost.GetModel(dt1.sHostInfoGUID);
                        if (dt2 != null)
                        {
                            if (!string.IsNullOrWhiteSpace(dt2.sID_Addr))
                            {

                                int hostID;
                                int lightID;

                                bool Mode;
                                bool Switch;
                                byte GroupID;
                                byte PowerValue;
                                byte Cmd;
                                byte ControlMode;

                                try
                                {
                                    hostID = int.Parse(dt2.sID_Addr);
                                    lightID = int.Parse(dt1.sLightID);
                                    Mode = bool.Parse(Request.QueryString["sMode"]);
                                    Switch = bool.Parse(Request.QueryString["sSwitch"]);
                                    PowerValue = byte.Parse(Request.QueryString["sValue"]);

                                    //GroupID = 0x00;
                                    if (lightID > 2047)
                                    {
                                        result = 0;
                                        return Json(result);
                                    }

                                    if (Mode == true)
                                    {
                                        if (Switch == true)
                                        {
                                            GroupID = 0x00;
                                            Cmd = 0x1B;
                                            ControlMode = 0x11;
                                            bt1 = LightGPRSProtocol.SetLightStateCMD(hostID, GroupID, lightID, Cmd, ControlMode, PowerValue);
                                        }
                                        else
                                        {
                                            GroupID = 0x00;
                                            Cmd = 0x1C;
                                            ControlMode = 0x13;
                                            bt1 = LightGPRSProtocol.SetLightStateCMD(hostID, GroupID, lightID, Cmd, ControlMode, PowerValue);
                                        }
                                    }
                                    else
                                    {
                                        if (Switch == true)
                                        {
                                            GroupID = 0x00;
                                            Cmd = 0x1B;
                                            ControlMode = 0x11;
                                            bt1 = LightGPRSProtocol.SetLightStateCMD(hostID, GroupID, lightID, Cmd, ControlMode, PowerValue);
                                        }
                                        else
                                        {
                                            GroupID = 0x00;
                                            Cmd = 0x1C;
                                            ControlMode = 0x13;
                                            bt1 = LightGPRSProtocol.SetLightStateCMD(hostID, GroupID, lightID, Cmd, ControlMode, PowerValue);
                                        }
                                    }
                                    if (bt1 != null)
                                    {
                                        modsend.dCreateDate = DateTime.Now;
                                        modsend.dUpdateTime = DateTime.Now;
                                        modsend.sGUID = Guid.NewGuid().ToString();
                                        modsend.iContentType = (int)CMDType.SetLightStateCMD;
                                        string str = HexHelper.ByteArrayToHexString(bt1);
                                        modsend.sContent = str;
                                        modsend.iState = (int)CMDState.NO;
                                        if (dt2.iIDType != null)
                                        {
                                            modsend.iHostIDType = dt2.iIDType;
                                        }
                                        if (dt2.iIDType != null)
                                        {
                                            modsend.iHostIDType = dt2.iIDType;
                                        }
                                        if (!string.IsNullOrWhiteSpace(dt2.sID_Addr))
                                        {
                                            modsend.sHostIDAddr = dt2.sID_Addr;
                                        }
                                        if (!string.IsNullOrWhiteSpace(dt2.sID_ID))
                                        {
                                            modsend.sHostIDID = dt2.sID_ID;
                                        }
                                        if (!string.IsNullOrWhiteSpace(dt2.sID_IP))
                                        {
                                            modsend.sHostIDIP = dt2.sID_IP;
                                        }
                                        if (!string.IsNullOrWhiteSpace(dt2.sID_MAC))
                                        {
                                            modsend.sHostIDMAC = dt2.sID_MAC;
                                        }
                                        if (!string.IsNullOrWhiteSpace(dt2.sID_SIM))
                                        {
                                            modsend.sHostIDSIM = dt2.sID_SIM;
                                        }
                                        if (bllsend.Add(modsend) == true)
                                        {
                                            result = 3;
                                            return Json(result);
                                        }
                                        else
                                        {
                                            result = 2;
                                            return Json(result);
                                        }
                                    }
                                    else
                                    {
                                        result = 2;
                                        return Json(result);
                                    }

                                }
                                catch (Exception)
                                {
                                    result = 2;
                                    return Json(result);
                                }
                            }
                            else
                            {
                                result = 1;
                                return Json(result);
                            }
                        }
                        else
                        {
                            result = 0;
                            return Json(result);
                        }
                    }
                    else
                    {
                        result = 0;
                        return Json(result);
                    }

                }
                else
                {
                    //查询单灯
                    Model.tLightGroupInfoes dt1 = blllightgroup.GetModel(Request.QueryString["sGUID"]);
                    if ((dt1 != null) && (!string.IsNullOrWhiteSpace(dt1.sHostInfoGUID)))
                    {
                        Model.tHostInfo dt2 = bllhost.GetModel(dt1.sHostInfoGUID);
                        if (dt2 != null)
                        {
                            if (!string.IsNullOrWhiteSpace(dt2.sID_Addr))
                            {

                                int hostID;
                                int lightID;
                                bool Mode;
                                bool Switch;
                                byte GroupID;
                                byte PowerValue;
                                byte Cmd;
                                byte ControlMode;

                                try
                                {
                                    hostID = int.Parse(dt2.sID_Addr);
                                    lightID = 0;
                                    Mode = bool.Parse(Request.QueryString["sMode"]);
                                    Switch = bool.Parse(Request.QueryString["sSwitch"]);
                                    PowerValue = byte.Parse(Request.QueryString["sValue"]);
                                    if (!string.IsNullOrWhiteSpace(dt1.sID))
                                    {
                                        GroupID =byte.Parse(dt1.sID);
                                    }
                                    else
                                    {
                                        result = 1;
                                        return Json(result);
                                    }

                                    if (lightID > 2047)
                                    {
                                        result = 0;
                                        return Json(result);
                                    }
                                    if (Mode == true)
                                    {
                                        if (Switch == true)
                                        {
                                            Cmd = 0x41;
                                            ControlMode = 0x11;
                                            bt1 = LightGPRSProtocol.SetLightStateCMD(hostID, GroupID, lightID, Cmd, ControlMode, PowerValue);
                                        }
                                        else
                                        {
                                            Cmd = 0x42;
                                            ControlMode = 0x13;
                                            bt1 = LightGPRSProtocol.SetLightStateCMD(hostID, GroupID, lightID, Cmd, ControlMode, PowerValue);
                                        }
                                    }
                                    else
                                    {
                                        if (Switch == true)
                                        {
                                            Cmd = 0x41;
                                            ControlMode = 0x11;
                                            bt1 = LightGPRSProtocol.SetLightStateCMD(hostID, GroupID, lightID, Cmd, ControlMode, PowerValue);
                                        }
                                        else
                                        {
                                            Cmd = 0x42;
                                            ControlMode = 0x13;
                                            bt1 = LightGPRSProtocol.SetLightStateCMD(hostID, GroupID, lightID, Cmd, ControlMode, PowerValue);
                                        }
                                    }
                                    if (bt1 != null)
                                    {
                                        modsend.dCreateDate = DateTime.Now;
                                        modsend.dUpdateTime = DateTime.Now;
                                        modsend.sGUID = Guid.NewGuid().ToString();
                                        modsend.iContentType = (int)CMDType.SetLightStateCMD;
                                        string str = HexHelper.ByteArrayToHexString(bt1);
                                        modsend.sContent = str;
                                        modsend.iState = (int)CMDState.NO;
                                        if (dt2.iIDType != null)
                                        {
                                            modsend.iHostIDType = dt2.iIDType;
                                        }
                                        if (dt2.iIDType != null)
                                        {
                                            modsend.iHostIDType = dt2.iIDType;
                                        }
                                        if (!string.IsNullOrWhiteSpace(dt2.sID_Addr))
                                        {
                                            modsend.sHostIDAddr = dt2.sID_Addr;
                                        }
                                        if (!string.IsNullOrWhiteSpace(dt2.sID_ID))
                                        {
                                            modsend.sHostIDID = dt2.sID_ID;
                                        }
                                        if (!string.IsNullOrWhiteSpace(dt2.sID_IP))
                                        {
                                            modsend.sHostIDIP = dt2.sID_IP;
                                        }
                                        if (!string.IsNullOrWhiteSpace(dt2.sID_MAC))
                                        {
                                            modsend.sHostIDMAC = dt2.sID_MAC;
                                        }
                                        if (!string.IsNullOrWhiteSpace(dt2.sID_SIM))
                                        {
                                            modsend.sHostIDSIM = dt2.sID_SIM;
                                        }
                                        if (bllsend.Add(modsend) == true)
                                        {
                                            result = 3;
                                            return Json(result);
                                        }
                                        else
                                        {
                                            result = 2;
                                            return Json(result);
                                        }
                                    }
                                    else
                                    {
                                        result = 2;
                                        return Json(result);
                                    }

                                }
                                catch (Exception)
                                {
                                    result = 2;
                                    return Json(result);
                                }
                            }
                            else
                            {
                                result = 1;
                                return Json(result);
                            }
                        }
                        else
                        {
                            result = 0;
                            return Json(result);
                        }
                    }
                    else
                    {
                        result = 0;
                        return Json(result);
                    }
                }
            }
            else
            {
                result = 0;
                return Json(result);
            }
        }

        public JsonResult ReturnLightRevsResult()
        {
            /*
            result :
             * 0:参数错误
             * 1:主机未设置地址
             * 2:未找到返回的命令
             * 3:写数据库失败
             * 4:成功
             */
            BLL.tLightInfoes blllight = new BLL.tLightInfoes();
            Model.tLightInfoes modlight = new Model.tLightInfoes();
            BLL.tLightGroupInfoes blllightgroup = new BLL.tLightGroupInfoes();
            Model.tLightGroupInfoes modlightgroup = new Model.tLightGroupInfoes();
            BLL.tHostInfo bllhost = new BLL.tHostInfo();
            Model.tHostInfo modhost = new Model.tHostInfo();
            BLL.tCMDRevs bllrevs = new BLL.tCMDRevs();
            Model.tCMDRevs modrevs = new Model.tCMDRevs();
            LightViewModel lightVM = new LightViewModel();

            int result = 0;
            if ((!string.IsNullOrWhiteSpace(Request.QueryString["sGUID"])) && (!string.IsNullOrWhiteSpace(Request.QueryString["sType"])) && (!string.IsNullOrWhiteSpace(Request.QueryString["sTime"])))
            {
                int Type = int.Parse(Request.QueryString["sType"]);//1为单灯，2为组
                if (Type == 1)
                {
                    //查询单灯
                    Model.tLightInfoes dt1 = blllight.GetModel(Request.QueryString["sGUID"]);
                    if ((dt1 != null) && (!string.IsNullOrWhiteSpace(dt1.sHostInfoGUID)))
                    {


                        Model.tHostInfo dt2 = bllhost.GetModel(dt1.sHostInfoGUID);
                        if ((dt2 != null) && (!string.IsNullOrWhiteSpace(dt2.sID_ID)))
                        {
                            int ContentType;
                            int Time;
                            try
                            {
                                Time = int.Parse(Request.QueryString["sTime"]);
                                ContentType = (int)CMDType.SetLightStateRev;

                                modrevs = bllrevs.GetCMDRecive(ContentType, dt2.sID_ID, Time);
                                if (modrevs != null)
                                {
                                    modrevs.iState = (int)CMDState.Yes;
                                    if (bllrevs.Update(modrevs))
                                    {
                                        result = 4;//成功
                                        return Json(result);
                                    }
                                    else
                                    {
                                        result = 3;//修改未成功
                                        return Json(result);
                                    }
                                }
                                else
                                {
                                    result = 2;//未找到返回的命令
                                    return Json(result);
                                }

                            }
                            catch (Exception)
                            {
                                result = 0;//参数错误
                                return Json(result);
                            }
                        }
                        else
                        {
                            result = 1;//未找到单灯的主机或主机IDID未设置
                            return Json(result);
                        }
                    }
                    else
                    {
                        result = 0;//未找到该单灯
                        return Json(result);
                    }
                }
                else
                {
                    //查询单灯
                    Model.tLightGroupInfoes dt1 = blllightgroup.GetModel(Request.QueryString["sGUID"]);
                    if ((dt1 != null) && (!string.IsNullOrWhiteSpace(dt1.sHostInfoGUID)))
                    {


                        Model.tHostInfo dt2 = bllhost.GetModel(dt1.sHostInfoGUID);
                        if ((dt2 != null) && (!string.IsNullOrWhiteSpace(dt2.sID_ID)))
                        {
                            int ContentType;
                            int Time;
                            try
                            {
                                Time = int.Parse(Request.QueryString["sTime"]);
                                ContentType = (int)CMDType.SetLightStateRev;

                                modrevs = bllrevs.GetCMDRecive(ContentType, dt2.sID_ID, Time);
                                if (modrevs != null)
                                {
                                    modrevs.iState = (int)CMDState.Yes;
                                    if (bllrevs.Update(modrevs))
                                    {
                                        result = 4;//成功
                                        return Json(result);
                                    }
                                    else
                                    {
                                        result = 3;//修改未成功
                                        return Json(result);
                                    }
                                }
                                else
                                {
                                    result = 2;//未找到返回的命令
                                    return Json(result);
                                }

                            }
                            catch (Exception)
                            {
                                result = 0;//参数错误
                                return Json(result);
                            }
                        }
                        else
                        {
                            result = 1;//未找到单灯的主机或主机IDID未设置
                            return Json(result);
                        }
                    }
                    else
                    {
                        result = 0;//未找到该单灯组
                        return Json(result);
                    }
                }
            }
            else
            {
                result = 0;//未选择单灯组
                return Json(result);
            }
        }

        #endregion 单灯组



        //
        // GET: /Lamp/Shared/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Lamp/Shared/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Lamp/Shared/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Lamp/Shared/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Lamp/Shared/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Lamp/Shared/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Lamp/Shared/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
