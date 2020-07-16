using ProtocolManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model = LumluxSSYDB.Model;

namespace AdminModel
{
    public enum LightAlarmEnum
    {
        Alarm,
        Normal
    }

    public enum LightFaultEnum
    {
        /// <summary>
        /// 正常关
        /// </summary>
        NormalClose = 0x00,

        /// <summary>
        /// 关灯有电流
        /// </summary>
        CloseExtistCurrent = 0x01,

        /// <summary>
        /// 通讯异常
        /// </summary>
        CommError = 0x02,

        /// <summary>
        /// 正常开
        /// </summary>
        NormalOpen = 0x08,

        /// <summary>
        /// 灯故障
        /// </summary>
        LampError = 0x09,

        /// <summary>
        /// 开灯无电流
        /// </summary>
        OpenSmallPower = 0x0A,

        /// <summary>
        /// 镇流器错误
        /// </summary>
        BallastError = 0x0B,

        /// <summary>
        /// 初始值
        /// </summary>
        None = 0xFF,
    }

    public class LightInfo : Database
    {
        public LightInfo(Model.tLightInfoes hi, string roadID)
        {
            tLightInfo = hi;
            RoadID = roadID;
        }

        public LightInfo(string roadID)
        {
            tLightInfo = new Model.tLightInfoes();
            RoadID = roadID;
        }

        public string RoadID
        {
            get;
            set;
        }

        /// <summary>
        /// 关联的数据库数据
        /// </summary>
        public Model.tLightInfoes tLightInfo;

        public Model.tLightInfoes T
        {
            get
            {
                return tLightInfo;
            }
        }

        public DateTime RealAlarmTime
        {
            get
            {
                if (tLightInfo.iRealTimeAlarm_CreateDateTime == null)
                    return new DateTime(1, 1, 1);
                return (DateTime)tLightInfo.iRealTimeAlarm_CreateDateTime;
            }
            set
            {
                tLightInfo.iRealTimeAlarm_CreateDateTime = value;
            }
        }

        public string Version
        {
            get
            {
                if (string.IsNullOrEmpty(tLightInfo.sHardware_Version))
                    return "";
                return tLightInfo.sHardware_Version;
            }
            set
            {
                tLightInfo.sHardware_Version = value;
            }
        }

        public int Type
        {
            get
            {
                if (tLightInfo.iHardware_Type == null)
                    return 0;
                return (int)tLightInfo.iHardware_Type;
            }
            set
            {
                tLightInfo.iHardware_Type = value;
            }
        }

        public int Enable
        {
            get
            {
                if (tLightInfo.iEnable == null)
                    return 0;
                return (int)tLightInfo.iEnable;
            }
            set
            {
                tLightInfo.iEnable = value;
            }
        }

        public DateTime CreateTime
        {
            get
            {
                if (tLightInfo.dCreateTime == null)
                    return new DateTime(1, 1, 1);
                return (DateTime)tLightInfo.dCreateTime;
            }
            set
            {
                tLightInfo.dCreateTime = value;
            }
        }

        public DateTime UpdateTime
        {
            get
            {
                if (tLightInfo.dUpdateTime == null)
                    return new DateTime(1, 1, 1);
                return (DateTime)tLightInfo.dUpdateTime;
            }
            set
            {
                tLightInfo.dUpdateTime = value;
            }
        }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark
        {
            get
            {
                if (string.IsNullOrEmpty(tLightInfo.sRemark))
                    return "";
                return tLightInfo.sRemark;
            }
            set
            {
                tLightInfo.sRemark = value;
            }
        }

        /// <summary>
        /// 物理地址
        /// </summary>
        public string PhyID
        {
            get
            {
                if (string.IsNullOrEmpty(tLightInfo.sLightPhyID))
                    return "";
                return tLightInfo.sLightPhyID;
            }
            set
            {
                tLightInfo.sLightPhyID = value;
            }
        }

        /// <summary>
        /// 逻辑地址
        /// </summary>
        public string ID
        {
            get
            {
                if (string.IsNullOrEmpty(tLightInfo.sLightID))
                    return "";
                return tLightInfo.sLightID;
            }
            set
            {
                tLightInfo.sLightID = value;
            }
        }

        /// <summary>
        /// 关联的主机GUID
        /// </summary>
        public string HostGUID
        {
            get
            {
                if (string.IsNullOrEmpty(tLightInfo.sHostInfoGUID))
                    return "";
                return tLightInfo.sHostInfoGUID;
            }
            set
            {
                tLightInfo.sHostInfoGUID = value;
            }
        }

        public string GUID
        {
            get
            {
                if (string.IsNullOrEmpty(tLightInfo.sGUID))
                    return "";
                return tLightInfo.sGUID;
            }
            set
            {
                tLightInfo.sGUID = value;
            }
        }

        public string Name
        {
            get
            {
                return tLightInfo.sName;
            }
            set
            {
                if (tLightInfo.sName != value)
                {
                    tLightInfo.sName = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }

        public double Lat
        {
            get
            {
                if (tLightInfo.fLat == null)
                    return 0;
                return (double)tLightInfo.fLat;
            }
            set
            {
                tLightInfo.fLat = (decimal)value;
            }
        }

        public double Lng
        {
            get
            {
                if (tLightInfo.fLng == null) 
                    return 0;
                return (double)tLightInfo.fLng;
            }
            set
            {
                tLightInfo.fLng = (decimal)value;
            }
        }

        public LightFaultEnum RealTimeFault
        {
            get
            {
                if (tLightInfo.iRealTimeAlarm_Fault == null)
                    return LightFaultEnum.None;
                return (LightFaultEnum)tLightInfo.iRealTimeAlarm_Fault;
            }
            set
            {
                tLightInfo.iRealTimeAlarm_Fault = (int)value;
            }
        }
        LightStateInfo lightStateInfo;
        public LightStateInfo LightStateInfo
        {
            get
            {
                return lightStateInfo;
            }
            set
            {
                lightStateInfo = value;
            }
        }

        public override string ToString()
        {
            string content = "";
            switch (((LightType)this.Type))
            {
                case LightType.NewTYN:
                    if (lightStateInfo != null)
                        content = "\r\n" + lightStateInfo.ToString();
                    content = "名称 : " + Name + "\r\n型号 : " + Version + "\r\n所属路段 : " + RoadID + "\r\n状态：" + (Enable == 0 ? "停用" : "启用") + content;
                    break;
                case LightType.Normal:
                    content = "名称 : " + Name + "\r\n型号 : " + Version + "\r\n所属路段 : " + RoadID + "\r\n状态：" + (Enable == 0 ? "停用" : "启用") + content;
                    break;
                case LightType.OldTYN:
                    if (lightStateInfo != null)
                        content = "\r\n" + lightStateInfo.ToOldString();
                    content = "名称 : " + Name + "\r\n型号 : " + Version + "\r\n所属路段 : " + RoadID + "\r\n状态：" + (Enable == 0 ? "停用" : "启用") + content;
                    break;
                default:
                    content = "名称 : " + Name + "\r\n型号 : " + Version + "\r\n所属路段 : " + RoadID + "\r\n状态：" + (Enable == 0 ? "停用" : "启用") + content;
                    break;
            }
            return content;
        }
    }
}
