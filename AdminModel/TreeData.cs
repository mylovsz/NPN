using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AdminModel
{
    public class TreeLightInfo
    {
        public LightInfo LightInfo { get; set; }

        public override string ToString()
        {
            return LightInfo.ToString();
            //return "名称 : " + LightInfo.Name + "\r\n地址 : " + LightInfo.ID + "\r\n状态 : " + LightInfo.RealTimeFault + "\r\n更新时间 : " + LightInfo.RealAlarmTime;
        }
    }

    public class TreeLightGroupInfo
    {
        public TreeLightGroupInfo()
        {
            TreeLightInfos = new ObservableCollection<TreeLightInfo>();
        }

        public ObservableCollection<TreeLightInfo> TreeLightInfos { get; set; }

        public LightGroupInfo LightGroupInfo { get; set; }

        public override string ToString()
        {
            return LightGroupInfo.Name;
        }
    }

    public class TreeHostInfo
    {
        public TreeHostInfo()
        {
            TreeLightGroupInfos = new ObservableCollection<TreeLightGroupInfo>();
        }

        public void AddAllGroup()
        {
            TreeLightGroupInfos.Add(new TreeLightGroupInfo(){ LightGroupInfo = new LightGroupInfo(true)});
        }

        public ObservableCollection<TreeLightGroupInfo> TreeLightGroupInfos { get; set; }

        public HostInfo HostInfo { get; set; }

        public override string ToString()
        {
            return "名称 : " + HostInfo.Name + "\r\n地址 : " + HostInfo.IDID + "\r\n状态 : " + (HostInfo.Online == 0 ? "离线" : "在线" + (HostInfo.Enable == false ? "  停用" : "  启用"));
        }
    }

    public class TreeGroupInfo
    {
        public TreeGroupInfo()
        {
            TreeHostInfos = new ObservableCollection<TreeHostInfo>();
        }

        public ObservableCollection<TreeHostInfo> TreeHostInfos { get; set; }

        public GroupInfo GroupInfo { get; set; }

        public override string ToString()
        {
            return GroupInfo.Name;
        }
    }

    public class TreeData
    {
        public ObservableCollection<TreeGroupInfo> TreeGroupInfos = new ObservableCollection<TreeGroupInfo>();

        public List<HostInfo> ListHostInfo = new List<HostInfo>();

        public List<LightInfo> ListLightInfo = new List<LightInfo>();
    }
}
