using LumluxSY.Areas.Lamp.Models;
using LumluxSY.Base;
using ProtocolManage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LumluxSY.Areas.Lamp.Controllers
{
    public class AlarmPageController : ControllerBaseHelper
    {
        //
        // GET: /Lamp/AlarmPage/

        public ActionResult Index()
        {
            string strLightName = " 1=1 and ";
            string curTime = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime dtStart = DateTime.Now.AddDays(-7);//DateTime.Parse("1999-01-01");
            DateTime dtEnd = DateTime.Parse(curTime).Add(new TimeSpan(23, 59, 59));
            if (Request.QueryString["sGUID"] != null)
            {
                ViewBag.sHostGUID = Request.QueryString["sGUID"].ToString();
                AlarmSelectedGUID = Request.QueryString["sGUID"].ToString();

                LumluxSSYDB.BLL.tHostInfo thostbll = new LumluxSSYDB.BLL.tHostInfo();
                LumluxSSYDB.Model.tHostInfo thostmode = thostbll.GetModel(AlarmSelectedGUID);
                if (thostmode != null)
                {
                    ViewBag.HostNames = thostmode.sName;
                }

                //getdataresource gd = new getdataresource();
                //PagingHelper<AlarmInfo> DataPaging = new PagingHelper<AlarmInfo>(10, GetDataSouceByTime(AlarmSelectedGUID, dtStart, dtEnd, 10));
                List<AlarmInfo> DataPaging = GetDataSouceByTime(PrjGUID, AlarmSelectedGUID, dtStart, dtEnd, 0,strLightName);
                ViewBag.CurPageIndex = 1;//当前页
                ViewBag.CurPageIndex = 1;
                if (DataPaging.Count > 0)
                {
                    ViewBag.iCount = DataPaging[0].iCount;//总记录
                    ViewBag.iPage = (int)Math.Ceiling(Convert.ToInt32(DataPaging[0].iCount) / (double)10);
                    ViewBag.Alarms = DataPaging;
                }
                else
                {
                    ViewBag.iCount = 0;//总记录
                    ViewBag.iPage = 0;
                    ViewBag.Alarms = new List<AlarmInfo>();
                }
                ViewBag.vHost = new List<LumluxSSYDB.Model.tHostInfo>();
            }
            else
            {
                #region MyRegion
                LumluxSSYDB.BLL.tHostInfo lbt = new LumluxSSYDB.BLL.tHostInfo();
                //and iState_Alarm=1
                List<LumluxSSYDB.Model.tHostInfo> listhost = lbt.GetModelList("sProjectInfoGUID='" + PrjGUID + "' and iState_Enable='" + (int)StateEnable.Enable + "' "); ;
                if (listhost.Count > 0)
                {
                    ViewBag.vHost = listhost;
                }
                else
                {
                    ViewBag.vHost = new List<LumluxSSYDB.Model.tHostInfo>();
                }
                #endregion
                // ViewBag.Alarms = new List<AlarmInfo>();
                List<AlarmInfo> DataPagingall = GetDataSouceByTime(PrjGUID, dtStart, dtEnd, 0, strLightName);
                ViewBag.CurPageIndex = 1; ;//当前页
                ViewBag.HostNames = "单灯信息";//"全部主机";
                if (DataPagingall.Count > 0)
                {
                    ViewBag.iCount = DataPagingall[0].iCount;//总记录
                    ViewBag.iPage = (int)Math.Ceiling(Convert.ToInt32(DataPagingall[0].iCount) / (double)10);//总页数
                    ViewBag.Alarms = DataPagingall;
                }
                else
                {
                    ViewBag.iCount = 0;//总记录
                    ViewBag.iPage = 0;
                    ViewBag.Alarms = new List<AlarmInfo>();
                }
            }
            #region MyRegion
            List<PrjectSetInfoVM> pslist = new List<PrjectSetInfoVM>();
            LumluxSSYDB.BLL.tPrjectSet light_bll = new LumluxSSYDB.BLL.tPrjectSet();
            LightsViewModel lightVM = new LightsViewModel();
            DataTable dt = light_bll.GetTableByWhere("sPrjectGUID='" + PrjGUID + "' and sKey like  '%Light_Image_%'");
            if (dt != null)
            {
                PrjectSetInfoVM psm;
                foreach (DataRow dr in dt.Rows)
                {
                    psm = addprjectsetInfo(dr);
                    pslist.Add(psm);
                }
                ViewBag.AlarmDemos = pslist;
            }
            else
            {
                ViewBag.AlarmDemos = new List<PrjectSetInfoVM>();
            }
            #endregion
            return View();
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="hostGUID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="hostWhere"></param>
        /// <param name="alarmWhere"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(string hostGUID, string startDate, string endDate, int pageIndex, string hostWhere, string alarmWhere, string LightName)
        {
            List<AlarmInfo> list = new List<AlarmInfo>();
            if (pageIndex >= 1)
            {
                int iPageIndex = pageIndex - 1;//当前页的索引
                DateTime dtStart;
                DateTime dtEnd;

                string strLightName;
                VStartAndEndTime(startDate, endDate, out dtStart, out dtEnd);
                if (!string.IsNullOrWhiteSpace(LightName))
                {
                    strLightName = " li.sName like '%" + LightName + "%' and ";
                }
                else
                {
                    strLightName = " 1=1 and ";
                }
                //AgricultureDB.BLL.RecordDataInfo rdi = new AgricultureDB.BLL.RecordDataInfo();
                // List<AgricultureDB.Model.RecordDataInfo> list = rdi.GetByDate("", dtStart, dtEnd);
                int iWhere;
                string strWhere = "";
                if (!string.IsNullOrEmpty(hostGUID))
                {
                    if (!string.IsNullOrEmpty(hostWhere))
                    {
                        strWhere += "(";

                        string[] s = hostWhere.Split(new char[] { ',' });

                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i] != "")
                            {
                                strWhere += "( h.sGUID='" + s[i] + "') or";
                            }

                        }
                        if (strWhere != "")
                        {
                            strWhere = strWhere.Remove(strWhere.LastIndexOf("or"), 2);
                        }
                        strWhere += ")";
                    }
                    if (!string.IsNullOrEmpty(alarmWhere))
                    {
                        if (!string.IsNullOrEmpty(hostWhere))
                        {
                            strWhere += " and ";
                        }
                        strWhere += " (  ";
                        string[] s = alarmWhere.Split(new char[] { ',' });

                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i] != "")
                            {
                                iWhere = Convert.ToInt32(s[i].Split('_')[2]);

                                strWhere += " ls.iFault=" + iWhere + " or";
                            }

                        }
                        if (strWhere != "")
                        {
                            strWhere = strWhere.Remove(strWhere.LastIndexOf("or"), 2);
                        }
                        strWhere += " )";
                    }
                    if (!string.IsNullOrEmpty(strWhere))
                    {
                        list = GetDataSouceByTAndWhere(PrjGUID, hostGUID, strWhere, dtStart, dtEnd, pageIndex, strLightName);
                    }
                    else
                    {
                        list = GetDataSouceByTime(PrjGUID, hostGUID, dtStart, dtEnd, pageIndex, strLightName);
                    }

                }
                else
                {

                    if (!string.IsNullOrEmpty(hostWhere))
                    {
                        strWhere += "(";

                        string[] s = hostWhere.Split(new char[] { ',' });

                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i] != "")
                            {
                                strWhere += "( h.sGUID='" + s[i] + "') or";
                            }

                        }
                        if (strWhere != "")
                        {
                            strWhere = strWhere.Remove(strWhere.LastIndexOf("or"), 2);
                        }
                        strWhere += ")";
                    }
                    if (!string.IsNullOrEmpty(alarmWhere))
                    {
                        if (!string.IsNullOrEmpty(hostWhere))
                        {
                            strWhere += " and ";
                        }
                        strWhere += " (  ";
                        string[] s = alarmWhere.Split(new char[] { ',' });

                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i] != "")
                            {
                                iWhere = Convert.ToInt32(s[i].Split('_')[2]);

                                strWhere += " ls.iFault=" + iWhere + " or";
                            }
                        }
                        if (strWhere != "")
                        {
                            strWhere = strWhere.Remove(strWhere.LastIndexOf("or"), 2);
                        }
                        strWhere += " )";
                    }
                    if (!string.IsNullOrEmpty(strWhere))
                    {
                        list = GetDataSouceByTAndWhere(PrjGUID, strWhere, dtStart, dtEnd, pageIndex, strLightName);
                    }
                    else
                    {
                        list = GetDataSouceByTime(PrjGUID, dtStart, dtEnd, pageIndex, strLightName);
                    }
                }

                if (list.Count > 0)
                {
                    return Json(list);
                }
            }
            return Json("");
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="hostGUID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="hostWhere"></param>
        /// <param name="alarmWhere"></param>
        /// <returns></returns>
        public JsonResult GetDateWhrer(string hostGUID, string startDate, string endDate, int pageIndex, string hostWhere, string alarmWhere, string LightName)
        {
            if (pageIndex >= 1)
            {
                List<AlarmInfo> list = new List<AlarmInfo>();
                int iPageIndex = pageIndex - 1;//当前页的索引
                DateTime dtStart;
                DateTime dtEnd;
                string strLightName;
                VStartAndEndTime(startDate, endDate, out dtStart, out dtEnd);
                if (!string.IsNullOrWhiteSpace(LightName))
                {
                    strLightName = " li.sName like '%" + LightName + "%' and ";
                }
                else
                {
                    strLightName = " 1=1 and ";
                }
                //AgricultureDB.BLL.RecordDataInfo rdi = new AgricultureDB.BLL.RecordDataInfo();
                // List<AgricultureDB.Model.RecordDataInfo> list = rdi.GetByDate("", dtStart, dtEnd);
                int iWhere;
                string strWhere = "";
                if (!string.IsNullOrEmpty(hostGUID))
                {
                    if (!string.IsNullOrEmpty(hostWhere))
                    {
                        strWhere += "(";

                        string[] s = hostWhere.Split(new char[] { ',' });

                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i] != "")
                            {
                                strWhere += "( h.sGUID='" + s[i] + "') or";
                            }
                        }
                        if (strWhere != "")
                        {
                            strWhere = strWhere.Remove(strWhere.LastIndexOf("or"), 2);
                        }
                        strWhere += ")";
                    }
                    if (!string.IsNullOrEmpty(alarmWhere))
                    {
                        if (!string.IsNullOrEmpty(hostWhere))
                        {
                            strWhere += " and ";
                        }
                        strWhere += " (  ";
                        string[] s = alarmWhere.Split(new char[] { ',' });

                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i] != "")
                            {
                                iWhere = Convert.ToInt32(s[i].Split('_')[2]);

                                strWhere += " ls.iFault=" + iWhere + " or";
                            }
                        }
                        if (strWhere != "")
                        {
                            strWhere = strWhere.Remove(strWhere.LastIndexOf("or"), 2);
                        }
                        strWhere += " )";
                    }
                    if (!string.IsNullOrEmpty(strWhere))
                    {
                        list = GetDataSouceByTAndWhere(PrjGUID, hostGUID, strWhere, dtStart, dtEnd, pageIndex, strLightName);
                    }
                    else
                    {
                        list = GetDataSouceByTime(PrjGUID, hostGUID, dtStart, dtEnd, pageIndex, strLightName);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(hostWhere))
                    {
                        strWhere += "(";

                        string[] s = hostWhere.Split(new char[] { ',' });

                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i] != "")
                            {
                                strWhere += "( h.sGUID='" + s[i] + "') or";
                            }
                        }
                        if (strWhere != "")
                        {
                            strWhere = strWhere.Remove(strWhere.LastIndexOf("or"), 2);
                        }
                        strWhere += ")";
                    }
                    if (!string.IsNullOrEmpty(alarmWhere))
                    {
                        if (!string.IsNullOrEmpty(hostWhere))
                        {
                            strWhere += " and ";
                        }
                        strWhere += " (  ";
                        string[] s = alarmWhere.Split(new char[] { ',' });

                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i] != "")
                            {
                                iWhere = Convert.ToInt32(s[i].Split('_')[2]);

                                strWhere += " ls.iFault=" + iWhere + " or";
                            }
                        }
                        if (strWhere != "")
                        {
                            strWhere = strWhere.Remove(strWhere.LastIndexOf("or"), 2);
                        }
                        strWhere += " )";
                    }
                    if (!string.IsNullOrEmpty(strWhere))
                    {
                        list = GetDataSouceByTAndWhere(PrjGUID, strWhere, dtStart, dtEnd, pageIndex, strLightName);
                    }
                    else
                    {
                        list = GetDataSouceByTime(PrjGUID, dtStart, dtEnd, pageIndex, strLightName);
                    }
                }
                if (list.Count > 0)
                {
                    return Json(list);
                }
            }
            return Json("");
        }
        /// <summary>
        /// 加载此项目下的所有主机的报警信息
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        private List<AlarmInfo> GetDataSouceByTime(string prjectGUID, DateTime dtStart, DateTime dtEnd, int pageIndex,string LightName)
        {
            LumluxSSYDB.BLL.tLightInfoes blllight = new LumluxSSYDB.BLL.tLightInfoes();
            DataTable dt = blllight.GetAllLightAlarmByWhereInfo(prjectGUID, dtStart, dtEnd, 10, pageIndex,LightName);
            List<AlarmInfo> list = GetListData(dt);
            return list;
        }
        /// <summary>
        /// 此项目下的此主机的所有数据
        /// </summary>
        /// <param name="prjectGUID"></param>
        /// <param name="sHostGUID"></param>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        private List<AlarmInfo> GetDataSouceByTime(string prjectGUID, string sHostGUID, DateTime dtStart, DateTime dtEnd, int pageIndex,string LightName)
        {
            LumluxSSYDB.BLL.tLightInfoes blllight = new LumluxSSYDB.BLL.tLightInfoes();
            DataTable dt = blllight.GetAllLightAlarmByWhereInfo(PrjGUID, sHostGUID, dtStart, dtEnd, 10, pageIndex,LightName);
            List<AlarmInfo> list = GetListData(dt);
            return list;
        }
        private List<AlarmInfo> GetDataSouceByTime(string prjectGUID, string sHostGUID, string AlarmWhere, DateTime dtStart, DateTime dtEnd, int pageIndex,string LightName)
        {
            LumluxSSYDB.BLL.tLightInfoes blllight = new LumluxSSYDB.BLL.tLightInfoes();
            DataTable dt = blllight.GetAllLightAlarmByWhereInfo(sHostGUID, AlarmWhere, dtStart, dtEnd, 10, pageIndex,LightName);
            List<AlarmInfo> list = GetListData(dt);
            return list;
        }
        private List<AlarmInfo> GetDataSouceByTAndWhere(string prjectGUID, string strWhere, DateTime dtStart, DateTime dtEnd, int pageIndex,string LightName)
        {
            LumluxSSYDB.BLL.tLightInfoes blllight = new LumluxSSYDB.BLL.tLightInfoes();
            DataTable dt = blllight.GetAllLightAlarmByTAndWhere(prjectGUID, strWhere, dtStart, dtEnd, 10, pageIndex,LightName);
            List<AlarmInfo> list = GetListData(dt);
            return list;
        }
        private List<AlarmInfo> GetDataSouceByTAndWhere(string prjectGUID, string hostGUID, string strWhere, DateTime dtStart, DateTime dtEnd, int pageIndex, string LightName)
        {
            LumluxSSYDB.BLL.tLightInfoes blllight = new LumluxSSYDB.BLL.tLightInfoes();
            DataTable dt = blllight.GetAllLightAlarmByTAndWhere(prjectGUID, hostGUID, strWhere, dtStart, dtEnd, 10, pageIndex,LightName);
            List<AlarmInfo> list = GetListData(dt);
            return list;
        }
        private List<AlarmInfo> GetListData(DataTable dt)
        {
            List<AlarmInfo> list = new List<AlarmInfo>();
            if (dt != null)
            {
                dt.Columns.Add("iPage", typeof(int));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["iPage"] = (int)Math.Ceiling(Convert.ToInt32(dt.Rows[i]["scount"]) / (double)10);
                }
                AlarmInfo ai;
                foreach (DataRow dr in dt.Rows)
                {
                    ai = new AlarmInfo();
                    ai.li.sName = dr["lightName"].ToString();
                    ai.li.iRealTimeAlarm_Fault = Convert.ToInt32(dr["iRealTimeAlarm_Fault"]);
                    ai.ls.iFault = Convert.ToInt32(dr["iFault"]);
                    ai.ls.dUpdateTime = Convert.ToDateTime(dr["lightStateUpdateTime"]);
                    ai.sUpdateTime = ToString(dr["lightStateUpdateTime"]) == "" ? "1999-01-01 00:00:00" : ToString(dr["lightStateUpdateTime"]);
                    ai.ls.sSpareField2 = ToString(dr["sSpareField2"]) == "" || ToString(dr["sSpareField2"]) == "255" ? "无电压" : ToString(dr["sSpareField2"]) + "V";
                    ai.ls.sSpareField3 = ToString(dr["sSpareField3"]) == "" || ToString(dr["sSpareField3"]) == "255" ? "无电流" : ToString(dr["sSpareField3"]) + "A";
                    ai.ls.sSpareField4 = ToString(dr["sSpareField4"]) == "" || ToString(dr["sSpareField4"]) == "255" ? "无功率" : ToString(dr["sSpareField4"]) + "W";
                    ai.ls.sSpareField1 = ToString(dr["sSpareField1"]) == "" || ToString(dr["sSpareField1"]) == "255" ? "无太阳能电压" : ToString(dr["sSpareField1"]) + "V";
                    if (Convert.ToInt32(dr["iHType"]) == Convert.ToInt32(LightType.OldTYN))
                    {
                        ai.ls.sSpareField6 = "NA";
                    }
                    else
                    {
                        ai.ls.sSpareField6 = ToString(dr["sSpareField6"]) == "" || ToString(dr["sSpareField6"]) == "255" ? "无电余量" : Convert.ToDouble(ToString(dr["sSpareField6"])).ToString("f2") + "%";
                    }
                    ai.ls.sSpareField5 = ToString(dr["sSpareField5"]) == "" || ToString(dr["sSpareField5"]) == "255" ? "无温度" : ToString(dr["sSpareField5"]) + "℃";
                    ai.li.sRemark = ToString(dr["sHardware_Version"]) == "" ? "无型号" : ToString(dr["sHardware_Version"]);
                    ai.iNum = Convert.ToInt32(dr["iNum"].ToString());
                    ai.iCount = Convert.ToInt32(ToString(dr["scount"]) == "" ? "0" : ToString(dr["scount"]));//post总记录数
                    ai.iPage = Convert.ToInt32(dr["iPage"].ToString());
                    ai.thost.sName = ToString(dr["hostName"]);
                    ai.Fault = GetSetValue("Light_Image_" + Convert.ToInt32(ai.ls.iFault).ToString("D4"), "sDesc");
                    list.Add(ai);
                }
            }
            return list;
        }
    }
}
