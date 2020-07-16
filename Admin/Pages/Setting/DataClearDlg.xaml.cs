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

namespace Admin.Pages.Setting
{
    /// <summary>
    /// Interaction logic for DataClearDlg.xaml
    /// </summary>
    public partial class DataClearDlg : ModernDialog
    {
        public DataClearDlg()
        {
            InitializeComponent();

            // define the dialog buttons
            this.Buttons = new Button[] { this.CloseButton };
            this.CloseButton.Content = "关闭";
        }

        private void ModernDialog_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            tpStart.Value = dt.AddDays(-7);
            tpEnd.Value = dt;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (tpStart.Value == null || tpEnd.Value == null)
                return;
            DateTime dtStart = (DateTime)tpStart.Value;
            DateTime dtEnd = (DateTime)tpEnd.Value;
            if(new AdminBLL.LightStateInfoBLL().Delete(dtStart, dtEnd))
            {
                ModernDialog.ShowMessage("删除成功", "提示", MessageBoxButton.OK);
            }
            else
            {
                ModernDialog.ShowMessage("删除失败", "提示", MessageBoxButton.OK);
            }
        }
    }
}
