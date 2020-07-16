using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolManage
{
    public class LightGPRSProtocolResult
    {
        /// <summary>
        /// 数据内容长度
        /// </summary>
        public int Length;

        /// <summary>
        /// 返回数据内容
        /// </summary>
        public object Datas;

        /// <summary>
        /// 老系统的命令类型
        /// </summary>
        public byte Type;
    }
}
