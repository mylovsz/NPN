/**  版本信息模板在安装目录下，可自行修改。
* tCMDRevs.cs
*
* 功 能： N/A
* 类 名： tCMDRevs
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:29   N/A    初版
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
	/// tCMDRevs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tCMDRevs
	{
		public tCMDRevs()
		{}
		#region Model
		private string _sguid;
		private int? _icontenttype;
		private string _scontent;
		private int? _istate;
		private DateTime? _dcreatedate;
		private DateTime? _dupdatetime;
		private int? _ihostidtype;
		private string _shostidaddr;
		private string _shostidid;
		private string _shostidsim;
		private string _shostidip;
		private string _shostidmac;
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
		public int? iContentType
		{
			set{ _icontenttype=value;}
			get{return _icontenttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sContent
		{
			set{ _scontent=value;}
			get{return _scontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iState
		{
			set{ _istate=value;}
			get{return _istate;}
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
		public int? iHostIDType
		{
			set{ _ihostidtype=value;}
			get{return _ihostidtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sHostIDAddr
		{
			set{ _shostidaddr=value;}
			get{return _shostidaddr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sHostIDID
		{
			set{ _shostidid=value;}
			get{return _shostidid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sHostIDSIM
		{
			set{ _shostidsim=value;}
			get{return _shostidsim;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sHostIDIP
		{
			set{ _shostidip=value;}
			get{return _shostidip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sHostIDMAC
		{
			set{ _shostidmac=value;}
			get{return _shostidmac;}
		}
		#endregion Model

	}
}

