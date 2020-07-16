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
    /// Interaction logic for LightInfoEditDlg.xaml
    /// </summary>
    public partial class LightInfoEditDlg : ModernDialog
    {
        MainWindow mainWindow = null;
        LightInfo lightInfo = null;
        LightInfoLightGroupInfo lightInfoLightGroupInfo = null;
        LightInfoLightGroupInfo lightInfoLightGroupInfoBack = null;

        public class LightTypeItem
        {
            public string Name;
            public LightType Value;

            public override string ToString()
            {
                return Name;
            }
        }

        public LightInfoEditDlg()
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
                        cbLightType.Items.Add(new LightTypeItem() { Name = "太阳能-V1.0", Value = LightType.OldTYN });
                        break;
                    case LightType.NewTYN:
                        cbLightType.Items.Add(new LightTypeItem() { Name = "太阳能-V2.0", Value = LightType.NewTYN });
                        break;
                    case LightType.Normal:
                        cbLightType.Items.Add(new LightTypeItem() { Name = "标准单灯", Value = LightType.Normal });
                        break;
                }
            }
            cbLightType.SelectedIndex = 2;
        }

        public LightInfoEditDlg(MainWindow main, string title, LightInfo li)
            : this()
        {
            this.Title = title;
            mainWindow = main;
            lightInfo = li;

            // 初始化基本数据
            txtLightID.Text = lightInfo.ID;
            txtLightLat.Text = lightInfo.Lat.ToString();
            txtLightLng.Text = lightInfo.Lng.ToString();
            txtLightName.Text = lightInfo.Name;
            txtLightPhyID.Text = lightInfo.PhyID;
            txtLightRemark.Text = lightInfo.Remark;
            txtLightVersion.Text = lightInfo.Version;
            foreach(LightTypeItem a in cbLightType.Items)
            {
                if(a.Value == ((LightType)lightInfo.Type))
                    cbLightType.SelectedItem = a;
            }
            cbLightEnable.IsChecked = lightInfo.Enable == 1 ? true : false;

            // 加载与该分组相关的分组信息
            List<LightGroupInfo> lgi = new LightGroupInfoBLL().GetAllLightGroupInfoByHostGUID(lightInfo.HostGUID);
            combLightGroupInfo.ItemsSource = lgi;
            combLightGroupInfo.DisplayMemberPath = "Name";

            // 加载该单灯所属的分组
            if (lgi != null)
            {
                List<LightInfoLightGroupInfo> list = new LightInfoLightGroupInfoBLL().GetByLightGUID(lightInfo.GUID.Trim());
                if (list != null && list.Count > 0)
                {
                    lightInfoLightGroupInfo = list[0];
                    lightInfoLightGroupInfoBack = (LightInfoLightGroupInfo)lightInfoLightGroupInfo.Clone();
                    combLightGroupInfo.SelectedItem = lgi.FirstOrDefault(t => t.GUID.Trim() == lightInfoLightGroupInfo.LightGroupInfoGUID);
                }
            }
        }

        void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lightInfo.ID = txtLightID.Text.Trim();
                lightInfo.Lat = double.Parse(txtLightLat.Text.Trim());
                lightInfo.Lng = double.Parse(txtLightLng.Text.Trim());
                lightInfo.Name = txtLightName.Text.Trim();
                lightInfo.PhyID = txtLightPhyID.Text.Trim();
                lightInfo.Remark = txtLightRemark.Text.Trim();
                lightInfo.Enable = cbLightEnable.IsChecked == true ? 1 : 0;
                lightInfo.Version = txtLightVersion.Text.Trim();
                lightInfo.Type = (int)(((LightTypeItem)cbLightType.SelectedItem).Value);
            }
            catch
            {
                ModernDialog.ShowMessage("经纬度数据格式错误！", "提示", MessageBoxButton.OK);
                return;
            }

            // 存入组的关联
            if(combLightGroupInfo.SelectedItem != null)
            {
                LightInfoLightGroupInfoBLL ltlgBLL = new LightInfoLightGroupInfoBLL();
                if (lightInfoLightGroupInfo != null)
                {
                    lightInfoLightGroupInfo.LightGroupInfoGUID = (combLightGroupInfo.SelectedItem as LightGroupInfo).GUID;
                    if (!ltlgBLL.Update(lightInfoLightGroupInfo))
                    {
                        ModernDialog.ShowMessage("更新数据库失败！", "提示", MessageBoxButton.OK);
                        return;
                    }
                }
                else
                {
                    lightInfoLightGroupInfo = new LightInfoLightGroupInfo();
                    lightInfoLightGroupInfo.GUID = Guid.NewGuid().ToString();
                    lightInfoLightGroupInfo.LightGroupInfoGUID = (combLightGroupInfo.SelectedItem as LightGroupInfo).GUID;
                    lightInfoLightGroupInfo.LightInfoGUID = lightInfo.GUID;
                    lightInfoLightGroupInfo.CreateTime = DateTime.Now;
                    lightInfoLightGroupInfo.UpdateTime = lightInfoLightGroupInfo.CreateTime;
                    if (!ltlgBLL.Add(lightInfoLightGroupInfo))
                    {
                        ModernDialog.ShowMessage("增加数据库失败！", "提示", MessageBoxButton.OK);
                        return;
                    }
                }
            }

            // 更新单灯
            LightInfoBLL liBLL = new LightInfoBLL();
            if(liBLL.Update(lightInfo))
            {
                Close();
                mainWindow.MapRefreshLightInfo(lightInfo, lightInfoLightGroupInfo, lightInfoLightGroupInfoBack);
            }
            else
            {
                ModernDialog.ShowMessage("更新数据库失败！", "提示", MessageBoxButton.OK);
                return;
            }
        }

        public void SetLatLng(double lat, double lng)
        {
            txtLightLat.Text = lat.ToString();
            txtLightLng.Text = lng.ToString();
        }

        private void btnMapSelect_Click(object sender, RoutedEventArgs e)
        {
            if (mainWindow != null)
            {
                this.WindowState = System.Windows.WindowState.Minimized;
                mainWindow.LightManageDlgSelectMapPoint();
            }
        }
    }
}
