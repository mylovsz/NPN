/**  版本信息模板在安装目录下，可自行修改。
* tUserInfoes.cs
*
* 功 能： N/A
* 类 名： tUserInfoes
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:38   N/A    初版
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
	/// tUserInfoes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tUserInfoes
	{
		public tUserInfoes()
		{}
		#region Model
		private string _sguid;
		private string _sid;
		private string _susername;
		private string _spassword;
		private string _iauthorityguid;
		private string _salias;
		private string _sphone;
		private string _semail;
		private DateTime? _dcreatedate;
		private DateTime? _dupdatetime;
		private string _sremark;
		private string _sprjectinfoguid;
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
		public string sUserName
		{
			set{ _susername=value;}
			get{return _susername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sPassWord
		{
			set{ _spassword=value;}
			get{return _spassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string iAuthorityGUID
		{
			set{ _iauthorityguid=value;}
			get{return _iauthorityguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sAlias
		{
			set{ _salias=value;}
			get{return _salias;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sPhone
		{
			set{ _sphone=value;}
			get{return _sphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sEmail
		{
			set{ _semail=value;}
			get{return _semail;}
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
		public string sPrjectInfoGUID
		{
			set{ _sprjectinfoguid=value;}
			get{return _sprjectinfoguid;}
		}
		#endregion Model

	}
}

