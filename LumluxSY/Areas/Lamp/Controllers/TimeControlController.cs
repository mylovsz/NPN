using LumluxSY.Areas.Lamp.Models;
using LumluxSY.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LumluxSY.Areas.Lamp.Controllers
{
    public class TimeControlController : ControllerBaseHelper
    {
        //
        // GET: /Lamp/TimeControl/

        public ActionResult Index()
        {
            #region 加载左侧所有主机信息

            ViewBag.PrjectGUID = PrjGUID;
            LumluxSSYDB.BLL.tHostInfo bllhost = new LumluxSSYDB.BLL.tHostInfo();
            List<HostInfoVM> list = new List<HostInfoVM>();
            List<TimeInterval> TableOTList = new List<TimeInterval>();
            List<TimeInterval> TableTTList = new List<TimeInterval>();
            LumluxSSYDB.BLL.tLightGroupInfoes blllightgroup = new LumluxSSYDB.BLL.tLightGroupInfoes();
            LumluxSSYDB.BLL.tRelayInfoes lbt = new LumluxSSYDB.BLL.tRelayInfoes();
            //mainVM.MapCenterLat = GetLat("Prject_CenterPoint_Lat");
            //mainVM.MapCenterLng = GetLng("Prject_CenterPoint_Lng");
            DataTable allhostdt = bllhost.GetHostInfo("dbo.tHostInfo.sProjectInfoGUID='" + PrjGUID + "'");

            if (allhostdt != null)
            {
                allhostdt.Columns.Add("hostByLightCount");
                allhostdt.Columns.Add("hostByAlarmLightCount");
                HostInfoVM hvm;
                foreach (DataRow dr in allhostdt.Rows)
                {
                    hvm = addInfo(dr);

                    list.Add(hvm);
                }
            }
            #endregion

            if (list.Count > 0)
            {
                ViewBag.hostlist = list;

                // 初始化主机下的24个时段
                InitTimeControl(list[0].GUID);
                if (!lbt.ExistLoop(list[0].GUID))
                {
                    AddLoop(lbt,list[0].GUID);
                }
                ViewBag.LightGroup = blllightgroup.GetModelListByHostGUID(list[0].GUID) == null ? (new List<LumluxSSYDB.Model.tLightGroupInfoes>()) : (blllightgroup.GetModelListByHostGUID(list[0].GUID));
                if (Convert.ToInt32(list[0].iHardware_Type) == Convert.ToInt32(EnumClass.SYType.eSixLoop))
                {
                    ViewBag.LoopInfo = lbt.GetModelList(" sHostInfoGUID='" + list[0].GUID + "' and iID between 0 and 6 order by iID") == null ? (new List<LumluxSSYDB.Model.tRelayInfoes>()) : lbt.GetModelList(" sHostInfoGUID='" + list[0].GUID + "' and iID between 0 and 6 order by iID");
                }
                else
                {
                    ViewBag.LoopInfo = lbt.GetModelList(" sHostInfoGUID='" + list[0].GUID + "' and iID  between 0 and 3 order by iID") == null ? (new List<LumluxSSYDB.Model.tRelayInfoes>()) : lbt.GetModelList(" sHostInfoGUID='" + list[0].GUID + "' and iID  between 0 and 3 order by iID");
                }
                //查询单灯分组
                //List<LumluxSSYDB.Model.tLightGroupInfoes> dt2 = 

            }
            else
            {
                ViewBag.hostlist = new List<HostInfoVM>();
                ViewBag.TableOT = new List<TimeInterval>();
                ViewBag.TableTT = new List<TimeInterval>();
                ViewBag.LightGroup = new List<LumluxSSYDB.Model.tLightGroupInfoes>();
                ViewBag.LoopInfo = new List<LumluxSSYDB.Model.tRelayInfoes>();
            }
            return View();
        }
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="shsotGUID"></param>
        private void InitTimeControl(string shsotGUID)
        {
            LumluxSSYDB.BLL.tTimeCtrlInfoes lbt = new LumluxSSYDB.BLL.tTimeCtrlInfoes();
            if (GetTableCount(shsotGUID, 1, 24) == 24)
            {
                #region 加载1-12个时段
                ViewBag.TableOT = GetTimeInterval(shsotGUID, 1, 12);
                #endregion
                #region 加载13-24个时段
                ViewBag.TableTT = GetTimeInterval(shsotGUID, 13, 24);
                #endregion
            }
            else
            {
                int iCount = GetTableCount(shsotGUID, 1, 24) + 1;
                LumluxSSYDB.Model.tTimeCtrlInfoes lmt;
                for (int i = iCount; i <= 24; i++)
                {
                    lmt = new LumluxSSYDB.Model.tTimeCtrlInfoes();
                    lmt.sGUID = Guid.NewGuid().ToString();
                    lmt.iID = i;
                    lmt.dTime = DateTime.Now;
                    lmt.iEnable = 0;//启用：1不启用：0
                    lmt.iState_Command = 1;//下放成功：1下放失败：0 
                    lmt.dCreateDate = DateTime.Now;
                    lmt.dUpdateTime = DateTime.Now;
                    lmt.sHostInfoGUID = shsotGUID;
                    lmt.sTagGUID = Guid.NewGuid().ToString();//控制对象GUID
                    lmt.sDesc = "自动生成";
                    if (lbt.Add(lmt))
                    {
                        #region 加载1-12个时段
                        ViewBag.TableOT = GetTimeInterval(shsotGUID, 1, 12);
                        #endregion
                        #region 加载13-24个时段
                        ViewBag.TableTT = GetTimeInterval(shsotGUID, 13, 24);
                        #endregion
                    }
                }
            }
        }
        /// <summary>
        /// 点击左菜单加载
        /// </summary>
        /// <param name="sHostGUID"></param>
        /// <returns></returns>
        private List<TimeInterval> LoadTimeControl(string sHostGUID)
        {
            List<TimeInterval> listTime = new List<TimeInterval>();
            LumluxSSYDB.BLL.tTimeCtrlInfoes lbt = new LumluxSSYDB.BLL.tTimeCtrlInfoes();

            if (GetTableCount(sHostGUID, 1, 24) == 24)
            {
                #region 加载1-24个时段
                listTime = GetTimeInterval(sHostGUID, 1, 24);
                #endregion
            }
            else
            {
                int iCount = GetTableCount(sHostGUID, 1, 24) + 1;
                LumluxSSYDB.Model.tTimeCtrlInfoes lmt;
                for (int i = iCount; i <= 24; i++)
                {
                    lmt = new LumluxSSYDB.Model.tTimeCtrlInfoes();
                    lmt.sGUID = Guid.NewGuid().ToString();
                    lmt.iID = i;
                    lmt.dTime = DateTime.Now;
                    lmt.iEnable = 0;//启用：1不启用：0
                    lmt.iState_Command = 1;//下放成功：1下放失败：0 
                    lmt.dCreateDate = DateTime.Now;
                    lmt.dUpdateTime = DateTime.Now;
                    lmt.sHostInfoGUID = sHostGUID;
                    lmt.sTagGUID = Guid.NewGuid().ToString();
                    lmt.sDesc = "自动生成";
                    if (lbt.Add(lmt))
                    {
                        #region 加载1-24个时段
                        listTime = GetTimeInterval(sHostGUID, 1, 24);
                        #endregion
                    }
                }
            }

            return listTime;
        }
        /// <summary>
        /// 点击编辑加载
        /// </summary>
        /// <param name="sGUID"></param>
        /// <returns></returns>
        private List<TimeInterval> GetTimeControl(string sGUID)
        {
            List<TimeInterval> listTime = new List<TimeInterval>();
            LumluxSSYDB.BLL.tTimeCtrlInfoes lbt = new LumluxSSYDB.BLL.tTimeCtrlInfoes();



            listTime = GetTimeInterval(sGUID);




            return listTime;
        }

        public ActionResult SaveSet()
        {
            return View();
        }
        /// <summary>
        /// 返回单灯分组
        /// </summary>
        /// <returns></returns>
        public JsonResult ReturnLightGroup(string sGUID)
        {
            LumluxSSYDB.BLL.tLightGroupInfoes blllightgroup = new LumluxSSYDB.BLL.tLightGroupInfoes();
            LumluxSSYDB.Model.tLightGroupInfoes modlightgroup = new LumluxSSYDB.Model.tLightGroupInfoes();
            LightGroupViewModel lightGroupVM = new LightGroupViewModel();
            LightGroupInfoeVM lgvm;
            if (!string.IsNullOrWhiteSpace(sGUID))
            {
                //查询单灯分组
                List<LumluxSSYDB.Model.tLightGroupInfoes> dt2 = blllightgroup.GetModelListByHostGUID(sGUID);
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
        public JsonResult GetLoopControl(string sGUID,string ttype)
        {
            List<LumluxSSYDB.Model.tRelayInfoes> lmtlist = new List<LumluxSSYDB.Model.tRelayInfoes>();
            LumluxSSYDB.BLL.tRelayInfoes lbt = new LumluxSSYDB.BLL.tRelayInfoes();
            if (!string.IsNullOrWhiteSpace(sGUID) && !string.IsNullOrWhiteSpace(ttype))
            {
                if (!lbt.ExistLoop(sGUID))
                {
                    AddLoop(lbt, sGUID);
                }
                if (Convert.ToInt32(ttype) == Convert.ToInt32(EnumClass.SYType.eSixLoop))
                {
                    lmtlist = lbt.GetModelList(" sHostInfoGUID='" + sGUID + "' and iID between 0 and 6 order by iID") == null ? (new List<LumluxSSYDB.Model.tRelayInfoes>()) : lbt.GetModelList(" sHostInfoGUID='" + sGUID + "' and iID between 0 and 6  order by iID");
                }
                else
                {
                    lmtlist = lbt.GetModelList(" sHostInfoGUID='" + sGUID + "' and iID between 0 and 3 order by iID") == null ? (new List<LumluxSSYDB.Model.tRelayInfoes>()) : lbt.GetModelList(" sHostInfoGUID='" + sGUID + "' and iID between 0 and 3 order by iID");
                }
            }

            return Json(lmtlist);
        }

        private void AddLoop(LumluxSSYDB.BLL.tRelayInfoes lbt,string sHsotGUID)
        {
            LumluxSSYDB.Model.tRelayInfoes lmt;

            for (int i = 0; i <= 6; i++)
            {

                lmt = new LumluxSSYDB.Model.tRelayInfoes();
                lmt.sGUID = Guid.NewGuid().ToString();
                lmt.iID = i;
                if (i==0)
                {
                    lmt.sName = "所有回路";
                }
                else
                {
                    lmt.sName = "回路" + i;
                }
                lmt.sHostInfoGUID = sHsotGUID;
                lmt.dCreateDate = DateTime.Now;
                lbt.Add(lmt);
            }
        }
        /// <summary>
        /// 保存设置
        /// </summary>
        /// <param name="TimeCtrGUID">时控GUID</param>
        /// <param name="timeset">所设时间</param>
        /// <param name="IsCheckBox">是否启用</param>
        /// <param name="selecttype_time">类型</param>
        /// <param name="selectcircuitinfo_time">所选回路</param>
        /// <param name="modeswitchhl_time">回路状态</param>
        /// <param name="selectlightgroupinfo_time">群组选择</param>
        /// <param name="modeswitch_time">调光选择</param>
        /// <param name="lightswitch">组状态</param>
        /// <param name="slider1_time">调光值</param>
        /// <returns></returns>
        public JsonResult SaveSets(string TimeCtrGUID, string timeset, string IsCheckBox, string selecttype_time, string selectcircuitinfo_time, string modeswitchhl_time, string selectlightgroupinfo_time, string modeswitch_time, string lightswitch, string slider1_time)
        {
            string iSuccess = "0";
            if (selecttype_time == "mr")
            {
                return Json(iSuccess);
            }
            if (!string.IsNullOrWhiteSpace(selecttype_time))
            {
                if (Convert.ToInt32(selecttype_time) == Convert.ToInt32(EnumClass.HWType.eLoop))//回路
                {
                    LumluxSSYDB.BLL.tTimeCtrlInfoes lbt = new LumluxSSYDB.BLL.tTimeCtrlInfoes();
                    if (!string.IsNullOrWhiteSpace(TimeCtrGUID))
                    {
                        LumluxSSYDB.Model.tTimeCtrlInfoes lmt = lbt.GetModel(TimeCtrGUID);
                        lmt.dTime = Convert.ToDateTime(timeset);
                        lmt.iEnable = Convert.ToInt32(IsCheckBox);
                        if (lbt.Update(lmt))
                        {
                            LumluxSSYDB.BLL.tCtrlTagInfoes lbc = new LumluxSSYDB.BLL.tCtrlTagInfoes();
                            LumluxSSYDB.Model.tCtrlTagInfoes lmc = lbc.GetModel(lmt.sTagGUID);
                            if (lmc != null)
                            {
                                lmc.iType = Convert.ToInt32(selecttype_time);//回路
                                lmc.sRelayState = modeswitchhl_time;//回路状态
                                lmc.sRelayInfo_GUID = selectcircuitinfo_time;
                                lbc.Update(lmc);
                            }
                            else
                            {
                                LumluxSSYDB.Model.tCtrlTagInfoes lmcc = new LumluxSSYDB.Model.tCtrlTagInfoes();
                                lmcc.sGUID = lmt.sTagGUID;
                                lmcc.iType = Convert.ToInt32(selecttype_time);
                                lmcc.sRelayInfo_GUID = selectcircuitinfo_time;
                                lmcc.sRelayState = modeswitchhl_time;//回路状态
                                lbc.Add(lmcc);
                            }
                        }
                    }

                }
                else if (Convert.ToInt32(selecttype_time) == Convert.ToInt32(EnumClass.HWType.eGroup))//组
                {
                    LumluxSSYDB.BLL.tTimeCtrlInfoes lbt = new LumluxSSYDB.BLL.tTimeCtrlInfoes();
                    if (!string.IsNullOrWhiteSpace(TimeCtrGUID))
                    {
                        LumluxSSYDB.Model.tTimeCtrlInfoes lmt = lbt.GetModel(TimeCtrGUID);
                        lmt.dTime = Convert.ToDateTime(timeset);
                        lmt.iEnable = Convert.ToInt32(IsCheckBox);
                        if (lbt.Update(lmt))
                        {
                            LumluxSSYDB.BLL.tCtrlTagInfoes lbc = new LumluxSSYDB.BLL.tCtrlTagInfoes();
                            LumluxSSYDB.Model.tCtrlTagInfoes lmc = lbc.GetModel(lmt.sTagGUID);
                            if (lmc != null)
                            {
                                lmc.iType = Convert.ToInt32(selecttype_time);//回路
                                if (modeswitch_time == "0")//没有调光
                                {
                                    lmc.sLightGroupState = modeswitch_time + "," + lightswitch;//状态
                                }
                                else
                                {
                                    lmc.sLightGroupState = modeswitch_time + "," + lightswitch + "," + slider1_time;//状态
                                }

                                lmc.sLightGroupGUID = selectlightgroupinfo_time;
                                lbc.Update(lmc);
                            }
                            else
                            {
                                LumluxSSYDB.Model.tCtrlTagInfoes lmcc = new LumluxSSYDB.Model.tCtrlTagInfoes();
                                lmcc.sGUID = lmt.sTagGUID;
                                lmcc.iType = Convert.ToInt32(selecttype_time);
                                lmcc.sLightGroupGUID = selectlightgroupinfo_time;
                                if (modeswitch_time == "0")//没有调光
                                {
                                    lmcc.sLightGroupState = modeswitch_time + "," + lightswitch;//状态
                                }
                                else
                                {
                                    lmcc.sLightGroupState = modeswitch_time + "," + lightswitch + "," + slider1_time;//状态
                                }
                                lbc.Add(lmcc);
                            }
                        }
                    }
                }
            }
           
            return Json("");
        }
        /// <summary>
        /// 获取设置
        /// </summary>
        /// <param name="sGUID"></param>
        /// <returns></returns>
        public JsonResult GetSets(string sGUID)
        {
            List<TimeInterval> list = new List<TimeInterval>();
            list = GetTimeControl(sGUID);
            return Json(list);
        }
        /// <summary>
        /// 单个主机24个时段
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult OneHostByTimeControl(string sGUID)
        {
            if (!string.IsNullOrWhiteSpace(sGUID))
            {
                List<TimeInterval> lti = new List<TimeInterval>();
                lti = LoadTimeControl(sGUID);
                if (lti.Count > 0)
                {
                    return this.Json(lti);
                }
                return this.Json("");
            }
            else
            {
                return this.Json("");
            }

        }
        [HttpPost]
        public JsonResult OneHostByTimeControlSave(string sGUID)
        {
            if (!string.IsNullOrWhiteSpace(sGUID))
            {
                List<TimeInterval> lti = new List<TimeInterval>();
                lti = LoadTimeControl(sGUID);
                if (lti.Count > 0)
                {
                    return this.Json(lti);
                }
                return this.Json("");
            }
            else
            {
                return this.Json("");
            }
        }
        /// <summary>
        /// 获取主机下的时段
        /// </summary>
        /// <param name="hostGUID"></param>
        /// <param name="startCount"></param>
        /// <param name="endCount"></param>
        /// <returns></returns>
        public List<TimeInterval> GetTimeInterval(string hostGUID, int startCount, int endCount)
        {
            List<TimeInterval> tilist = new List<TimeInterval>();
            LumluxSSYDB.BLL.tTimeCtrlInfoes lbt = new LumluxSSYDB.BLL.tTimeCtrlInfoes();
            DataTable dtTableOT = lbt.GetTimeCtrlInfo(hostGUID, startCount, endCount);
            if (dtTableOT != null)
            {
                TimeInterval til;
                foreach (DataRow dr in dtTableOT.Rows)
                {
                    til = addTimeInterval(dr);
                    tilist.Add(til);
                }
            }
            return tilist;
        }
        /// <summary>
        /// 获取单个时段
        /// </summary>
        /// <param name="sGUID"></param>
        /// <returns></returns>
        public List<TimeInterval> GetTimeInterval(string sGUID)
        {
            List<TimeInterval> tilist = new List<TimeInterval>();
            LumluxSSYDB.BLL.tTimeCtrlInfoes lbt = new LumluxSSYDB.BLL.tTimeCtrlInfoes();
            DataTable dt = lbt.GetTimeCtrlInfoByOne(sGUID);
            if (dt != null)
            {

                TimeInterval til;
                foreach (DataRow dr in dt.Rows)
                {
                    til = addTimeInterval(dr);

                    tilist.Add(til);
                }
            }
            return tilist;
        }

        public TimeInterval addTimeInterval(DataRow dr)
        {
            TimeInterval ti = new TimeInterval();
            ti.tct.sGUID = dr["sGUID"].ToString();
            ti.tct.dTime = Convert.ToDateTime(ToString(dr["dTime"]) == "" ? "1999-01-01 00:00:00" : ToString(dr["dTime"]));
            DateTime dt = Convert.ToDateTime(ti.tct.dTime);
            ti.setTime = dt.ToString("HH:mm:ss");
            ti.tct.iID = Convert.ToInt32(dr["iID"]);
            ti.tct.iEnable = Convert.ToInt32(ToString(dr["iEnable"]) == "" ? "0" : ToString(dr["iEnable"]));//默认非启用
            if (ti.tct.iEnable == 1)
            {
                ti.IsEnable = "已启用";
            }
            if (ti.tct.iEnable == 0)
            {
                ti.IsEnable = "非启用";
            }

            ti.tct.iState_Command = Convert.ToInt32(dr["iState_Command"]);
            ti.tct.sHostInfoGUID = ToString(dr["sHostInfoGUID"]);
            ti.tct.dCreateDate = Convert.ToDateTime(ToString(dr["dCreateDate"]) == "" ? "1999-01-01 00:00:00" : ToString(dr["dCreateDate"]));
            ti.tct.dUpdateTime = Convert.ToDateTime(ToString(dr["dUpdateTime"]) == "" ? "1999-01-01 00:00:00" : ToString(dr["dUpdateTime"]));
            ti.tct.sTagGUID = ToString(dr["sTagGUID"]);
            ti.tct.sDesc = ToString(dr["sDesc"]);
            ti.iHardware_Type = Convert.ToInt32(ToString(dr["iHardware_Type"]) == "" ? "0" : ToString(dr["iHardware_Type"]));//默认小三遥
            ti.sHostName = ToString(dr["sName"]);
            ti.sRelayState = ToString(dr["sRelayState"]);
            ti.sRelayInfo_GUID = ToString(dr["sRelayInfo_GUID"]);

            ti.sLightGroupState = ToString(dr["sLightGroupState"]);

            if (ToString(dr["sLightGroupState"])!="")
            {
                string str = ToString(dr["sLightGroupState"]);
                string[] sArray=str.Split(',');
                if (sArray.Length>2)//说明有调光
                {
                    ti.sLightGroupMState = sArray[0].ToString();
                    ti.sLightGroupState = sArray[1].ToString();
                    ti.sLightGroupMVaule = sArray[2].ToString();
                }
                else
                {
                    ti.sLightGroupMState = sArray[0].ToString();
                    ti.sLightGroupState = sArray[1].ToString();
                }
                
            }
            else
            {
                ti.sLightGroupMState ="";
                ti.sLightGroupState = "";
                ti.sLightGroupMVaule = "";
            }
            ti.sLightGroupGUID = ToString(dr["sLightGroupGUID"]);
            
            if (ToString(dr["iType"]) != "")
            {
                ti.iType = ToString(dr["iType"]);
                if (Convert.ToInt32(dr["iType"]) == Convert.ToInt32(EnumClass.HWType.eLoop))//回路
                {
                    string sTemp = "";
                    if (!string.IsNullOrWhiteSpace(ti.sRelayInfo_GUID))
                    {
                        sTemp += GetLoopNameByGUID(ti.sRelayInfo_GUID) + "-";
                    }
                    if (!string.IsNullOrWhiteSpace(ti.sRelayState))
                    {
                        sTemp += ti.sRelayState=="0"?"关":"开";
                    }
                    ti.ExecutiveAction = sTemp;
                }
                if (Convert.ToInt32(dr["iType"]) == Convert.ToInt32(EnumClass.HWType.eGroup))//群组
                {
                    string sTemp1 = "";
                    if (!string.IsNullOrWhiteSpace(ti.sLightGroupGUID))
                    {
                        sTemp1 += GetGroupNameByGUID(ti.sLightGroupGUID) + "-";
                    }
                    if (!string.IsNullOrWhiteSpace(ti.sLightGroupState))
                    {
                        sTemp1 += ti.sLightGroupState == "0" ? "关" : "开" + "-"; 
                    }
                    if (!string.IsNullOrWhiteSpace(ti.sLightGroupMVaule))
                    {
                        sTemp1 += ti.sLightGroupMVaule == "" ? "空值" :"调光为："+ ti.sLightGroupMVaule+"%";
                    }
                    ti.ExecutiveAction = sTemp1;
                }
            }
            else
            {
                ti.ExecutiveAction = "";
                ti.iType ="";
            }
            return ti;
        }


        /// <summary>
        /// 获取回路的名称
        /// </summary>
        /// <param name="sGUID"></param>
        /// <returns></returns>
        private string GetLoopNameByGUID(string sGUID)
        {
            string LoopName = null;
            LumluxSSYDB.BLL.tRelayInfoes lbti = new LumluxSSYDB.BLL.tRelayInfoes();
            LumluxSSYDB.Model.tRelayInfoes lmti = lbti.GetModel(sGUID);
            if (lmti != null)
            {
                LoopName = lmti.sName;
            }
            return LoopName;
        }
        /// <summary>
        /// 获取组名
        /// </summary>
        /// <param name="sGUID"></param>
        /// <returns></returns>
        private string GetGroupNameByGUID(string sGUID)
        {
            string GroupName = null;
            LumluxSSYDB.BLL.tLightGroupInfoes lbtg = new LumluxSSYDB.BLL.tLightGroupInfoes();
            LumluxSSYDB.Model.tLightGroupInfoes lmtg = lbtg.GetModel(sGUID);
            if (lmtg != null)
            {
                GroupName = lmtg.sName;
            }
            return GroupName;
        }
    }
}
