using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GMap.NET.WindowsPresentationExt.CustomMarkers
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class CustomMarkerLightInfo : UserControl
    {
        Popup popup;
        Label label;
        int heightDefault = 20;
        int widthDefault = 10;

        public CustomMarkerLightInfo()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        LightInfo li;
        public LightInfo LI
        {
            set
            {
                li = value;
            }
            get
            {
                return li;
            }
        }

        public LightFaultEnum Fault
        {
            get
            {
                if (li == null)
                    return LightFaultEnum.None;
                return li.RealTimeFault;
            }
            set
            {
                li.RealTimeFault = value;
            }
        }

        public CustomMarkerLightInfo(LightInfo hi)
            :this()
        {
            LI = hi;
            //string c = AppDomain.CurrentDomain.BaseDirectory;
            //string path = c + @"Image\Markers\" + ((int)li.RealTimeFault).ToString() + ".png";
            //image.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
            //ellipse.ToolTip = tooltip;

            //this.ToolTip = tooltip;
            
            //popup = new Popup();
            //label = new Label();
            //popup.Placement = PlacementMode.Mouse;
            //label.Background = Brushes.Blue;
            //label.Foreground = Brushes.White;
            //label.BorderBrush = Brushes.WhiteSmoke;
            //label.BorderThickness = new Thickness(2);
            //label.Padding = new Thickness(5);
            //label.FontSize = 22;
            //label.Content = tooltip;
            //popup.Child = label;

            //this.MouseEnter += CustomMarkerLightInfo_MouseEnter;
            //this.MouseLeave += CustomMarkerLightInfo_MouseLeave;
        }

        public CustomMarkerLightInfo(LightInfo hi, Color color)
            :this(hi)
        {
            //ellipse.Fill = new SolidColorBrush(color);
        }

        void CustomMarkerLightInfo_MouseLeave(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();

            popup.IsOpen = false;
        }

        void CustomMarkerLightInfo_MouseEnter(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();

            popup.IsOpen = true;
        }

        public void UpdateSize(double p)
        {
            //throw new NotImplementedException();
            this.Height = p * heightDefault;
            this.Width = p * widthDefault;
        }
    }
}
