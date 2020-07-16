using GMap.NET.WindowsPresentation;
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
    /// CustomMarkerHostInfo.xaml 的交互逻辑
    /// </summary>
    public partial class CustomMarkerHostInfo : UserControl
    {
        Popup Popup;
        Label Label;
        GMapMarker Marker;
        GMapControlExt mapControlExt;
        object objTag;
        double heightDefault=30;
        double widthDefault=30;

        public CustomMarkerHostInfo(GMapControlExt mapControl, GMapMarker marker, string title, object obj)
        {
            this.InitializeComponent();

            this.mapControlExt = mapControl;
            this.Marker = marker;
            this.objTag = obj;

            Popup = new Popup();
            Label = new Label();

            this.Unloaded += new RoutedEventHandler(CustomMarkerDemo_Unloaded);
            this.Loaded += new RoutedEventHandler(CustomMarkerDemo_Loaded);
            this.SizeChanged += new SizeChangedEventHandler(CustomMarkerDemo_SizeChanged);

            //this.MouseEnter += new MouseEventHandler(MarkerControl_MouseEnter);
            //this.MouseLeave += new MouseEventHandler(MarkerControl_MouseLeave);
            
            this.MouseMove += new MouseEventHandler(CustomMarkerDemo_MouseMove);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(CustomMarkerDemo_MouseLeftButtonUp);
            this.MouseLeftButtonDown += new MouseButtonEventHandler(CustomMarkerDemo_MouseLeftButtonDown);
            this.MouseDoubleClick += CustomMarkerHostInfo_MouseDoubleClick;

            //Popup.Placement = PlacementMode.Mouse;
            //{
            //    Label.Background = Brushes.Blue;
            //    Label.Foreground = Brushes.White;
            //    Label.BorderBrush = Brushes.WhiteSmoke;
            //    Label.BorderThickness = new Thickness(2);
            //    Label.Padding = new Thickness(5);
            //    Label.FontSize = 22;
            //    Label.Content = title;
            //}
            //Popup.Child = Label;
            this.ToolTip = title;
        }

        public string Title
        {
            get
            {
                return this.ToolTip.ToString();
            }
            set
            {
                this.ToolTip = value;
            }
        }

        public delegate void MarkerHostInfoDoubleClickDelegate(object sender, MouseButtonEventArgs e, object objTag);
        public event MarkerHostInfoDoubleClickDelegate MarkerHostInfoDoubleClick;

        void CustomMarkerHostInfo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MarkerHostInfoDoubleClick != null)
                MarkerHostInfoDoubleClick(sender, e, objTag);
        }

        public void UpdateSize(double size)
        {
            icon.Height = this.heightDefault * size;
            icon.Width = this.widthDefault * size;
        }

        void CustomMarkerDemo_Loaded(object sender, RoutedEventArgs e)
        {
            if (icon.Source.CanFreeze)
            {
                icon.Source.Freeze();
            }
        }

        void CustomMarkerDemo_Unloaded(object sender, RoutedEventArgs e)
        {
            this.Unloaded -= new RoutedEventHandler(CustomMarkerDemo_Unloaded);
            this.Loaded -= new RoutedEventHandler(CustomMarkerDemo_Loaded);
            this.SizeChanged -= new SizeChangedEventHandler(CustomMarkerDemo_SizeChanged);
            this.MouseEnter -= new MouseEventHandler(MarkerControl_MouseEnter);
            this.MouseLeave -= new MouseEventHandler(MarkerControl_MouseLeave);
            this.MouseMove -= new MouseEventHandler(CustomMarkerDemo_MouseMove);
            this.MouseLeftButtonUp -= new MouseButtonEventHandler(CustomMarkerDemo_MouseLeftButtonUp);
            this.MouseLeftButtonDown -= new MouseButtonEventHandler(CustomMarkerDemo_MouseLeftButtonDown);
            this.MouseDoubleClick -= CustomMarkerHostInfo_MouseDoubleClick;

            Marker.Shape = null;
            icon.Source = null;
            icon = null;
            Popup = null;
            Label = null;
        }

        void CustomMarkerDemo_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Marker.Offset = new Point(-e.NewSize.Width / 2, -e.NewSize.Height);
        }

        void CustomMarkerDemo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && IsMouseCaptured)
            {
                Point p = e.GetPosition(mapControlExt);
                Marker.Position = mapControlExt.FromLocalToLatLng((int)(p.X), (int)(p.Y));
            }
        }

        void CustomMarkerDemo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 临时去掉鼠标移动
            //if (!IsMouseCaptured)
            //{
            //    Mouse.Capture(this);
            //}
        }

        void CustomMarkerDemo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // 临时去掉鼠标移动
            //if (IsMouseCaptured)
            //{
            //    Mouse.Capture(null);
            //}
        }

        void MarkerControl_MouseLeave(object sender, MouseEventArgs e)
        {
            Marker.ZIndex -= 10000;
            Popup.IsOpen = false;
        }

        void MarkerControl_MouseEnter(object sender, MouseEventArgs e)
        {
            Marker.ZIndex += 10000;
            Popup.IsOpen = true;
        }
    }
}
