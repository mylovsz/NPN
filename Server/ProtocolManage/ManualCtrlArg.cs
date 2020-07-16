using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolManage
{
    public enum ManualCtrlType
    {
        ALL_ON = 0x11,
        ALL_OFF,
        ODD_ON,
        ODD_OFF,
        EVEN_ON,
        EVEN_OFF,
        THIRD_ON,
        THIRD_OFF,
        QUARTER_ON,
        QUARTER_OFF,
        NODE_ON,
        NODE_OFF,
        NODE_STATE = 0x20,
        BUFF_CLEAR = 0x30,
        TYPE_ALL_ON = 0x41,
        TYPE_ALL_OFF,
        TYPE_ODD_ON,
        TYPE_ODD_OFF,
        TYPE_EVEN_ON,
        TYPE_EVEN_OFF,
    }

    [Serializable]
    public class ManualCtrlArg
    {
        /// <summary>
        /// 要控制的节点
        /// </summary>
        public int Node { get; set; }

        /// <summary>
        /// 控制类型，全开，全关，单开等待
        /// </summary>
        public ManualCtrlType Type { get; set; }

        /// <summary>
        /// 控制字节，在控制类型下，所提供的控制内容
        /// </summary>
        public byte Ctrl { get; set; }

        /// <summary>
        /// 控制字节扩展，在控制类型下，所提供的控制内容
        /// </summary>
        public byte CtrlEx { get; set; }

        /// <summary>
        /// 功率值，无用
        /// </summary>
        public byte Power { get; set; }
    }
}
