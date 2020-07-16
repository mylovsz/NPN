/**  版本信息模板在安装目录下，可自行修改。
* tMeasureInfoes.cs
*
* 功 能： N/A
* 类 名： tMeasureInfoes
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
	/// tMeasureInfoes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tMeasureInfoes
	{
		public tMeasureInfoes()
		{}
		#region Model
		private string _sguid;
		private int? _iid;
		private decimal? _fvlota;
		private decimal? _fvlotb;
		private decimal? _fvlotc;
		private int? _ialarmvlota;
		private int? _ialarmvlotb;
		private int? _ialarmvlotc;
		private DateTime? _dcreatedate;
		private DateTime? _dupdatetime;
		private string _shostinfoguid;
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
		public decimal? fVlotA
		{
			set{ _fvlota=value;}
			get{return _fvlota;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fVlotB
		{
			set{ _fvlotb=value;}
			get{return _fvlotb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fVlotC
		{
			set{ _fvlotc=value;}
			get{return _fvlotc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iAlarmVlotA
		{
			set{ _ialarmvlota=value;}
			get{return _ialarmvlota;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iAlarmVlotB
		{
			set{ _ialarmvlotb=value;}
			get{return _ialarmvlotb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iAlarmVlotC
		{
			set{ _ialarmvlotc=value;}
			get{return _ialarmvlotc;}
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
		public string sHostInfoGUID
		{
			set{ _shostinfoguid=value;}
			get{return _shostinfoguid;}
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

