/**  版本信息模板在安装目录下，可自行修改。
* tHostInfoState.cs
*
* 功 能： N/A
* 类 名： tHostInfoState
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/9 14:17:00   N/A    初版
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
	/// tHostInfoState:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tHostInfoState
	{
		public tHostInfoState()
		{}
		#region Model
		private string _sguid;
		private string _shostinfoguid;
		private int? _istate_online;
		private int? _iflag;
		private string _sstate_alarm;
		private string _smeasureinfoguid;
		private string _sswitchinfoguid;
		private DateTime? _dcreatedate;
		private DateTime? _dupdatetime;
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
		public string sHostInfoGUID
		{
			set{ _shostinfoguid=value;}
			get{return _shostinfoguid;}
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
		public int? iFlag
		{
			set{ _iflag=value;}
			get{return _iflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sState_Alarm
		{
			set{ _sstate_alarm=value;}
			get{return _sstate_alarm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sMeasureInfoGUID
		{
			set{ _smeasureinfoguid=value;}
			get{return _smeasureinfoguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sSwitchInfoGUID
		{
			set{ _sswitchinfoguid=value;}
			get{return _sswitchinfoguid;}
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
		#endregion Model

	}
}

