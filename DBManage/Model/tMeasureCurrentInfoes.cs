/**  版本信息模板在安装目录下，可自行修改。
* tMeasureCurrentInfoes.cs
*
* 功 能： N/A
* 类 名： tMeasureCurrentInfoes
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:34   N/A    初版
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
	/// tMeasureCurrentInfoes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tMeasureCurrentInfoes
	{
		public tMeasureCurrentInfoes()
		{}
		#region Model
		private string _sguid;
		private int? _iid;
		private decimal? _fvalue;
		private decimal? _ialarm;
		private string _smeasureinfoguid;
		private DateTime? _dcreatetime;
		private DateTime? _dupdatetime;
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
		public int? iID
		{
			set{ _iid=value;}
			get{return _iid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fValue
		{
			set{ _fvalue=value;}
			get{return _fvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iAlarm
		{
			set{ _ialarm=value;}
			get{return _ialarm;}
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
		public string sDesc
		{
			set{ _sdesc=value;}
			get{return _sdesc;}
		}
		#endregion Model

	}
}

