using AdminModel;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.AppData
{
    public class MapData
    {
        public Dictionary<string, GMapMarker> DicHostInfoMarker = new Dictionary<string, GMapMarker>();
        public Dictionary<string, GMapMarker> DicLightInfoMarker = new Dictionary<string, GMapMarker>();
    }

    public enum AppMapState
    {
        Normal,
        HostSelectMapPoint,
        LightSelectMapPoint,
        LightSelectMapStartPoint,
        LightSelectMapEndPoint
    }

    public enum WorkModel
    {
        New,
        Edit
    }

    public enum ShowModel
    {
        GIS,
        List
    }

    /// <summary>
    /// 服务器参数
    /// </summary>
    public class AppServerConfig
    {
        public string IP;
        public ushort Port;
    }

    /// <summary>
    /// 地图GIS参数
    /// </summary>
    public class AppMapConfig
    {
        /// <summary>
        /// 时控采用的lng
        /// </summary>
        public double SunTimeCtrlLng;

        /// <summary>
        /// 时控采用的lat
        /// </summary>
        public double SunTimeCtrlLat;

        /// <summary>
        /// 地图中心点lng
        /// </summary>
        public double CenterLng;

        /// <summary>
        /// 地图中心点lat
        /// </summary>
        public double CenterLat;
    }

    public class AppSunTimeConfig
    {
        /// <summary>
        /// 日出时间
        /// </summary>
        public DateTime NowSunRise;
        /// <summary>
        /// 日落时间
        /// </summary>
        public DateTime NowSunSet;
    }

    /// <summary>
    /// 系统参数
    /// </summary>
    public class AppState
    {
        public AppState()
        {
            ServerConfig = new AppServerConfig();
            MapConfig = new AppMapConfig();
            SunTimeConfig = new AppSunTimeConfig();
        }

        /// <summary>
        /// 项目的配置信息
        /// </summary>
        public List<ProjectSet> ProjectSets;

        /// <summary>
        /// 地图状态
        /// </summary>
        public AppMapState MapState
        {
            get;
            set;
        }

        /// <summary>
        /// 服务器参数
        /// </summary>
        public AppServerConfig ServerConfig;

        /// <summary>
        /// 地图GIS参数
        /// </summary>
        public AppMapConfig MapConfig;

        /// <summary>
        /// 经纬度（日出日落）参数
        /// </summary>
        public AppSunTimeConfig SunTimeConfig;

        /// <summary>
        /// 当前登陆用户
        /// </summary>
        public UserInfo CurrentUserInfo;

        /// <summary>
        /// 超时时间
        /// </summary>
        public int Timeout;

        /// <summary>
        /// 右侧树形菜单数据
        /// </summary>
        public TreeData TreeDatas = new TreeData();

        /// <summary>
        /// 地图数据
        /// </summary>
        public MapData MapDatas = new MapData();
    }
}
