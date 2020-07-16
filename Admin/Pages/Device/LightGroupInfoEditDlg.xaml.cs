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
    /// Interaction logic for LightGroupInfoEditDlg.xaml
    /// </summary>
    public partial class LightGroupInfoEditDlg : ModernDialog
    {
        public LightGroupInfo LightGroupInfo = null;

        public LightGroupInfoEditDlg()
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

        void OkButton_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            LightGroupInfo.Name = txtLightGroupInfoName.Text.Trim();
            LightGroupInfo.ID = txtLightGroupInfoID.Text.Trim();
            this.DialogResult = true;
        }

        public LightGroupInfoEditDlg(string title, LightGroupInfo lgi)
            :this()
        {
            this.Title = title;
            this.LightGroupInfo = lgi;

            txtLightGroupInfoID.Text = lgi.ID.Trim();
            txtLightGroupInfoName.Text = lgi.Name.Trim();
        }
    }
}
