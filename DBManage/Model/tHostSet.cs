/**  版本信息模板在安装目录下，可自行修改。
* tHostSet.cs
*
* 功 能： N/A
* 类 名： tHostSet
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:30   N/A    初版
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
	/// tHostSet:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tHostSet
	{
		public tHostSet()
		{}
		#region Model
		private string _sguid;
		private string _skey;
		private string _svalue;
		private string _shostguid;
		private string _sdesc;
		private DateTime? _dcreatedate;
		private DateTime? _dupdatedate;
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
		public string sKey
		{
			set{ _skey=value;}
			get{return _skey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sValue
		{
			set{ _svalue=value;}
			get{return _svalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sHostGUID
		{
			set{ _shostguid=value;}
			get{return _shostguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sDesc
		{
			set{ _sdesc=value;}
			get{return _sdesc;}
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
		public DateTime? dUpdateDate
		{
			set{ _dupdatedate=value;}
			get{return _dupdatedate;}
		}
		#endregion Model

	}
}

