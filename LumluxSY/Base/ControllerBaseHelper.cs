using LumluxSY.Areas.Lamp.Models;
using LumluxSY.Attributes;
using Maticsoft.DBUtility;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LumluxSY.Base
{
    public class ControllerBaseHelper : Controller
    {
        public int RemPassWord = 0;
        public string TerminalID;

        private string _AlarmSelectedGUID;
        public string AlarmSelectedGUID
        {
            get { return _AlarmSelectedGUID; }
            set { _AlarmSelectedGUID = value; }
        }
        string imageurl = "logoMain.png";
        public ControllerBaseHelper()
            : base()
        {
            List<HostInfoVM> list = new List<HostInfoVM>();
            LumluxSSYDB.BLL.tHostInfo bllhost = new LumluxSSYDB.BLL.tHostInfo();
            #region 加载顶部所有单灯报警
            DataTable allhostalarmdt = bllhost.GetHostInfo("dbo.tHostInfo.sProjectInfoGUID='" + PrjGUID + "' and dbo.tHostInfo.iState_Online=1 and dbo.tHostInfo.iState_Alarm=1");

            if (allhostalarmdt != null)
            {
                allhostalarmdt.Columns.Add("hostByLightCount");
                allhostalarmdt.Columns.Add("hostByAlarmLightCount");
                HostInfoVM hvms;
                foreach (DataRow dr in allhostalarmdt.Rows)
                {
                    hvms = addInfo(dr);
                    list.Add(hvms);
                }
                ViewBag.allAlarmhostlist = list;
            }
            else
            {
                ViewBag.allAlarmhostlist = new List<HostInfoVM>();
            }
            #endregion
            #region 加载该项目的logo图片
            LumluxSSYDB.BLL.tPrjectSet set_bll = new LumluxSSYDB.BLL.tPrjectSet();
            LumluxSSYDB.Model.tPrjectSet set_mod = set_bll.GetModelByWhere(PrjGUID, "logoMain_0001");
            if (set_mod != null)
            {
                ViewBag.logoMain = set_mod.sValue;
            }
            else
            {
                ViewBag.logoMain = imageurl;
            }
            #endregion
            #region 用户相关
            ViewBag.UserName = this.UserName;
            ViewBag.UserAuthority = this.UserAuthority;
            #endregion
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set
            {
                CookieHelper.Save("UserName", value);
            }
            get
            {
                return CookieHelper.GetValue("UserName");
            }
        }
        private string getKey()
        {
            for (int i = 0; i < 99; i++)
            {
                if (true)
                {

                }
            }
            return "";
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID
        {
            set
            {
                if (RemPassWord > 0)
                {
                    CookieHelper.Save("UserID", value, RemPassWord);
                }
                CookieHelper.Save("UserID", value);
            }
            get
            {
                return CookieHelper.GetValue("UserID");
            }
        }

        public string UserAuthority
        {
            set
            {
                CookieHelper.Save("UserAuthority", value);
            }
            get
            {
                return CookieHelper.GetValue("UserAuthority");
            }
        }

        /// <summary>
        /// 项目GUID
        /// </summary>
        public string PrjGUID
        {
            set
            {
                CookieHelper.Save("PrjGUID", value);
            }
            get
            {
                return CookieHelper.GetValue("PrjGUID");
            }
        }

        public string ToString(object obj)
        {

            if (!DBNull.Value.Equals(obj))
                return obj.ToString();
            else
                return String.Empty;
        }
        public HostInfoVM addInfo(DataRow dr)
        {
            HostInfoVM hvm = new HostInfoVM();

            hvm.GUID = dr["sGUID"].ToString();

            dr["hostByLightCount"] = GetLightCountByHostGUID(hvm.GUID);
            dr["hostByAlarmLightCount"] = GetLightCountByHostGUID(hvm.GUID, "Alarm");//获取主机下的所有单灯报警的个数
            hvm.ID = ToString(dr["sID_ID"]) == "" ? "无地址" : ToString(dr["sID_ID"]);//主机地址
            hvm.Lat = ToString(dr["fLat"]);
            hvm.Lng = ToString(dr["fLng"]);
            hvm.Name = ToString(dr["sName"].ToString());
            hvm.iHardware_Type = Convert.ToInt32(ToString(dr["iHardware_Type"]) == "" ? "0" : ToString(dr["iHardware_Type"]));//默认小三要
            if (hvm.Name.Length > 8)
            {
                hvm.AsName = hvm.Name.Substring(0, 8) + "...";
            }
            else
            {
                hvm.AsName = hvm.Name;
            }
            hvm.UpdateTime = Convert.ToDateTime(ToString(dr["dUpdateTime"]) == "" ? "1999-01-01 00:00:00" : ToString(dr["dUpdateTime"]));
            hvm.sUpdateTime = hvm.UpdateTime.ToString("yyyy-MM-dd hh:mm") == "" ? "1999-01-01 00:00" : hvm.UpdateTime.ToString("yyyy-MM-dd hh:mm");
            hvm.GroupName = ToString(dr["GroupName"]) == "" ? "无分组" : ToString(dr["GroupName"]);
            if (hvm.GroupName.Length>4)
            {
                hvm.AllGroupName = hvm.GroupName.Substring(0, 4)+"...";
            }
            else
            {
                hvm.AllGroupName = hvm.GroupName;
            }
            hvm.Online = Convert.ToInt32(ToString(dr["iState_Online"]) == "" ? "0" : ToString(dr["iState_Online"]));
            hvm.Alarm = Convert.ToInt32(ToString(dr["iState_Alarm"]) == "" ? "0" : ToString(dr["iState_Alarm"]));
            hvm.hostByLightCount = Convert.ToInt32(ToString(dr["hostByLightCount"]) == "" ? "0" : ToString(dr["hostByLightCount"]));
            hvm.hostByAlarmLightCount = Convert.ToInt32(ToString(dr["hostByAlarmLightCount"]) == "" ? "0" : ToString(dr["hostByAlarmLightCount"]));
            if (hvm.State == "alarm")
            {
                hvm.strHostState = "报警";
                hvm.sImageUrl = ToString(GetSetValue("Host_Alarm_Image_" + hvm.Alarm.ToString("D4"), "sValue")) == "" ? "HostDefault.png" : ToString(GetSetValue("Host_Alarm_Image_" + hvm.Alarm.ToString("D4"), "sValue"));
            }
            else if (hvm.State == "unonline")
            {
                hvm.strHostState = "离线";
                hvm.sImageUrl = ToString(GetSetValue("Host_Unonline_Image_" + hvm.Alarm.ToString("D4"), "sValue")) == "" ? "HostDefault.png" : ToString(GetSetValue("Host_Unonline_Image_" + hvm.Alarm.ToString("D4"), "sValue"));
            }
            else if (hvm.State == "online")
            {
                hvm.strHostState = "在线";
                hvm.sImageUrl = ToString(GetSetValue("Host_Online_Image_" + hvm.Alarm.ToString("D4"), "sValue")) == "" ? "HostDefault.png" : ToString(GetSetValue("Host_Online_Image_" + hvm.Alarm.ToString("D4"), "sValue"));
            }
            //hvm.strHostState = ToString(GetSetValue("Host_StateAlarm_" + hvm.Alarm.ToString("D4"), "sValue")) == "" ? "无状态" : ToString(GetSetValue("Host_StateAlarm_" + hvm.Alarm.ToString("D4"), "sValue"));

            return hvm;
        }
        public PrjectSetInfoVM addprjectsetInfo(DataRow dr)
        {
            PrjectSetInfoVM psm = new PrjectSetInfoVM();
            psm.GUID = dr["sGUID"].ToString();
            psm.sKey = ToString(dr["sKey"]);
            psm.sValue = ToString(dr["sValue"]) == "" ? "255.png" : ToString(dr["sValue"]);
            psm.sDesc = ToString(dr["sDesc"]);
            return psm;
        }
        public DataTable Alarms
        {
            get
            {
                //if (string.IsNullOrEmpty(UserID))
                return null;
                //return new BLL.RecordDataInfo().GetAlarmByUserID(UserID, 10);    
            }
        }


        public DataTable Cameras
        {
            get
            {
                // if (string.IsNullOrEmpty(UserID))
                return null;
                //return new BLL.RecordDataInfo().GetCameras(TerminalID);
            }
        }

        /// <summary>
        /// 获取主机单灯总个数
        /// </summary>
        /// <param name="hostGUID"></param>
        /// <returns></returns>
        public int GetLightCountByHostGUID(string hostGUID)
        {
            string sql = "select count(*) from tLightInfoes where iEnable=1 and sHostInfoGUID ='" + hostGUID + "'";
            object x = DbHelperSQL.GetSingle(sql);
            if (x != null)
            {
                return Convert.ToInt32(x);
            }
            return 0;
        }

        public int GetMaxPageCount(string prjGUID, string strWhere, DateTime startTime, DateTime endTime, int iCount, string LightName)
        {
            string sql = "SELECT MAX( iNum ) as m FROM (select row_number() over (order by h.sName, ls.dUpdateTime, li.sName) as iNum from tLightInfoes as li inner join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID inner join tHostInfo as h on li.sHostInfoGUID=h.sGUID  where " + LightName + " li.iEnable=1 and h.sProjectInfoGUID='" + prjGUID + "' and " + strWhere + " and ls.dUpdateTime >='" + startTime + "' and ls.dUpdateTime <= '" + endTime + "')   as A  WHERE iNum > 10*(1-1) ";
            object x = DbHelperSQL.GetSingle(sql);
            if (x != null)
            {
                return Convert.ToInt32(x);
            }
            return 0;
        }



        /// <summary>
        /// 故障的个数
        /// </summary>
        /// <param name="prjGUID"></param>
        /// <param name="iFault"></param>
        /// <param name="sHostGUID"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int GetFalutCount(string prjGUID, string strWhere, DateTime startTime, DateTime endTime,string LightName)
        {
            //string sql = "SELECT  count(*)  from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID inner join tHostInfo as h on li.sHostInfoGUID=h.sGUID  where h.sProjectInfoGUID='" + prjGUID + "' and ls.dUpdateTime >='" + startTime + "' and ls.dUpdateTime <= '" + endTime + "'" + stWhere;
            string sql = "SELECT count(*) ,(select count(1) from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID inner join tHostInfo as h on li.sHostInfoGUID=h.sGUID where h.sProjectInfoGUID='" + prjGUID + "'and " + strWhere + " and ls.dUpdateTime >='" + startTime + "' and ls.dUpdateTime <= '" + endTime + "') as scount FROM (select row_number() over ( order by h.sName, ls.dUpdateTime, li.sName) as iNum,h.sName as hostName,li.sGUID as lightGUID, li.sName as lightName,li.sLightID,li.sLightPhyID,li.fLng,li.fLat,li.sAddr,li.iState_Command, li.iAlarmConfig_Config,li.dAlarmConfig_Start,li.dAlarmConfig_End,li.sAlarmConfig_Remark,li.iRealTimeAlarm_FaultState,li.iRealTimeAlarm_Fault,li.iRealTimeAlarm_CreateDateTime,li.sHostInfoGUID,li.dCreateTime as lightCreateTime,li.dUpdateTime as lightUpadateTime ,li.sRemark,li.sHardware_Version,li.iHardware_Type,li.iEnable,ls.sGUID as lightStateGUID,ls.fVoltage,ls.fCurrent,ls.fPower,ls.iFault,ls.dCreateDate as lightStateCreateTime,ls.dUpdateTime as lightStateUpdateTime,ls.sLightInfoGUID,ls.sSpareField1,ls.sSpareField2,ls.sSpareField3,ls.sSpareField4,ls.sSpareField5,ls.sSpareField6,ls.sSpareField7,ls.sSpareField8,ls.sSpareField9,ls.sSpareField10   from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID inner join tHostInfo as h on li.sHostInfoGUID=h.sGUID  where " + LightName + " li.iEnable=1 and h.sProjectInfoGUID='" + prjGUID + "' and " + strWhere + " and ls.dUpdateTime >='" + startTime + "' and ls.dUpdateTime <= '" + endTime + "')  as A WHERE iNum > 10*(0-1) ";
            object x = DbHelperSQL.GetSingle(sql);

            if (x!=null)
            {
                 return Convert.ToInt32(x);
            }
            return 0;
        }
        public int GetTableCount(string hostGUID,int startCount, int endCount)
        {
            string sql = "select count(*) from tTimeCtrlInfoes where sHostInfoGUID='" + hostGUID + "' and  iID  between '" + startCount + "' and '" + endCount + "'";
            object x = DbHelperSQL.GetSingle(sql);

            if (x != null)
            {
                return Convert.ToInt32(x);
            }
            return 0;
        }

        /// <summary>
        /// 验证开始时间和结束时间
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        public static void VStartAndEndTime(string startDate, string endDate, out DateTime dtStart, out DateTime dtEnd)
        {
            dtStart = DateTime.Parse("1999-01-01");
            if (!string.IsNullOrWhiteSpace(startDate))
            {
                if (DateTime.TryParse(startDate, out dtStart))//如何符合时间格式
                {
                    dtStart = DateTime.Parse(startDate);
                }
                else
                {
                    dtStart = DateTime.Parse("1999-01-01");
                }
            }
            dtEnd = DateTime.Parse("1999-01-01");
            if (!string.IsNullOrWhiteSpace(endDate))
            {
                if (DateTime.TryParse(endDate, out dtEnd))//如何符合时间格式
                {
                    dtEnd = DateTime.Parse(endDate);
                }
                else
                {
                    dtEnd = DateTime.Parse("1999-01-01");
                    //dtEnd = DateTime.Parse("1999-01-01").Add(new TimeSpan(23, 59, 59));
                }
            }
        }

        /// <summary>
        /// 获取主机报了警的单灯总个数
        /// </summary>
        /// <param name="hostGUID"></param>
        /// <returns></returns>
        public int GetLightCountByHostGUID(string hostGUID, string IsAlarm)
        {
            int alarmCount = 0;
            LumluxSSYDB.BLL.tLightInfoes light_bll = new LumluxSSYDB.BLL.tLightInfoes();
            DataTable dt = light_bll.GetLightByWhereInfo(" li.iEnable=1 and sHostInfoGUID='" + hostGUID + "'");
            if (dt != null)
            {
                LumluxSSYDB.BLL.tPrjectSet set_bll = new LumluxSSYDB.BLL.tPrjectSet();
                LumluxSSYDB.Model.tPrjectSet set_mod = new LumluxSSYDB.Model.tPrjectSet();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int RealTimeAlarm_Fault = Convert.ToInt32(ToString(dt.Rows[i]["iRealTimeAlarm_Fault"]) == "" ? "-1" : ToString(dt.Rows[i]["iRealTimeAlarm_Fault"]));
                    set_mod = set_bll.GetModelByWhere(PrjGUID, "Light_IsAlarm_" + RealTimeAlarm_Fault.ToString("D4"));
                    if (set_mod != null && set_mod.sValue == "Alarm")
                    {
                        alarmCount = alarmCount + 1;
                    }
                }
            }
            return alarmCount;
        }

        public string GetLat(string setkey)
        {
            LumluxSSYDB.BLL.tPrjectSet set_bll = new LumluxSSYDB.BLL.tPrjectSet();
            LumluxSSYDB.Model.tPrjectSet set_mod = set_bll.GetModelByWhere(PrjGUID, setkey);
            if (set_mod != null)
            {
                return set_mod.sValue;
            }
            return "31.064698120353743";
        }
        public string GetLng(string setkey)
        {
            LumluxSSYDB.BLL.tPrjectSet set_bll = new LumluxSSYDB.BLL.tPrjectSet();
            LumluxSSYDB.Model.tPrjectSet set_mod = set_bll.GetModelByWhere(PrjGUID, setkey);
            if (set_mod != null)
            {
                return set_mod.sValue;
            }
            return "120.6298828125";
        }
        public string comMax(float a, float b)
        {
            a = System.Math.Abs(a);
            b = System.Math.Abs(b);
            if (a > b)
            {
                return a.ToString();
            }
            else
            {
                return b.ToString();
            }
        }
        public string GetMaxLat(string hostGUID)
        {
            object ob = DbHelperSQL.GetSingle("select max(fLat) from tLightInfoes where iEnable=1 and sHostInfoGUID='" + hostGUID + "'");
            LumluxSSYDB.BLL.tHostInfo host_bll = new LumluxSSYDB.BLL.tHostInfo();
            LumluxSSYDB.Model.tHostInfo host_mod = host_bll.GetModel(hostGUID);
           

            if (ob!=null)
            {

                return comMax(Convert.ToSingle(ob.ToString()), Convert.ToSingle(host_mod.fLat));
            }

            return "";
        }

        public string GetMaxLng(string hostGUID)
        {
            object ob = DbHelperSQL.GetSingle("select max(fLng) from tLightInfoes where iEnable=1 and sHostInfoGUID='" + hostGUID + "'");
            LumluxSSYDB.BLL.tHostInfo host_bll = new LumluxSSYDB.BLL.tHostInfo();
            LumluxSSYDB.Model.tHostInfo host_mod = host_bll.GetModel(hostGUID);
            if (ob != null)
            {
                return comMax(Convert.ToSingle(ob.ToString()), Convert.ToSingle(host_mod.fLng));
            }

            return "";
        }


        /// <summary>
        /// 获取用户配置的报警图片路径
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public string GetSetImageUrl(string setName)
        {
            LumluxSSYDB.BLL.tPrjectSet set_bll = new LumluxSSYDB.BLL.tPrjectSet();
            LumluxSSYDB.Model.tPrjectSet set_mod = set_bll.GetModelByWhere(PrjGUID, setName);
            if (set_mod != null)
            {
                return set_mod.sValue;
            }
            return "2.png";
        }
        public string GetSetValue(string setName,string sFeild)
        {
            LumluxSSYDB.BLL.tPrjectSet set_bll = new LumluxSSYDB.BLL.tPrjectSet();
            LumluxSSYDB.Model.tPrjectSet set_mod = set_bll.GetModelByWhere(PrjGUID, setName);
            if (set_mod != null)
            {
                if (sFeild=="sValue")
                {
                    return set_mod.sValue;
                }
                if (sFeild=="sDesc")
                {
                    return set_mod.sDesc;
                }
            }
            return "";
        }
        protected ContentResult JsonDate(object datas)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return Content(JsonConvert.SerializeObject(datas, Formatting.Indented, timeConverter));
        }

        #region Override controller methods
        /// <summary>
        /// 方法执行前，如果没有登录就调整到Passport登录页面，没有权限就抛出信息
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var noAuthorizeAttributes = filterContext.ActionDescriptor.GetCustomAttributes(typeof(AuthorizeIgnoreAttribute), false);
            if (noAuthorizeAttributes.Length > 0)
                return;

            base.OnActionExecuting(filterContext);

            if (string.IsNullOrEmpty(this.UserID) || string.IsNullOrEmpty(this.PrjGUID))
            {
                filterContext.Result = RedirectToAction("Login", "User", new { Area = "Lamp" });
                return;
            }
        }

        /// <summary>
        /// 方法后执行后注入一些视图数据
        /// </summary>
        /// <param name="filterContext">filter context</param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.ActionDescriptor.ActionName.Contains("Edit") ||
                filterContext.ActionDescriptor.ActionName.Contains("Add"))
                return;
        }

        /// <summary>
        /// 如果是Ajax请求的话，清除浏览器缓存
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
                filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
                filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                filterContext.HttpContext.Response.Cache.SetNoStore();
            }

            base.OnResultExecuted(filterContext);
        }

        #endregion
    }
}