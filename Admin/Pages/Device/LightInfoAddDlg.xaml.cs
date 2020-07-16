using AdminBLL;
using AdminModel;
using FirstFloor.ModernUI.Windows.Controls;
using ProtocolManage;
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
    /// Interaction logic for LightInfoAddDlg.xaml
    /// </summary>
    public partial class LightInfoAddDlg : ModernDialog
    {
        MainWindow mainWindow = null;
        HostInfo hostInfo = null;
        TreeLightGroupInfo treeLightGroupInfo;
        TreeLightGroupInfo treeLightGroupInfoTag;
        TreeHostInfo treeHostInfo;

        public LightInfoAddDlg()
        {
            InitializeComponent();

            // define the dialog buttons
            this.Buttons = new Button[] { this.OkButton, this.CancelButton };
            this.OkButton.Content = "保存";
            this.OkButton.Command = null;
            this.OkButton.Click += OkButton_Click;
            this.CancelButton.Content = "取消";
            IsLumlux = true;

            Array array = Enum.GetValues(typeof(LightType));
            cbLightType.Items.Clear();
            foreach (var a in array)
            {
                switch ((LightType)a)
                {
                    case LightType.OldTYN:
                        cbLightType.Items.Add(new Admin.Pages.Device.LightInfoEditDlg.LightTypeItem() { Name = "太阳能-V1.0", Value = LightType.OldTYN });
                        break;
                    case LightType.NewTYN:
                        cbLightType.Items.Add(new Admin.Pages.Device.LightInfoEditDlg.LightTypeItem() { Name = "太阳能-V2.0", Value = LightType.NewTYN });
                        break;
                    case LightType.Normal:
                        cbLightType.Items.Add(new Admin.Pages.Device.LightInfoEditDlg.LightTypeItem() { Name = "标准单灯", Value = LightType.Normal });
                        break;
                }
            }
            cbLightType.SelectedIndex = 2;
        }

        void OkButton_Click(object sender, RoutedEventArgs e)
        {
            int startID, endID, tempID;
            double startLat, endLat, startLng, endLng, tempLat, tempLng;
            try
            {
                startID = int.Parse(txtStartID.Text.Trim());
                endID = int.Parse(txtEndID.Text.Trim());
                startLat = double.Parse(txtStartLightLat.Text.Trim());
                startLng = double.Parse(txtStartLightLng.Text.Trim());
                endLat = double.Parse(txtEndLightLat.Text.Trim());
                endLng = double.Parse(txtEndLightLng.Text.Trim());
                tempID = endID - startID + 1;
                tempLat = (endLat - startLat) / tempID;
                tempLng = (endLng - startLng) / tempID;
            }
            catch
            {
                ModernDialog.ShowMessage("起始结束地址错误！", "提示", MessageBoxButton.OK);
                return;
            }
            if(startID > endID)
            {
                ModernDialog.ShowMessage("起始地址不能大于结束地址！", "提示", MessageBoxButton.OK);
                return;
            }

            LightInfo lightInfo;
            LightInfoBLL liBLL = new LightInfoBLL();
            LightInfoLightGroupInfoBLL lilgiBLL = new LightInfoLightGroupInfoBLL();

            LightInfoLightGroupInfo lightInfoLightGroupInfo = null;
            if(combLightGroupInfo.SelectedItem != null)
            {
                lightInfoLightGroupInfo = new LightInfoLightGroupInfo();
                lightInfoLightGroupInfo.LightGroupInfoGUID = ((LightGroupInfo)combLightGroupInfo.SelectedItem).GUID;
                treeLightGroupInfoTag = treeHostInfo.TreeLightGroupInfos.FirstOrDefault(a=>a.LightGroupInfo.GUID == lightInfoLightGroupInfo.LightGroupInfoGUID);
            }
            DateTime dtNow = DateTime.Now;
            for(int i=0;i<tempID;i++)
            {
                try
                {
                    // 增加节点
                    lightInfo = new LightInfo(hostInfo.Addr);
                    lightInfo.HostGUID = hostInfo.GUID;
                    lightInfo.GUID = Guid.NewGuid().ToString();
                    lightInfo.ID = (startID + i).ToString("D03");
                    lightInfo.Lat = startLat + tempLat * i;
                    lightInfo.Lng = startLng + tempLng * i;
                    lightInfo.Name = lightInfo.ID;
                    lightInfo.PhyID = lightInfo.ID;
                    lightInfo.Version = txtLightVersion.Text.Trim();
                    lightInfo.Type = (int)(((Admin.Pages.Device.LightInfoEditDlg.LightTypeItem)cbLightType.SelectedItem).Value); // 1 太阳能
                    lightInfo.Enable = 1; // 使能
                    lightInfo.Remark = "";
                    lightInfo.CreateTime = dtNow;
                    lightInfo.UpdateTime = dtNow;
                    liBLL.Add(lightInfo);
                    if(mainWindow != null)
                    {
                        mainWindow.UIAddLightInfo(lightInfo, treeLightGroupInfo);
                    }

                    // 增加节点关系
                    if(lightInfoLightGroupInfo != null)
                    {
                        lightInfoLightGroupInfo.GUID = Guid.NewGuid().ToString();
                        lightInfoLightGroupInfo.CreateTime = dtNow;
                        lightInfoLightGroupInfo.UpdateTime = dtNow;
                        lightInfoLightGroupInfo.LightInfoGUID = lightInfo.GUID;
                        lilgiBLL.Add(lightInfoLightGroupInfo);
                        if (mainWindow != null && treeLightGroupInfoTag != null)
                        {
                            mainWindow.UIAddLightInfoLightGroupInfo(lightInfo, treeLightGroupInfoTag);
                        }
                    }
                }
                catch
                {

                }
            }
            Close();
        }

        public LightInfoAddDlg(MainWindow main, string title, TreeHostInfo thi)
            :this()
        {
            mainWindow = main;
            this.Title = title;
            hostInfo = thi.HostInfo;
            treeHostInfo = thi;
            treeLightGroupInfo = thi.TreeLightGroupInfos.FirstOrDefault(t => t.LightGroupInfo.GUID == "");

            // 增加分组信息
            List<LightGroupInfo> listLGI = new LightGroupInfoBLL().GetAllLightGroupInfoByHostGUID(hostInfo.GUID);
            combLightGroupInfo.ItemsSource = listLGI;
            combLightGroupInfo.DisplayMemberPath = "Name";
            if (combLightGroupInfo.Items.Count > 0)
                combLightGroupInfo.SelectedIndex = 0;
        }

        public void SetStartLatLng(double lat, double lng)
        {
            txtStartLightLat.Text = lat.ToString();
            txtStartLightLng.Text = lng.ToString();
        }

        public void SetEndLatLng(double lat, double lng)
        {
            txtEndLightLat.Text = lat.ToString();
            txtEndLightLng.Text = lng.ToString();
        }

        private void btnStartMapSelect_Click(object sender, RoutedEventArgs e)
        {
            if (mainWindow != null)
            {
                this.WindowState = System.Windows.WindowState.Minimized;
                mainWindow.LightManageDlgSelectMapStartPoint();
            }
        }

        private void btnEndMapSelect_Click(object sender, RoutedEventArgs e)
        {
            if (mainWindow != null)
            {
                this.WindowState = System.Windows.WindowState.Minimized;
                mainWindow.LightManageDlgSelectMapEndPoint();
            }
        }
    }
}
