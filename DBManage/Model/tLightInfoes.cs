/**  版本信息模板在安装目录下，可自行修改。
* tLightInfoes.cs
*
* 功 能： N/A
* 类 名： tLightInfoes
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:32   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace LumluxSSYDB.Model
{
	/// <summary>
	/// tLightInfoes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tLightInfoes
	{
		public tLightInfoes()
		{}
		#region Model
		private string _sguid;
		private string _sname;
		private string _slightid;
		private string _slightphyid;
		private decimal? _flng;
		private decimal? _flat;
		private string _saddr;
		private int? _istate_command;
		private int? _ialarmconfig_config;
		private DateTime? _dalarmconfig_start;
		private DateTime? _dalarmconfig_end;
		private string _salarmconfig_remark;
		private int? _irealtimealarm_faultstate;
		private int? _irealtimealarm_fault;
		private DateTime? _irealtimealarm_createdatetime;
		private string _shostinfoguid;
		private string _sstateguid;
		private DateTime? _dcreatetime;
		private DateTime? _dupdatetime;
		private string _sremark;
		private string _shardware_version;
		private int? _ihardware_type;
		private int? _ienable;
		/// <summary>
		/// 
		/// </summary>
		public string sGUID
		{
			set{ _sguid=value;}
			get{return _sguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sName
		{
			set{ _sname=value;}
			get{return _sname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sLightID
		{
			set{ _slightid=value;}
			get{return _slightid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sLightPhyID
		{
			set{ _slightphyid=value;}
			get{return _slightphyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fLng
		{
			set{ _flng=value;}
			get{return _flng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fLat
		{
			set{ _flat=value;}
			get{return _flat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sAddr
		{
			set{ _saddr=value;}
			get{return _saddr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iState_Command
		{
			set{ _istate_command=value;}
			get{return _istate_command;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iAlarmConfig_Config
		{
			set{ _ialarmconfig_config=value;}
			get{return _ialarmconfig_config;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dAlarmConfig_Start
		{
			set{ _dalarmconfig_start=value;}
			get{return _dalarmconfig_start;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dAlarmConfig_End
		{
			set{ _dalarmconfig_end=value;}
			get{return _dalarmconfig_end;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sAlarmConfig_Remark
		{
			set{ _salarmconfig_remark=value;}
			get{return _salarmconfig_remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iRealTimeAlarm_FaultState
		{
			set{ _irealtimealarm_faultstate=value;}
			get{return _irealtimealarm_faultstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iRealTimeAlarm_Fault
		{
			set{ _irealtimealarm_fault=value;}
			get{return _irealtimealarm_fault;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? iRealTimeAlarm_CreateDateTime
		{
			set{ _irealtimealarm_createdatetime=value;}
			get{return _irealtimealarm_createdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sHostInfoGUID
		{
			set{ _shostinfoguid=value;}
			get{return _shostinfoguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sStateGUID
		{
			set{ _sstateguid=value;}
			get{return _sstateguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dCreateTime
		{
			set{ _dcreatetime=value;}
			get{return _dcreatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dUpdateTime
		{
			set{ _dupdatetime=value;}
			get{return _dupdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sRemark
		{
			set{ _sremark=value;}
			get{return _sremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sHardware_Version
		{
			set{ _shardware_version=value;}
			get{return _shardware_version;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iHardware_Type
		{
			set{ _ihardware_type=value;}
			get{return _ihardware_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iEnable
		{
			set{ _ienable=value;}
			get{return _ienable;}
		}
		#endregion Model

	}
}

