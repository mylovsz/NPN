using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPSocketCS.Tools
{
    public class DataTool
    {
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
        /// <returns></returns>
        public static byte[] HexStringToByteArray(string s)
        {
            try
            {
                s = s.Replace(" ", "");
                byte[] buf = new byte[s.Length / 2];
                for (int i = 0; i < s.Length; i += 2)
                    buf[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
                return buf;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
