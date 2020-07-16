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
    /// Interaction logic for GroupInfoEditDlg.xaml
    /// </summary>
    public partial class GroupInfoEditDlg : ModernDialog
    {
        public GroupInfo GroupInfo = null;

        public GroupInfoEditDlg()
        {
            InitializeComponent();

            // define the dialog buttons
            this.Buttons = new Button[] { this.OkButton, this.CancelButton };
            this.OkButton.Content = "保存";
            this.OkButton.Command = null;
            this.OkButton.Click += OkButton_Click;
            this.CancelButton.Content = "取消";
        }

        void OkButton_Click(object sender, RoutedEventArgs e)
        {
            GroupInfo.Name = txtGroupInfoName.Text.Trim();
            GroupInfo.ID = txtGroupInfoID.Text.Trim();
            this.DialogResult = true;
            //Close();
        }

        public GroupInfoEditDlg(string title, GroupInfo gi)
            :this()
        {
            this.Title = title;
            this.GroupInfo = gi;

            txtGroupInfoName.Text = gi.Name;
            txtGroupInfoID.Text = gi.ID;
        }
    }
}
