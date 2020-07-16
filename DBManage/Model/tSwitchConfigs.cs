/**  版本信息模板在安装目录下，可自行修改。
* tSwitchConfigs.cs
*
* 功 能： N/A
* 类 名： tSwitchConfigs
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:36   N/A    初版
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
	/// tSwitchConfigs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tSwitchConfigs
	{
		public tSwitchConfigs()
		{}
		#region Model
		private string _sguid;
		private int? _iid;
		private string _sname;
		private int? _istatecommand;
		private int? _ialarmenable;
		private string _shostinfoguid;
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
		public int? iID
		{
			set{ _iid=value;}
			get{return _iid;}
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
		public int? iStateCommand
		{
			set{ _istatecommand=value;}
			get{return _istatecommand;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iAlarmEnable
		{
			set{ _ialarmenable=value;}
			get{return _ialarmenable;}
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

