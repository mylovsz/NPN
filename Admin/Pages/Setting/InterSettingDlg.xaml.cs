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
    /// Interaction logic for InterSettingDlg.xaml
    /// </summary>
    public partial class InterSettingDlg : ModernDialog
    {
        HostInfo hostInfo;
        HostSetBLL hsBLL = new HostSetBLL();
        HostSet hsStart;
        HostSet hsLen;
        HostSet hsCount;
        BackgroundWorker bw = null;
        int timeout = 10;
        int defaultTimeout = 10;
        int start, len, count;

        public InterSettingDlg()
        {
            InitializeComponent();

            // define the dialog buttons
            this.Buttons = new Button[] { this.OkButton, this.CancelButton };
            this.OkButton.Content = "保存";
            this.OkButton.Command = null;
            this.OkButton.Click += OkButton_Click;
            this.CancelButton.Content = "取消";
        }

        public InterSettingDlg(string title, HostInfo hi)
            :this()
        {
            this.Title = title;
            hostInfo = hi;
            DateTime dtNow = DateTime.Now;
            hsStart = hsBLL.GetAllByHostGUIDKey(hi.GUID, "IntervalStart");
            if(hsStart == null)
            {
                hsStart = new HostSet();
                hsStart.GUID = Guid.NewGuid().ToString();
                hsStart.Key = "IntervalStart";
                hsStart.Value = "1";
                hsStart.Desc = "区间开始节点";
                hsStart.HostGUID = hi.GUID;
                hsStart.CreateDate = dtNow;
                hsStart.UpdateDate = dtNow;
                hsBLL.Add(hsStart);
            }
            txtStart.Text = hsStart.Value;
            hsLen = hsBLL.GetAllByHostGUIDKey(hi.GUID, "IntervalLen");
            if (hsLen == null)
            {
                hsLen = new HostSet();
                hsLen.GUID = Guid.NewGuid().ToString();
                hsLen.Key = "IntervalLen";
                hsLen.Value = "1";
                hsLen.Desc = "每个区间长度";
                hsLen.HostGUID = hi.GUID;
                hsLen.CreateDate = dtNow;
                hsLen.UpdateDate = dtNow;
                hsBLL.Add(hsLen);
            }
            txtLen.Text = hsLen.Value;
            hsCount = hsBLL.GetAllByHostGUIDKey(hi.GUID, "IntervalCount");
            if(hsCount == null)
            {
                hsCount = new HostSet();
                hsCount.GUID = Guid.NewGuid().ToString();
                hsCount.Key = "IntervalCount";
                hsCount.Value = "1";
                hsCount.Desc = "区间个数";
                hsCount.HostGUID = hi.GUID;
                hsCount.CreateDate = dtNow;
                hsCount.UpdateDate = dtNow;
                hsBLL.Add(hsCount);
            }
            txtCount.Text = hsCount.Value;
        }

        void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if(!int.TryParse(txtStart.Text.Trim(), out start))
            {
                ModernDialog.ShowMessage("起始节点格式错误", "提示", MessageBoxButton.OK);
                return;
            }
            DateTime dt = DateTime.Now;
            hsStart.Value = txtStart.Text.Trim();
            hsStart.UpdateDate = dt;
            if (!int.TryParse(txtLen.Text, out len))
            {
                ModernDialog.ShowMessage("区间长度格式错误", "提示", MessageBoxButton.OK);
                return;
            }
            hsLen.Value = txtLen.Text.Trim();
            hsLen.UpdateDate = dt;
            if (!int.TryParse(txtCount.Text, out count))
            {
                ModernDialog.ShowMessage("区间个数格式错误", "提示", MessageBoxButton.OK);
                return;
            }
            hsCount.Value = txtCount.Text.Trim();
            hsCount.UpdateDate = dt;
            hsBLL.Update(hsStart);
            hsBLL.Update(hsLen);
            hsBLL.Update(hsCount);
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
                cmdSend.Content = HexHelper.ByteArrayToHexString(ProtocolManage.LightGPRSProtocol.IntervalSyncCMD(id, start, len, count));
                cmdSend.ContentType = (int)CMDType.InterSetCMD;
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
                        case CMDType.InterSetCMD:
                            {
                                try
                                {
                                    Debug.WriteLine("查询服务器返回的值");
                                    List<CMDRev> result = cmdRevBLL.GetModelByIDAndTime(cmdSend.ID, (byte)CMDType.InterSetRev, -60, (int)CMDState.NO);
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
    }
}
