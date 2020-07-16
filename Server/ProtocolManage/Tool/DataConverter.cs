using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolManage.Tool
{
    public class DataConverter
    {
        /// <summary>
        /// byte数组转换成16进制，空格隔开
        /// </summary>
        /// <param name="data">要转换的数组</param>
        /// <returns></returns>
        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 2);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0') + " ");
            return sb.ToString().Trim().ToUpper();
        }

        /// <summary>
        /// 16进制空格间隔的字符串，转化成byte数组
        /// </summary>
        /// <param name="s">要转换的字符串</param>
        /// <param name="space"></param>
        /// <returns></returns>
        public static byte[] HexStringToByteArray(string s, bool space = false)
        {
            try
            {
                if (string.IsNullOrEmpty(s))
                    return new byte[0];
                if (space == false)
                {
                    s = s.Replace(" ", "");
                    byte[] buf = new byte[s.Length / 2];
                    for (int i = 0; i < s.Length; i += 2)
                        buf[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
                    return buf;
                }
                else
                {
                    string[] arrayStr = s.Trim().Split(' ');
                    byte[] buf = new byte[arrayStr.Length];
                    for (int i = 0; i < arrayStr.Length; i++)
                    {
                        buf[i] = Convert.ToByte(arrayStr[i], 16);
                    }
                    return buf;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
