using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LumluxSY.Areas.Lamp.Models
{
    public class MainViewModel
    {
        /// <summary>
        /// 主机相关信息
        /// </summary>
        public List<HostInfoVM> HostInfos = new List<HostInfoVM>();

        /// <summary>
        /// 地图中心的lat
        /// </summary>
        public string MapCenterLat = "0";

        /// <summary>
        /// 地图中心的lng
        /// </summary>
        public string MapCenterLng = "0";
        public string maxLat;
        public string maxlng;
        
    }
}