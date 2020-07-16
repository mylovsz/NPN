using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolManage
{
    public class SYProtocol
    {
        /// <summary>
        /// 返回真实的电压
        /// </summary>
        /// <param name="voltageHex"></param>
        /// <returns></returns>
        public static double ConvertVoltage(int voltageHex)
        {
            //return 1.0 * voltageHex / 0x7FFF * 176.78 / 150 * 300;
            double d = ((voltageHex * 5000) >> 16) / 10.0;
            if (d < 50)
                d = 0;
            return d;
        }

        /// <summary>
        /// 返回真实的电流值，此值需要再乘以变比才是最终的数据
        /// </summary>
        /// <param name="currentHex"></param>
        /// <returns></returns>
        public static double ConvertCurrent(int currentHex)
        {
            //return 1.0 * currentHex / 0x7FFF * 176.78 / 150 * 5;
            double d = ((currentHex * 83) >> 16) / 10.0;
            return d;
        }

        /// <summary>
        /// 返回真实的功率，此值需要再乘以变比才是最终的数据
        /// </summary>
        /// <param name="powerHex"></param>
        /// <returns></returns>
        public static double ConvertPower(int powerHex)
        {
            //return 1.0 * powerHex / 0x7FFF * 300 * 5;
            return (((powerHex & 0x7fff) * 405) >> 16) / 100.0;
        }

        /// <summary>
        /// 返回0x68的协议
        /// </summary>
        /// <param name="type"></param>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static byte[] GetStringFor0x68(byte type, string strDatas)
        {
            byte[] datas = Tool.DataConverter.HexStringToByteArray(strDatas, true);
            return GetStringFor0x68(type, datas);
        }

        /// <summary>
        /// 返回0x68协议
        /// </summary>
        /// <param name="type"></param>
        /// <param name="strDatas"></param>
        /// <returns></returns>
        public static byte[] GetStringFor0x68(byte type, byte[] strDatas)
        {
            byte[] datas = strDatas;
            int length = 0;
            if (datas != null)
                length = datas.Length + 1;
            else
                datas = new byte[0];
            byte[] result = new byte[5] { 0x68, 0x00, 0x00, 0x00, 0x68 };
            result[1] = type;
            result[2] = (byte)((length >> 8) & 0xFF);
            result[3] = (byte)(length & 0xFF);
            result = result.Concat(datas).Concat(new byte[1] { 0x16 }).ToArray();
            return (result);
        }

        /// <summary>
        /// 封装三遥的发送命令，返回值为16进制字符串
        /// </summary>
        /// <param name="hi">发送的对象</param>
        /// <param name="type">发送的命令类型</param>
        /// <param name="content">发送的内容</param>
        /// <returns></returns>
        //public static string Package(HostInfo hi, CMDType type, object content)
        //{
        //    string result = "";
        //    switch(hi.Hardware.Version)
        //    {
        //        case "1":
        //            switch (type)
        //            {
        //                case CMDType.SyncDateTime:
        //                    {
        //                        int netAddr = int.Parse(hi.ID.Addr);
        //                        DateTime dt = DateTime.Now;
        //                        byte[] bData = new byte[5];
        //                        bData[0] = (byte)(netAddr >> 8);
        //                        bData[1] = (byte)netAddr;
        //                        bData[2] = (byte)dt.Hour;
        //                        bData[3] = (byte)dt.Minute;
        //                        bData[4] = (byte)dt.Second;
        //                        return Tool.DataConverter.ByteArrayToHexString(GetStringFor0x68(0x03, bData));
        //                    }
        //                    break;
        //                case CMDType.ManualContrl:
        //                    {
        //                        ManualCtrlArg mca = (ManualCtrlArg)content;
        //                        int netAddr = int.Parse(hi.ID.Addr);
        //                        byte[] bData = new byte[8];
        //                        bData[0] = (byte)(netAddr >> 8);
        //                        bData[1] = (byte)netAddr;
        //                        bData[2] = 0xF8;
        //                        bData[3] = (byte)mca.Node;
        //                        bData[4] = (byte)mca.Type;
        //                        bData[5] = mca.Ctrl;
        //                        bData[6] = mca.CtrlEx;
        //                        bData[7] = mca.Power;
        //                        return Tool.DataConverter.ByteArrayToHexString(GetStringFor0x68(0x10, bData));
        //                    }
        //                case CMDType.GetMeasureInfo:
        //                    {
        //                        int netAddr = int.Parse(hi.ID.Addr);
        //                        byte[] bData = new byte[2];
        //                        bData[0] = (byte)(netAddr >> 8);
        //                        bData[1] = (byte)netAddr;
        //                        return Tool.DataConverter.ByteArrayToHexString(GetStringFor0x68(0x95, bData));
        //                    }
        //                case CMDType.SyncAddr:
        //                    {
        //                        int addr = int.Parse(content.ToString());
        //                        byte[] bData = new byte[4];
        //                        bData[0] = 0;
        //                        bData[1] = 0;
        //                        bData[2] = (byte)(addr >> 8);
        //                        bData[3] = (byte)(addr);
        //                        return Tool.DataConverter.ByteArrayToHexString(GetStringFor0x68(0x81, bData));
        //                    }
        //                default:
        //                    break;
        //            }
        //            break;
        //        default:
        //            break;
        //    }
            
        //    return result;
        //}
    }
}
