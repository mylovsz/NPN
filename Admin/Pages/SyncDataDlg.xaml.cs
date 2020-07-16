using AdminBLL;
using AdminModel;
using FirstFloor.ModernUI.Windows.Controls;
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

namespace Admin.Pages
{
    /// <summary>
    /// Interaction logic for SyncDataDlg.xaml
    /// </summary>
    public partial class SyncDataDlg : ModernDialog
    {
        BackgroundWorker bw = null;
        CMDSend cmdSend;
        byte[] datas;
        int timeout;
        int defaultTimeout;

        public SyncDataDlg()
        {
            InitializeComponent();

            // define the dialog buttons
            this.Buttons = new Button[] { this.CloseButton };
            this.CloseButton.Content = "关闭";
            this.CloseButton.Click += CloseButton_Click;
        }

        /// <summary>
        /// 有效初始化
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="header">页眉</param>
        /// <param name="type">数据类型</param>
        /// <param name="d">数据内容</param>
        /// <param name="t">超时时间</param>
        public SyncDataDlg(string title, string header, CMDSend send, int t = 10)
            :this()
        {
            this.Title = title;
            txtTip.Text = header;
            cmdSend = send;
            timeout = t;
            defaultTimeout = t;
        }

        void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Dispose();
        }

        public void Dispose()
        {
            if (bw != null)
                bw.CancelAsync();
        }

        private void btnRedo_Click(object sender, RoutedEventArgs e)
        {
            SendCMDToDB();
        }

        private void ModernDialog_Loaded(object sender, RoutedEventArgs e)
        {
            SendCMDToDB();
        }

        void SendCMDToDB()
        {
            gridProgress.Visibility = System.Windows.Visibility.Visible;
            gridInfo.Visibility = System.Windows.Visibility.Hidden;
            txtClock.Text = defaultTimeout.ToString();
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

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage <= timeout)
            {
                if (e.ProgressPercentage == 0)
                {
                    // 失败
                    txtInfo.Text = "发送超时，是否重新发送";
                    btnRedo.Visibility = System.Windows.Visibility.Visible;
                    gridProgress.Visibility = System.Windows.Visibility.Hidden;
                    gridInfo.Visibility = System.Windows.Visibility.Visible;
                }
                else
                    txtClock.Text = e.ProgressPercentage.ToString();
            }
            if (e.ProgressPercentage == 99)
            {
                // 失败
                txtInfo.Text = "发送失败，是否重新发送";
                btnRedo.Visibility = System.Windows.Visibility.Visible;
                gridProgress.Visibility = System.Windows.Visibility.Hidden;
                gridInfo.Visibility = System.Windows.Visibility.Visible;
            }
            else if (e.ProgressPercentage == 100)
            {
                // 成功
                txtInfo.Text = "发送成功，3秒后自动关闭";
                btnRedo.Visibility = System.Windows.Visibility.Hidden;
                gridProgress.Visibility = System.Windows.Visibility.Hidden;
                gridInfo.Visibility = System.Windows.Visibility.Visible;
            }
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            bool exit = false;
            e.Result = false;
            CMDRevBLL cmdRevBLL = new CMDRevBLL();

            Debug.WriteLine("开始往数据库中写入命令");
            {
                if(new CMDSendBLL().Add(cmdSend))
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
                    case CMDType.TimeSyncCMD:
                        {
                            try
                            {
                                Debug.WriteLine("查询服务器返回的值");
                                List<CMDRev> result = cmdRevBLL.GetModelByIDAndTime(cmdSend.ID, (byte)CMDType.TimeSyncRev, -60, (int)CMDState.NO);
                                if (result != null && result.Count>0)
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
