using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model = LumluxSSYDB.Model;

namespace AdminModel
{
    public class LightStateInfo
    {
        public static List<ProjectSet> ProjectSets;

        Model.tLightStateInfoes tLSI;

        public LightStateInfo(Model.tLightStateInfoes t)
        {
            tLSI = t;
        }

        public string GUID
        {
            get
            {
                return tLSI.sGUID;
            }
        }

        public double Voltage
        {
            get
            {
                if (tLSI.fVoltage == null)
                    return 0;
                return (double)tLSI.fVoltage;
            }
        }

        public double Current
        {
            get
            {
                if (tLSI.fCurrent == null)
                    return 0;
                return (double)tLSI.fCurrent;
            }
        }

        public double Power
        {
            get
            {
                if(tLSI.fPower==null)
                {
                    return 0;
                }
                return (double)tLSI.fPower;
            }
        }

        public int Fault
        {
            get
            {
                if(tLSI.iFault == null)
                {
                    return 255;
                }
                return (int)tLSI.iFault;
            }
        }

        public string FaultTitle
        {
            get
            {
                string where = "Light_Image_" + Fault.ToString("D04");
                if (ProjectSets == null) return "无信息";
                ProjectSet ps = ProjectSets.FirstOrDefault(a => a.Key == where);
                if(ps != null)
                {
                    return ps.Remark;
                }
                return "无信息";
            }
        }

        public double Temper
        {
            get
            {
                double d;
                try
                {
                    if (double.TryParse(tLSI.sSpareField1, out d))
                        return d;
                    return 0;
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 太阳能电压
        /// </summary>
        public double Field1
        {
            get
            {
                double d;
                try
                {
                    if (double.TryParse(tLSI.sSpareField1, out d))
                        return d;
                    return 0;
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 超容电压
        /// </summary>
        public double Field2
        {
            get
            {
                double d;
                try
                {
                    if (double.TryParse(tLSI.sSpareField2, out d))
                        return d;
                    return 0;
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 超容电流
        /// </summary>
        public double Field3
        {
            get
            {
                double d;
                try
                {
                    if (double.TryParse(tLSI.sSpareField3, out d))
                        return d;
                    return 0;
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 超容功率
        /// </summary>
        public double Field4
        {
            get
            {
                double d;
                try
                {
                    if (double.TryParse(tLSI.sSpareField4, out d))
                        return d;
                    return 0;
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 温度
        /// </summary>
        public double Field5
        {
            get
            {
                double d;
                try
                {
                    if (double.TryParse(tLSI.sSpareField5, out d))
                        return d;
                    return 0;
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 超容余量
        /// </summary>
        public double Field6
        {
            get
            {
                double d;
                try
                {
                    if (double.TryParse(tLSI.sSpareField6, out d))
                        return d;
                    return 0;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public DateTime CreateTime
        {
            get
            {
                if (tLSI.dCreateDate == null)
                    return new DateTime(1, 1, 1);
                return (DateTime)tLSI.dCreateDate;
            }
        }

        public string ToOldString()
        {
            string content = "当前状态 : " + FaultTitle + "\r\n太阳能电压 : " + Field1.ToString("0.00") + " V\r\n超容电压 : " + Field2.ToString("0.00") + " V\r\n超容电流 : " + Field3.ToString("0.00") + " A\r\n功率 : " + Field4.ToString("0.00") + " W\r\n温度 : " + Field5.ToString("0.00") + " ℃";
            content += "\r\n更新时间 : " + CreateTime;

            return content;
        }

        public override string ToString()
        {
            string content = "当前状态 : " + FaultTitle + "\r\n太阳能电压 : " + Field1.ToString("0.00") + " V\r\n超容电压 : " + Field2.ToString("0.00") + " V\r\n超容电流 : " + Field3.ToString("0.00") + " A\r\n功率 : " + Field4.ToString("0.00") + " W\r\n温度 : " + Field5.ToString("0.00") + " ℃";
            if (Field6 > 100)
            {
                content += "\r\n更新时间 : " + CreateTime;
            }
            else
            {
                content += "\r\n超容余量 : " + Field6.ToString("0.00") + " %\r\n更新时间 : " + CreateTime;
            }
            return content;
        }
    }
}
