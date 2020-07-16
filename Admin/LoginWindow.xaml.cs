using AdminBLL;
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

namespace Admin
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : ModernWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text.Trim();
            if(string.IsNullOrEmpty(name))
            {
                ModernDialog.ShowMessage("用户名不能为空", "提示", MessageBoxButton.OK);
                return ;
            }
            string psd = txtPassword.Password;
            if(string.IsNullOrEmpty(psd))
            {
                ModernDialog.ShowMessage("密码不能为空", "提示", MessageBoxButton.OK);
                return ;
            }
            UserInfo ui = null;
            try
            {
                ui = new UserBLL().GetModelByNamePsd(name, psd);
            }
            catch(Exception ex)
            {
                ModernDialog.ShowMessage("数据库连接错误："+ex.Message, "提示", MessageBoxButton.OK);
                return;
            }
            if (ui != null)
            {
                MainWindow main = new MainWindow();
                MainWindow.appState.CurrentUserInfo = ui;

                // 项目信息
                ProjectInfo pi = new ProjectInfoBLL().GetModel(ui.ProjectGUID);
                if (pi != null)
                {
                    MainWindow.appState.MapConfig.CenterLat = pi.Lat;
                    MainWindow.appState.MapConfig.CenterLng = pi.Lng;
                }
                else
                {
                    MainWindow.appState.MapConfig.CenterLat = 31.02;
                    MainWindow.appState.MapConfig.CenterLng = 120.6;
                }

                // 项目配置信息
                MainWindow.appState.ProjectSets = new ProjectSetBLL().GetListByPrjGUID(ui.ProjectGUID);
                LightStateInfo.ProjectSets = MainWindow.appState.ProjectSets;

                main.Show();
                this.Close();
            }
            else
            {
                ModernDialog.ShowMessage("用户名和密码错误！", "提示", MessageBoxButton.OK);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
