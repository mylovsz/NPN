using LumluxSSYDB.Common.Log;
using ProtocolManage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL = LumluxSSYDB.BLL;
using Model = LumluxSSYDB.Model;
using Common = LumluxSSYDB.Common;
using LumluxSSYDB.Common.DataConverter;
using LumluxSSYDB.BLL;
using System.IO;
using LampService.Dialog;
using System.Runtime.ExceptionServices;

namespace LampService
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// GPRS服务
        /// </summary>
        GPRSServer.TDDPServer gprsServer = null;

        /// <summary>
        /// GPRS后台运行线程
        /// </summary>
        BackgroundWorker gprsBackWorker;

        /// <summary>
        /// GPRS实时信息[UI]
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="what">动作</param>
        /// <param name="content">实际内容</param>
        void UIRealInfoForGPRS(string obj, string what, string content)
        {
            if (txtGPRSRealInfo.Text.Length > 60000)
                txtGPRSRealInfo.Text = "";
            txtGPRSRealInfo.Text = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]-[" + obj + "]-[" + what + "]-" + content + "\r\n" + txtGPRSRealInfo.Text;
        }

        System.Windows.Forms.NotifyIcon notifyIcon;

        public MainWindow()
        {
            InitializeComponent();

            IntiNotifyIcon();
        }

        private void IntiNotifyIcon()
        {
            string path = System.IO.Path.GetFullPath(@"Image\LightServer.ico");
            if (File.Exists(path))
            {
                notifyIcon = new System.Windows.Forms.NotifyIcon();
                notifyIcon.BalloonTipText = "服务程序";
                notifyIcon.Text = "服务程序(双击打开窗体)";
                notifyIcon.Icon = new System.Drawing.Icon(path);//程序图标
                notifyIcon.Visible = true;
                notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
                notifyIcon.ShowBalloonTip(1000);

                this.StateChanged += MainWindow_StateChanged;
            }
            else
            {
                MessageBox.Show("无法加载图标，托盘功能无法使用");
            }
        }

        void MainWindow_StateChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (this.WindowState == System.Windows.WindowState.Minimized)
            {
                this.Hide();
            }
        }

        void notifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //throw new NotImplementedException();
            this.Show();
            this.WindowState = System.Windows.WindowState.Normal;
        }

        private void combGPRSIP_DropDownOpened(object sender, EventArgs e)
        {
            string ipBack = combGPRSIP.Text;
            string hostName = Dns.GetHostName();
            IPAddress[] ipAddr = Dns.GetHostAddresses(hostName);
            combGPRSIP.Items.Clear();
            combGPRSIP.Text = ipBack;
            foreach (IPAddress ip in ipAddr)
            {
                Debug.WriteLine("[系统]：" + ip.ToString());
                if (ip.AddressFamily.ToString() == "InterNetwork")
                    combGPRSIP.Items.Add(ip.ToString());
            }
        }

        void gprsBackWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // 当前无用
        }

        void gprsBackWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // 当前无用
            lbSrvTime.Text = e.UserState.ToString();
        }

        bool isSendGetLightCMD = false;
        int sendGetLightCMDCount = 0;
        List<Model.tHostInfo> listHIForSendGetLightCMD;

        [HandleProcessCorruptedStateExceptions]
        void GprsTimeTask(List<GPRSServer.ClientInfo> listGPRS)
        {
            DateTime dtNow = DateTime.Now;
            BLL.tHostInfo hiBLL = new tHostInfo();
            List<Model.tHostInfo> listHI;

            // 更新数据库在线状态
            if (dtNow.Second < 3)
            {
                listHI = hiBLL.GetModelList("1=1");
                foreach(Model.tHostInfo hi in listHI)
                {
                    if(listGPRS != null && listGPRS.Count(a=>a.IMEI.Trim() == hi.sID_ID.Trim()) > 0)
                    {
                        // 说明在线
                        // 如果之前的记录为不在线，则需要更新其状态信息
                        if (hi.iState_Online == (int)HostOnline.Unonline)
                        {
                            #region
                            // 获取三遥的状态表
                            //Model.tHostInfoState his = null;
                            //BLL.tHostInfoState bllHis = new tHostInfoState();
                            //if (!string.IsNullOrEmpty(hi.sHostInfoStateGUID))
                            //{
                            //    his = new BLL.tHostInfoState().GetModel(hi.sHostInfoStateGUID);
                            //}
                            //if (his == null)
                            //{
                            //    // 说明关联的主机状态并不存在，需要增加一个新的
                            //    his = new Model.tHostInfoState();
                            //    his.sGUID = Guid.NewGuid().ToString();
                            //    his.dCreateDate = dtNow;
                            //    his.dUpdateTime = dtNow;
                            //    his.iState_Online = hi.iState_Online;
                            //    his.sHostInfoGUID = hi.sGUID;
                            //    his.iFlag = (int)HostStateFlag.Open;
                            //    his.sMeasureInfoGUID = "";
                            //    his.sState_Alarm = "";
                            //    his.sSwitchInfoGUID = "";
                            //    bllHis.Add(his);

                            //    // 更新主机的关联
                            //    hi.sHostInfoStateGUID = his.sGUID;
                            //    hiBLL.Update(hi);
                            //}
                            //else
                            //{
                            //    // 说明存在
                            //    if (his.iState_Online != hi.iState_Online || his.sState_Alarm != alarm)
                            //    {
                            //        // 说明状态发生变化，要记录数据库的
                            //        his.dUpdateTime = dtNow;
                            //        bllHis.Update(his);

                            //        // 增加一条新的记录
                            //        his = new Model.tHostInfoState();
                            //        his.sGUID = Guid.NewGuid().ToString();
                            //        his.dCreateDate = dtNow;
                            //        his.dUpdateTime = dtNow;
                            //        his.iState_Online = hi.iState_Online;
                            //        his.sHostInfoGUID = hi.sGUID;
                            //        his.iFlag = (int)HostStateFlag.Open;
                            //        his.sMeasureInfoGUID = "";
                            //        if (mi != null && mi.Length > 0)
                            //        {
                            //            foreach (Model.tMeasureInfoes m in mi)
                            //                his.sMeasureInfoGUID += m.sGUID + ";";
                            //        }
                            //        his.sState_Alarm = alarm;
                            //        his.sSwitchInfoGUID = "";
                            //        bllHis.Add(his);

                            //        // 更新主机的关联
                            //        hi.sHostInfoStateGUID = his.sGUID;
                            //        bllHostInfo.Update(hi);
                            //    }
                            //    else
                            //    {
                            //        // 说明状态没有发生变化，更新数据库的时间
                            //        his.dUpdateTime = dtNow;
                            //        bllHis.Update(his);
                            //    }
                            //}
                            #endregion

                            hi.iState_Online = (byte)HostOnline.Online;
                            hi.dUpdateTime = dtNow;
                            hiBLL.Update(hi);
                        }
                    }
                    else
                    {
                        // 说明不在线
                        if(hi.iState_Online == (byte)HostOnline.Online)
                        {
                            hi.iState_Online = (byte)HostOnline.Unonline;
                            hi.dUpdateTime = dtNow;
                            hiBLL.Update(hi);
                        }
                    }
                }
            }


            // 召测单灯状态
            if(isSendGetLightCMD)
            {
                try
                {
                    if (listHIForSendGetLightCMD != null && listHIForSendGetLightCMD.Count > 0)
                    {
                        if (sendGetLightCMDCount >= listHIForSendGetLightCMD.Count)
                        {
                            LogHelper.Info("定时召测-结束");
                            this.Dispatcher.Invoke((Action)(() =>
                            {
                                UIRealInfoForGPRS("定时召测-结束", "回复", "召测结束");
                            }));
                            // 结束召测
                            isSendGetLightCMD = false;
                        }
                        Model.tHostInfo hi = listHIForSendGetLightCMD[sendGetLightCMDCount++];
                        GPRSServer.ClientInfo ci = listGPRS.FirstOrDefault(a => a.IMEI.Trim() == hi.sID_ID.Trim());
                        if (ci != null)
                        {
                            // 获取区间个数
                            Model.tHostSet hsCount = new BLL.tHostSet().GetAllByHostGUIDKey(hi.sGUID, "IntervalCount");
                            if (hsCount != null)
                            {
                                int count = int.Parse(hsCount.sValue);
                                for (int i = 0; i < count; i++)
                                {
                                    byte[] datas = LightGPRSProtocol.GetLightDataCMD(int.Parse(hi.sID_Addr), i+1);
                                    gprsServer.Send(ci, datas);
                                    LogHelper.Info(ci.IMEI + "-发送：" + Common.DataConverter.HexHelper.ByteArrayToHexString(datas));
                                    this.Dispatcher.Invoke((Action)(() =>
                                    {
                                        UIRealInfoForGPRS(ci.IMEI, "发送", Common.DataConverter.HexHelper.ByteArrayToHexString(datas));
                                    }));

                                    //Thread.Sleep(5000);
                                    for (int tempI = 0; tempI < 10; tempI++)
                                    {
                                        DealSendCMD(listGPRS);
                                        Thread.Sleep(500);
                                    }
                                }
                            }
                            Model.tCMDSends tCMDSends = new BLL.tCMDSends_TimeCtr().GetModel(hi.sID_ID.Trim());
                            if (tCMDSends!=null)
                            {
                                gprsServer.Send(ci, Common.DataConverter.HexHelper.HexStringToByteArray(tCMDSends.sContent));

                                LogHelper.Info(ci.IMEI + "-定时发送最后控制命令：" + tCMDSends.sContent);
                                this.Dispatcher.Invoke((Action)(() =>
                                {
                                    UIRealInfoForGPRS(ci.IMEI, "定时发送最后控制命令", tCMDSends.sContent);
                                }));
                            }
                            else
                            {
                                //string data = "68 10 00 08 68 00 01 00 00 41 11 32 16";//50%开灯
                                StringBuilder sb = new StringBuilder();
                                sb.Append("68 10 00 08 68 ");
                                sb.Append(Convert.ToString(ushort.Parse(hi.sID_Addr) >> 8, 16).PadLeft(2, '0') + " ");
                                sb.Append(Convert.ToString(ushort.Parse(hi.sID_Addr), 16).PadLeft(2, '0') + " ");
                                sb.Append("00 00 41 11 32 16");
                                string data = sb.ToString();
                                gprsServer.Send(ci, Common.DataConverter.HexHelper.HexStringToByteArray(data));


                                LogHelper.Info(ci.IMEI + "-定时发送最后控制命令(默认50%)：" + data);
                                this.Dispatcher.Invoke((Action)(() =>
                                {
                                    UIRealInfoForGPRS(ci.IMEI, "定时发送最后控制命令(默认50%)", data);
                                }));
                            }
                        }
                    }
                    else
                    {
                        // 结束召测
                        isSendGetLightCMD = false;
                    }
                }
                catch(Exception ex)
                {
                    LogHelper.Error("1-"+ex.Message);
                }

            }
            else if(dtNow.Minute % 20 == 0 && dtNow.Second < 6 && dtNow.Second > 3)  // 每20分钟召测一次
            {
                if (dtNow.Hour == 13 && dtNow.Minute < 15)
                {
                    // 过滤掉
                }
                else
                {
                    LogHelper.Info("定时召测-开始");
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        UIRealInfoForGPRS("定时召测-开始", "回复", "开始召测");
                    }));
                    isSendGetLightCMD = true;
                    sendGetLightCMDCount = 0;
                    listHIForSendGetLightCMD = hiBLL.GetModelList("1=1");
                }
            }
            //MessageCenter.Instance.NotifyMessage(DateTime.Now.ToString());
            // 当前测试，每一秒回传一次在线GPRS状态
            //if (listGPRS.Count > 0 && listGPRS.Count <= 5000)
            //{
            //    List<ClientServer.ClientInfo> list = new List<ClientServer.ClientInfo>();
            //    if (clientServer != null)
            //    {
            //        if (clientServer.TryGetOnlineList(ref list))
            //        {
            //            if (list.Count > 0)
            //            {
            //                // 序列号数据
            //                byte[] sendDatas = TcpClientProtocol.LightProtocol.LightTcpClientProtocol.GetOnlineImei(listGPRS);
            //                foreach (ClientServer.ClientInfo ci in list)
            //                {
            //                    clientServer.Send(ci.ConnID, sendDatas);
            //                }
            //            }
            //        }
            //    }
            //}
        }

        /// <summary>
        /// 处理要发送的命令
        /// </summary>
        /// <param name="listGPRS">当前在线的GPRS</param>
        [HandleProcessCorruptedStateExceptions]
        void DealSendCMD(List<GPRSServer.ClientInfo> listGPRS)
        {
            DateTime dt = DateTime.Now;
            BLL.tCMDSends bllCMDSend = new BLL.tCMDSends();
            List<Model.tCMDSends> listCMDSend = bllCMDSend.GetCMDSending(60);
            if (listCMDSend != null && listCMDSend.Count > 0)
            {
                GPRSServer.ClientInfo ci;
                foreach (Model.tCMDSends cmd in listCMDSend)
                {
                    try
                    {
                        ci = listGPRS.FirstOrDefault(t => t.IMEI == cmd.sHostIDID);
                        if (ci != null && cmd.sContent != null && cmd.sContent.Length > 0)
                        {
                            if (cmd.iContentType == (int)CMDType.RecruitAllCMD)//招测全部命令
                            {
                                BLL.tCMDRevs bllCMDRev = new BLL.tCMDRevs();
                                Model.tCMDRevs rev = new Model.tCMDRevs();

                                rev.sGUID = Guid.NewGuid().ToString();
                                rev.iContentType = (int)CMDType.RecruitAllRev;
                                rev.iState = (int)CMDDealState.No;
                                rev.sHostIDID = cmd.sHostIDID;
                                rev.dCreateDate = dt;
                                rev.dUpdateTime = dt;
                                
                                if (isSendGetLightCMD == false)
                                {
                                    BLL.tHostInfo hiBLL = new tHostInfo();
                                    isSendGetLightCMD = true;//使用定时任务去招测
                                    sendGetLightCMDCount = 0;
                                    listHIForSendGetLightCMD = hiBLL.GetModelList("1=1");
                                    rev.sContent = "开始召测，请耐心等候。。。";
                                }
                                else
                                {
                                    rev.sContent = "正在召测中，请稍后尝试。。。";
                                }
                                bllCMDRev.Add(rev);

                                //读取命令后 更新状态
                                cmd.iState = (int)BLL.CMDDealState.Yes;
                                cmd.dUpdateTime = dt;
                                bllCMDSend.Update(cmd);

                                LogHelper.Info(cmd.sHostIDID + "-发送：" + cmd.sContent);
                                this.Dispatcher.Invoke((Action)(() =>
                                {
                                    UIRealInfoForGPRS(cmd.sHostIDID, "发送", cmd.sContent);
                                }));

                                LogHelper.Info(cmd.sHostIDID + "-回复：" + rev.sContent);
                                this.Dispatcher.Invoke((Action)(() =>
                                {
                                    UIRealInfoForGPRS(cmd.sHostIDID, "回复", rev.sContent);
                                }));
                                continue;//不需要发命令，使用定时任务去发命令
                            }
                            if (gprsServer.Send(ci, Common.DataConverter.HexHelper.HexStringToByteArray(cmd.sContent)))
                            {
                                cmd.iState = (int)BLL.CMDDealState.Yes;
                                cmd.dUpdateTime = dt;
                                bllCMDSend.Update(cmd);
                                LogHelper.Info(cmd.sHostIDID + "-发送：" + cmd.sContent);
                                this.Dispatcher.Invoke((Action)(() =>
                                {
                                    UIRealInfoForGPRS(cmd.sHostIDID, "发送", cmd.sContent);
                                }));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("发送GPRS信息，失败：" + ex.Message);
                        LogHelper.Error("2-"+ex.Message);
                    }
                }
            }
            #region 老三遥数据库处理
            //if (isSyncSanYao)
            //{
            //    // 单灯数据
            //    DataSet dsLight = OldDB.OldDBManage.GetRoadLightControl();
            //    if (dsLight != null && dsLight.Tables.Count > 0 && dsLight.Tables[0].Rows.Count > 0)
            //    {
            //        GPRSServer.ClientInfo ci;
            //        foreach (DataRow dr in dsLight.Tables[0].Rows)
            //        {
            //            int id = (int)dr["ID"];
            //            string content = string.Empty;
            //            if (dr["ControlContent"] != null)
            //                content = dr["ControlContent"].ToString();
            //            byte[] datas = HPSocketCS.Tools.DataTool.HexStringToByteArray(content);
            //            if (datas.Length >= 7)
            //            {
            //                string imei = OldDB.OldDBManage.GetImeiByRoadID(datas[datas.Length - 1] * 256 + datas[0]);
            //                byte[] resultDatas = new byte[datas.Length];
            //                Array.Copy(datas, 0, resultDatas, 1, datas.Length - 1);
            //                resultDatas[0] = datas[datas.Length - 1];

            //                ci = listGPRS.FirstOrDefault(t => t.IMEI == imei);
            //                if (ci != null)
            //                {
            //                    if (gprsServer.Send(ci, LightGPRSProtocol.GetStringFor0x68((byte)0x10, HPSocketCS.Tools.DataTool.ByteArrayToHexString(resultDatas))))
            //                    {
            //                        OldDB.OldDBManage.UpdateRoadLightControl(id);
            //                        this.Dispatcher.Invoke((Action)(() =>
            //                        {
            //                            UIRealInfoForGPRS(imei, "发送", "16:" + content);
            //                        }));
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    // End 单灯数据

            //    DataSet ds = OldDB.OldDBManage.GetTimeControl();
            //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //    {
            //        GPRSServer.ClientInfo ci;
            //        foreach (DataRow dr in ds.Tables[0].Rows)
            //        {
            //            try
            //            {
            //                int id = (int)dr["ID"];
            //                int type = (int)dr["CMDType"];
            //                string imei = (string)dr["RoadIMEI"];
            //                string content = string.Empty;
            //                try
            //                {
            //                    if (dr["CMDContent"] != null)
            //                    {
            //                        content = (string)dr["CMDContent"];
            //                    }
            //                }
            //                catch
            //                {
            //                    content = string.Empty;
            //                }
            //                ci = listGPRS.FirstOrDefault(t => t.IMEI == imei);
            //                if (ci != null)
            //                {
            //                    if (gprsServer.Send(ci, LightGPRSProtocol.GetStringFor0x68((byte)type, content)))
            //                    {
            //                        OldDB.OldDBManage.UpdateTimeControl(id);
            //                        this.Dispatcher.Invoke((Action)(() =>
            //                        {
            //                            UIRealInfoForGPRS(imei, "发送", type.ToString("X2") + ":" + content);
            //                        }));
            //                    }
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                Debug.WriteLine("发送GPRS信息，失败：" + ex.Message);
            //            }
            //        }
            //    }
            //}
            #endregion 老三遥数据库处理
        }

        [HandleProcessCorruptedStateExceptions]
        void gprsBackWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<GPRSServer.ClientInfo> list = new List<GPRSServer.ClientInfo>();
            //int count = 0;
            while (true)
            {
                try
                {
                    Debug.WriteLine("----GPRS-DoWork----");
                    if (gprsBackWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    // 清空在线列表
                    if (list != null)
                        list.Clear();

                    // 延迟检索时间
                    Thread.Sleep(1000);

                    // 获取在线列表
                    gprsServer.TryGetOnlineList(ref list);

                    #region 当前不采用数据库记录状态
                    // 更新数据库状态
                    ; ; ; ; ; ; ; ; ;
                    // End 更新数据库状态
                    #endregion

                    // 定时处理一些任务
                    GprsTimeTask(list);
                    // End 定时处理一些任务

                    // 处理要发送的命令
                    DealSendCMD(list);
                    // End 处理要发送的命令

                    // 更新界面元素
                    ; ; ; ; ; ; ; ; ;
                    gprsBackWorker.ReportProgress(0, DateTime.Now);
                    // End 更新界面元素
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    LogHelper.Error("3-" + ex.Message);
                }
            }
        }

        void gprsServer_Register(object sender, GPRSServer.TDDPServer.RegisterEventArgs e)
        {
            // 心跳包
            try
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    UIRealInfoForGPRS(e.UserInfo.IMEI, "注册", "心跳包");
                }));
            }
            catch(Exception ex)
            {
                LogHelper.Error("4-" + ex.Message);
            }
        }

        void gprsServer_DataRecords(object sender, GPRSServer.TDDPServer.DataRecordEventArgs e)
        {
            try
            {
                List<LightGPRSProtocolResult> listGPRS = LightGPRSProtocol.DealGPRSData(e.Datas.Datas, (ushort)e.Datas.Datas.Length);
                if (listGPRS != null && listGPRS.Count > 0)
                {
                    DateTime dtNow = DateTime.Now;
                    BLL.tCMDRevs bllCMDRev = new tCMDRevs();
                    BLL.tMeasureConfigs bllMeasureConfigs = new tMeasureConfigs();
                    BLL.tBranchConfigs bllBranchConfigs = new tBranchConfigs();
                    BLL.tMeasureInfoes bllMeasureInfoes = new tMeasureInfoes();
                    BLL.tMeasureCurrentInfoes bllMeasureCurrentInfoes = new tMeasureCurrentInfoes();
                    BLL.tMeasurePowerInfoes bllMeasurePowerInfoes = new tMeasurePowerInfoes();
                    Model.tCMDRevs rev = new Model.tCMDRevs();
                    BLL.tHostInfo bllHostInfo = new BLL.tHostInfo();
                    foreach (LightGPRSProtocolResult l in listGPRS)
                    {
                        rev.sGUID = Guid.NewGuid().ToString();
                        rev.iState = (int)CMDDealState.No;
                        rev.dCreateDate = dtNow;
                        rev.dUpdateTime = dtNow;
                        Model.tHostInfo hi = bllHostInfo.GetHostInfoByID(e.Datas.IMEI);
                        if (hi != null)
                        {
                            rev.sHostIDID = hi.sID_ID;

                            #region 类型特殊处理
                            switch (l.Type)
                            {
                                case (byte)CMDType.GetLightDataRev:
                                    {
                                        // 单灯数据回复
                                        BLL.tLightInfoes liBLL = new tLightInfoes();
                                        BLL.tLightStateInfoes lsiBLL = new tLightStateInfoes();
                                        List<Model.tLightInfoes> listLI = liBLL.GetModelListByHostGUID(hi.sGUID);
                                        byte[] datas = (byte[])l.Datas;
                                        int roadID = (int)datas[0] * 256 + datas[1];
                                        int start = (int)datas[2] * 256 + datas[3];
                                        int length = (int)datas[4] * 256 + datas[5];
                                        for (int i = 0; i < length; i++)
                                        {
                                            Model.tLightInfoes li = listLI.FirstOrDefault(a => int.Parse(a.sLightID.Trim()) == start + i);
                                            if (li != null)
                                            {
                                                switch ((LightType)li.iHardware_Type)
                                                {
                                                    case LightType.Normal:
                                                        {

                                                        }
                                                        break;
                                                    case LightType.NewTYN:
                                                        {
                                                            double v = 0, current = 0, power = 0, temper = 0;
                                                            double field1 = 0; // 太阳能版电压
                                                            double field2 = 0; // 超容电压
                                                            double field3 = 0; // 超容电流
                                                            double field4 = 0; // 超容功率
                                                            double field5 = 0; // 温度
                                                            double field6 = 0; // 电压百分比
                                                            int fault = 0xff, id = 0xff;
                                                            if (datas[6 + i * 6] == 0xff && datas[7 + i * 6] == 0xff && datas[8 + i * 6] == 0xff && datas[9 + i * 6] == 0xff && datas[10 + i * 6] == 0xff)
                                                            {
                                                                id = 0xff;
                                                            }
                                                            else
                                                            {
                                                                id = (0x0F) & (datas[10 + i * 6] >> 4);
                                                            }
                                                            if (id == 0)
                                                            {
                                                                // 最早的单灯
                                                                v = datas[6 + i * 6];
                                                                current = datas[7 + i * 6];
                                                                power = datas[8 + i * 6];
                                                                temper = datas[9 + i * 6];
                                                                fault = datas[10 + i * 6];
                                                            }
                                                            else if (id < 255)
                                                            {
                                                                fault = datas[10 + i * 6] & 0x0F;
                                                                // 太阳能电压
                                                                field1 = ((datas[6 + i * 6] << 4) + (0x0f & (datas[7 + i * 6] >> 4))) / 10.0;
                                                                // 超容电压
                                                                field2 = (((datas[7 + i * 6] & 0x0f) << 6) + (0x3F & (datas[8 + i * 6] >> 2))) / 10.0;

                                                                // 超容电流（3）与功率（4）
                                                                if (fault == 2)
                                                                {
                                                                    // 超容电流
                                                                    //field3 = 0;
                                                                    field4 = datas[11 + i * 6];
                                                                    field3 = field4 / field2 * 1.2;
                                                                }
                                                                else
                                                                {
                                                                    // 超容电流
                                                                    field3 = datas[11 + i * 6] / 10.0;
                                                                    field4 = field2 * field3;
                                                                }
                                                                // 温度
                                                                field5 = datas[9 + i * 6];
                                                                switch (id)
                                                                {
                                                                    case 1:
                                                                        // 电压百分比
                                                                        field6 = (field2 - 6.5) / (8.0 - 6.5) * 100;
                                                                        li.sHardware_Version = "LC0H01";
                                                                        break;
                                                                    case 2:
                                                                        // 电压百分比
                                                                        field6 = (field2 - 6.5) / (8.0 - 6.5) * 100;
                                                                        li.sHardware_Version = "LC0H01 - 8.1V";
                                                                        break;
                                                                    case 3:
                                                                        // 电压百分比
                                                                        field6 = (field2 - 6.5) / (8.0 - 6.5) * 100;
                                                                        li.sHardware_Version = "LC0H01 - 8.1V";
                                                                        break;
                                                                    case 4:
                                                                        // 电压百分比
                                                                        field6 = (field2 - 6.9) / (16.0 - 6.9) * 100;
                                                                        li.sHardware_Version = "LC0H04 - 16.2V";
                                                                        break;
                                                                    case 5:
                                                                        // 电压百分比
                                                                        field6 = (field2 - 17.9) / (26.5 - 17.9) * 100;
                                                                        li.sHardware_Version = "LC0H02 - 27V";
                                                                        break;
                                                                    case 7:
                                                                        // 电压百分比   7 串
                                                                        field6 = (field2 - 15.5) / (18.3 - 15.5) * 100;
                                                                        li.sHardware_Version = "LC0H06 - 18.5V";
                                                                        break;
                                                                    default: // 此未无信息返回
                                                                        v = 0;
                                                                        current = 0;
                                                                        power = 0;
                                                                        temper = 0;
                                                                        fault = 0xff;
                                                                        break;
                                                                }
                                                                if (field6 < 0) field6 = 0;
                                                            }

                                                            // 修复现场在98%的时候出现已充满问题
                                                            if (fault == 4 && field6 < 98.5)
                                                            {
                                                                // 此时在充电中
                                                                fault = 1;
                                                            }
                                                            // End

                                                            Model.tLightStateInfoes lsi = new Model.tLightStateInfoes();
                                                            lsi.dCreateDate = dtNow;
                                                            lsi.dUpdateTime = dtNow;
                                                            lsi.fCurrent = (decimal)current;
                                                            lsi.fPower = (decimal)power;
                                                            lsi.fVoltage = (decimal)v;
                                                            lsi.iFault = fault;

                                                            lsi.sSpareField1 = field1.ToString("0.00");
                                                            lsi.sSpareField2 = field2.ToString("0.00");
                                                            lsi.sSpareField3 = field3.ToString("0.00");
                                                            lsi.sSpareField4 = field4.ToString("0.00");
                                                            lsi.sSpareField5 = field5.ToString("0.00");
                                                            lsi.sSpareField6 = field6.ToString("0.00");

                                                            lsi.sGUID = Guid.NewGuid().ToString();
                                                            lsi.sLightInfoGUID = li.sGUID;
                                                            //lsi.sSpareField1 = temper.ToString("f2");
                                                            lsiBLL.Add(lsi);

                                                            li.sStateGUID = lsi.sGUID;
                                                            li.iRealTimeAlarm_Fault = fault;
                                                            li.iRealTimeAlarm_CreateDateTime = dtNow;
                                                            liBLL.Update(li);
                                                        }
                                                        break;
                                                    case LightType.OldTYN:
                                                        {
                                                            double v = 0, current = 0, power = 0, temper = 0;
                                                            double field1 = 0; // 太阳能版电压
                                                            double field2 = 0; // 超容电压
                                                            double field3 = 0; // 超容电流
                                                            double field4 = 0; // 超容功率
                                                            double field5 = 0; // 温度
                                                            double field6 = 0; // 电压百分比
                                                            int fault = 0xff;
                                                            if (datas[6 + i * 6] == 0xff && datas[7 + i * 6] == 0xff && datas[8 + i * 6] == 0xff && datas[9 + i * 6] == 0xff && datas[10 + i * 6] == 0xff && datas[11 + i * 6] == 0xff)
                                                            {
                                                                // 无信息返回，使用初始值
                                                                ;
                                                            }
                                                            else
                                                            {
                                                                fault = datas[10 + i * 6] & 0x0F;
                                                                // 太阳能电压
                                                                field1 = ((datas[6 + i * 6] << 4) + (0x0f & (datas[7 + i * 6] >> 4))) / 10.0;
                                                                // 超容电压
                                                                field2 = (((datas[7 + i * 6] & 0x0f) << 6) + (0x3F & (datas[8 + i * 6] >> 2))) / 10.0;

                                                                // 超容电流（3）与功率（4）
                                                                field3 = datas[11 + i * 6] / 10.0;
                                                                field4 = field2 * field3;

                                                                // 温度
                                                                field5 = (((0x03 & datas[8 + i * 6]) << 12) + (datas[9 + i * 6] << 4) + (0x0f & (datas[10 + i * 6] >> 4))) / 10.0;

                                                                // 电压百分比
                                                                field6 = 999;
                                                                //li.sHardware_Version = "LC0H01";
                                                            }

                                                            Model.tLightStateInfoes lsi = new Model.tLightStateInfoes();
                                                            lsi.dCreateDate = dtNow;
                                                            lsi.dUpdateTime = dtNow;
                                                            lsi.fCurrent = (decimal)current;
                                                            lsi.fPower = (decimal)power;
                                                            lsi.fVoltage = (decimal)v;
                                                            lsi.iFault = fault;

                                                            lsi.sSpareField1 = field1.ToString("0.00");
                                                            lsi.sSpareField2 = field2.ToString("0.00");
                                                            lsi.sSpareField3 = field3.ToString("0.00");
                                                            lsi.sSpareField4 = field4.ToString("0.00");
                                                            lsi.sSpareField5 = field5.ToString("0.00");
                                                            lsi.sSpareField6 = field6.ToString("0.00");

                                                            lsi.sGUID = Guid.NewGuid().ToString();
                                                            lsi.sLightInfoGUID = li.sGUID;
                                                            //lsi.sSpareField1 = temper.ToString("f2");
                                                            lsiBLL.Add(lsi);

                                                            li.sStateGUID = lsi.sGUID;
                                                            li.iRealTimeAlarm_Fault = fault;
                                                            li.iRealTimeAlarm_CreateDateTime = dtNow;
                                                            liBLL.Update(li);
                                                        }
                                                        break;
                                                }
                                            }
                                        }
                                        rev.iState = (int)CMDDealState.Yes;
                                    }
                                    break;
                                case 0x03:
                                    break;
                                case 0x11:
                                    {
                                        //rev.ContentType = CMDType.ManualContrlRev;
                                    }
                                    break;
                                case 33: // 三遥数据 0
                                case 35: // 三遥扩展数据 0
                                case 49: // 单灯巡测配置返回 0
                                    break;
                                case 0x82: // 路段号配置回复
                                    {
                                        //rev.ContentType = CMDType.SyncAddrRev;
                                    }
                                    break;
                                case 0x9D:
                                    {
                                        // 小三遥
                                        // 保存到Rev记录
                                        string alarm = "";
                                        Model.tMeasureConfigs mc = bllMeasureConfigs.GetModelByHostGuid(hi.sGUID);
                                        List<Model.tBranchConfigs> listBC = null;
                                        if (mc != null)
                                            listBC = bllBranchConfigs.GetModelByMeasureConfigGUID(mc.sGUID);
                                        else
                                            listBC = new List<Model.tBranchConfigs>();
                                        try
                                        {
                                            // 生成Measure测量版记录
                                            byte[] datas = (byte[])l.Datas;
                                            if (datas[2] > 0 && datas[2] <= 3)
                                            {
                                                Model.tMeasureInfoes[] mi = new Model.tMeasureInfoes[datas[2]];
                                                List<Model.tMeasureCurrentInfoes> listMCI = new List<Model.tMeasureCurrentInfoes>();
                                                List<Model.tMeasurePowerInfoes> listMPI = new List<Model.tMeasurePowerInfoes>();
                                                for (int i = 0; i < datas[2]; i++)
                                                {
                                                    mi[i] = new Model.tMeasureInfoes();
                                                    mi[i].sHostInfoGUID = hi.sGUID;
                                                    mi[i].iID = i + 1;
                                                    mi[i].sGUID = Guid.NewGuid().ToString();
                                                    mi[i].dCreateDate = dtNow;
                                                    mi[i].fVlotA = (decimal)SYProtocol.ConvertVoltage(datas[i * 30 + 3] * 256 + datas[i * 30 + 4]);
                                                    mi[i].fVlotB = (decimal)SYProtocol.ConvertVoltage(datas[i * 30 + 5] * 256 + datas[i * 30 + 6]);
                                                    mi[i].fVlotC = (decimal)SYProtocol.ConvertVoltage(datas[i * 30 + 7] * 256 + datas[i * 30 + 8]);
                                                    double[] ratioCurrent = new double[12];
                                                    for (int j = 0; j < 6; j++)
                                                    {
                                                        Model.tMeasureCurrentInfoes mci = new Model.tMeasureCurrentInfoes();
                                                        mci.dCreateTime = dtNow;
                                                        mci.dUpdateTime = dtNow;
                                                        mci.sGUID = Guid.NewGuid().ToString();
                                                        mci.sMeasureInfoGUID = mi[i].sGUID;
                                                        mci.iAlarm = 0;
                                                        mci.sDesc = "";
                                                        mci.iID = i * 6 + j + 1;
                                                        Model.tBranchConfigs acci = listBC.FirstOrDefault(t => t.iID == mci.iID);
                                                        if (acci != null)
                                                        {
                                                            ratioCurrent[j] = (double)acci.fRatio;
                                                            mci.fValue = (decimal)(ratioCurrent[j] * SYProtocol.ConvertCurrent(datas[i * 30 + 9 + j * 2] * 256 + datas[i * 30 + 9 + j * 2 + 1]));
                                                        }
                                                        else
                                                        {
                                                            ratioCurrent[j] = 1;
                                                            mci.fValue = (decimal)(SYProtocol.ConvertCurrent(datas[i * 30 + 9 + j * 2] * 256 + datas[i * 30 + 9 + j * 2 + 1]));
                                                        }
                                                        listMCI.Add(mci);
                                                    }
                                                    for (int j = 0; j < 6; j++)
                                                    {
                                                        Model.tMeasurePowerInfoes mpi = new Model.tMeasurePowerInfoes();
                                                        mpi.sGUID = Guid.NewGuid().ToString();
                                                        mpi.sMeasureInfoGUID = mi[i].sGUID;
                                                        mpi.sDesc = "";
                                                        mpi.iID = i * 6 + j + 1;
                                                        mpi.fValue = (decimal)(ratioCurrent[j] * SYProtocol.ConvertPower(datas[i * 30 + 21 + j * 2] * 256 + datas[i * 30 + 21 + j * 2 + 1]));
                                                        listMPI.Add(mpi);
                                                    }
                                                    mi[i].iAlarmVlotA = datas[33];
                                                    mi[i].iAlarmVlotB = datas[34];
                                                    mi[i].iAlarmVlotC = datas[35];

                                                    // 关于电压的报警格式：【测量版编号:A相,B相,C相;】
                                                    alarm += string.Format("{0}:{1},{2},{3};", mi[i].iID, datas[33], datas[34], datas[35]);
                                                }
                                                if (datas[datas[2] * 30 + 6] > 0)
                                                {
                                                    for (int i = 0; i < datas[datas[2] * 30 + 6]; i += 2)
                                                    {
                                                        int id = datas[datas[2] * 30 + 7 + i];
                                                        if (id >= 1 && id <= 6 && mi.Length > 0)
                                                        {
                                                            // 测量版1
                                                            Model.tMeasureCurrentInfoes mci = listMCI.FirstOrDefault(t => t.iID == id);
                                                            if (mci != null)
                                                            {
                                                                mci.iAlarm = (datas[datas[2] * 30 + 7 + 1 + i]);
                                                            }
                                                            // 关于回路报警格式：【回路编号:状态;】
                                                            alarm += string.Format("{0}:{1}-", id, mci.iAlarm);
                                                        }
                                                        else if (id >= 7 && id <= 12 && mi.Length > 1)
                                                        {
                                                            // 测量版2
                                                            Model.tMeasureCurrentInfoes mci = listMCI.FirstOrDefault(t => t.iID == id);
                                                            if (mci != null)
                                                                mci.iAlarm = (datas[datas[2] * 30 + 7 + 1 + i]);
                                                            // 关于回路报警格式：【回路编号:状态;】
                                                            alarm += string.Format("{0}:{1}-", id, mci.iAlarm);
                                                        }
                                                        else if (id >= 13 && id <= 18 && mi.Length > 2)
                                                        {
                                                            // 测量版3
                                                            Model.tMeasureCurrentInfoes mci = listMCI.FirstOrDefault(t => t.iID == id);
                                                            if (mci != null)
                                                                mci.iAlarm = (datas[datas[2] * 30 + 7 + 1 + i]);
                                                            // 关于回路报警格式：【回路编号:状态;】
                                                            alarm += string.Format("{0}:{1}-", id, mci.iAlarm);
                                                        }
                                                    }
                                                }
                                                foreach (Model.tMeasureInfoes fm in mi)
                                                {
                                                    bllMeasureInfoes.Add(fm);
                                                }
                                                foreach (Model.tMeasureCurrentInfoes fi in listMCI)
                                                {
                                                    bllMeasureCurrentInfoes.Add(fi);
                                                }
                                                foreach (Model.tMeasurePowerInfoes fp in listMPI)
                                                {
                                                    bllMeasurePowerInfoes.Add(fp);
                                                }

                                                // 获取三遥的状态表
                                                Model.tHostInfoState his = null;
                                                BLL.tHostInfoState bllHis = new tHostInfoState();
                                                if (!string.IsNullOrEmpty(hi.sHostInfoStateGUID))
                                                {
                                                    his = new BLL.tHostInfoState().GetModel(hi.sHostInfoStateGUID);
                                                }
                                                if (his == null)
                                                {
                                                    // 说明关联的主机状态并不存在，需要增加一个新的
                                                    his = new Model.tHostInfoState();
                                                    his.sGUID = Guid.NewGuid().ToString();
                                                    his.dCreateDate = dtNow;
                                                    his.dUpdateTime = dtNow;
                                                    his.iState_Online = hi.iState_Online;
                                                    his.sHostInfoGUID = hi.sGUID;
                                                    his.iFlag = (int)HostStateFlag.Open;
                                                    his.sMeasureInfoGUID = "";
                                                    if (mi != null && mi.Length > 0)
                                                    {
                                                        foreach (Model.tMeasureInfoes m in mi)
                                                            his.sMeasureInfoGUID += m.sGUID + ";";
                                                    }
                                                    his.sState_Alarm = alarm;
                                                    his.sSwitchInfoGUID = "";
                                                    bllHis.Add(his);

                                                    // 更新主机的关联
                                                    hi.sHostInfoStateGUID = his.sGUID;
                                                    bllHostInfo.Update(hi);
                                                }
                                                else
                                                {
                                                    // 说明存在
                                                    if (his.iState_Online != hi.iState_Online || his.sState_Alarm != alarm)
                                                    {
                                                        // 说明状态发生变化，要记录数据库的
                                                        his.dUpdateTime = dtNow;
                                                        bllHis.Update(his);

                                                        // 增加一条新的记录
                                                        his = new Model.tHostInfoState();
                                                        his.sGUID = Guid.NewGuid().ToString();
                                                        his.dCreateDate = dtNow;
                                                        his.dUpdateTime = dtNow;
                                                        his.iState_Online = hi.iState_Online;
                                                        his.sHostInfoGUID = hi.sGUID;
                                                        his.iFlag = (int)HostStateFlag.Open;
                                                        his.sMeasureInfoGUID = "";
                                                        if (mi != null && mi.Length > 0)
                                                        {
                                                            foreach (Model.tMeasureInfoes m in mi)
                                                                his.sMeasureInfoGUID += m.sGUID + ";";
                                                        }
                                                        his.sState_Alarm = alarm;
                                                        his.sSwitchInfoGUID = "";
                                                        bllHis.Add(his);

                                                        // 更新主机的关联
                                                        hi.sHostInfoStateGUID = his.sGUID;
                                                        bllHostInfo.Update(hi);
                                                    }
                                                    else
                                                    {
                                                        // 说明状态没有发生变化，更新数据库的时间
                                                        his.dUpdateTime = dtNow;
                                                        bllHis.Update(his);
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            LogHelper.Error("在处理三遥召测命令时，转换数据出错", ex);
                                        }
                                    }
                                    break;
                                case 0x96:
                                    {
                                        // 大三遥
                                        // 保存到Rev记录
                                        Model.tMeasureConfigs mc = bllMeasureConfigs.GetModelByHostGuid(hi.sGUID);
                                        List<Model.tBranchConfigs> listBC = null;
                                        if (mc != null)
                                            listBC = bllBranchConfigs.GetModelByMeasureConfigGUID(mc.sGUID);
                                        else
                                            listBC = new List<Model.tBranchConfigs>();
                                        try
                                        {
                                            // 生成Measure测量版记录
                                            byte[] datas = (byte[])l.Datas;
                                            if (datas[2] > 0 && datas[2] <= 3)
                                            {
                                                Model.tMeasureInfoes[] mi = new Model.tMeasureInfoes[datas[2]];
                                                List<Model.tMeasureCurrentInfoes> listMCI = new List<Model.tMeasureCurrentInfoes>();
                                                List<Model.tMeasurePowerInfoes> listMPI = new List<Model.tMeasurePowerInfoes>();
                                                for (int i = 0; i < datas[2]; i++)
                                                {
                                                    mi[i] = new Model.tMeasureInfoes();
                                                    mi[i].sHostInfoGUID = hi.sGUID;
                                                    mi[i].iID = i + 1;
                                                    mi[i].sGUID = Guid.NewGuid().ToString();
                                                    mi[i].dCreateDate = dtNow;
                                                    mi[i].fVlotA = (decimal)SYProtocol.ConvertVoltage(datas[i * 54 + 3] * 256 + datas[i * 54 + 4]);
                                                    mi[i].fVlotB = (decimal)SYProtocol.ConvertVoltage(datas[i * 54 + 5] * 256 + datas[i * 54 + 6]);
                                                    mi[i].fVlotC = (decimal)SYProtocol.ConvertVoltage(datas[i * 54 + 7] * 256 + datas[i * 54 + 8]);
                                                    double[] ratioCurrent = new double[12];
                                                    for (int j = 0; j < 12; j++)
                                                    {
                                                        Model.tMeasureCurrentInfoes mci = new Model.tMeasureCurrentInfoes();
                                                        mci.sGUID = Guid.NewGuid().ToString();
                                                        mci.iID = i * 12 + j + 1;
                                                        Model.tBranchConfigs acci = listBC.FirstOrDefault(t => t.iID == mci.iID);
                                                        if (acci != null)
                                                        {
                                                            ratioCurrent[j] = (double)acci.fRatio;
                                                            mci.fValue = (decimal)(ratioCurrent[j] * SYProtocol.ConvertCurrent(datas[i * 54 + 9 + j * 2] * 256 + datas[i * 54 + 9 + j * 2 + 1]));
                                                        }
                                                        else
                                                        {
                                                            ratioCurrent[j] = 1;
                                                            mci.fValue = (decimal)(SYProtocol.ConvertCurrent(datas[i * 54 + 9 + j * 2] * 256 + datas[i * 54 + 9 + j * 2 + 1]));
                                                        }
                                                        listMCI.Add(mci);
                                                    }
                                                    for (int j = 0; j < 12; j++)
                                                    {
                                                        Model.tMeasurePowerInfoes mpi = new Model.tMeasurePowerInfoes();
                                                        mpi.sGUID = Guid.NewGuid().ToString();
                                                        mpi.iID = i * 12 + j + 1;
                                                        mpi.fValue = (decimal)(ratioCurrent[j] * SYProtocol.ConvertPower(datas[i * 54 + 33 + j * 2] * 256 + datas[i * 54 + 33 + j * 2 + 1]));
                                                    }
                                                    mi[i].iAlarmVlotA = datas[57];
                                                    mi[i].iAlarmVlotB = datas[58];
                                                    mi[i].iAlarmVlotC = datas[59];
                                                }
                                                if (datas[datas[2] * 54 + 6] > 0)
                                                {
                                                    for (int i = 0; i < datas[datas[2] * 54 + 6]; i += 2)
                                                    {
                                                        int id = datas[datas[2] * 54 + 7 + i];
                                                        if (id >= 1 && id <= 12 && mi.Length > 0)
                                                        {
                                                            // 测量版1
                                                            Model.tMeasureCurrentInfoes mci = listMCI.FirstOrDefault(t => t.iID == id);
                                                            if (mci != null)
                                                                mci.iAlarm = (datas[datas[2] * 54 + 7 + 1 + i]);
                                                        }
                                                        else if (id >= 13 && id <= 24 && mi.Length > 1)
                                                        {
                                                            // 测量版2
                                                            Model.tMeasureCurrentInfoes mci = listMCI.FirstOrDefault(t => t.iID == id);
                                                            if (mci != null)
                                                                mci.iAlarm = (datas[datas[2] * 54 + 7 + 1 + i]);
                                                        }
                                                        else if (id >= 25 && id <= 36 && mi.Length > 2)
                                                        {
                                                            // 测量版3
                                                            Model.tMeasureCurrentInfoes mci = listMCI.FirstOrDefault(t => t.iID == id);
                                                            if (mci != null)
                                                                mci.iAlarm = (datas[datas[2] * 54 + 7 + 1 + i]);
                                                        }
                                                    }
                                                }
                                                foreach (Model.tMeasureInfoes fm in mi)
                                                {
                                                    bllMeasureInfoes.Add(fm);
                                                }
                                                foreach (Model.tMeasureCurrentInfoes fi in listMCI)
                                                {
                                                    bllMeasureCurrentInfoes.Add(fi);
                                                }
                                                foreach (Model.tMeasurePowerInfoes fp in listMPI)
                                                {
                                                    bllMeasurePowerInfoes.Add(fp);
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            LogHelper.Error("在处理三遥召测命令时，转换数据出错", ex);
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                            #endregion 类型特殊处理
                        }
                        else
                        {
                            rev.sHostIDID = e.Datas.IMEI;
                            rev.iContentType = (int)CMDType.None;
                        }
                        rev.iContentType = l.Type;
                        rev.sContent = HexHelper.ByteArrayToHexString((byte[])l.Datas);
                        bllCMDRev.Add(rev);
                    }
                }
                string log = HexHelper.ByteArrayToHexString(e.Datas.Datas);
                LogHelper.Info(e.Datas.IMEI + "-收到数据包：" + log);
                // 数据包
                this.Dispatcher.Invoke((Action)(() =>
                {
                    UIRealInfoForGPRS(e.Datas.IMEI, "数据包", log);
                }));
            }
            catch(Exception ex)
            {
                LogHelper.Error("5-" + ex.Message);
            }
        }

        private void btnGPRSStart_Click(object sender, RoutedEventArgs e)
        {
            // 心跳包超时时间
            uint headTimeout;
            if (!uint.TryParse(txtGPRSHeadTimeout.Text, out headTimeout))
            {
                MessageBox.Show("心跳包输入错误！");
                return;
            }

            // IP 验证
            if (combGPRSIP.SelectedIndex == -1)
            {
                System.Windows.MessageBox.Show("请选择合法的服务IP");
                return;
            }
            IPAddress ipTemp;
            if (!IPAddress.TryParse(combGPRSIP.SelectedItem.ToString(), out ipTemp) || combGPRSIP.SelectedItem.ToString().Length < 7)  // 1.1.1.1
            {
                MessageBox.Show("请选择合法的服务IP");
                return;
            }

            // 端口验证
            int port;
            if (!int.TryParse(txtGPRSPort.Text.Trim(), out port))
            {
                MessageBox.Show("服务端口必须是0-65535");
                return;
            }
            if (port < 0 || port > 65535)
            {
                MessageBox.Show("服务端口必须是0-65535");
                return;
            }

            // 初始化服务，启动服务
            if (gprsServer == null)
            {
                gprsServer = new GPRSServer.TDDPServer(combGPRSIP.SelectedItem.ToString(), (ushort)port);
                gprsServer.Register += gprsServer_Register;
                gprsServer.DataRecords += gprsServer_DataRecords;
            }
            else
            {
                gprsServer.SevIP = combGPRSIP.SelectedItem.ToString();
                gprsServer.SevPort = (ushort)port;
            }
            gprsServer.HeadTimeout = headTimeout;
            if (gprsServer.StartServer())
            {
                btnGPRSStart.IsEnabled = false;
                spGPRSConfig.IsEnabled = false;
                btnGPRSStop.IsEnabled = true;

                // 启动工作线程
                try
                {
                    gprsBackWorker = new BackgroundWorker();
                    gprsBackWorker.WorkerSupportsCancellation = true;
                    gprsBackWorker.WorkerReportsProgress = true;
                    gprsBackWorker.DoWork += gprsBackWorker_DoWork;
                    gprsBackWorker.ProgressChanged += gprsBackWorker_ProgressChanged;
                    gprsBackWorker.RunWorkerCompleted += gprsBackWorker_RunWorkerCompleted;
                    gprsBackWorker.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    LogHelper.Error("异常-启动服务-异常信息：", ex);
                    UIRealInfoForGPRS("异常", "启动服务", "异常信息：" + ex.Message);
                    return;
                }

                // 保存当前设置的参数
                Properties.Settings.Default.GPRSPort = ushort.Parse(txtGPRSPort.Text);
                Properties.Settings.Default.GPRSIP = combGPRSIP.SelectedItem.ToString();
                Properties.Settings.Default.GPRSHeadTimeout = uint.Parse(txtGPRSHeadTimeout.Text);
                Properties.Settings.Default.Save();
                LogHelper.Info("GRPS系统启动服务");
                UIRealInfoForGPRS("系统", "启动服务", "正常");
            }
            else
            {
                LogHelper.Error("异常-启动服务-异常信息：此端口无法使用，请检测是否已经打开！");
                UIRealInfoForGPRS("异常", "启动服务", "异常信息：此端口无法使用，请检测是否已经打开！");
            }
        }

        private void btnGPRSStop_Click(object sender, RoutedEventArgs e)
        {
            if (gprsServer != null && gprsServer.GetServerState() != HPSocketCS.ServiceState.Stoped)
            {
                gprsServer.StopServer();
                if (gprsBackWorker != null)
                {
                    try
                    {
                        gprsBackWorker.CancelAsync();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error("异常-停止服务-异常信息：", ex);
                        UIRealInfoForGPRS("异常", "停止服务", "异常信息：" + ex.Message);
                        Debug.WriteLine(ex.Message);
                        return;
                    }
                }
                UIRealInfoForGPRS("系统", "停止服务", "正常");
                btnGPRSStart.IsEnabled = true;
                spGPRSConfig.IsEnabled = true;
                btnGPRSStop.IsEnabled = false;
            }
        }

        private void btnReGPRSOnline_Click(object sender, RoutedEventArgs e)
        {
            if (gprsServer == null)
                return;
            List<GPRSServer.ClientInfo> list = new List<GPRSServer.ClientInfo>();
            gprsServer.TryGetOnlineList(ref list);
            lbGPRSOnline.ItemsSource = list;
            lbGPRSOnline.DisplayMemberPath = "IMEI";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LogHelper.Info("打开监听软件");

            // 基本参数初始化
            combGPRSIP_DropDownOpened(null, null);
            combGPRSIP.SelectedItem = Properties.Settings.Default.GPRSIP;
            txtGPRSPort.Text = Properties.Settings.Default.GPRSPort.ToString();
            txtGPRSHeadTimeout.Text = Properties.Settings.Default.GPRSHeadTimeout.ToString();

            //btnGPRSStart_Click(null, null);
            //btnClientStart_Click(null, null);
            //btnStartWCF_Click(null, null);
            // 打开自动启动程序
            btnGPRSStart_Click(null, null);
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            //if(MessageBox.Show("确定退出系统？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.No)
            MessageBoxMinDlg mbmd = new MessageBoxMinDlg();
            mbmd.Owner = this;
            if(mbmd.ShowDialog() == false)
            {
                e.Cancel = true;
                if (mbmd.IsMin == true)
                {
                    this.WindowState = System.Windows.WindowState.Minimized;
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            LogHelper.Info("退出监听软件");
        }

        private void btnPrjAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = txtPrjName.Text.Trim();
            if(string.IsNullOrEmpty(name))
            {
                MessageBox.Show("项目名称不能为空！", "提示");
                return;
            }

            decimal lat, lng;
            if(decimal.TryParse(txtPrjLat.Text, out lat) && decimal.TryParse(txtPrjLng.Text, out lng))
            {

            }
            else
            {
                MessageBox.Show("经纬度格式不正确 ！", "提示");
                return;
            }

            BLL.tPrjectInfo prjBLL = new tPrjectInfo();
            if(prjBLL.ExistsName(name))
            {
                MessageBox.Show("项目名称已存在，请更换！", "提示");
                return;
            }
            
            Model.tPrjectInfo prjModel = new Model.tPrjectInfo();
            prjModel.sGUID = Guid.NewGuid().ToString();
            prjModel.dCreateDate = DateTime.Now;
            prjModel.dUpdateTime = prjModel.dCreateDate;
            prjModel.fLat = lat;
            prjModel.fLng = lng;
            prjModel.sAuthor = txtPrjAdmin.Text.Trim();
            prjModel.sName = txtPrjName.Text.Trim();
            prjModel.sRemark = txtPrjRemark.Text.Trim();
            if(prjBLL.Add(prjModel))
            {
                // 添加项目成功，此时开始增加总体的配置信息
                BLL.tPrjectSet psBLL = new tPrjectSet();
                Model.tPrjectSet psModel = new Model.tPrjectSet();
                psModel.sPrjectGUID = prjModel.sGUID;
                psModel.dCreateTime = prjModel.dCreateDate;
                psModel.dUpdateTime = prjModel.dCreateDate;

                psModel.sGUID = Guid.NewGuid().ToString();
                psModel.sKey = "logoMain_0001";
                psModel.sValue = "logo.png";
                psModel.sDesc = "项目Logo";
                psBLL.Add(psModel);

                psModel.sGUID = Guid.NewGuid().ToString();
                psModel.sKey = "MainTitle";
                psModel.sValue = "单灯控制系统";
                psModel.sDesc = "网站首页的页眉名称";
                psBLL.Add(psModel);

                psModel.sGUID = Guid.NewGuid().ToString();
                psModel.sKey = "Light_Image_0001";
                psModel.sValue = "1.png";
                psModel.sDesc = "充电中";
                psBLL.Add(psModel);

                psModel.sGUID = Guid.NewGuid().ToString();
                psModel.sKey = "Light_Image_0002";
                psModel.sValue = "2.png";
                psModel.sDesc = "开灯";
                psBLL.Add(psModel);

                psModel.sGUID = Guid.NewGuid().ToString();
                psModel.sKey = "Light_Image_0003";
                psModel.sValue = "3.png";
                psModel.sDesc = "关灯";
                psBLL.Add(psModel);

                psModel.sGUID = Guid.NewGuid().ToString();
                psModel.sKey = "Light_Image_0004";
                psModel.sValue = "4.png";
                psModel.sDesc = "已充满";
                psBLL.Add(psModel);

                psModel.sGUID = Guid.NewGuid().ToString();
                psModel.sKey = "Light_Image_0005";
                psModel.sValue = "5.png";
                psModel.sDesc = "负载异常";
                psBLL.Add(psModel);

                psModel.sGUID = Guid.NewGuid().ToString();
                psModel.sKey = "Light_Image_0006";
                psModel.sValue = "6.png";
                psModel.sDesc = "温度过高";
                psBLL.Add(psModel);

                psModel.sGUID = Guid.NewGuid().ToString();
                psModel.sKey = "Light_Image_0007";
                psModel.sValue = "7.png";
                psModel.sDesc = "过压";
                psBLL.Add(psModel);

                psModel.sGUID = Guid.NewGuid().ToString();
                psModel.sKey = "Light_Image_0008";
                psModel.sValue = "8.png";
                psModel.sDesc = "电容短路";
                psBLL.Add(psModel);

                psModel.sGUID = Guid.NewGuid().ToString();
                psModel.sKey = "Light_IsAlarm_0005";
                psModel.sValue = "Alarm";
                psModel.sDesc = "负载异常";
                psBLL.Add(psModel);

                psModel.sGUID = Guid.NewGuid().ToString();
                psModel.sKey = "Light_IsAlarm_0006";
                psModel.sValue = "Alarm";
                psModel.sDesc = "温度过高";
                psBLL.Add(psModel);

                psModel.sGUID = Guid.NewGuid().ToString();
                psModel.sKey = "Light_IsAlarm_0007";
                psModel.sValue = "Alarm";
                psModel.sDesc = "过压";
                psBLL.Add(psModel);

                psModel.sGUID = Guid.NewGuid().ToString();
                psModel.sKey = "Light_IsAlarm_0008";
                psModel.sValue = "Alarm";
                psModel.sDesc = "电容短路";
                psBLL.Add(psModel);

                psModel.sGUID = Guid.NewGuid().ToString();
                psModel.sKey = "Light_Image_0255";
                psModel.sValue = "255.png";
                psModel.sDesc = "无信息";
                psBLL.Add(psModel);

                psModel.sGUID = Guid.NewGuid().ToString();
                psModel.sKey = "Light_IsAlarm_0004";
                psModel.sValue = "Normal";
                psModel.sDesc = "测试错误";
                psBLL.Add(psModel);

                btnPrjRefresh_Click(null, null);
            }
            else
            {
                MessageBox.Show("加入失败，请检查参数是否正确", "提示");
            }
        }

        private void btnPrjSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPrjCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPrjRefresh_Click(object sender, RoutedEventArgs e)
        {
            BLL.tPrjectInfo prjBLL = new tPrjectInfo();
            List<Model.tPrjectInfo> list = prjBLL.GetAllModel();
            lbPrjShow.ItemsSource = list;
            lbPrjShow.DisplayMemberPath = "sName";

            combUserPrj.ItemsSource = list;
            combUserPrj.DisplayMemberPath = "sName";
            combUserPrj.SelectedValuePath = "sGUID";

            // 清楚双击的选择
            prjSelectItem = null;
        }

        private void btnUserAdd_Click(object sender, RoutedEventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            if(string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("请输入用户名", "提示");
                return ;
            }
            if(combUserPrj.SelectedIndex < 0)
            {
                MessageBox.Show("请选择关联的项目", "提示");
                return ;
            }
            BLL.tUserInfoes uiBLL = new tUserInfoes();
            if (uiBLL.ExistsName(userName))
            {
                MessageBox.Show("用户名称已存在，请更换！", "提示");
                return;
            }
            
            Model.tUserInfoes uiModel = new Model.tUserInfoes();
            uiModel.sGUID = Guid.NewGuid().ToString();
            uiModel.sUserName = userName;
            uiModel.sPrjectInfoGUID = combUserPrj.SelectedValue.ToString();
            uiModel.dCreateDate = DateTime.Now;
            uiModel.dUpdateTime = uiModel.dCreateDate;
            uiModel.iAuthorityGUID = combUserAuthority.SelectedIndex.ToString();
            uiModel.sAlias = userName;
            uiModel.sPassWord = LumluxSSYDB.DBUtility.Utility.MD5("Aa123456");
            if(uiBLL.Add(uiModel))
            {
                combUserPrj_SelectionChanged(null, null);
            }
            else
            {
                MessageBox.Show("加入失败，请检查参数是否正确", "提示");
            }
        }

        Model.tUserInfoes uiSelectItem = null;

        private void btnUserSave_Click(object sender, RoutedEventArgs e)
        {
            if(uiSelectItem != null)
            {
                uiSelectItem.sUserName = txtUserName.Text;
                uiSelectItem.iAuthorityGUID = combUserAuthority.SelectedIndex.ToString();
                new BLL.tUserInfoes().Update(uiSelectItem);
                uiSelectItem = null;
            }

            btnUserCancel_Click(null, null);
        }

        private void btnUserCancel_Click(object sender, RoutedEventArgs e)
        {
            btnUserAdd.IsEnabled = true;
            btnUserCancel.IsEnabled = false;
            btnUserSave.IsEnabled = false;

            uiSelectItem = null;
        }

        private void btnUserRefresh_Click(object sender, RoutedEventArgs e)
        {
            combUserPrj_SelectionChanged(null, null);
        }

        private void combUserPrj_DropDownOpened(object sender, EventArgs e)
        {
            btnPrjRefresh_Click(null, null);
        }

        private void combUserPrj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(combUserPrj.SelectedIndex>-1)
            {
                string guid = combUserPrj.SelectedValue.ToString();
                BLL.tUserInfoes uiBLL = new tUserInfoes();
                List<Model.tUserInfoes> list = uiBLL.GetUserByPrj(guid);
                lbUserShow.ItemsSource = list;
                lbUserShow.DisplayMemberPath = "sUserName";
            }
        }

        private void btnTestAdd_Click(object sender, RoutedEventArgs e)
        {
            if (combUserPrj.SelectedIndex > -1)
            {
                string guid = combUserPrj.SelectedValue.ToString();
                BLL.tHostInfo hiBLL = new tHostInfo();
                BLL.tGroupInfoes giBLL = new tGroupInfoes();
                BLL.tLightInfoes liBLL = new tLightInfoes();
                BLL.tLightGroupInfoes lgiBLL = new tLightGroupInfoes();
                BLL.tLightInfoLightGroupInfoes ligiBLL = new tLightInfoLightGroupInfoes();
                Model.tLightGroupInfoes lgiModel = new Model.tLightGroupInfoes();
                Model.tHostInfo hiModel = new Model.tHostInfo();
                Model.tGroupInfoes giModel = new Model.tGroupInfoes();
                Model.tLightInfoes liModel = new Model.tLightInfoes();
                Model.tLightInfoLightGroupInfoes ligiModel = new Model.tLightInfoLightGroupInfoes();
                for(int i=0;i<5;i++)
                {
                    giModel.dCreateDate = DateTime.Now;
                    giModel.dUpdateTime = giModel.dCreateDate;
                    giModel.sGUID = Guid.NewGuid().ToString();
                    giModel.sName = "Group"+i;
                    giModel.sProjectInfoGUID = guid;
                    giModel.sRemark = giModel.sName;
                    giBLL.Add(giModel);

                    hiModel.sGUID = Guid.NewGuid().ToString();
                    hiModel.dCreateDate = DateTime.Now;
                    hiModel.dUpdateTime = hiModel.dCreateDate;
                    hiModel.fLat = (decimal)31.298886;
                    hiModel.fLng = (decimal)(120.58531600000003 + 0.01 * i);
                    hiModel.iHardware_Type = 1;
                    hiModel.iIDType = 0;
                    if (i < 3)
                        hiModel.sGroupInfoGUID = giModel.sGUID;
                    hiModel.sID_ID = "1891352313"+i*2;
                    hiModel.sName = "主机" + (i * 2);
                    hiModel.sProjectInfoGUID = guid;
                    hiModel.sRemark = hiModel.sName;
                    hiBLL.Add(hiModel);
                    hiModel.sGUID = Guid.NewGuid().ToString();
                    hiModel.sID_ID = "1891352313" + (i * 2 + 1);
                    hiModel.sName = "主机" + (i * 2+1);
                    hiBLL.Add(hiModel);

                    for(int j=0;j<3;j++)
                    {
                        liModel.sGUID = Guid.NewGuid().ToString();
                        liModel.sHostInfoGUID = hiModel.sGUID;
                        liModel.sLightID = j.ToString();
                        liModel.sName = "单灯" + j;
                        liModel.dCreateTime = DateTime.Now;
                        liModel.dUpdateTime = liModel.dCreateTime;
                        liBLL.Add(liModel);
                    }

                    lgiModel.sGUID = Guid.NewGuid().ToString();
                    lgiModel.dCreateTime = DateTime.Now;
                    lgiModel.dUpdateTime = lgiModel.dCreateTime;
                    lgiModel.sHostInfoGUID = hiModel.sGUID;
                    lgiModel.sName = "Group"+i;
                    lgiBLL.Add(lgiModel);

                    ligiModel.sGUID = Guid.NewGuid().ToString();
                    ligiModel.dCreateTime = DateTime.Now;
                    ligiModel.dUpdateTime = ligiModel.dCreateTime;
                    ligiModel.sLightGroupInfoGUID = lgiModel.sGUID;
                    ligiModel.sLightInfoGUID = liModel.sGUID;
                    ligiBLL.Add(ligiModel);
                }
            }
            else
            {
                MessageBox.Show("请选择关联的项目！");
            }
        }

        Model.tPrjectInfo prjSelectItem = null;
        private void lbPrjShow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbPrjShow.SelectedItem != null && lbPrjShow.SelectedItem is Model.tPrjectInfo)
            {
                prjSelectItem = lbPrjShow.SelectedItem as Model.tPrjectInfo;
                btnPrjSetRefresh_Click(null, null);
            }
        }

        private void btnPrjSetRefresh_Click(object sender, RoutedEventArgs e)
        {
            if(prjSelectItem != null)
            {
                List<Model.tPrjectSet> list = new BLL.tPrjectSet().GetModelList("sPrjectGUID = '" + prjSelectItem.sGUID + "'");
                lbPrjSetShow.ItemsSource = list;
                lbPrjSetShow.DisplayMemberPath = "sKey";
            }
        }

        private void btnPrjSetAdd_Click(object sender, RoutedEventArgs e)
        {
            if (prjSelectItem != null)
            {
                Model.tPrjectSet ps = new Model.tPrjectSet();
                ps.sGUID = Guid.NewGuid().ToString();
                ps.dCreateTime = DateTime.Now;
                ps.dUpdateTime = ps.dCreateTime;
                ps.sDesc = txtPrjSetDesc.Text.Trim();
                ps.sKey = txtPrjSetKey.Text.Trim();
                ps.sPrjectGUID = prjSelectItem.sGUID;
                ps.sValue = txtPrjSetValue.Text.Trim();
                new BLL.tPrjectSet().Add(ps);
                btnPrjSetRefresh_Click(null, null);
            }
        }

        Model.tPrjectSet prjSetSelectItem = null;
        private void btnPrjSetSave_Click(object sender, RoutedEventArgs e)
        {
            if (prjSetSelectItem != null)
            {
                prjSetSelectItem.sKey = txtPrjSetKey.Text.Trim();
                prjSetSelectItem.sValue = txtPrjSetValue.Text.Trim();
                prjSetSelectItem.sDesc = txtPrjSetDesc.Text.Trim();
                prjSetSelectItem.dUpdateTime = DateTime.Now;
                new BLL.tPrjectSet().Update(prjSetSelectItem);
                btnPrjSetRefresh_Click(null, null);
                prjSetSelectItem = null;
            }
            btnPrjSetCancel_Click(null, null);
        }

        private void btnPrjSetCancel_Click(object sender, RoutedEventArgs e)
        {
            btnPrjSetAdd.IsEnabled = true;
            btnPrjSetSave.IsEnabled = false;
            btnPrjSetCancel.IsEnabled = false;

            prjSetSelectItem = null;
        }

        private void btnPrjSetEdit_Click(object sender, RoutedEventArgs e)
        {
            if(lbPrjSetShow.SelectedItem != null)
            {
                prjSetSelectItem = lbPrjSetShow.SelectedItem as Model.tPrjectSet;

                txtPrjSetDesc.Text = prjSetSelectItem.sDesc;
                txtPrjSetKey.Text = prjSetSelectItem.sKey;
                txtPrjSetValue.Text = prjSetSelectItem.sValue;

                btnPrjSetAdd.IsEnabled = false;
                btnPrjSetSave.IsEnabled = true;
                btnPrjSetCancel.IsEnabled = true;
            }
        }

        private void LbUserShow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(lbUserShow.SelectedItem != null)
            {
                uiSelectItem = lbUserShow.SelectedItem as Model.tUserInfoes;

                txtUserName.Text = uiSelectItem.sUserName;
                if (string.IsNullOrWhiteSpace(uiSelectItem.iAuthorityGUID))
                    uiSelectItem.iAuthorityGUID = "0";
                combUserAuthority.SelectedIndex = int.Parse(uiSelectItem.iAuthorityGUID);

                btnUserAdd.IsEnabled = false;
                btnUserCancel.IsEnabled = true;
                btnUserSave.IsEnabled = true;
            }
        }

    }
}
