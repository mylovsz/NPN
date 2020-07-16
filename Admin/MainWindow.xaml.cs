using Admin.AppData;
using Admin.Pages;
using Admin.Pages.Device;
using Admin.Pages.Setting;
using AdminBLL;
using AdminModel;
using FirstFloor.ModernUI.Windows.Controls;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using GMap.NET.WindowsPresentationExt;
using GMap.NET.WindowsPresentationExt.CustomMarkers;
using LumluxSSYDB.Common.DataConverter;
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

namespace Admin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public static AppState appState = new AppState();
        BackgroundWorker bwLoadData;
        BackgroundWorker bwRealData;

        /// <summary>
        /// 单灯编辑
        /// </summary>
        LightInfoEditDlg lightInfoEditDlg = null;

        void ShowState(string content)
        {
            txtTcpServerState.Text = content;
        }

        #region
        GMapMarker currentMarker;
        private void LoadInit(object obj)
        {
            // 此延迟仅仅是为了等待界面更新
            Thread.Sleep(100);

            // 界面元素，因此使用invoke
            this.Dispatcher.Invoke((Action)(() =>
            {
                MapInfo();
            }));
        }
        public void MapInfo()
        {
            ShowState("加载地图...");
            string gmapPath = Environment.CurrentDirectory + System.IO.Path.DirectorySeparatorChar + "GMapCache" + System.IO.Path.DirectorySeparatorChar;
            map.CacheLocation = gmapPath;

            // 在线与缓冲
            map.Manager.Mode = GMap.NET.AccessMode.ServerAndCache;

            // 地图提供商
            map.MapProvider = GMapProviders.GoogleChinaMap;
            map.MapProvider.Copyright = "苏州纽克斯照明";

            // 初始位置
            map.Position = new GMap.NET.PointLatLng(appState.MapConfig.CenterLat, appState.MapConfig.CenterLng);

            // 放大缩小等级
            map.MaxZoom = 18;
            map.MinZoom = 2; // 8
            map.Zoom = 13;

            // 地图语言
            GMapProvider.Language = LanguageType.ChineseSimplified;

            // Marker 是否支持缩放
            map.IgnoreMarkerOnMouseWheel = false;
            //map.DragButton = MouseButton.Left;
            map.DragButton = MouseButton.Right;

            // 地图事件
            map.OnPositionChanged += map_OnPositionChanged;
            map.MouseMove += map_MouseMove;
            map.MouseEnter += map_MouseEnter;
            map.MouseLeave += map_MouseLeave;
            map.MouseUp += map_MouseUp;
            map.OnTileLoadStart += map_OnTileLoadStart;
            map.OnTileLoadComplete += map_OnTileLoadComplete;
            map.OnMapTypeChanged += map_OnMapTypeChanged;
            map.MouseLeftButtonDown += map_MouseLeftButtonDown;
            map.MouseDoubleClick += map_MouseDoubleClick;

            // 地图事件2
            map.OnMapZoomChanged += map_OnMapZoomChanged;

            // 设置区域
            map.MapProvider.Copyright = "苏州纽克斯照明";
            ShowState("TileDBv5\\zh-CN\\Data.gmdb,缓存数据包位置定向，开始加载");
            // 缓存数据包位置定向
            if (!System.IO.File.Exists(gmapPath + "TileDBv5\\zh-CN\\Data.gmdb"))
            {
                if (GMaps.Instance.ImportFromGMDB("DataExp.gmdb") == false)
                {
                    //MessageBox.Show("不存在缓冲包", "GMap");
                    ShowState("不存在缓冲包，尝试在线加载地图信息");
                }
                else
                {
                    ModernDialog.ShowMessage("开始载入离线地图，请点击OK继续执行", "GMap", MessageBoxButton.OK);
                    MapInfo();
                }
            }

            // 增加地图工具

            // End 增加地图工具

            // 重新载入，可以触发OnTileLoadStart
            map.ReloadMap();

            // 初始化界面元素
            // 提供者
            //combMapProviders.ItemsSource = GMapProviders.List;
            //combMapProviders.DisplayMemberPath = "Name";
            //combMapProviders.SelectedItem = map.MapProvider;
            // 访问方式
            //combMapAccessMode.ItemsSource = Enum.GetValues(typeof(AccessMode));
            //combMapAccessMode.SelectedItem = map.Manager.Mode;
            // 获取缓冲模式
            //map.Manager.UseRouteCache;
            //map.Manager.UseGeocoderCache;
            // 获取区域位置
            //MainMap.Position.Lat.ToString(CultureInfo.InvariantCulture);
            //MainMap.Position.Lng.ToString(CultureInfo.InvariantCulture);
        }

        void map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            switch (appState.MapState)
            {
                case AppMapState.HostSelectMapPoint:
                    if (hostInfoEditDlg != null)
                    {
                        map.Cursor = Cursors.Arrow;
                        ToolTipService.SetIsEnabled(map, false);
                        Point p = Mouse.GetPosition(map);
                        PointLatLng latLng = map.FromLocalToLatLng((int)p.X, (int)p.Y);
                        hostInfoEditDlg.SetLatLng(latLng.Lat, latLng.Lng);
                        hostInfoEditDlg.WindowState = System.Windows.WindowState.Normal;
                    }
                    appState.MapState = AppMapState.Normal;
                    break;
                case AppMapState.LightSelectMapPoint:
                    if (lightInfoEditDlg != null)
                    {
                        map.Cursor = Cursors.Arrow;
                        ToolTipService.SetIsEnabled(map, false);
                        Point p = Mouse.GetPosition(map);
                        PointLatLng latLng = map.FromLocalToLatLng((int)p.X, (int)p.Y);
                        lightInfoEditDlg.SetLatLng(latLng.Lat, latLng.Lng);
                        lightInfoEditDlg.WindowState = System.Windows.WindowState.Normal;
                    }
                    appState.MapState = AppMapState.Normal;
                    break;
                case AppMapState.LightSelectMapStartPoint:
                    if (lightInfoAddDlg != null)
                    {
                        map.Cursor = Cursors.Arrow;
                        ToolTipService.SetIsEnabled(map, false);
                        Point p = Mouse.GetPosition(map);
                        PointLatLng latLng = map.FromLocalToLatLng((int)p.X, (int)p.Y);
                        lightInfoAddDlg.SetStartLatLng(latLng.Lat, latLng.Lng);
                        lightInfoAddDlg.WindowState = System.Windows.WindowState.Normal;
                    }
                    appState.MapState = AppMapState.Normal;
                    break;
                case AppMapState.LightSelectMapEndPoint:
                    if (lightInfoAddDlg != null)
                    {
                        map.Cursor = Cursors.Arrow;
                        ToolTipService.SetIsEnabled(map, false);
                        Point p = Mouse.GetPosition(map);
                        PointLatLng latLng = map.FromLocalToLatLng((int)p.X, (int)p.Y);
                        lightInfoAddDlg.SetEndLatLng(latLng.Lat, latLng.Lng);
                        lightInfoAddDlg.WindowState = System.Windows.WindowState.Normal;
                    }
                    appState.MapState = AppMapState.Normal;
                    break;
            }
        }

        void map_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void map_OnMapTypeChanged(GMapProvider type)
        {
            Console.WriteLine("Type");
        }

        void map_OnPositionChanged(PointLatLng point)
        {
            // 当前的中心点
            //ThreadShowCente(point.Lat.ToString(), point.Lng.ToString());
        }

        void map_OnMapZoomChanged()
        {
            //throw new NotImplementedException();
            UpdateMapMarkerSize();
            // 此处可以放置缩放地图图标的大小代码
            //mainWindowViewModel.UpdateMapMarkerSize();
        }

        /// <summary>
        /// 更新尺寸
        /// </summary>
        public void UpdateMapMarkerSize()
        {
            double zoom = map.Zoom;
            if (appState.MapDatas.DicHostInfoMarker != null && appState.MapDatas.DicHostInfoMarker.Values.Count > 0)
            {
                foreach (GMapMarker g in appState.MapDatas.DicHostInfoMarker.Values)
                {
                    CustomMarkerHostInfo c = (CustomMarkerHostInfo)g.Shape;
                    if (c != null)
                        c.UpdateSize(zoom / 18);
                }
            }
            if (appState.MapDatas.DicLightInfoMarker != null && appState.MapDatas.DicLightInfoMarker.Values.Count > 0)
            {
                foreach (GMapMarker g in appState.MapDatas.DicLightInfoMarker.Values)
                {
                    CustomMarkerLightInfo c = (CustomMarkerLightInfo)g.Shape;
                    if (c != null)
                        c.UpdateSize(zoom / 18);
                }
            }
        }

        void map_OnTileLoadComplete(long ElapsedMilliseconds)
        {
            // 加载后台数据
            if (bwLoadData == null)
            {
                bwLoadData = new BackgroundWorker();
                bwLoadData.DoWork += bwLoadData_DoWork;
                bwLoadData.RunWorkerAsync();
            }
            // 获取最新的加载时间
            //map.ElapsedMilliseconds = ElapsedMilliseconds;

            // 加上下面内容会导致鼠标线程死锁
            // 显示加载后的状态
            //System.Windows.Forms.MethodInvoker m = delegate()
            //{
            //    progressBar1.Visibility = Visibility.Hidden;
            //    groupBox3.Header = "loading, last in " + MainMap.ElapsedMilliseconds + "ms";
            //};

            //try
            //{
            //    this.Dispatcher.BeginInvoke(DispatcherPriority.Loaded, m);
            //}
            //catch
            //{
            //}
            //ThreadShowState("OK [" + ElapsedMilliseconds + "ms]");
        }

        void map_OnTileLoadStart()
        {
            // 情况计时
            //map.ElapsedMilliseconds = 0;

            // 显示开始状态
            //ThreadShowState("Load ", false);
        }

        void map_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void map_MouseLeave(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void map_MouseEnter(object sender, MouseEventArgs e)
        {
            //map.Focus();
        }

        void map_MouseMove(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            Point p = Mouse.GetPosition(map);
            PointLatLng latLng = map.FromLocalToLatLng((int)p.X, (int)p.Y);
            //ThreadShowLng(String.Format("    Lat:{0:N4}, Lng:{1:N4}, Level:{2:N0}", latLng.Lat, latLng.Lng, map.Zoom));
            this.Dispatcher.Invoke(((Action)(() =>
            {
                txtStatusMapLatLng.Text = String.Format("纬度 : {0:N6}, 经度 : {1:N6}, 等级 : {2:N0}", latLng.Lat, latLng.Lng, map.Zoom);
            })));
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ModernWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ShowState("同步数据...");
            // 加载用户信息
            btnUserManage.Content = appState.CurrentUserInfo.Name;
            // 采用线程延迟加载地图，防止开始地图的卡壳
            Thread t = new Thread(LoadInit);
            t.Start();
        }

        public void MapRefreshLightInfo(List<LightInfo> list)
        {
            if (list != null && list.Count > 0)
            {
                if (appState.MapDatas.DicLightInfoMarker.Count > 0)
                {
                    foreach (GMapMarker gm in appState.MapDatas.DicLightInfoMarker.Values)
                    {
                        map.Markers.Remove(gm);
                    }
                }
                appState.MapDatas.DicLightInfoMarker.Clear();
                GMapMarker g;
                foreach (LightInfo l in list)
                {
                    g = MapAddLightInfo(l, map);
                    appState.MapDatas.DicLightInfoMarker.Add(l.GUID, g);
                }
            }
        }

        /// <summary>
        ///  增加单灯，更新左侧列表的全部组，增加地图标记，增加全局缓冲单灯
        /// </summary>
        /// <param name="l"></param>
        public void UIAddLightInfo(LightInfo l, TreeLightGroupInfo t)
        {
            // 更新左侧列表
            if (t != null)
                t.TreeLightInfos.Add(new TreeLightInfo() { LightInfo = l });
            // 增加地图标记
            GMapMarker g = MapAddLightInfo(l, map);
            if (g != null)
            {
                appState.MapDatas.DicLightInfoMarker.Add(l.GUID, g);
            }
            // 增加全局缓冲区
            appState.TreeDatas.ListLightInfo.Add(l);
        }

        /// <summary>
        /// 增加单灯与分组的真正关系
        /// </summary>
        /// <param name="l"></param>
        /// <param name="t"></param>
        public void UIAddLightInfoLightGroupInfo(LightInfo l, TreeLightGroupInfo t)
        {
            // 更新左侧列表
            if (t != null)
                t.TreeLightInfos.Add(new TreeLightInfo() { LightInfo = l });
        }

        /// <summary>
        /// 增加单灯，更新左侧列表的全部组，增加地图标记，增加全局缓冲单灯
        /// </summary>
        /// <param name="li"></param>
        public GMapMarker MapAddLightInfo(LightInfo l, GMapControlExt gMapControlExt)
        {
            // 更新地图信息
            GMapMarker g = null;
            Color color = Colors.White;
            g = new GMapMarker(new PointLatLng((double)l.Lat, (double)l.Lng));
            {
                switch (l.RealTimeFault)
                {
                    case LightFaultEnum.BallastError:
                        //result = "镇流器错误";
                        color = Colors.Red;
                        break;
                    case LightFaultEnum.CloseExtistCurrent:
                        //result = "关灯有电流";
                        color = Colors.Red;
                        break;
                    case LightFaultEnum.CommError:
                        //result = "通讯异常";
                        color = Colors.Red;
                        break;
                    case LightFaultEnum.LampError:
                        //result = "灯故障";
                        color = Colors.Red;
                        break;
                    case LightFaultEnum.None:
                        //result = "正常";
                        color = Colors.White;
                        break;
                    case LightFaultEnum.NormalClose:
                        //result = "正常关";
                        color = Colors.Gray;
                        break;
                    case LightFaultEnum.NormalOpen:
                        //result = "正常开";
                        color = Colors.Orange;
                        break;
                    case LightFaultEnum.OpenSmallPower:
                        //result = "开灯无电流";
                        color = Colors.Red;
                        break;
                    default:
                        break;
                }
                CustomMarkerLightInfo c = new CustomMarkerLightInfo(l, color);
                c.UpdateSize(gMapControlExt.Zoom / 18);
                g.Shape = c;
                g.Offset = new System.Windows.Point(-3, -15);
                g.ZIndex = int.MaxValue;
                gMapControlExt.Markers.Add(g);
            }
            return g;
        }

        public void MapAddHostInfo(HostInfo h)
        {
            // 在地图显示
            GMapMarker g = null;
            GMapControlExt gMapControlExt = map;
            g = new GMapMarker(new PointLatLng((double)h.Lat, (double)h.Lng));
            {
                CustomMarkerHostInfo customMarkerHostInfo = new CustomMarkerHostInfo(gMapControlExt, g, h.ToString(), h);
                //customMarkerHostInfo.MarkerHostInfoDoubleClick += customMarkerHostInfo_MarkerHostInfoDoubleClick;
                customMarkerHostInfo.UpdateSize(13.0 / 18);
                g.Shape = customMarkerHostInfo;
                //g.Offset = new System.Windows.Point(-13, -13);
                g.ZIndex = int.MaxValue;
                gMapControlExt.Markers.Add(g);
            }
            appState.MapDatas.DicHostInfoMarker.Add(h.GUID, g);

            // 在左侧列表显示
            // 加入新的分组
            TreeGroupInfo tgi = appState.TreeDatas.TreeGroupInfos.FirstOrDefault(t => t.GroupInfo.GUID.Trim() == h.GroupInfoGUID.Trim());
            TreeHostInfo thi = new TreeHostInfo() { HostInfo = h };
            thi.AddAllGroup();
            if (tgi != null)
            {
                tgi.TreeHostInfos.Add(thi);
            }
            else
            {
                if (h.GroupInfoGUID.Trim() == "")
                {
                    // 增加未分组的主机
                    new UIBLL().AddNoneTreeGroupInfo().TreeHostInfos.Add(thi);
                }
            }
            appState.TreeDatas.ListHostInfo.Add(h);
        }

        public void MapRefreshLightInfo(LightInfo light, LightInfoLightGroupInfo newLightInfoGroupInfo, LightInfoLightGroupInfo backLightInfoGroupInfo)
        {
            // 更新地图，如果存在
            GMapMarker g;
            if (appState.MapDatas.DicLightInfoMarker.TryGetValue(light.GUID, out g))
            {
                g.Position = new PointLatLng(light.Lat, light.Lng);
                //((CustomMarkerLightInfo)g.Shape).Title = light.Name;
            }

            // 更新左侧树形
            if (newLightInfoGroupInfo != backLightInfoGroupInfo)
            {
                // 移除旧的分组
                TreeHostInfo thi = null;
                TreeLightGroupInfo tlgi = null;
                TreeLightInfo tli = null;

                foreach (TreeGroupInfo t in appState.TreeDatas.TreeGroupInfos)
                {
                    thi = t.TreeHostInfos.FirstOrDefault(a => a.HostInfo.GUID == light.HostGUID);
                    if (thi != null)
                    {
                        break;
                    }
                }
                if (backLightInfoGroupInfo != null)
                {
                    if (thi != null)
                    {
                        tlgi = thi.TreeLightGroupInfos.FirstOrDefault(a => a.LightGroupInfo.GUID != "" && a.LightGroupInfo.GUID.Trim() == backLightInfoGroupInfo.LightGroupInfoGUID.Trim());
                        if (tlgi != null)
                        {
                            tli = tlgi.TreeLightInfos.FirstOrDefault(a => a.LightInfo.GUID.Trim() == light.GUID.Trim());
                            if (tli != null)
                            {
                                tlgi.TreeLightInfos.Remove(tli);
                            }
                        }
                    }
                }

                // 增加新的分组
                if (thi != null)
                {
                    tlgi = thi.TreeLightGroupInfos.FirstOrDefault(a => a.LightGroupInfo.GUID.Trim() == newLightInfoGroupInfo.LightGroupInfoGUID.Trim());
                    if (tlgi != null)
                    {
                        tlgi.TreeLightInfos.Add(new TreeLightInfo() { LightInfo = light });
                    }
                }
            }
        }

        public void MapRefreshHostInfo(HostInfo host, HostInfo hostBack)
        {
            // 更新地图
            GMapMarker g;
            if (appState.MapDatas.DicHostInfoMarker.TryGetValue(host.GUID, out g))
            {
                g.Position = new PointLatLng(host.Lat, host.Lng);
                ((CustomMarkerHostInfo)g.Shape).Title = host.Name;
            }

            // 更新左侧树形
            if (host.GroupInfoGUID != hostBack.GroupInfoGUID)
            {
                // 去除旧的分组
                TreeGroupInfo tgi = appState.TreeDatas.TreeGroupInfos.FirstOrDefault(t => t.GroupInfo.GUID.Trim() == hostBack.GroupInfoGUID.Trim());
                TreeHostInfo thi = null;
                if (tgi != null)
                {
                    thi = tgi.TreeHostInfos.FirstOrDefault(t => t.HostInfo.GUID == hostBack.GUID);
                    tgi.TreeHostInfos.Remove(thi);
                }

                // 加入新的分组
                tgi = appState.TreeDatas.TreeGroupInfos.FirstOrDefault(t => t.GroupInfo.GUID == host.GroupInfoGUID);
                if (tgi != null && thi != null)
                {
                    tgi.TreeHostInfos.Add(thi);
                }
            }

            // 如果未分组的主机为0，则移除此分组
            TreeGroupInfo none = appState.TreeDatas.TreeGroupInfos.FirstOrDefault(t => t.GroupInfo.GUID.Trim() == "");
            if (none != null && none.TreeHostInfos.Count == 0)
                appState.TreeDatas.TreeGroupInfos.Remove(none);
        }

        public void MapRefreshHostInfo(List<HostInfo> list)
        {
            // 显示所有的主机
            GMapMarker g = null;
            GMapControlExt gMapControlExt = map;

            if (appState.MapDatas.DicHostInfoMarker.Count > 0)
            {
                foreach (GMapMarker gm in appState.MapDatas.DicHostInfoMarker.Values)
                {
                    gMapControlExt.Markers.Remove(gm);
                }
            }

            appState.MapDatas.DicHostInfoMarker.Clear();

            if (list != null && list.Count > 0)
            {
                foreach (HostInfo h in list)
                {
                    g = new GMapMarker(new PointLatLng((double)h.Lat, (double)h.Lng));
                    {
                        CustomMarkerHostInfo customMarkerHostInfo = new CustomMarkerHostInfo(gMapControlExt, g, h.ToString(), h);
                        //customMarkerHostInfo.MarkerHostInfoDoubleClick += customMarkerHostInfo_MarkerHostInfoDoubleClick;
                        customMarkerHostInfo.UpdateSize(13.0 / 18);
                        g.Shape = customMarkerHostInfo;
                        //g.Offset = new System.Windows.Point(-13, -13);
                        g.ZIndex = int.MaxValue;
                        gMapControlExt.Markers.Add(g);
                    }
                    appState.MapDatas.DicHostInfoMarker.Add(h.GUID, g);
                }
            }
        }

        void bwLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.Dispatcher.Invoke((Action)(() =>
            {
                ShowState("地图加载完成");
            }));
                Thread.Sleep(1000);
                this.Dispatcher.Invoke((Action)(() =>
                {
                    ShowState("加载后台数据...");
                }));
                appState.TreeDatas = new UIBLL().GetTreeData(appState.CurrentUserInfo.ProjectGUID);
                Thread.Sleep(1000);
                this.Dispatcher.Invoke((Action)(() =>
                {
                    ShowState($"加载树形结构... {appState.TreeDatas != null}");
                }));

                if (appState.TreeDatas != null)
                {
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        ShowState("更新后台数据");
                        Thread.Sleep(2000);
                        // 显示左侧列表
                        tvHostLightInfo.ItemsSource = appState.TreeDatas.TreeGroupInfos;
                        ShowState("更新后台数据1");
                        Thread.Sleep(2000);
                        //更新右上角的报警标志
                        List<LightStateImageInfo> list = new List<LightStateImageInfo>();
                        string c = AppDomain.CurrentDomain.BaseDirectory;
                        List<ProjectSet> listPS = appState.ProjectSets.Where(a => (a.Key.Length > 12 && a.Key.Substring(0, 12) == "Light_Image_")).ToList();
                        ShowState("更新后台数据2");
                        Thread.Sleep(2000);
                        if (listPS != null && listPS.Count > 0)
                        {
                            ShowState("更新后台数据3");
                            Thread.Sleep(2000);
                            string path;
                            BitmapImage bitMapImage;
                            foreach (ProjectSet p in listPS)
                            {
                                path = c + @"Image\Markers\" + p.Value;
                                try
                                {
                                    bitMapImage = new BitmapImage(new Uri(path, UriKind.Absolute));
                                    list.Add(new LightStateImageInfo() { ImagePath = bitMapImage, ImageText = p.Remark });
                                }
                                catch (Exception exp)
                                {
                                    ShowState($"{path}不存在");
                                }

                            }
                        }
                        ShowState("更新后台数据4");
                        Thread.Sleep(2000);
                        lbLightStateInfo.ItemsSource = list;
                        ShowState("更新后台数据5");
                        Thread.Sleep(2000);
                        // 显示所有的主机
                        MapRefreshHostInfo(appState.TreeDatas.ListHostInfo);
                        ShowState("更新后台数据6");
                        Thread.Sleep(2000);
                        // 显示所有的单灯
                        MapRefreshLightInfo(appState.TreeDatas.ListLightInfo);
                        ShowState("更新后台数据7");
                        Thread.Sleep(2000);
                        // 自动排版
                        mapMenuShowAllMarker_Click(null, null);
                        ShowState("更新后台数据8");
                        Thread.Sleep(2000);
                    }));
                }
                if (bwRealData == null)
                {
                    bwRealData = new BackgroundWorker();
                    bwRealData.DoWork += bwRealData_DoWork;
                    bwRealData.WorkerSupportsCancellation = true;
                    bwRealData.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    ShowState(ex.Message);
                }));
            }
        }

        void bwRealData_DoWork(object sender, DoWorkEventArgs e)
        {
            //throw new NotImplementedException();
            while (true)
            {
                if (bwRealData.CancellationPending)
                    break;
                if (!bwLoadData.IsBusy)
                {
                    // 请求最新的数据
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        ShowState("更新后台数据中...");
                    }));
                    Thread.Sleep(1000);
                    List<HostInfo> list = new HostInfoBLL().GetModelByPrjGUID(appState.CurrentUserInfo.ProjectGUID);
                    if (list != null && list.Count > 0)
                    {
                        LightInfoBLL liBLL = new LightInfoBLL();
                        foreach (HostInfo hi in list)
                        {
                            HostInfo h = appState.TreeDatas.ListHostInfo.FirstOrDefault(a => a.GUID == hi.GUID);
                            if (h != null)
                            {
                                h.Online = hi.Online;
                            }
                            // 更新单灯
                            List<LightInfo> listLI = liBLL.GetModelByHost(h);
                            if (listLI != null && listLI.Count > 0)
                            {
                                foreach (LightInfo li in listLI)
                                {
                                    LightInfo l = appState.TreeDatas.ListLightInfo.FirstOrDefault(b => b.GUID == li.GUID);
                                    if (l != null)
                                    {
                                        l.LightStateInfo = li.LightStateInfo;
                                        //Debug.WriteLine(l.LightStateInfo.ToString());
                                    }
                                }
                            }
                        }
                    }
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        ShowState("更新后台数据成功");
                    }));
                }
                Thread.Sleep(10000);
            }
        }

        private void tvHostLightInfo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (tvHostLightInfo.SelectedItem == null)
                return;

            if (tvHostLightInfo.SelectedItem is TreeHostInfo)
            {
                TreeHostInfo thi = (TreeHostInfo)tvHostLightInfo.SelectedItem;
                if (thi != null)
                {
                    map.Position = new PointLatLng((double)thi.HostInfo.Lat, (double)thi.HostInfo.Lng);
                }
                e.Handled = true;
            }

            if (tvHostLightInfo.SelectedItem is TreeLightInfo)
            {
                TreeLightInfo tli = (TreeLightInfo)tvHostLightInfo.SelectedItem;
                if (tli != null)
                {
                    map.Position = new PointLatLng((double)tli.LightInfo.Lat, (double)tli.LightInfo.Lng);
                }
                e.Handled = true;
            }
        }

        static DependencyObject VisualUpwardSearch<T>(DependencyObject source)
        {
            while (source != null && source.GetType() != typeof(T))
                source = VisualTreeHelper.GetParent(source);

            return source;
        }

        private void tvHostLightInfo_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var treeViewItem = VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;
            if (treeViewItem != null)
            {
                treeViewItem.Focus();
            }
        }

        public void LightManageDlgSelectMapPoint()
        {
            // 进去取点模式
            map.Cursor = Cursors.Cross;
            map.ToolTip = "双击要设置的地点";
            ToolTipService.SetIsEnabled(map, true);
            appState.MapState = AppMapState.LightSelectMapPoint;
            map.Focus();
        }

        public void LightManageDlgSelectMapStartPoint()
        {
            // 进去取点模式
            map.Cursor = Cursors.Cross;
            map.ToolTip = "双击要设置的地点";
            ToolTipService.SetIsEnabled(map, true);
            appState.MapState = AppMapState.LightSelectMapStartPoint;
            map.Focus();
        }

        public void LightManageDlgSelectMapEndPoint()
        {
            // 进去取点模式
            map.Cursor = Cursors.Cross;
            map.ToolTip = "双击要设置的地点";
            ToolTipService.SetIsEnabled(map, true);
            appState.MapState = AppMapState.LightSelectMapEndPoint;
            map.Focus();
        }

        public void HostManageDlgSelectMapPoint()
        {
            // 进去取点模式
            map.Cursor = Cursors.Cross;
            map.ToolTip = "双击要设置的地点";
            ToolTipService.SetIsEnabled(map, true);
            appState.MapState = AppMapState.HostSelectMapPoint;
            map.Focus();
        }
        HostInfoEditDlg hostInfoEditDlg;
        private void lbMIHostInfoEdit_Click(object sender, RoutedEventArgs e)
        {
            TreeHostInfo thi = (TreeHostInfo)tvHostLightInfo.SelectedItem;
            if (thi != null)
            {
                hostInfoEditDlg = new HostInfoEditDlg(this, "编辑主机 - " + thi.HostInfo.Name, thi.HostInfo);
                hostInfoEditDlg.Show();
            }
        }

        private void miHostAdd_Click(object sender, RoutedEventArgs e)
        {
            HostInfo hi = new HostInfo();
            hi.ProjectInfoGUID = appState.CurrentUserInfo.ProjectGUID;
            hostInfoEditDlg = new HostInfoEditDlg(this, "增加主机", hi, true);
            hostInfoEditDlg.Show();
        }

        private void lbMILightInfoEdit_Click(object sender, RoutedEventArgs e)
        {
            TreeLightInfo tli = (TreeLightInfo)tvHostLightInfo.SelectedItem;
            if (tli != null)
            {
                lightInfoEditDlg = new LightInfoEditDlg(this, "编辑单灯 - " + tli.LightInfo.Name, tli.LightInfo);
                lightInfoEditDlg.Show();
            }
        }

        private void mapMenuCenter_Click(object sender, RoutedEventArgs e)
        {
            map.Position = new GMap.NET.PointLatLng(appState.MapConfig.CenterLat, appState.MapConfig.CenterLng);
        }

        private void lbMILightGroupInfoEdit_Click(object sender, RoutedEventArgs e)
        {
            TreeLightGroupInfo tlgi = (TreeLightGroupInfo)tvHostLightInfo.SelectedItem;
            LightGroupInfo lgi = new LightGroupInfo();
            lgi.Name = tlgi.LightGroupInfo.Name;
            lgi.ID = tlgi.LightGroupInfo.ID;
            LightGroupInfoEditDlg gie = new LightGroupInfoEditDlg("修改单灯分组 - " + tlgi.LightGroupInfo.Name, lgi);
            if (gie.ShowDialog() == true)
            {
                tlgi.LightGroupInfo.Name = gie.LightGroupInfo.Name;
                tlgi.LightGroupInfo.ID = gie.LightGroupInfo.ID;
                tlgi.LightGroupInfo.UpdateTime = DateTime.Now;
                if (new AdminBLL.LightGroupInfoBLL().Update(tlgi.LightGroupInfo))
                {

                }
                else
                {
                    ModernDialog.ShowMessage("加入数据库失败！", "提示", MessageBoxButton.OK);
                }
            }
        }

        LightInfoAddDlg lightInfoAddDlg = null;
        private void lbMILightInfoAdd_Click(object sender, RoutedEventArgs e)
        {
            TreeHostInfo thi = (TreeHostInfo)tvHostLightInfo.SelectedItem;
            if (thi != null)
            {
                lightInfoAddDlg = new LightInfoAddDlg(this, "批量添加单灯 - " + thi.HostInfo.Name, thi);
                lightInfoAddDlg.Show();
            }
        }

        private void miGroupAdd_Click(object sender, RoutedEventArgs e)
        {
            GroupInfo gi = new GroupInfo();
            GroupInfoEditDlg gie = new GroupInfoEditDlg("增加分组", gi);
            if (gie.ShowDialog() == true)
            {
                gie.GroupInfo.GUID = Guid.NewGuid().ToString();
                gie.GroupInfo.CreateDate = DateTime.Now;
                gie.GroupInfo.UpdateDate = gie.GroupInfo.CreateDate;
                gie.GroupInfo.ProjectGUID = appState.CurrentUserInfo.ProjectGUID;
                if (new AdminBLL.GroupInfoBLL().Add(gie.GroupInfo))
                {
                    appState.TreeDatas.TreeGroupInfos.Add(new TreeGroupInfo() { GroupInfo = gie.GroupInfo });
                }
                else
                {
                    ModernDialog.ShowMessage("加入数据库失败！", "提示", MessageBoxButton.OK);
                }
            }
        }

        private void lbMIGroupInfoEdit_Click(object sender, RoutedEventArgs e)
        {
            TreeGroupInfo tgi = (TreeGroupInfo)tvHostLightInfo.SelectedItem;
            GroupInfo gi = new GroupInfo();
            gi.Name = tgi.GroupInfo.Name;
            gi.ID = tgi.GroupInfo.ID;
            GroupInfoEditDlg gie = new GroupInfoEditDlg("修改区域 - " + tgi.GroupInfo.Name, gi);
            if (gie.ShowDialog() == true)
            {
                tgi.GroupInfo.Name = gie.GroupInfo.Name;
                tgi.GroupInfo.ID = gie.GroupInfo.ID;
                tgi.GroupInfo.UpdateDate = DateTime.Now;
                if (new AdminBLL.GroupInfoBLL().Update(tgi.GroupInfo))
                {

                }
                else
                {
                    ModernDialog.ShowMessage("加入数据库失败！", "提示", MessageBoxButton.OK);
                }
            }
        }

        private void mapMenuShowAllMarker_Click(object sender, RoutedEventArgs e)
        {
            map.ZoomAndCenterMarkers(null);
        }

        private void lbMILightGroupInfoAdd_Click(object sender, RoutedEventArgs e)
        {
            TreeHostInfo thi = (TreeHostInfo)tvHostLightInfo.SelectedItem;
            LightGroupInfo lgi = new LightGroupInfo();
            LightGroupInfoEditDlg lgie = new LightGroupInfoEditDlg("增加单灯分组", lgi);
            if (lgie.ShowDialog() == true)
            {
                lgie.LightGroupInfo.GUID = Guid.NewGuid().ToString();
                lgie.LightGroupInfo.CreateTime = DateTime.Now;
                lgie.LightGroupInfo.UpdateTime = lgie.LightGroupInfo.CreateTime;
                lgie.LightGroupInfo.HostGUID = thi.HostInfo.GUID;
                if (new AdminBLL.LightGroupInfoBLL().Add(lgie.LightGroupInfo))
                {
                    thi.TreeLightGroupInfos.Add(new TreeLightGroupInfo() { LightGroupInfo = lgie.LightGroupInfo });
                }
                else
                {
                    ModernDialog.ShowMessage("加入数据库失败！", "提示", MessageBoxButton.OK);
                }
            }
        }

        private void lbMIHostInfoTimeSync_Click(object sender, RoutedEventArgs e)
        {
            TreeHostInfo thi = (TreeHostInfo)tvHostLightInfo.SelectedItem;
            int id;
            if (!string.IsNullOrEmpty(thi.HostInfo.Addr) && int.TryParse(thi.HostInfo.Addr, out id))
            {
                //ProtocolManage.LightGPRSProtocol.TimeSyncCMD(id);
                CMDSend cmdSend = new CMDSend();
                cmdSend.GUID = Guid.NewGuid().ToString();
                cmdSend.Addr = thi.HostInfo.Addr;
                cmdSend.Content = HexHelper.ByteArrayToHexString(ProtocolManage.LightGPRSProtocol.TimeSyncCMD(id));
                cmdSend.ContentType = (int)CMDType.TimeSyncCMD;
                cmdSend.CreateDate = DateTime.Now;
                cmdSend.ID = thi.HostInfo.IDID;
                cmdSend.UpdateDate = cmdSend.CreateDate;
                cmdSend.State = (int)CMDState.NO;
                SyncDataDlg sdd = new SyncDataDlg("同步时间", thi.HostInfo.Name, cmdSend);
                sdd.ShowDialog();
            }
        }

        private void lbMIHostInfoAddrSync_Click(object sender, RoutedEventArgs e)
        {
            TreeHostInfo thi = (TreeHostInfo)tvHostLightInfo.SelectedItem;
            int id;
            if (!string.IsNullOrEmpty(thi.HostInfo.Addr) && int.TryParse(thi.HostInfo.Addr, out id))
            {
                CMDSend cmdSend = new CMDSend();
                cmdSend.GUID = Guid.NewGuid().ToString();
                cmdSend.Addr = thi.HostInfo.Addr;
                cmdSend.Content = HexHelper.ByteArrayToHexString(ProtocolManage.LightGPRSProtocol.AddrSyncCMD(id));
                cmdSend.ContentType = (int)CMDType.InterSetCMD;
                cmdSend.CreateDate = DateTime.Now;
                cmdSend.ID = thi.HostInfo.IDID;
                cmdSend.UpdateDate = cmdSend.CreateDate;
                cmdSend.State = (int)CMDState.NO;
                SyncDataDlg sdd = new SyncDataDlg("同步地址", thi.HostInfo.Name, cmdSend);
                sdd.ShowDialog();
            }
        }

        private void lbMIHostInfoInterSync_Click(object sender, RoutedEventArgs e)
        {
            TreeHostInfo thi = (TreeHostInfo)tvHostLightInfo.SelectedItem;
            int id;
            if (!string.IsNullOrEmpty(thi.HostInfo.Addr) && int.TryParse(thi.HostInfo.Addr, out id))
            {
                InterSettingDlg sdd = new InterSettingDlg("同步区间 - " + thi.HostInfo.Name, thi.HostInfo);
                sdd.ShowDialog();
            }
        }

        private void lbMIHostInfoGetInterSync_Click(object sender, RoutedEventArgs e)
        {
            TreeHostInfo thi = (TreeHostInfo)tvHostLightInfo.SelectedItem;
            int id;
            if (!string.IsNullOrEmpty(thi.HostInfo.Addr) && int.TryParse(thi.HostInfo.Addr, out id))
            {
                LightGetIntervalDlg sdd = new LightGetIntervalDlg("设置扫描间隔 - " + thi.HostInfo.Name, thi.HostInfo);
                sdd.ShowDialog();
            }
        }

        private void mapMenuShowAllLightInfo_Click(object sender, RoutedEventArgs e)
        {
            if (bwLoadData.IsBusy)
                return;
            bwLoadData.RunWorkerAsync();
        }

        private void miThemeSetting_Click(object sender, RoutedEventArgs e)
        {
            Pages.Setting.ThemeDlg td = new Pages.Setting.ThemeDlg();
            td.ShowDialog();
        }

        private void miDataClear_Click(object sender, RoutedEventArgs e)
        {
            DataClearDlg dcd = new DataClearDlg();
            dcd.ShowDialog();
        }

        private void LbMIHostInfoRecruitAll_Click(object sender, RoutedEventArgs e)
        {
            TreeHostInfo thi = (TreeHostInfo)tvHostLightInfo.SelectedItem;
            int id;
            if (!string.IsNullOrEmpty(thi.HostInfo.Addr) && int.TryParse(thi.HostInfo.Addr, out id))
            {
                RecruitAllDlg sdd = new RecruitAllDlg("召测全部 - " + thi.HostInfo.Name, thi.HostInfo);
                sdd.ShowDialog();
            }
        }
    }
}
