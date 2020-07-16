using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LumluxSSYDB.Common.Check
{
    public class XOR
    {
        /// <summary>
        /// 异或和校验
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="length"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static byte CalculateXor(byte[] buffer, int length, int offset = 0)
        {
            byte xor = 0;
            for (int j = offset; j < length; j++)
                xor ^= buffer[j];
            return xor;
        }
    }
}
