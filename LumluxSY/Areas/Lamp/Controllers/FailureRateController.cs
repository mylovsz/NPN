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
    public class FailureRateController : ControllerBaseHelper
    {
        //
        // GET: /Lamp/FailureRate/

        public ActionResult Index()
        {
            LumluxSSYDB.BLL.tHostInfo lbt = new LumluxSSYDB.BLL.tHostInfo();
            //and iState_Alarm=1
            List<LumluxSSYDB.Model.tHostInfo> listhost = lbt.GetModelList("sProjectInfoGUID='" + PrjGUID + "' and iState_Enable= '" + (int)StateEnable.Enable + "'"); ;
            if (listhost.Count > 0)
            {
                ViewBag.vHost = listhost;
            }
            else
            {
                ViewBag.vHost = new List<LumluxSSYDB.Model.tHostInfo>();
            }

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
            return View();
        }
        [HttpPost]
        public ActionResult Index(string startDate, string endDate, string hostWhere, string alarmWhere, string LightName)
        {
            string strLightName;
            DateTime dtStart;
            DateTime dtEnd;
            VStartAndEndTime(startDate, endDate, out dtStart, out dtEnd);
            if (!string.IsNullOrWhiteSpace(LightName))
            {
                strLightName = " li.sName like '%"+LightName+"%' and ";
            }
            else
            {
                strLightName = " 1=1 and ";
            }
            LumluxSSYDB.BLL.tPrjectSet light_bll = new LumluxSSYDB.BLL.tPrjectSet();
            DataTable dt = null;
            List<FailureInfo> list = new List<FailureInfo>();
            if (!string.IsNullOrWhiteSpace(hostWhere) && !string.IsNullOrWhiteSpace(alarmWhere))
            {
                //int iWherebyhost;
                string strWherebyalarm = "";

                strWherebyalarm += "(";

                string[] s = alarmWhere.Split(new char[] { ',' });

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != "")
                    {
                        strWherebyalarm += "'" + s[i] + "',";
                    }
                }
                if (strWherebyalarm != "")
                {
                    strWherebyalarm = strWherebyalarm.Remove(strWherebyalarm.LastIndexOf(","), 1);
                }
                strWherebyalarm += ")";
                dt = light_bll.GetTableByWhere("sPrjectGUID='" + PrjGUID + "' and sKey in " + strWherebyalarm);

                if (dt != null)
                {
                    list = GetListData(dt, PrjGUID, hostWhere, alarmWhere, dtStart, dtEnd, strLightName);
                }
                LumluxSSYDB.BLL.tLightInfoes blllight = new LumluxSSYDB.BLL.tLightInfoes();
                if (list.Count > 0)
                {
                    int x = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].sValue == "0")
                        {
                            x=x+1;
                        }
                    }
                    if (x == list.Count)
                    {
                        FailureInfo fInfos = new FailureInfo();
                        fInfos.sKey = "当前无数据";
                        fInfos.sValue = "100";
                        list.Add(fInfos);
                        return this.Json(list);
                    }
                    else
                    {
                        return this.Json(list);
                    }
                }
            }
            FailureInfo fInfo = new FailureInfo();
            fInfo.sKey = "请选择条件统计";
            fInfo.sValue = "100";
            list.Add(fInfo);
            return this.Json(list);
        }
        private List<FailureInfo> GetListData(DataTable dt, string prjGUID, string hostWhere, string alarmWhere, DateTime startTime, DateTime endTime,string LightName)
        {
            List<FailureInfo> list = new List<FailureInfo>();
            if (dt != null)
            {
                string strWhere = "";
                //int iWhere;
                FailureInfo ai, all;
                all = new FailureInfo();
                all.sKey = "其他";
                long allCount = 0;//总的个数
                long aiAllCount = 0;//
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
                    allCount = GetFalutCount(prjGUID, strWhere, startTime, endTime,LightName);
                }
                if (!string.IsNullOrEmpty(alarmWhere))
                {
                    if (!string.IsNullOrEmpty(hostWhere))
                    {
                        strWhere += " and ";
                    }
                }
                foreach (DataRow dr in dt.Rows)
                {
                    ai = new FailureInfo();
                    ai.sKey = ToString(dr["sDesc"]);

                    long aiCount = GetFalutCount(prjGUID, strWhere + "ls.iFault=" + Convert.ToInt32(ToString(dr["sKey"]).Split('_')[2]), startTime, endTime,LightName);
                    aiAllCount += aiCount;
                    if (aiCount != 0)
                    {
                        ai.sValue = ToString(aiCount * 10000 / allCount);
                    }
                    else
                    {
                        ai.sValue = ToString(aiCount);
                    }
                    list.Add(ai);
                }
                if (allCount != 0)
                {
                    all.sValue = ToString((allCount - aiAllCount) * 10000 / allCount);
                    list.Add(all);
                }
            }
            return list;
        }
    }
}
