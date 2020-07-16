using LumluxSSYDB.Common.DataConverter;
using LumluxSY.Areas.Lamp.Models;
using LumluxSY.Base;
using ProtocolManage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL = LumluxSSYDB.BLL;
using Model = LumluxSSYDB.Model;

namespace LumluxSY.Areas.Lamp.Controllers
{
    public class MainController : ControllerBaseHelper
    {
        //
        // GET: /Lamp/Main/
        public ActionResult Index()
        {
            #region 加载左侧所有主机信息

            LumluxSSYDB.Model.tUserInfoes ui = new LumluxSSYDB.Model.tUserInfoes();
            LumluxSSYDB.BLL.tUserInfoes uiBll = new LumluxSSYDB.BLL.tUserInfoes();
            
            ui=uiBll.GetModel(UserID);

            ViewBag.ConfigMap = ui.sRemark;

            ViewBag.PrjectGUID = PrjGUID;
            BLL.tHostInfo bllhost = new BLL.tHostInfo();
            MainViewModel mainVM = new MainViewModel();

            BLL.tPrjectInfo tp = new BLL.tPrjectInfo();
            Model.tPrjectInfo tp_mod = tp.GetModel(PrjGUID);
            if (tp_mod != null)
            {
                mainVM.MapCenterLat = tp_mod.fLat.ToString();
                mainVM.MapCenterLng = tp_mod.fLng.ToString();

            }
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

                    mainVM.HostInfos.Add(hvm);
                }
            }
            #endregion


            #region 获取当前项目的标题
            ViewBag.Title = ToString(GetSetValue("MainTitle", "sValue")) == "" ? "无标题，请联系管理员..." : ToString(GetSetValue("MainTitle", "sValue"));
            #endregion

            ViewData["Message"] = "WW";
            return View(mainVM);
        }

        public JsonResult ConfigMap(string map)
        {
            LumluxSSYDB.Model.tUserInfoes ui = new LumluxSSYDB.Model.tUserInfoes();
            LumluxSSYDB.BLL.tUserInfoes uiBll = new LumluxSSYDB.BLL.tUserInfoes();
            ui = uiBll.GetModel(UserID);
            ui.sRemark = map;
            uiBll.Update(ui);
            return this.Json("");
        }
        #region 获取主机实时状态

        public static GetAllStateVM A = new GetAllStateVM();

        /// <summary>
        /// 获取返回界面
        /// </summary>
        /// <param name="guid">主机Guid</param>
        /// <param name="result">发送返回结果</param>
        /// <param name="datetime">查找到数据的时间</param>
        /// <returns>View()</returns>
        [HttpPost]
        public ActionResult HostRealStateDefaultView(string guid, int result, string datetime = "")
        {
            ModelState.Clear();
            BLL.tHostInfo hostbll = new BLL.tHostInfo();
            Model.tHostInfo hostmodel = new Model.tHostInfo();
            BLL.tMeasureConfigs measureconfigbll = new BLL.tMeasureConfigs();
            Model.tMeasureConfigs measureconfigmodel = new Model.tMeasureConfigs();
            BLL.tBranchConfigs branchconfigbll = new BLL.tBranchConfigs();
            List<Model.tBranchConfigs> branchconfigmodellist = new List<Model.tBranchConfigs>();
            BLL.tMeasureInfoes measurebll = new BLL.tMeasureInfoes();
            Model.tMeasureInfoes measuremodel = new Model.tMeasureInfoes();
            List<Model.tMeasureInfoes> measuremodellist = new List<Model.tMeasureInfoes>();
            Model.tMeasurePowerInfoes measurepowermodel = new Model.tMeasurePowerInfoes();
            BLL.tMeasurePowerInfoes measurepowerbll = new BLL.tMeasurePowerInfoes();
            Model.tMeasureCurrentInfoes measurecurrentmodel = new Model.tMeasureCurrentInfoes();
            BLL.tMeasureCurrentInfoes measurecurrentbll = new BLL.tMeasureCurrentInfoes();

            A = new GetAllStateVM();
            A.OneCircuitList = new MeasureState();
            A.TwoCircuitList = new MeasureState();
            A.ThreeCircuitList = new MeasureState();
            A.ThreeCircuitList.CircuitList = new List<CircuitStateVM>();
            A.OneCircuitList.CircuitList = new List<CircuitStateVM>();
            A.TwoCircuitList.CircuitList = new List<CircuitStateVM>();
            //default
            A.Name = "获取失败";
            A.MesureCount = 0;
            A.UpdateTime = "获取失败";
            A.OneCircuitList.AState = "获取失败";
            A.OneCircuitList.BState = "获取失败";
            A.OneCircuitList.CState = "获取失败";
            A.OneCircuitList.Avoltage = "N/A";
            A.OneCircuitList.Bvoltage = "N/A";
            A.OneCircuitList.Cvoltage = "N/A";
            A.guid = guid;

            switch (result)
            {
                case 0:
                    A.Name = "参数错误";
                    return View(A);
                case 1:
                    A.Name = "主机未设置地址";
                    return View(A);
                case 2:
                    A.Name = "写数据库失败";
                    return View(A);
                case 3:
                    A.Name = "参数错误";
                    return View(A);
                case 4:
                    A.Name = "无此主机";
                    return View(A);
                case 5:
                    A.Name = "未配置测量板";
                    return View(A);
                case 6:
                    A.Name = "无返回";
                    return View(A);
                case 7:
                    try
                    {
                        DateTime ResultTime = DateTime.Parse(datetime);
                        hostmodel = hostbll.GetModel(guid);
                        if (hostmodel != null)
                        {
                            if (hostmodel.sName != null)
                            {
                                A.Name = hostmodel.sName;
                            }
                            measureconfigmodel = measureconfigbll.GetModelByHostGuid(guid);
                            if (measureconfigmodel != null)
                            {
                                if (measureconfigmodel.iMeasureNumber != null)
                                {
                                    A.MesureCount = (int)measureconfigmodel.iMeasureNumber;
                                    if (measuremodel.dCreateDate != null)
                                    {
                                        A.UpdateTime = measuremodel.dCreateDate.ToString();
                                    }
                                    for (int i = 0; i < measureconfigmodel.iMeasureNumber; i++)
                                    {
                                        measuremodel = measurebll.GetModelByHostGuidAndIdAndTime(guid, i + 1, ResultTime);
                                        if (measuremodel != null)
                                        {
                                            if (measuremodel.fVlotA != null)
                                            {
                                                A.OneCircuitList.Avoltage = measuremodel.fVlotA.ToString();
                                            }
                                            if (measuremodel.fVlotB != null)
                                            {
                                                A.OneCircuitList.Bvoltage = measuremodel.fVlotB.ToString();
                                            }
                                            if (measuremodel.fVlotC != null)
                                            {
                                                A.OneCircuitList.Cvoltage = measuremodel.fVlotC.ToString();
                                            }
                                            if (measuremodel.iAlarmVlotA != null)
                                            {
                                                switch ((VoltageAlarm)measuremodel.iAlarmVlotA)
                                                {
                                                    case VoltageAlarm.Va_Normal: A.OneCircuitList.AState = "正常";
                                                        break;
                                                    case VoltageAlarm.Va_Zero: A.OneCircuitList.AState = "缺相";
                                                        break;
                                                    case VoltageAlarm.Va_OvUpper: A.OneCircuitList.AState = "过压";
                                                        break;
                                                    case VoltageAlarm.Va_OverLower: A.OneCircuitList.AState = "欠压";
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }
                                            if (measuremodel.iAlarmVlotB != null)
                                            {
                                                switch ((VoltageAlarm)measuremodel.iAlarmVlotB)
                                                {
                                                    case VoltageAlarm.Va_Normal: A.OneCircuitList.BState = "正常";
                                                        break;
                                                    case VoltageAlarm.Va_Zero: A.OneCircuitList.BState = "缺相";
                                                        break;
                                                    case VoltageAlarm.Va_OvUpper: A.OneCircuitList.BState = "过压";
                                                        break;
                                                    case VoltageAlarm.Va_OverLower: A.OneCircuitList.BState = "欠压";
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }
                                            if (measuremodel.iAlarmVlotC != null)
                                            {
                                                switch ((VoltageAlarm)measuremodel.iAlarmVlotC)
                                                {
                                                    case VoltageAlarm.Va_Normal: A.OneCircuitList.CState = "正常";
                                                        break;
                                                    case VoltageAlarm.Va_Zero: A.OneCircuitList.CState = "缺相";
                                                        break;
                                                    case VoltageAlarm.Va_OvUpper: A.OneCircuitList.CState = "过压";
                                                        break;
                                                    case VoltageAlarm.Va_OverLower: A.OneCircuitList.CState = "欠压";
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }

                                            branchconfigmodellist = branchconfigbll.GetModelList("sMeasureConfigGUID = '" + measureconfigmodel.sGUID + "' and iEnable = " + StateEnable.Enable);
                                            if (branchconfigmodellist != null)
                                            {

                                                foreach (var item in branchconfigmodellist.OrderBy(c => c.iID))
                                                {
                                                    if (item.iID != null)
                                                    {
                                                        CircuitStateVM C = new CircuitStateVM();
                                                        measurepowermodel = measurepowerbll.GetModelByHostGuidAndIDAndTime(measuremodel.sGUID, (int)item.iID);
                                                        measurecurrentmodel = measurecurrentbll.GetModelByHostGuidAndIDAndTime(measuremodel.sGUID, (int)item.iID);
                                                        if ((measurepowermodel != null) && (measurecurrentmodel != null))
                                                        {

                                                            if (measurecurrentmodel.fValue != null)
                                                            {
                                                                C.Current = measurecurrentmodel.fValue.ToString();
                                                            }
                                                            C.ID = item.iID.ToString();
                                                            if (measurepowermodel.fValue != null)
                                                            {
                                                                C.Power = measurepowermodel.fValue.ToString();
                                                            }
                                                            if (measurecurrentmodel.iAlarm != null)
                                                            {
                                                                switch ((CurrentAlarm)measurecurrentmodel.iAlarm)
                                                                {
                                                                    case CurrentAlarm.I_Normal: C.State = "正常";
                                                                        break;
                                                                    case CurrentAlarm.IO_Nmatch_CIR: C.State = "接触器断路";
                                                                        break;
                                                                    case CurrentAlarm.IO_Nmatch_SW: C.State = "接触器吸合";
                                                                        break;
                                                                    case CurrentAlarm.IO_Nmatch_All: C.State = "回路开路";
                                                                        break;
                                                                    case CurrentAlarm.INO_Nmatch_CIR: C.State = "接触器未释放";
                                                                        break;
                                                                    case CurrentAlarm.INO_Nmatch_SW: C.State = "辅助触点故障";
                                                                        break;
                                                                    case CurrentAlarm.INO_Nmatch_All: C.State = "异常有电流";
                                                                        break;
                                                                    case CurrentAlarm.INO_OverUpper: C.State = "电流越上限";
                                                                        break;
                                                                    case CurrentAlarm.INO_OverLower: C.State = "电流越下限";
                                                                        break;
                                                                    default:
                                                                        break;
                                                                }
                                                            }
                                                            if (item.iVoltType != null)
                                                            {
                                                                switch ((VoltageType)item.iVoltType)
                                                                {
                                                                    case VoltageType.A: C.Phase = "A"; break;
                                                                    case VoltageType.B: C.Phase = "B"; break;
                                                                    case VoltageType.C: C.Phase = "C"; break;
                                                                    default:
                                                                        break;
                                                                }
                                                            }
                                                            if (item.iID <= 12)
                                                            {
                                                                A.OneCircuitList.CircuitList.Add(C);
                                                            }
                                                            else if (item.iID <= 24)
                                                            {
                                                                A.TwoCircuitList.CircuitList.Add(C);
                                                            }
                                                            else
                                                            {
                                                                A.ThreeCircuitList.CircuitList.Add(C);
                                                            }
                                                        }
                                                        //else
                                                        //{
                                                        //    //功率电流为null
                                                        //}
                                                    }
                                                    //else
                                                    //{
                                                    //    //item.id为null
                                                    //}
                                                }
                                            }
                                            //else
                                            //{
                                            //    //回路表为空
                                            //}
                                        }
                                        //else
                                        //{
                                        //    //查询到的测量板信息为空
                                        //}
                                    }
                                    return View(A);
                                }
                                else
                                {
                                    //测量板个数为空
                                    A.Name = "测量板个数为空";
                                    return View(A);
                                }
                            }
                            else
                            {
                                //测量板配置表为空
                                A.Name = "测量板配置表为空";
                                return View(A);
                            }
                        }
                        else
                        {
                            //主机未找到
                            A.Name = "未找到该主机";
                            return View(A);
                        }
                    }
                    catch
                    {
                        //发生异常
                        A.Name = "异常错误";
                        return View(A);
                    }

                default:
                    A.Name = "传输错误";
                    return View(A);
            }


        }

        /// <summary>
        /// 默认界面
        /// </summary>
        /// <returns>View()</returns>
        public ActionResult HostRealStateDefaultView()
        {
            A = new GetAllStateVM();
            A.OneCircuitList = new MeasureState();
            A.TwoCircuitList = new MeasureState();
            A.ThreeCircuitList = new MeasureState();
            A.ThreeCircuitList.CircuitList = new List<CircuitStateVM>();
            A.OneCircuitList.CircuitList = new List<CircuitStateVM>();
            A.TwoCircuitList.CircuitList = new List<CircuitStateVM>();
            A.Name = "正在获取";
            A.MesureCount = 0;
            A.UpdateTime = "正在获取";
            A.OneCircuitList.AState = "正在获取";
            A.OneCircuitList.BState = "正在获取";
            A.OneCircuitList.CState = "正在获取";
            A.OneCircuitList.Avoltage = "N/A";
            A.OneCircuitList.Bvoltage = "N/A";
            A.OneCircuitList.Cvoltage = "N/A";
            //for (int i = 1; i < 13; i++)
            //{
            //    CircuitStateVM C=new CircuitStateVM();
            //    C.Current="0.23";
            //    C.ID=i.ToString();
            //    C.Phase="A";
            //    C.Power="112.4";
            //    C.State="正常";
            //    A.OneCircuitList.CircuitList.Add(C);
            //}
            //A.TwoCircuitList.AState = "电压报警";
            //A.TwoCircuitList.BState = "B";
            //A.TwoCircuitList.CState = "C";
            //A.TwoCircuitList.Avoltage = "210";
            //A.TwoCircuitList.Bvoltage = "220";
            //A.TwoCircuitList.Cvoltage = "230";
            //for (int i = 1; i < 13; i++)
            //{
            //    CircuitStateVM C = new CircuitStateVM();
            //    C.Current = "0.23";
            //    C.ID = i.ToString();
            //    C.Phase = "A";
            //    C.Power = "112.4";
            //    C.State = "电流报警";
            //    A.TwoCircuitList.CircuitList.Add(C);
            //}
            //A.ThreeCircuitList.AState = "电压报警";
            //A.ThreeCircuitList.BState = "B";
            //A.ThreeCircuitList.CState = "C";
            //A.ThreeCircuitList.Avoltage = "210";
            //A.ThreeCircuitList.Bvoltage = "220";
            //A.ThreeCircuitList.Cvoltage = "230";
            //for (int i = 1; i < 13; i++)
            //{
            //    CircuitStateVM C = new CircuitStateVM();
            //    C.Current = "0.23";
            //    C.ID = i.ToString();
            //    C.Phase = "A";
            //    C.Power = "112.4";
            //    C.State = "电流报警";
            //    A.ThreeCircuitList.CircuitList.Add(C);
            //}
            return View(A);
        }

        /// <summary>
        /// 发送命令返回类型类
        /// </summary>
        public class StateResult
        {
            public DateTime StateDateTime;
            public int Stateresult;
        }

        /// <summary>
        /// 获取是否返回成功
        /// </summary>
        /// <returns>StateResultClass</returns>
        public JsonResult HostRealStateReceiveState()
        {
            /*
             * 3：无GUID或sTime
             * 4: 无此主机
             * 5：没配置测量板
             * 6：无返回
             * 7：返回正确
            */

            StateResult result = new StateResult();
            BLL.tHostInfo hostbll = new BLL.tHostInfo();
            Model.tHostInfo hostmodel = new Model.tHostInfo();
            BLL.tMeasureConfigs measureconfigbll = new BLL.tMeasureConfigs();
            Model.tMeasureConfigs measureconfigmodel = new Model.tMeasureConfigs();
            BLL.tMeasureInfoes measurebll = new BLL.tMeasureInfoes();
            Model.tMeasureInfoes measuremodel = new Model.tMeasureInfoes();
            List<Model.tMeasureInfoes> measuremodellist = new List<Model.tMeasureInfoes>();
            BLL.tMeasurePowerInfoes measurepowerbll = new BLL.tMeasurePowerInfoes();
            List<Model.tMeasurePowerInfoes> measurepowermodellist = new List<Model.tMeasurePowerInfoes>();
            BLL.tMeasureCurrentInfoes measurecurrentbll = new BLL.tMeasureCurrentInfoes();
            List<Model.tMeasureCurrentInfoes> measurecurrentmodellist = new List<Model.tMeasureCurrentInfoes>();

            if (!string.IsNullOrWhiteSpace(Request.QueryString["sGuid"]) && (!string.IsNullOrWhiteSpace(Request.QueryString["sTime"])))
            {
                if ((hostmodel = hostbll.GetModel(Request.QueryString["sGuid"])) != null)
                {
                    if ((measureconfigmodel = measureconfigbll.GetModelByHostGuid(Request.QueryString["sGuid"])) != null)
                    {
                        if ((measuremodellist = measurebll.GetModelList("")).Count > 0)
                        {
                            DateTime dt1 = DateTime.Now;
                            dt1.AddSeconds(-int.Parse(Request.QueryString["sTime"]));
                            result.StateDateTime = dt1;
                            result.Stateresult = 7;
                            return Json(result);
                        }
                        else
                        {
                            //未返回数据
                            result.Stateresult = 6;
                            return Json(result);
                        }
                    }
                    else
                    {
                        //没有配置测量板
                        result.Stateresult = 5;
                        return Json(result);
                    }
                }
                else
                {
                    //没有该主机
                    result.Stateresult = 4;
                    return Json(result);
                }
            }
            else
            {
                //没有传guid过来
                result.Stateresult = 3;
                return Json(result);
            }
        }

        /// <summary>
        /// 发送命令
        /// </summary>
        /// <returns>Int</returns>
        public JsonResult GetHostRealStateCmdPost()
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

            if (!string.IsNullOrWhiteSpace(Request.QueryString["sGuid"]))
            {
                Model.tHostInfo dt2 = bllhost.GetModel(Request.QueryString["sGuid"]);
                if (dt2 != null)
                {
                    if (!string.IsNullOrWhiteSpace(dt2.sID_Addr))
                    {
                        try
                        {
                            byte[] a = new byte[2];
                            a[0] = (byte)(int.Parse(dt2.sID_Addr) >> 8);
                            a[1] = (byte)(int.Parse(dt2.sID_Addr));
                            bt1 = LightGPRSProtocol.GetStringFor0x68((byte)CMDType.GetHostAllInfoCMD, a);
                            if (bt1 != null)
                            {
                                modsend.dCreateDate = DateTime.Now;
                                modsend.dUpdateTime = DateTime.Now;
                                modsend.sGUID = Guid.NewGuid().ToString();
                                modsend.iContentType = (int)CMDType.GetHostAllInfoCMD;
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

        #endregion 获取主机实时状态

        public JsonResult MapInitLeftMenu()
        {
            List<HostInfoVM> list = new List<HostInfoVM>();
            string imageurl = "logoMain.png";
            ViewBag.PrjectGUID = PrjGUID;
            BLL.tHostInfo bllhost = new BLL.tHostInfo();
            MainViewModel mainVM = new MainViewModel();


            //ViewBag.MapCenterLat = GetLat("Prject_CenterPoint_Lat");
            //ViewBag.MapCenterLng = GetLng("Prject_CenterPoint_Lng");
            DataTable allhostdt = bllhost.GetHostInfo(" dbo.tHostInfo.sProjectInfoGUID='" + PrjGUID + "' ");
            if (allhostdt != null)
            {
                allhostdt.Columns.Add("hostByLightCount");
                allhostdt.Columns.Add("hostByAlarmLightCount");
                HostInfoVM hvm;
                foreach (DataRow dr in allhostdt.Rows)
                {
                    hvm = addInfo(dr);

                    mainVM.HostInfos.Add(hvm);
                }
                return this.Json(mainVM);
            }
            return this.Json("");
        }

        private LightInfoVM addlightInfo(DataRow dr)
        {
            LightInfoVM hvm = new LightInfoVM();

            hvm.GUID = dr["lightGUID"].ToString();
            hvm.iFualt = Convert.ToInt32(ToString(dr["iRealTimeAlarm_Fault"]) == "" ? "-1" : ToString(dr["iRealTimeAlarm_Fault"]));
            hvm.Alarm = Convert.ToInt32(ToString(dr["iRealTimeAlarm_Fault"]) == "" ? "0" : ToString(dr["iRealTimeAlarm_Fault"]));

            hvm.Voltage = ToString(dr["sSpareField2"]) == "" || ToString(dr["sSpareField2"]) == "255" ? "" : Convert.ToDouble(ToString(dr["sSpareField2"])).ToString("f2") + "V";
            hvm.Current = ToString(dr["sSpareField3"]) == "" || ToString(dr["sSpareField3"]) == "255" ? "" : Convert.ToDouble(ToString(dr["sSpareField3"])).ToString("f2") + "A";
            hvm.Power = ToString(dr["sSpareField4"]) == "" || ToString(dr["sSpareField4"]) == "255" ? "" : Convert.ToDouble(ToString(dr["sSpareField4"])).ToString("f2") + "W";

            hvm.SolarEnergyVoltage = ToString(dr["sSpareField1"]) == "" || ToString(dr["sSpareField1"]) == "255" ? "" : Convert.ToDouble(ToString(dr["sSpareField1"])).ToString("f2") + "V";
            if (Convert.ToInt32(dr["iHType"]) == Convert.ToInt32(LightType.OldTYN))
            {
                hvm.sVoltagePercent = "NA";
            }
            else
            {
                hvm.sVoltagePercent = ToString(dr["sSpareField6"]) == "" || ToString(dr["sSpareField6"]) == "255" ? "无电余量" : Convert.ToDouble(ToString(dr["sSpareField6"])).ToString("f2") + "%";
            }


            hvm.sTemperature = ToString(dr["sSpareField5"]) == "" || ToString(dr["sSpareField5"]) == "255" ? "" : Convert.ToDouble(ToString(dr["sSpareField5"])).ToString("f2") + "℃";
            if (hvm.iFualt == 255)
            {
                hvm.Faul = ToString(GetSetValue("Light_Image_" + hvm.iFualt.ToString("D4"), "sDesc"));
            }
            else
            {
                hvm.Faul = ToString(GetSetValue("Light_Image_" + hvm.iFualt.ToString("D4"), "sDesc")) == "" ? "" : ToString(GetSetValue("Light_Image_" + hvm.iFualt.ToString("D4"), "sDesc"));
            }
            hvm.sImageUrl = ToString(GetSetValue("Light_Image_" + hvm.Alarm.ToString("D4"), "sValue")) == "" ? "255.png" : ToString(GetSetValue("Light_Image_" + hvm.Alarm.ToString("D4"), "sValue"));
            hvm.Lat = ToString(dr["fLat"]);
            hvm.Lng = ToString(dr["fLng"]);
            hvm.Name = ToString(dr["lightName"].ToString());
            hvm.UpdateTime = Convert.ToDateTime(ToString(dr["lightStateUpdateTime"]) == "" ? "1999-01-01 00:00:00" : ToString(dr["lightStateUpdateTime"]));
            hvm.sUpdateTime = ToString(dr["lightStateUpdateTime"]) == "" ? "1999-01-01 00:00:00" : ToString(dr["lightStateUpdateTime"]);
            hvm.sDesc = ToString(dr["sHardware_Version"]);
            return hvm;
        }

        
        public JsonResult AllMarker()
        {
            BLL.tHostInfo bllhost = new BLL.tHostInfo();
            Model.tHostInfo modhost = new Model.tHostInfo();
            MainViewModel mainVM = new MainViewModel();
            if (Request.QueryString["sGUID"] != null)
            {
                DataTable dt = bllhost.GetHostInfo("dbo.tHostInfo.sGUID='" + Request.QueryString["sGUID"] + "'");
                //mainVM.maxLat = GetMaxLat(Request.QueryString["sGUID"].ToString());
                //mainVM.maxlng = GetMaxLng(Request.QueryString["sGUID"].ToString());
                if (dt != null)
                {
                    dt.Columns.Add("hostByLightCount");
                    dt.Columns.Add("hostByAlarmLightCount");
                    HostInfoVM hvm;
                    foreach (DataRow dr in dt.Rows)
                    {
                        hvm = addInfo(dr);
                        //hvm = new HostInfoVM();
                        //hvm.GUID = dr["sGUID"].ToString();
                        //hvm.ID = ToString(dr["sID_Addr"]);
                        //hvm.Lat = ToString(dr["fLat"]);
                        //hvm.Lng = ToString(dr["fLng"]);
                        //hvm.Name = ToString(dr["sName"].ToString());
                        //hvm.UpdateTime = Convert.ToDateTime(ToString(dr["dUpdateTime"]) == "" ? "1999-01-01 00:00:00" : ToString(dr["dUpdateTime"]));
                        //hvm.GroupName = dr["GroupName"].ToString();
                        //hvm.Online = Convert.ToInt32(ToString(dr["iState_Online"]) == "" ? "0" : ToString(dr["iState_Online"]));
                        //hvm.Alarm = Convert.ToInt32(ToString(dr["iState_Alarm"]) == "" ? "0" : ToString(dr["iState_Alarm"]));
                        mainVM.HostInfos.Add(hvm);
                    }
                    // ViewBag.hostlist = mainVM.HostInfos;
                }
                return this.Json(mainVM);
            }
            else
            {
                return this.Json("");
            }
        }
        /// <summary>
        /// 点击左菜单获取单灯信息
        /// </summary>
        /// <returns></returns>
        public JsonResult AllMarkerLights()
        {

            if (Request.QueryString["sGUID"] != null)
            {


                LumluxSSYDB.BLL.tLightInfoes light_bll = new LumluxSSYDB.BLL.tLightInfoes();

                LightsViewModel lightVM = new LightsViewModel();
                DataTable dt = light_bll.GetLightByWhereInfo(" li.iEnable=1 and sHostInfoGUID='" + Request.QueryString["sGUID"].ToString() + "'");


                if (dt != null)
                {

                    //lightVM.maxLat = GetMaxLat(Request.QueryString["sGUID"].ToString());
                    //lightVM.maxlng = GetMaxLng(Request.QueryString["sGUID"].ToString());
                    LightInfoVM hvm;
                    foreach (DataRow dr in dt.Rows)
                    {
                        hvm = addlightInfo(dr);
                        lightVM.LightInfos.Add(hvm);
                    }
                }
                return this.Json(lightVM.LightInfos);
            }
            else
            {
                return this.Json("");
            }
        }
        /// <summary>
        /// 实时刷新单灯
        /// </summary>
        /// <returns></returns>
        public JsonResult curHostAllLights()
        {
            if (Request.QueryString["hostGUID"] != null)
            {
                //List<Model.tLightInfoes> list = new List<Model.tLightInfoes>();


                LumluxSSYDB.BLL.tLightInfoes light_bll = new LumluxSSYDB.BLL.tLightInfoes();
                //list = light_bll.GetModelList("sHostInfoGUID='" + Request.QueryString["hostGUID"] + "'");
                LightsViewModel lightVM = new LightsViewModel();
                DataTable dt = light_bll.GetLightByWhereInfo(" li.iEnable=1 and sHostInfoGUID='" + Request.QueryString["hostGUID"].ToString() + "'");
                if (dt != null)
                {
                    LightInfoVM hvm;
                    foreach (DataRow dr in dt.Rows)
                    {
                        hvm = addlightInfo(dr);
                        lightVM.LightInfos.Add(hvm);
                    }
                }
                return this.Json(lightVM.LightInfos);
            }
            else
            {
                return this.Json("");
            }
        }
        //模糊搜索
        public JsonResult SeachData()
        {
            if (Request.QueryString["sWhere"] != null)
            {
                BLL.tHostInfo bllhost = new BLL.tHostInfo();
                Model.tHostInfo modhost = new Model.tHostInfo();

                MainViewModel mainVM = new MainViewModel();
                DataTable dt = bllhost.GetHostInfo(" dbo.tHostInfo.sProjectInfoGUID='" + PrjGUID + "' and dbo.tHostInfo.sName like'%" + Request.QueryString["sWhere"].ToString() + "%'");

                if (dt != null)
                {
                    dt.Columns.Add("hostByLightCount");
                    dt.Columns.Add("hostByAlarmLightCount");
                    HostInfoVM hvm;
                    foreach (DataRow dr in dt.Rows)
                    {
                        hvm = addInfo(dr);
                        //hvm = new HostInfoVM();
                        //hvm.GUID = dr["sGUID"].ToString();
                        //hvm.ID = ToString(dr["sID_Addr"]);
                        //hvm.Lat = ToString(dr["fLat"]);
                        //hvm.Lng = ToString(dr["fLng"]);
                        //hvm.Name = ToString(dr["sName"].ToString());
                        //hvm.sUpdateTime = ToString(dr["dUpdateTime"]) == "" ? "1999-01-01 00:00:00" : ToString(dr["dUpdateTime"]);
                        //hvm.GroupName = dr["GroupName"].ToString();
                        //hvm.Online = Convert.ToInt32(ToString(dr["iState_Online"]) == "" ? "0" : ToString(dr["iState_Online"]));
                        //hvm.Alarm = Convert.ToInt32(ToString(dr["iState_Alarm"]) == "" ? "0" : ToString(dr["iState_Alarm"]));
                        mainVM.HostInfos.Add(hvm);
                    }
                    ;
                }
                return this.Json(mainVM.HostInfos);
            }
            else
            {
                return this.Json("");
            }
        }
        //刷新左侧菜单报警状态
        public JsonResult ReloadState()
        {
            if (!string.IsNullOrEmpty(PrjGUID))
            {
                BLL.tHostInfo bllhost = new BLL.tHostInfo();
                Model.tHostInfo modhost = new Model.tHostInfo();

                MainViewModel mainVM = new MainViewModel();
                DataTable dt = bllhost.GetHostInfo("dbo.tHostInfo.sProjectInfoGUID='" + PrjGUID + "'");

                if (dt != null)
                {
                    dt.Columns.Add("hostByLightCount");
                    dt.Columns.Add("hostByAlarmLightCount");
                    HostInfoVM hvm;


                    foreach (DataRow dr in dt.Rows)
                    {
                        hvm = addInfo(dr);
                        mainVM.HostInfos.Add(hvm);
                    }
                    ;
                }
                return this.Json(mainVM.HostInfos);
            }
            else
            {
                return this.Json("");
            }
        }

        /// <summary>
        /// DataTable行转列
        /// </summary>
        /// <param name="dtable">需要转换的表</param>
        /// <param name="head">转换表表头对应旧表字段（小写）</param>
        /// <returns></returns>
        public static DataTable DataTableRowtoCon(DataTable dtable, string head)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NumberID");
            for (int i = 0; i < dtable.Rows.Count; i++)
            {//设置表头
                dt.Columns.Add(dtable.Rows[i][head].ToString());
            }
            for (int k = 0; k < dtable.Columns.Count; k++)
            {
                string temcol = dtable.Columns[k].ToString();
                if (dtable.Columns[k].ToString().ToLower() != head)//过滤掉设置表头的列
                {
                    DataRow new_dr = dt.NewRow();
                    new_dr[0] = dtable.Columns[k].ToString();
                    for (int j = 0; j < dtable.Rows.Count; j++)
                    {
                        string temp = dtable.Rows[j][k].ToString();
                        new_dr[j + 1] = (Object)temp;
                    }
                    dt.Rows.Add(new_dr);
                }
            }

            DataRow[] drArr = dt.Select("NumberID='sValue'");
            //克隆dt赋值给新的table
            DataTable dtNew = dt.Clone();
            for (int i = 0; i < drArr.Length; i++)
            {
                dtNew.ImportRow(drArr[i]);
            }
            return dtNew;
        }
        /// <summary>
        /// 报警取样图片
        /// </summary>
        /// <returns></returns>
        public JsonResult AlarmDemoInfo()
        {
            if (Request.QueryString["PrjctGUID"] != null)
            {
                List<PrjectSetInfoVM> pslist = new List<PrjectSetInfoVM>();
                LumluxSSYDB.BLL.tPrjectSet light_bll = new LumluxSSYDB.BLL.tPrjectSet();

                LightsViewModel lightVM = new LightsViewModel();
                DataTable dt = light_bll.GetTableByWhere("sPrjectGUID='" + Request.QueryString["PrjctGUID"].ToString() + "' and sKey like  '%Light_Image_%'");
                //DataTable dt=DataTableRowtoCon(dtold, "sKey");

                if (dt != null)
                {
                    PrjectSetInfoVM psm;
                    foreach (DataRow dr in dt.Rows)
                    {
                        psm = addprjectsetInfo(dr);
                        pslist.Add(psm);
                    }
                }
                return this.Json(pslist);
            }
            else
            {
                return this.Json("");
            }
        }


        public JsonResult RealTimeAlarmDemoInfo()
        {
            if (Request.QueryString["RTPrjctGUID"] != null)
            {
                List<PrjectSetInfoVM> pslist = new List<PrjectSetInfoVM>();
                LumluxSSYDB.BLL.tPrjectSet light_bll = new LumluxSSYDB.BLL.tPrjectSet();

                LightsViewModel lightVM = new LightsViewModel();
                DataTable dt = light_bll.GetTableByWhere("sPrjectGUID='" + Request.QueryString["RTPrjctGUID"].ToString() + "' and sKey like  '%Light_Image_%'");
                //DataTable dt=DataTableRowtoCon(dtold, "sKey");

                if (dt != null)
                {
                    PrjectSetInfoVM psm;
                    foreach (DataRow dr in dt.Rows)
                    {
                        psm = addprjectsetInfo(dr);
                        pslist.Add(psm);
                    }
                }
                return this.Json(pslist);
            }
            else
            {
                return this.Json("");
            }
        }
        //
        // GET: /Lamp/Main/Details/5

        public ActionResult Details()
        {


            return View();


        }
        //
        // GET: /Lamp/Main/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Lamp/Main/Create

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
        // GET: /Lamp/Main/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Lamp/Main/Edit/5

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
        // GET: /Lamp/Main/Delete/5

        public ActionResult Delete(int id)
        {

            return View();
        }

        //
        // POST: /Lamp/Main/Delete/5

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
