using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LumluxSY.Areas.Lamp.Models
{
    public class HostGroupViewModel
    {
       public List<GroupInfoeVM>      GroupInfoes       = new List<GroupInfoeVM>();      //组
       public List<HostInfoeVM>       HostInfoes        = new List<HostInfoeVM>();       //主机
    }

    public class LightViewModel
    {
        public List<LightInfoeVM> LightInfoes = new List<LightInfoeVM>();      //单灯
    }
    public class LightGroupViewModel
    {
        public List<LightGroupInfoeVM> LightGroupInfoes = new List<LightGroupInfoeVM>(); //单灯组
    }
    public class GroupInfoeVM
    {
        //组相关GUID
        public string GUID = Guid.Empty.ToString();

        //组相关名称
        public string Name = "";
    }
    public class HostInfoeVM
    {
        //主机相关GUID
        public string GUID = Guid.Empty.ToString();

        //主机相关组GUID
        public string GroupGUID = Guid.Empty.ToString();

        //主机相关名称
        public string Name = "";
    }
    public class LightInfoeVM
    {
        //单灯相关GUID
        public string GUID = Guid.Empty.ToString();

        //单灯相关名称
        public string Name = "";

        ////主机相关GUID
        //public string HostInfoGUID = Guid.Empty.ToString();

    }
    public class LightGroupInfoeVM
    {
        //单灯组相关GUID
        public string GUID = Guid.Empty.ToString();

        //单灯组相关名称
        public string Name = "";

        ////主机相关GUID
        //public string HostInfoGUID = Guid.Empty.ToString();
    }
}