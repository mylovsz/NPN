using AdminModel;
using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Admin.Pages.Device
{
    /// <summary>
    /// Interaction logic for HostInfoEidtDlg.xaml
    /// </summary>
    public partial class HostInfoEditDlg : ModernDialog
    {
        MainWindow mainWindow = null;
        HostInfo hostInfo = null;
        HostInfo hostInfoBack = null;
        bool isAdd = false;

        public HostInfoEditDlg()
        {
            InitializeComponent();

            // define the dialog buttons
            this.Buttons = new Button[] { this.OkButton, this.CancelButton };
            this.OkButton.Content = "保存";
            this.OkButton.Command = null;
            this.OkButton.Click += OkButton_Click;
            this.CancelButton.Content = "取消";
            IsLumlux = true;
        }

        void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                hostInfo.IDID = txtHostIMEI.Text.Trim();
                hostInfo.Lat = double.Parse(txtHostLat.Text);
                hostInfo.Lng = double.Parse(txtHostLng.Text);
                hostInfo.Name = txtHostName.Text.Trim();
                hostInfo.Remark = txtHostRemark.Text.Trim();
                hostInfo.Addr = txtHostRoadID.Text.Trim();
                hostInfo.Enable = (bool)cbHostEnable.IsChecked;
                if(combGroupInfo.SelectedItem == null)
                {
                    hostInfo.GroupInfoGUID = "";
                }
                else
                {
                    hostInfo.GroupInfoGUID = ((TreeGroupInfo)(combGroupInfo.SelectedItem)).GroupInfo.GUID;
                }
            }
            catch
            {
                ModernDialog.ShowMessage("经纬度数据格式错误！", "提示", MessageBoxButton.OK);
                return;
            }
            if (isAdd)
            {
                hostInfo.GUID = Guid.NewGuid().ToString();
                hostInfo.ProjectInfoGUID = MainWindow.appState.CurrentUserInfo.ProjectGUID;
                if(hostInfo.Add())
                {
                    Close();
                    mainWindow.MapAddHostInfo(hostInfo);
                }
            }
            else
            {
                if (hostInfo.Update())
                {
                    Close();
                    mainWindow.MapRefreshHostInfo(hostInfo, hostInfoBack);
                }
                else
                {
                    ModernDialog.ShowMessage("数据存储失败！", "提示", MessageBoxButton.OK);
                }
            }
        }

        public HostInfoEditDlg(MainWindow main, string title, HostInfo hi)
            :this()
        {
            mainWindow = main;
            hostInfo = hi;
            hostInfoBack = (HostInfo)hi.Clone();
            this.Title = title;

            txtHostIMEI.Text = hi.IDID;
            txtHostLat.Text = hi.Lat.ToString();
            txtHostLng.Text = hi.Lng.ToString();
            txtHostName.Text = hi.Name;
            txtHostRemark.Text = hi.Remark;
            txtHostRoadID.Text = hi.Addr;
            cbHostEnable.IsChecked = hi.Enable;

            // 初始化组信息
            combGroupInfo.ItemsSource = MainWindow.appState.TreeDatas.TreeGroupInfos.Where(t=>t.GroupInfo.GUID.Trim() != "").ToList();
            combGroupInfo.DisplayMemberPath = "GroupInfo.Name";

            combGroupInfo.SelectedItem = MainWindow.appState.TreeDatas.TreeGroupInfos.FirstOrDefault(t => t.GroupInfo.GUID == hi.GroupInfoGUID);
        }

        public HostInfoEditDlg(MainWindow main, string title, HostInfo hi, bool add)
            :this(main, title, hi)
        {
            isAdd = add;
        }

        private void btnMapSelect_Click(object sender, RoutedEventArgs e)
        {
            if (mainWindow != null)
            {
                this.WindowState = System.Windows.WindowState.Minimized;
                mainWindow.HostManageDlgSelectMapPoint();
            }
        }

        public void SetLatLng(double lat, double lng)
        {
            txtHostLat.Text = lat.ToString();
            txtHostLng.Text = lng.ToString();
        }

        private void ModernDialog_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
