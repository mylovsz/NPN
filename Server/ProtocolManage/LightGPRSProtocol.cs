using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolManage
{
    public class LightGPRSProtocol
    {
        static byte order433M = 0;

        /// <summary>
        /// 获取针对433M的协议byte数组
        /// </summary>
        /// <param name="contentTypeH">高命令类型</param>
        /// <param name="contentTypeL">低命令类型</param>
        /// <param name="content">实际数据</param>
        /// <returns></returns>
        public static byte[] GetBytesFor433M(byte contentTypeH, byte contentTypeL, byte[] content)
        {
            if (content == null)
                return null;
            byte length = (byte)(content.Length);
            byte[] bTemp = new byte[length + 7];
            bTemp[0] = 0x68;
            bTemp[1] = contentTypeH;
            bTemp[2] = contentTypeL;
            bTemp[3] = (byte)(length + 2);
            bTemp[4] = order433M++;
            int i = 5;
            if (length > 0)
            {
                Array.Copy(content, 0, bTemp, i, length);
                i += length;
            }
            byte xor = 0;
            for (int j = 0; j < bTemp.Length - 2; j++)
                xor ^= bTemp[j];
            bTemp[i++] = xor;
            bTemp[i] = 0x16;
            return bTemp;
        }

        /// <summary>
        /// 返回0x68的协议
        /// </summary>
        /// <param name="type"></param>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static byte[] GetStringFor0x68(byte type, byte[] bDatas)
        {
            byte[] datas = bDatas;
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
        /// 返回0x68的协议
        /// </summary>
        /// <param name="type"></param>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static byte[] GetStringFor0x68(byte type, string strDatas)
        {
            byte[] datas = Tool.DataConverter.HexStringToByteArray(strDatas, true);
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
        /// 同步时间命令
        /// </summary>
        /// <param name="hostAddr">对应的主机地址</param>
        /// <returns></returns>
        public static byte[] TimeSyncCMD(int hostAddr)
        {
            DateTime dt = DateTime.Now;
            byte[] datas = new byte[5] { (byte)(hostAddr >> 8), (byte)hostAddr, (byte)dt.Hour, (byte)dt.Minute, (byte)dt.Second };
            return GetStringFor0x68((byte)CMDType.TimeSyncCMD, datas);
        }

        /// <summary>
        /// 获取单灯数据命令
        /// </summary>
        /// <param name="hostAddr">对应的主机地址</param>
        /// <returns></returns>
        public static byte[] GetLightDataCMD(int hostAddr, int intervalID)
        {
            byte[] datas = new byte[3] { (byte)(hostAddr >> 8), (byte)hostAddr, (byte)intervalID};
            return GetStringFor0x68((byte)CMDType.GetLightDataCMD, datas);
        }

        /// <summary>
        /// 设置灯状态
        /// </summary>
        /// <param name="hostAddr">主机地址</param>
        /// <param name="intervalID">单灯地址</param>
        /// <param name="Cmd">命令</param>
        /// <param name="ControlMode">控制模式</param>
        /// <param name="PowerValue">功率字节</param>
        /// <returns></returns>
        public static byte[] SetLightStateCMD(int hostAddr,byte GroupID, int LightID,byte Cmd,byte ControlMode,byte PowerValue)
        {
            //if ((GroupID<=31)&&(LightID<=2047))
            byte[] datas = new byte[7] { (byte)(hostAddr >> 8), (byte)hostAddr, (byte)((byte)(GroupID<<3)+(byte)(LightID >> 8)), (byte)(LightID), Cmd, ControlMode, PowerValue };
            return GetStringFor0x68((byte)CMDType.SetLightStateCMD, datas);

        }

        /// <summary>
        /// 同步扫描间隔命令
        /// </summary>
        /// <param name="hostAddr">对应的主机地址</param>
        /// <returns></returns>
        public static byte[] LightGetIntervalSyncCMD(int hostAddr, DateTime start, DateTime end, int lightsGetInterval, int lightGetInterval, int timeout, int count)
        {
            DateTime dt = DateTime.Now;
            byte[] datas = new byte[11] { (byte)(hostAddr >> 8), (byte)hostAddr, (byte)start.Hour, (byte)start.Minute, (byte)end.Hour, (byte)end.Minute, (byte)(lightsGetInterval>>8), (byte)lightsGetInterval, (byte)lightGetInterval, (byte)timeout, (byte)count };
            return GetStringFor0x68((byte)CMDType.LightGetIntervalCMD, datas);
        }

        /// <summary>
        /// 同步区间命令
        /// </summary>
        /// <param name="hostAddr">对应的主机地址</param>
        /// <returns></returns>
        public static byte[] IntervalSyncCMD(int hostAddr, int start, int len, int count)
        {
            DateTime dt = DateTime.Now;
            byte[] datas = new byte[4] { (byte)(count >> 8), (byte)count, (byte)(hostAddr>>8), (byte)hostAddr };
            int t;
            for (int i = 0; i < count; i++)
            {
                t = start+i*len;
                datas = datas.Concat(new byte[4] { (byte)(t >> 8), (byte)t, (byte)(len >> 8), (byte)len }).ToArray();
            }
            return GetStringFor0x68((byte)CMDType.InterSetCMD, datas);
        }

        /// <summary>
        /// 同步时间命令
        /// </summary>
        /// <param name="hostAddr">对应的主机地址</param>
        /// <returns></returns>
        public static byte[] AddrSyncCMD(int hostAddr)
        {
            DateTime dt = DateTime.Now;
            byte[] datas = new byte[4] { 0, 0, (byte)(hostAddr >> 8), (byte)hostAddr };
            return GetStringFor0x68((byte)CMDType.InterSetCMD, datas);
        }

        /// <summary>
        /// 获取0x67的命令内容，十六进制空格间隔
        /// </summary>
        /// <param name="contentType">命令类型，0x01-透传，0x03-时控，0x07-经纬度时控，0x0b校时命令</param>
        /// <param name="content">要发送的数据区内容</param>
        /// <returns></returns>
        public static string GetStringFor0x67(byte contentType, byte[] content)
        {
            if (content == null)
            {
                return null;
            }
            int length = content.Length;
            byte[] bTemp = new byte[length + 8];
            bTemp[0] = 0x67;
            bTemp[1] = contentType;
            bTemp[2] = (byte)(((length + 3) >> 8) & 0xFF);
            bTemp[3] = (byte)((length + 3) & 0xFF);
            bTemp[4] = 0x67;
            int i = 5;
            if (length > 0)
            {
                Array.Copy(content, 0, bTemp, i, length);
                i += length;
            }
            bTemp[i++] = 0x17;
            ushort crc = LumluxSSYDB.Common.Check.CRC.CalculateCrc16(bTemp, bTemp.Length - 2);
            bTemp[bTemp.Length - 1] = (byte)((crc >> 8) & 0xFF);
            bTemp[bTemp.Length - 2] = (byte)(crc & 0xFF);
            return Tool.DataConverter.ByteArrayToHexString(bTemp);
        }

        /// <summary>
        /// 获取针对433M的协议string内容，十六进制空格间隔
        /// </summary>
        /// <param name="contentTypeH">高命令类型</param>
        /// <param name="contentTypeL">低命令类型</param>
        /// <param name="content">实际数据</param>
        /// <returns></returns>
        public static string GetStringFor433M(byte contentTypeH, byte contentTypeL, byte[] content)
        {
            return GetStringFor0x67(0x01, GetBytesFor433M(contentTypeH, contentTypeL, content));
        }

        /// <summary>
        /// 处理宏电内层协议
        /// </summary>
        /// <param name="datas">内层数据集合</param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static List<LightGPRSProtocolResult> DealGPRSData(byte[] datas, ushort len)
        {
            if (len < 8)
                return null;
            List<LightGPRSProtocolResult> result = new List<LightGPRSProtocolResult>();
            int index = 0;
            ushort l = 0;
            while (len - index >= 8)
            {
                // 67 xx xx 67 协议
                #region 67协议
                //if (datas[index] == 0x67 && datas[index +4]==0x67)
                //{
                //    l = (ushort)(datas[index + 2] * 256 + datas[index + 3]);
                //    if ((l + index + 5) <= len)
                //    {
                //        if (Check.CRC.CalculateCrc16(datas, l + 5 - 2, index) == (ushort)(datas[index + 5 + l - 1] * 256 + datas[index + 5 + l - 2]))
                //        {
                //            LightGPRSProtocolResult lgpr = new LightGPRSProtocolResult();
                //            lgpr.Length = l - 3;
                //            switch (datas[index + 1])
                //            {
                //                case 0x02: // 透传命令
                //                    {
                //                        lgpr.ContentType = GPRSContentTypeEnum.Transmission;
                //                    }
                //                    break;
                //                case 0x04: // 时控命令
                //                    {
                //                        lgpr.ContentType = GPRSContentTypeEnum.TimeCtr;
                //                    }
                //                    break;
                //                case 0x08: //经纬度时控
                //                    {
                //                        lgpr.ContentType = GPRSContentTypeEnum.SunTimeCtrl;
                //                    }
                //                    break;
                //                case 0x0C: //校时命令
                //                    {
                //                        lgpr.ContentType = GPRSContentTypeEnum.SyncDateTime;
                //                    }
                //                    break;
                //                default:
                //                    lgpr.ContentType = GPRSContentTypeEnum.None;
                //                    break;
                //            }
                //            if (lgpr.ContentType != GPRSContentTypeEnum.None)
                //            {
                //                index += 5;
                //                byte[] bD = new byte[l - 3];
                //                Array.Copy(datas, index, bD, 0, l - 3);
                //                lgpr.Datas = bD;
                //                result.Add(lgpr);
                //                index += l;
                //                continue;
                //            }
                //        }
                //    }
                //}
                #endregion 67协议

                // 68 xx xx 68 协议
                if (datas[index] == 0x68 && datas[index + 4] == 0x68)
                {
                    l = (ushort)(datas[index + 2] * 256 + datas[index + 3]);
                    if ((l + index + 5) <= len)
                    {
                        if (datas[index + l + 4] == 0x16)
                        {
                            LightGPRSProtocolResult lgpr = new LightGPRSProtocolResult();
                            lgpr.Length = l - 1;
                            lgpr.Type = datas[index + 1];

                            index += 5;
                            byte[] bD = new byte[l - 1];
                            Array.Copy(datas, index, bD, 0, l - 1);
                            lgpr.Datas = bD;
                            result.Add(lgpr);
                            index += l;
                            continue;
                        }
                    }
                }
                index++;
            }
            return result;
        }
    }
}
