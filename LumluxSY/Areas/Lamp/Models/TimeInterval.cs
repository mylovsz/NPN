using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LumluxSY.Areas.Lamp.Models
{
    public class TimeInterval
    {
        public TimeInterval()
        {
            tct = new LumluxSSYDB.Model.tTimeCtrlInfoes();
        }
        public LumluxSSYDB.Model.tTimeCtrlInfoes tct;
        public string setTime;
        public string ExecutiveAction="";
        public string IsEnable;
        /// <summary>
        /// 三遥类型
        /// </summary>
        public int iHardware_Type;
        /// <summary>
        /// 执行类型
        /// </summary>
        public string iType;
        /// <summary>
        /// 时控对应的主机
        /// </summary>
        public string sHostName;
        /// <summary>
        /// 执行动作
        /// </summary>
        public string sExecutiveAction;
        public string sRelayState;//回路状态
        public string sRelayInfo_GUID;//回路的GUID
        /// <summary>
        /// 群组开光状态
        /// </summary>
        public string sLightGroupState; 
        /// <summary>
        /// 群组调光状态
        /// </summary>
        public string sLightGroupMState; 
        /// <summary>
        /// 调光值
        /// </summary>
        public string sLightGroupMVaule;
        /// <summary>
        /// 群组GUID
        /// </summary>
        public string sLightGroupGUID;
    }
}