/**  版本信息模板在安装目录下，可自行修改。
* tSwitchInfoes.cs
*
* 功 能： N/A
* 类 名： tSwitchInfoes
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:37   N/A    初版
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
	/// tSwitchInfoes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tSwitchInfoes
	{
		public tSwitchInfoes()
		{}
		#region Model
		private string _sguid;
		private int? _ialarmstate;
		private int? _istate_command;
		private string _shostinfo_guid;
		private DateTime? _dcreatedate;
		private string _sswitch_guid;
		private DateTime? _dupdatetiime;
		private string _sdesc;
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
		public int? iAlarmState
		{
			set{ _ialarmstate=value;}
			get{return _ialarmstate;}
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
		public string sHostInfo_GUID
		{
			set{ _shostinfo_guid=value;}
			get{return _shostinfo_guid;}
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
		public string sSwitch_GUID
		{
			set{ _sswitch_guid=value;}
			get{return _sswitch_guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dUpdateTiime
		{
			set{ _dupdatetiime=value;}
			get{return _dupdatetiime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sDesc
		{
			set{ _sdesc=value;}
			get{return _sdesc;}
		}
		#endregion Model

	}
}

