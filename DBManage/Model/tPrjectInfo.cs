/**  版本信息模板在安装目录下，可自行修改。
* tPrjectInfo.cs
*
* 功 能： N/A
* 类 名： tPrjectInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:35   N/A    初版
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
	/// tPrjectInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tPrjectInfo
	{
		public tPrjectInfo()
		{}
		#region Model
		private string _sguid;
		private string _sid;
		private string _sname;
		private string _sauthor;
		private decimal? _flng;
		private decimal? _flat;
		private DateTime? _dcreatedate;
		private DateTime? _dupdatetime;
		private string _sremark;
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
		public string sID
		{
			set{ _sid=value;}
			get{return _sid;}
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
		public string sAuthor
		{
			set{ _sauthor=value;}
			get{return _sauthor;}
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
		#endregion Model

	}
}

