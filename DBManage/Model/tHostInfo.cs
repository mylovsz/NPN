/**  版本信息模板在安装目录下，可自行修改。
* tHostInfo.cs
*
* 功 能： N/A
* 类 名： tHostInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/8 13:36:39   N/A    初版
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
	/// tHostInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tHostInfo
	{
		public tHostInfo()
		{}
		#region Model
		private string _sguid;
		private string _sname;
		private decimal? _flng;
		private decimal? _flat;
		private int? _iidtype;
		private string _sid_id;
		private string _sid_addr;
		private string _sid_ip;
		private string _sid_mac;
		private string _sid_sim;
		private string _shardware_version;
		private int? _ihardware_type;
		private int? _istate_online;
		private int? _istate_alarm;
		private int? _istate_enable;
		private int? _istate_command;
		private string _sgroupinfoguid;
		private string _sprojectinfoguid;
		private DateTime? _dcreatedate;
		private DateTime? _dupdatetime;
		private string _sremark;
		private string _shostinfostateguid;
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
		public int? iIDType
		{
			set{ _iidtype=value;}
			get{return _iidtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sID_ID
		{
			set{ _sid_id=value;}
			get{return _sid_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sID_Addr
		{
			set{ _sid_addr=value;}
			get{return _sid_addr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sID_IP
		{
			set{ _sid_ip=value;}
			get{return _sid_ip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sID_MAC
		{
			set{ _sid_mac=value;}
			get{return _sid_mac;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sID_SIM
		{
			set{ _sid_sim=value;}
			get{return _sid_sim;}
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
		public int? iState_Online
		{
			set{ _istate_online=value;}
			get{return _istate_online;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iState_Alarm
		{
			set{ _istate_alarm=value;}
			get{return _istate_alarm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iState_Enable
		{
			set{ _istate_enable=value;}
			get{return _istate_enable;}
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
		public string sGroupInfoGUID
		{
			set{ _sgroupinfoguid=value;}
			get{return _sgroupinfoguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sProjectInfoGUID
		{
			set{ _sprojectinfoguid=value;}
			get{return _sprojectinfoguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dCreateDate
		{
			set{ _dcreatedate=value;}
			get{return _dcreatedate;}
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
		public string sHostInfoStateGUID
		{
			set{ _shostinfostateguid=value;}
			get{return _shostinfostateguid;}
		}
		#endregion Model

	}
}

