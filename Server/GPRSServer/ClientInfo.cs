using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPRSServer
{
    [Serializable]
    public class ClientInfo
    {
        /// <summary>
        /// 当前客户端的IMEI
        /// </summary>
        public string IMEI { set; get; }
        /// <summary>
        /// 此客户端最后更新时间
        /// </summary>
        public DateTime UpdateTime;
        /// <summary>
        /// 当前客户端所对用的连接ID
        /// </summary>
        public IntPtr ConnID;
        /// <summary>
        /// 当前客户端在服务器中的地址
        /// </summary>
        public string LocalIP;
        /// <summary>
        /// 当前客户端在服务器中的端口
        /// </summary>
        public ushort LocalPort;
        /// <summary>
        /// 当前客户端的IP
        /// </summary>
        public string TelIP;
        /// <summary>
        /// 当前客户端的端口
        /// </summary>
        public ushort TelPort;
        /// <summary>
        /// 当前客户端是否在线
        /// </summary>
        public bool Online;

        public override string ToString()
        {
            return "IMEI : " + IMEI + "\r\n网络连接 : " + ConnID + "\r\n本地IP : " + LocalIP + "\r\n本地端口 : " + LocalPort + "\r\n客户端IP : " + TelIP + "\r\n客户端端口 : " + TelPort + "\r\n在线状态 : " + Online+"\r\n最后一次心跳包时间 : "+UpdateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
