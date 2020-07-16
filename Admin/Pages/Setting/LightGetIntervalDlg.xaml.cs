using AdminBLL;
using AdminModel;
using FirstFloor.ModernUI.Windows.Controls;
using LumluxSSYDB.Common.DataConverter;
using ProtocolManage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Admin.Pages.Setting
{
    /// <summary>
    /// Interaction logic for LightGetIntervalDlg.xaml
    /// </summary>
    public partial class LightGetIntervalDlg : ModernDialog
    {
        HostInfo hostInfo;
        HostSetBLL hsBLL = new HostSetBLL();
        BackgroundWorker bw = null;
        int timeout = 10;
        int defaultTimeout = 10;
        /// <summary>
        /// 扫描开始时间
        /// </summary>
        HostSet hsLightsGetStartTime;
        /// <summary>
        /// 扫描结束时间
        /// </summary>
        HostSet hsLightsGetEndTime;
        /// <summary>
        /// 扫描间隔
        /// </summary>
        HostSet hsLightsGetIntervalTime;
        /// <summary>
        /// 单个灯扫描间隔
        /// </summary>
        HostSet hsLightGetIntervalTime;
        /// <summary>
        /// 单个灯超时时间
        /// </summary>
        HostSet hsLightGetTimeoutTime;
        /// <summary>
        /// 单个灯超时采集次数
        /// </summary>
        HostSet hsLightGetCount;

        public LightGetIntervalDlg()
        {
            InitializeComponent();

            // define the dialog buttons
            this.Buttons = new Button[] { this.OkButton, this.CancelButton };
            this.Buttons = new Button[] { this.OkButton, this.CancelButton };
            this.OkButton.Content = "保存";
            this.OkButton.Command = null;
            this.OkButton.Click += OkButton_Click;
            this.CancelButton.Content = "取消";
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            hsLightGetCount.Value = iudLightCount.Value.ToString();
            hsLightGetCount.UpdateDate = dt;
            hsBLL.Update(hsLightGetCount);
            hsLightGetIntervalTime.Value = iudLightInterval.Value.ToString();
            hsLightGetIntervalTime.UpdateDate = dt;
            hsBLL.Update(hsLightGetIntervalTime);
            hsLightGetTimeoutTime.Value = iudLightTimeout.Value.ToString();
            hsLightGetTimeoutTime.UpdateDate = dt;
            hsBLL.Update(hsLightGetTimeoutTime);
            hsLightsGetEndTime.Value = tpEnd.Value.ToString();
            hsLightsGetEndTime.UpdateDate = dt;
            hsBLL.Update(hsLightsGetEndTime);
            hsLightsGetIntervalTime.Value = iudGetInterval.Value.ToString();
            hsLightsGetIntervalTime.UpdateDate = dt;
            hsBLL.Update(hsLightsGetIntervalTime);
            hsLightsGetStartTime.Value = tpStart.Value.ToString();
            hsLightsGetStartTime.UpdateDate = dt;
            hsBLL.Update(hsLightsGetStartTime);
            this.OkButton.IsEnabled = false;
            spSend.Visibility = System.Windows.Visibility.Visible;
            // 下放到三遥
            InitWorker();
        }

        void InitWorker()
        {
            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.RunWorkerAsync();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {

                }
                else if (e.Result != null && e.Result is bool && (bool)e.Result == true)
                {
                    Close();
                }
            }
            catch
            {

            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage <= timeout)
            {
                if (e.ProgressPercentage == 0)
                {
                    // 失败
                    labSendTimeout.Text = "发送超时，点击保存重新发送";
                    this.OkButton.IsEnabled = true;
                }
                else
                    labSendTimeout.Text = "数据下放中..." + e.ProgressPercentage.ToString();
            }
            if (e.ProgressPercentage == 99)
            {
                // 失败
                labSendTimeout.Text = "发送失败，是否重新发送";
                this.OkButton.IsEnabled = true;
            }
            else if (e.ProgressPercentage == 100)
            {
                // 成功
                labSendTimeout.Text = "发送成功，3秒后自动关闭";
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            bool exit = false;
            e.Result = false;
            CMDRevBLL cmdRevBLL = new CMDRevBLL();

            CMDSend cmdSend = new CMDSend();
            int id;
            if (!string.IsNullOrEmpty(hostInfo.Addr) && int.TryParse(hostInfo.Addr, out id))
            {
                cmdSend.GUID = Guid.NewGuid().ToString();
                cmdSend.Addr = hostInfo.Addr;
                cmdSend.Content = HexHelper.ByteArrayToHexString(ProtocolManage.LightGPRSProtocol.LightGetIntervalSyncCMD(id, DateTime.Parse(hsLightsGetStartTime.Value), DateTime.Parse(hsLightsGetEndTime.Value), int.Parse(hsLightsGetIntervalTime.Value), int.Parse(hsLightGetIntervalTime.Value), int.Parse(hsLightGetTimeoutTime.Value), int.Parse(hsLightGetCount.Value)));
                cmdSend.ContentType = (int)CMDType.LightGetIntervalCMD;
                cmdSend.CreateDate = DateTime.Now;
                cmdSend.ID = hostInfo.IDID;
                cmdSend.UpdateDate = cmdSend.CreateDate;
                cmdSend.State = (int)CMDState.NO;

                Debug.WriteLine("开始往数据库中写入命令");
                {
                    if (new CMDSendBLL().Add(cmdSend))
                    {
                        timeout = defaultTimeout;
                        Debug.WriteLine("写入服务器命令成功");
                    }
                    else
                    {
                        return;
                    }
                }
                while (true)
                {
                    if (bw.CancellationPending == true || timeout == 0)
                    {
                        e.Cancel = true;
                        break;
                    }
                    switch ((CMDType)(cmdSend.ContentType))
                    {
                        case CMDType.LightGetIntervalCMD:
                            {
                                try
                                {
                                    Debug.WriteLine("查询服务器返回的值");
                                    List<CMDRev> result = cmdRevBLL.GetModelByIDAndTime(cmdSend.ID, (byte)CMDType.LightGetIntervalRev, -60, (int)CMDState.NO);
                                    if (result != null && result.Count > 0)
                                    {
                                        string[] strContent = result[0].Content.Split(' ');
                                        if (strContent.Length == 3)
                                        {
                                            if (int.Parse(strContent[2]) == 1)
                                            {
                                                Debug.WriteLine("命令执行成功");
                                                // 命令成功
                                                bw.ReportProgress(100, true);
                                                exit = true;
                                                e.Result = true;
                                                Thread.Sleep(2000);
                                            }
                                            else
                                            {
                                                Debug.WriteLine("命令执行失败");
                                                // 命令失败
                                                bw.ReportProgress(99, false);
                                                exit = true;
                                            }
                                            result[0].State = (int)CMDState.Yes;
                                            result[0].UpdateDate = DateTime.Now;
                                            cmdRevBLL.Update(result[0]);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine(ex.Message);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    if (exit == true)
                    {
                        break;
                    }
                    timeout--;
                    bw.ReportProgress(timeout, null);
                    Thread.Sleep(1000);
                }
            }
        }

        public LightGetIntervalDlg(string title, HostInfo hi)
            :this()
        {
            this.Title = title;
            hostInfo = hi;

            DateTime dtNow = DateTime.Now;
            // 扫描开始时间
            hsLightsGetStartTime = hsBLL.GetAllByHostGUIDKey(hi.GUID, "LightsGetStartTime");
            if (hsLightsGetStartTime == null)
            {
                hsLightsGetStartTime = new HostSet();
                hsLightsGetStartTime.GUID = Guid.NewGuid().ToString();
                hsLightsGetStartTime.Key = "LightsGetStartTime";
                hsLightsGetStartTime.Value = "1990-12-17 04:00:00";
                hsLightsGetStartTime.Desc = "扫描开始时间";
                hsLightsGetStartTime.HostGUID = hi.GUID;
                hsLightsGetStartTime.CreateDate = dtNow;
                hsLightsGetStartTime.UpdateDate = dtNow;
                hsBLL.Add(hsLightsGetStartTime);
            }
            tpStart.Value = DateTime.Parse(hsLightsGetStartTime.Value);
            // 扫描结束时间
            hsLightsGetEndTime = hsBLL.GetAllByHostGUIDKey(hi.GUID, "LightsGetEndTime");
            if (hsLightsGetEndTime == null)
            {
                hsLightsGetEndTime = new HostSet();
                hsLightsGetEndTime.GUID = Guid.NewGuid().ToString();
                hsLightsGetEndTime.Key = "LightsGetEndTime";
                hsLightsGetEndTime.Value = "1990-12-17 12:00:00";
                hsLightsGetEndTime.Desc = "扫描结束时间";
                hsLightsGetEndTime.HostGUID = hi.GUID;
                hsLightsGetEndTime.CreateDate = dtNow;
                hsLightsGetEndTime.UpdateDate = dtNow;
                hsBLL.Add(hsLightsGetEndTime);
            }
            tpEnd.Value = DateTime.Parse(hsLightsGetEndTime.Value);
            // 扫描间隔
            hsLightsGetIntervalTime = hsBLL.GetAllByHostGUIDKey(hi.GUID, "LightsGetIntervalTime");
            if (hsLightsGetIntervalTime == null)
            {
                hsLightsGetIntervalTime = new HostSet();
                hsLightsGetIntervalTime.GUID = Guid.NewGuid().ToString();
                hsLightsGetIntervalTime.Key = "LightsGetIntervalTime";
                hsLightsGetIntervalTime.Value = "10";
                hsLightsGetIntervalTime.Desc = "扫描间隔（分钟）";
                hsLightsGetIntervalTime.HostGUID = hi.GUID;
                hsLightsGetIntervalTime.CreateDate = dtNow;
                hsLightsGetIntervalTime.UpdateDate = dtNow;
                hsBLL.Add(hsLightsGetIntervalTime);
            }
            iudGetInterval.Value = int.Parse(hsLightsGetIntervalTime.Value);
            // 单个灯扫描间隔
            hsLightGetIntervalTime = hsBLL.GetAllByHostGUIDKey(hi.GUID, "LightGetIntervalTime");
            if (hsLightGetIntervalTime == null)
            {
                hsLightGetIntervalTime = new HostSet();
                hsLightGetIntervalTime.GUID = Guid.NewGuid().ToString();
                hsLightGetIntervalTime.Key = "LightGetIntervalTime";
                hsLightGetIntervalTime.Value = "5";
                hsLightGetIntervalTime.Desc = "单个灯扫描间隔（秒）";
                hsLightGetIntervalTime.HostGUID = hi.GUID;
                hsLightGetIntervalTime.CreateDate = dtNow;
                hsLightGetIntervalTime.UpdateDate = dtNow;
                hsBLL.Add(hsLightGetIntervalTime);
            }
            iudLightInterval.Value = int.Parse(hsLightGetIntervalTime.Value);
            // 单个灯超时时间
            hsLightGetTimeoutTime = hsBLL.GetAllByHostGUIDKey(hi.GUID, "LightGetTimeoutTime");
            if (hsLightGetTimeoutTime == null)
            {
                hsLightGetTimeoutTime = new HostSet();
                hsLightGetTimeoutTime.GUID = Guid.NewGuid().ToString();
                hsLightGetTimeoutTime.Key = "LightGetTimeoutTime";
                hsLightGetTimeoutTime.Value = "10";
                hsLightGetTimeoutTime.Desc = "单个灯超时时间（秒）";
                hsLightGetTimeoutTime.HostGUID = hi.GUID;
                hsLightGetTimeoutTime.CreateDate = dtNow;
                hsLightGetTimeoutTime.UpdateDate = dtNow;
                hsBLL.Add(hsLightGetTimeoutTime);
            }
            iudLightTimeout.Value = int.Parse(hsLightGetTimeoutTime.Value);
            // 单个灯超时采集次数
            hsLightGetCount = hsBLL.GetAllByHostGUIDKey(hi.GUID, "LightGetCount");
            if (hsLightGetCount == null)
            {
                hsLightGetCount = new HostSet();
                hsLightGetCount.GUID = Guid.NewGuid().ToString();
                hsLightGetCount.Key = "LightGetCount";
                hsLightGetCount.Value = "3";
                hsLightGetCount.Desc = "单个灯超时采集次数";
                hsLightGetCount.HostGUID = hi.GUID;
                hsLightGetCount.CreateDate = dtNow;
                hsLightGetCount.UpdateDate = dtNow;
                hsBLL.Add(hsLightGetCount);
            }
            iudLightCount.Value = int.Parse(hsLightGetCount.Value);
        }
    }
}
