using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolManage
{
    /// <summary>
    /// 当前单灯类型
    /// </summary>
    public enum LightType
    {
        Normal = 0,
        OldTYN = 10,
        NewTYN
    }

    public enum StateEnable
    {
        Disenable,
        Enable
    }

    public enum HostHardwareType
    {
        Small,
        Big
    }

    public enum HostStateFlag
    {
        Open,
        Close
    }

    public enum CurrentAlarm
    {
        I_Normal,
        IO_Nmatch_CIR,
        IO_Nmatch_SW,
        IO_Nmatch_All,
        INO_Nmatch_CIR,
        INO_Nmatch_SW,
        INO_Nmatch_All,
        INO_OverUpper,
        INO_OverLower
    }

    public enum VoltageAlarm
    {
        Va_Normal,
        Va_Zero,
        Va_OvUpper,
        Va_OverLower
    }

    public enum VoltageType
    {
        A,
        C=2,
        B=4
    }

    public enum CMDState
    {
        NO,
        Yes
    }

    public enum HostOnline
    {
        Unonline,
        Online
    }

    public enum CMDType
    {
        None = 0xFF,
        /// <summary>
        /// 单灯控制
        /// </summary>
        LightCtrlCMD,
        LightCtrlRev,
        /// <summary>
        /// 时间同步
        /// </summary>
        TimeSyncCMD = 0x02,
        TimeSyncRev = 0x04,
        /// <summary>
        /// 带日期的时间同步
        /// </summary>
        DateTimeSyncCMD,
        DateTimeSyncRev,
        /// <summary>
        /// 控制单灯命令
        /// </summary>
        SetLightStateCMD = 0x10,
        SetLightStateRev = 0x11,
        /// <summary>
        /// 区间设置
        /// </summary>
        InterSetCMD = 0x81,
        InterSetRev,
        /// <summary>
        /// 单灯间隔配置
        /// </summary>
        LightGetIntervalCMD = 0x83,
        LightGetIntervalRev,
        /// <summary>
        /// 获取主机信息
        /// </summary>
        GetHostAllInfoCMD=0x95,
        GetHostAllInfoRev,
        /// <summary>
        /// 获取单灯数据
        /// </summary>
        GetLightDataCMD = 0x9E,
        GetLightDataRev = 0x19,

        /// <summary>
        /// 招测全部
        /// </summary>
        RecruitAllCMD = 1000,
        RecruitAllRev = 1001
    }
    class LightGPRSProtocolEnum
    {
    }
}
