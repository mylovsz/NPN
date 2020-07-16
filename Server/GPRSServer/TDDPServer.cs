using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace GPRSServer
{
    public class TDDPServer
    {
        #region 私有属性
        /// <summary>
        /// 在线客户端列表
        /// </summary>
        ConcurrentBag<ClientInfo> listOnlineClient = null;

        /// <summary>
        /// TCP服务IP地址
        /// </summary>
        string sevIP;

        /// <summary>
        /// TCP服务端口
        /// </summary>
        ushort sevPort;

        /// <summary>
        /// HPTcpSocket
        /// </summary>
        HPSocketCS.TcpServer server;

        /// <summary>
        /// 发送数据统计
        /// </summary>
        long totalSent = 0;

        /// <summary>
        /// 接收数据统计
        /// </summary>
        long totalReceived = 0;

        /// <summary>
        /// 宏电心跳包超时时间
        /// </summary>
        uint headTimeout = 60;
        #endregion

        #region 属性
        /// <summary>
        /// 发送数据统计
        /// </summary>
        public long TotalSent
        {
            get { return totalSent; }
        }
        /// <summary>
        /// 接收数据统计
        /// </summary>
        public long TotalReceived
        {
            get { return totalReceived; }
        }
        /// <summary>
        /// 宏电心跳包超时时间（此值是判断客户端在线与离线的标准）
        /// </summary>
        public uint HeadTimeout
        {
            get { return headTimeout; }
            set { headTimeout = value; }
        }
        /// <summary>
        /// 服务IP
        /// </summary>
        public string SevIP
        {
            get { return sevIP; }
            set { sevIP = value; }
        }
        /// <summary>
        /// 服务端口
        /// </summary>
        public ushort SevPort
        {
            get { return sevPort; }
            set { sevPort = value; }
        }
        /// <summary>
        /// 在线客户端列表
        /// </summary>
        public ConcurrentBag<ClientInfo> ListOnlineClient
        {
            get { return listOnlineClient; }
        }
        #endregion

        /// <summary>
        /// 清空统计信息
        /// </summary>
        public void TotalReset()
        {
            totalReceived = 0;
            totalSent = 0;
        }

        public TDDPServer()
        {
            server = new HPSocketCS.TcpServer();
            server.OnAccept += new HPSocketCS.TcpServerEvent.OnAcceptEventHandler(server_OnAccept);
            server.OnClose += new HPSocketCS.TcpServerEvent.OnCloseEventHandler(server_OnClose);
            server.OnError += new HPSocketCS.TcpServerEvent.OnErrorEventHandler(server_OnError);
            server.OnPrepareListen += new HPSocketCS.TcpServerEvent.OnPrepareListenEventHandler(server_OnPrepareListen);
            server.OnReceive += new HPSocketCS.TcpServerEvent.OnReceiveEventHandler(server_OnReceive);
            server.OnSend += new HPSocketCS.TcpServerEvent.OnSendEventHandler(server_OnSend);
            server.OnShutdown += new HPSocketCS.TcpServerEvent.OnShutdownEventHandler(server_OnShutdown);

            // 关闭心跳包检测，采用宏电定义的心跳包
            server.KeepAliveInterval = 0;
            server.KeepAliveTime = 0;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ip">服务IP</param>
        /// <param name="port">服务Port</param>
        public TDDPServer(string ip, ushort port)
            :this()
        {
            sevIP = ip;
            sevPort = port;
        }

        HPSocketCS.HandleResult server_OnShutdown()
        {
            // 当前无用
            Debug.WriteLine("[TDDPServer]-OnShutdown");

            return HPSocketCS.HandleResult.Ok;
        }

        HPSocketCS.HandleResult server_OnSend(IntPtr connId, IntPtr pData, int length)
        {
            // 发送数据统计
            Interlocked.Add(ref totalSent, length);

            return HPSocketCS.HandleResult.Ok;
        }

        #region 声明心跳包event
        public class RegisterEventArgs : EventArgs
        {
            public readonly ClientInfo UserInfo;
            public RegisterEventArgs(ClientInfo user)
            {
                UserInfo = user;
            }
        }
        public delegate void RegisterEventHandler(Object sender, RegisterEventArgs e);
        /// <summary>
        /// 心跳包事件
        /// </summary>
        public event RegisterEventHandler Register;
        #endregion

        #region 数据接收集合Event
        /// <summary>
        /// 数据接收集合
        /// </summary>
        public class DataRecord
        {
            public IntPtr ConnId;
            public string IMEI;
            public byte[] Datas;
        }
        public class DataRecordEventArgs : EventArgs
        {
            public readonly DataRecord Datas;
            public DataRecordEventArgs(DataRecord datas)
            {
                Datas = datas;
            }
        }
        public delegate void DataRecordEventHandler(object sender, DataRecordEventArgs e);
        /// <summary>
        /// 数据接收事件
        /// </summary>
        public event DataRecordEventHandler DataRecords;
        #endregion

        /// <summary>
        /// 接收参数封装
        /// </summary>
        class DealDatasArg
        {
            public IntPtr ConnId;
            public byte[] Datas;
        }

        /// <summary>
        /// 使用宏电协议进行数据解析
        /// </summary>
        /// <param name="obj">数据封装DealDatasArg</param>
        void DealDatas(Object obj)
        {
            DealDatasArg arg = (DealDatasArg)obj;
            IntPtr connId = arg.ConnId;
            byte[] datas = arg.Datas;
            int i = 0;
            int length;
            int dataLength;
            byte[] baImei = new byte[11];
            int type;
            while (datas.Length - i >= 16)
            {
                if (datas[i] == 0x7B)
                {
                    length = datas[i + 2] * 256 + datas[i + 3];
                    if (length >= 16 && length <= datas.Length - i)
                    {
                        if (datas[i + length - 1] == 0x7B)
                        {
                            type = datas[i + 1];
                            Array.Copy(datas, i + 4, baImei, 0, 11);
                            i += 15;
                            switch (type)
                            {
                                case 9: // 客户端发送的数据
                                    if (DataRecords != null)
                                    {
                                        dataLength = length - 16;
                                        DataRecord dr = new DataRecord();
                                        dr.ConnId = arg.ConnId;
                                        dr.IMEI = System.Text.Encoding.ASCII.GetString(baImei);
                                        dr.Datas = new byte[dataLength];
                                        Array.Copy(datas, i, dr.Datas, 0, dataLength);

                                        DataRecords(this, new DataRecordEventArgs(dr));
                                    }
                                    break;
                                case 1: // 注册包处理，宏电协议必须做回复
                                    string imei = System.Text.Encoding.ASCII.GetString(baImei);
                                    ClientInfo c = listOnlineClient.FirstOrDefault(x => x.IMEI == imei);
                                    if (c == null)
                                    {
                                        c = new ClientInfo();
                                        c.IMEI = imei;
                                        listOnlineClient.Add(c);
                                    }
                                    c.UpdateTime = DateTime.Now;
                                    c.Online = true;
                                    c.ConnID = connId;
                                    c.TelIP = datas[i] + ":" + datas[i + 1] + ":" + datas[i + 2] + ":" + datas[i + 3];
                                    i += 4;
                                    c.TelPort = (ushort)(datas[i] * 256 + datas[i + 1]);
                                    i += 2;
                                    if (server.GetRemoteAddress(connId, ref c.LocalIP, ref c.LocalPort))
                                    {
                                        Debug.WriteLine(string.Format(" > [{0},OnReceive] -> Pass({1})", c.ConnID, c.ToString()));
                                    }
                                    else
                                    {
                                        Debug.WriteLine(string.Format(" > [{0},OnReceive] -> Server GetClientAddress() Error", connId));
                                    }
                                    // 回复心跳包
                                    byte[] baSend = new byte[16] { 0x7B, 0x81, 0x00, 0x10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0x7B };
                                    Array.Copy(baImei, 0, baSend, 4, 11);
                                    Debug.WriteLine(HPSocketCS.Tools.DataTool.ByteArrayToHexString(baSend));
                                    server.Send(connId, baSend, baSend.Length);

                                    // 导出事件
                                    if (Register != null)
                                    {
                                        Register(this, new RegisterEventArgs(c));
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                i++;
            }
        }

        HPSocketCS.HandleResult server_OnReceive(IntPtr connId, IntPtr pData, int length)
        {
            // 接收数据统计
            Interlocked.Add(ref totalReceived, length);

            // 准备数据
            DealDatasArg arg = new DealDatasArg();
            arg.Datas = new byte[length];
            arg.ConnId = connId;
            Marshal.Copy(pData, arg.Datas, 0, length);

            // 线程池分配解析线程
            ThreadPool.QueueUserWorkItem(new WaitCallback(DealDatas), (Object)arg);

            return HPSocketCS.HandleResult.Ok;
        }

        HPSocketCS.HandleResult server_OnPrepareListen(IntPtr soListen)
        {
            // 当前无用
            Debug.WriteLine("[TDDPServer]-OnPrepareListen");

            return HPSocketCS.HandleResult.Ok;
        }

        HPSocketCS.HandleResult server_OnError(IntPtr connId, HPSocketCS.SocketOperation enOperation, int errorCode)
        {
            // 当前无用
            Debug.WriteLine("[TDDPServer]-OnError");

            return HPSocketCS.HandleResult.Ok;
        }

        HPSocketCS.HandleResult server_OnClose(IntPtr connId)
        {
            // 当前无用
            Debug.WriteLine("[TDDPServer]-OnClose");

            return HPSocketCS.HandleResult.Ok;
        }

        HPSocketCS.HandleResult server_OnAccept(IntPtr connId, IntPtr pClient)
        {
            // 当前无用
            Debug.WriteLine("[TDDPServer]-OnAccept");

            return HPSocketCS.HandleResult.Ok;
        }

        public bool StartServer()
        {
            // 初始化在线客户端列表
            if (listOnlineClient == null)
                listOnlineClient = new ConcurrentBag<ClientInfo>();
            int listOnlineClientLength = listOnlineClient.Count;
            ClientInfo listOnlineClientC;
            for (int i = 0; i < listOnlineClientLength; i++)
                listOnlineClient.TryTake(out listOnlineClientC);

            // 设置线程池数量
            //ThreadPool.SetMaxThreads(6, 6);
            TotalReset();

            // 启动服务
            server.IpAddress = sevIP;
            server.Port = sevPort;
            return server.Start();
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        /// <returns></returns>
        public bool StopServer()
        {
            return server.Stop();
        }

        /// <summary>
        /// 对指定ConnID发送数据
        /// </summary>
        /// <param name="connId">目标ConnId</param>
        /// <param name="send">要发送的数据</param>
        /// <returns>True-成功，False-失败</returns>
        public bool Send(IntPtr connId, byte[] send)
        {
            return server.Send(connId, send, send.Length);
        }

        /// <summary>
        /// 对指定宏电客户端发送数据
        /// </summary>
        /// <param name="c">宏电客户端信息</param>
        /// <param name="send">要发送的数据</param>
        /// <returns>True-成功，False-失败</returns>
        public bool Send(ClientInfo c, byte[] send)
        {
            byte[] result = new byte[4] { 0x7B, 0x89, 0x00, 0x00 };
            result = result.Concat(System.Text.Encoding.ASCII.GetBytes(c.IMEI)).ToArray();
            result = result.Concat(send).ToArray();
            result = result.Concat(new byte[1] { 0x7B }).ToArray();
            result[2] = (byte)(result.Length >> 8);
            result[3] = (byte)(result.Length);
            return Send(c.ConnID, result);
        }

        /// <summary>
        /// 尝试关闭所有不在线的宏电客户端连接
        /// </summary>
        /// <returns></returns>
        public bool TryDisconnectUnonlineClient()
        {
            if (server.State != HPSocketCS.ServiceState.Started)
                return false;

            if (listOnlineClient == null || listOnlineClient.Count == 0)
            {
                return true;
            }
            else
            {
                ConcurrentBag<ClientInfo> listTemp = new ConcurrentBag<ClientInfo>();
                DateTime dtNow = DateTime.Now;
                Parallel.ForEach(listOnlineClient, Line => {
                    if ((dtNow - Line.UpdateTime).TotalSeconds < headTimeout)
                    {
                        listTemp.Add(Line);
                    }
                });
                listOnlineClient = listTemp;
            }
            
            return true;
        }

        /// <summary>
        /// 关闭静默连接
        /// </summary>
        /// <param name="period">断开超过指定时长的静默连接（毫秒）</param>
        /// <param name="force">是否强制</param>
        /// <returns></returns>
        public bool DisconnectSilenceConnections(uint period, bool force = true)
        {
            if (server != null && server.State == HPSocketCS.ServiceState.Started)
            {
                return server.DisconnectSilenceConnections(period, force);
            }
            return true;
        }

        /// <summary>
        /// 尝试获取所有列表，包括在线与不在线
        /// </summary>
        /// <param name="listOut"></param>
        /// <returns></returns>
        public bool TryGetAllList(ref List<ClientInfo> listOut)
        {
            if (server.State != HPSocketCS.ServiceState.Started)
                return false;

            if (listOnlineClient == null || listOnlineClient.Count == 0)
            {
                listOut.Clear();
            }
            else
            {
                DateTime dtNow = DateTime.Now;
                foreach (ClientInfo c in listOnlineClient)
                {
                    if ((dtNow - c.UpdateTime).TotalSeconds >= headTimeout)
                        c.Online = false;
                    listOut.Add(c);
                }
            }
            return true;
        }

        /// <summary>
        /// 尝试获取在线列表，在线与否通过心跳包超时来确定
        /// </summary>
        /// <param name="listOut"></param>
        /// <returns></returns>
        public bool TryGetOnlineList(ref List<ClientInfo> listOut)
        {
            if (server.State != HPSocketCS.ServiceState.Started)
                return false;

            if (listOnlineClient == null || listOnlineClient.Count == 0)
            {
                listOut.Clear();
            }
            else
            {
                DateTime dtNow = DateTime.Now;
                foreach (ClientInfo c in listOnlineClient)
                {
                    if ((dtNow - c.UpdateTime).TotalSeconds < headTimeout)
                        listOut.Add(c);
                }
            }
            return true;
        }

        /// <summary>
        /// 获取所有的ConnID
        /// </summary>
        /// <returns>失败返回null</returns>
        public IntPtr[] GetAllConnID()
        {
            return server.GetAllConnectionIDs();
        }

        /// <summary>
        /// 返回当前TCP服务器的状态
        /// </summary>
        /// <returns></returns>
        public HPSocketCS.ServiceState GetServerState()
        {
            if (server != null)
                return server.State;
            return HPSocketCS.ServiceState.Stoped;
        }

        /// <summary>
        /// 序列数据到byte[]
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] ObjectToBytes(object obj)
        {
            return server.ObjectToBytes(obj);
        }

        /// <summary>
        /// 反序列号数据
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public object BytesToObject(byte[] datas)
        {
            return server.BytesToObject(datas);
        }
    }
}
