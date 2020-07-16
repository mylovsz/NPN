using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LumluxSY.Areas.Lamp.Models
{
    public class HostInfoVM
    {
        /// <summary>
        /// 主机相关的GUID
        /// </summary>
        public string GUID = Guid.Empty.ToString();
        /// <summary>
        /// 单灯总个数
        /// </summary>
        public int hostByLightCount = 0;
        /// <summary>
        /// 报警的单灯个数
        /// </summary>
        public int hostByAlarmLightCount = 0;
        /// <summary>
        /// 主机名称
        /// </summary>
        public string Name = "";
        /// <summary>
        /// 主机别名
        /// </summary>
        public string AsName;
        /// <summary>
        /// 主机的地址
        /// </summary>
        public string ID = "";
        /// <summary>
        /// 主机状态显示
        /// </summary>
        public string strHostState = "";
        /// <summary>
        /// 是否在线
        /// </summary>
        public int Online = 0;
        
        /// <summary>
        /// 是否报警
        /// </summary>
        public int Alarm = 0;

        /// <summary>
        /// 所属组
        /// </summary>
        public string GroupName = "春秋路";
        /// <summary>
        /// 分组全名
        /// </summary>
        public string AllGroupName;
        /// <summary>
        /// 主机图片
        /// </summary>
        public string sImageUrl;
        /// <summary>
        /// 更新的时间
        /// </summary>
        public DateTime UpdateTime;
        public string sUpdateTime;
        public string Lat;
        public string Lng;
        /// <summary>
        /// 区分三要类型 0：小三遥，1：大三遥
        /// </summary>
        public int iHardware_Type;
        /// <summary>
        /// 主机的状态，根据主机的标志来进行返回
        /// </summary>
        public string State
        {
            get
            {
                if (Online == 1)
                {
                    return "online";
                }
                return "unonline";
            }
        }

        public string AlarmState
        {
            get
            {
                if (Alarm == 1)
                {
                    return "alarm";
                }
                return "online";
            }
        }
    }
}