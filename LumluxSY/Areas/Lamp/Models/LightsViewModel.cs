using LumluxSY.Areas.Lamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LumluxSY.Areas.Lamp.Models
{

    public class LightInfoVM
    {
        /// <summary>
        /// 单灯相关的GUID
        /// </summary>
        public string GUID = Guid.Empty.ToString();

        /// <summary>
        /// 单灯名称
        /// </summary>
        public string Name = "";
        /// <summary>
        /// 单灯备注
        /// </summary>
        public string sDesc;
        /// <summary>
        /// 是否报警
        /// </summary>
        public int Alarm = 0;

        public string sImageUrl = "2.png";
        /// <summary>
        /// 更新的时间
        /// </summary>
        public DateTime UpdateTime;
        public string sUpdateTime;
        public int iFualt = 0;
        /// <summary>
        /// 经度
        /// </summary>
        public string Lat;
        /// <summary>
        /// 纬度
        /// </summary>
        public string Lng;
        /// <summary>
        /// 电压
        /// </summary>
        public string Voltage;
        /// <summary>
        /// 电流
        /// </summary>
        public string Current;
        /// <summary>
        /// 太阳能电压
        /// </summary>
        public string SolarEnergyVoltage;
        /// <summary>
        /// 温度
        /// </summary>
        public string sTemperature;
        /// <summary>
        /// 电压百分比
        /// </summary>
        public string sVoltagePercent;
        /// <summary>
        /// 功率
        /// </summary>
        public string Power;
        /// <summary>
        /// 故障
        /// </summary>
        public string Faul;
        /// <summary>
        /// 单灯的状态，
        /// </summary>
        public string State
        {
            
            get
            {
                if (Alarm == 0)
                {
                    return "light_0001";
                }
                if (Alarm == 0)
                {
                    return "2";
                }
                if (Alarm == 0)
                {
                    return "2";
                }
                return "10";
            }

        }
    }



    public class LightsViewModel
    {
        /// <summary>
        /// 主机相关信息
        /// </summary>
        public List<LightInfoVM> LightInfos = new List<LightInfoVM>();
        public string maxLat;
        public string maxlng;

    }
}