using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LumluxSY.Areas.Lamp.Models
{
    public class AlarmInfo
    {
        public AlarmInfo()
        {
            li = new LumluxSSYDB.Model.tLightInfoes();
            ls = new LumluxSSYDB.Model.tLightStateInfoes();
            thost = new LumluxSSYDB.Model.tHostInfo();
        }
        public LumluxSSYDB.Model.tLightInfoes li;
        public LumluxSSYDB.Model.tLightStateInfoes ls;
        public LumluxSSYDB.Model.tHostInfo thost;
        public int iNum;//行号
        public int iCount;//总记录
        public int iPage;//总页数
        public string sUpdateTime;//更新时时间
        public string Fault;
        //{
        //    get
        //    {
        //        try
        //        {
        //            byte[] b = Tools.DataConverter.HexStringToByteArray(RDI.RDIFault.Split(';')[0]);
        //            string r = "";
        //            for (int i = 0; i < b.Length; i++)
        //            {
        //                if (b[i] == 0)
        //                    continue;
        //                switch (i)
        //                {
        //                    case 0:
        //                        r += "[环境温度";
        //                        break;
        //                    case 1:
        //                        r += "[环境湿度";
        //                        break;
        //                    case 2:
        //                        r += "[二氧化碳";
        //                        break;
        //                    case 3:
        //                        r += "[光合有效";
        //                        break;
        //                    case 4:
        //                        r += "[土壤湿度";
        //                        break;
        //                    case 5:
        //                        r += "[土壤温度";
        //                        break;
        //                    case 6:
        //                        r += "[水表";
        //                        break;
        //                    case 7:
        //                        r += "[电表";
        //                        break;
        //                    case 8:
        //                        r += "[土壤PH";
        //                        break;
        //                    case 9:
        //                        r += "[EC";
        //                        break;
        //                    case 10:
        //                        r += "[继电器";
        //                        break;
        //                    default:
        //                        return r;
        //                }
        //                switch (b[i])
        //                {
        //                    case 1:
        //                        r += "离线] ";
        //                        break;
        //                    case 2:
        //                        r += "超上限] ";
        //                        break;
        //                    case 3:
        //                        r += "越下限] ";
        //                        break;
        //                    case 4:
        //                        r += "异常] ";
        //                        break;
        //                    default:
        //                        r += "数据异常] ";
        //                        break;
        //                }
        //            }
        //            return r;

        //        }
        //        catch
        //        {
        //            return "";
        //        }
        //    }
        //}
    }
}