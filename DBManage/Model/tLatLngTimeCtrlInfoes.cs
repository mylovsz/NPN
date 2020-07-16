/**  版本信息模板在安装目录下，可自行修改。
* tLatLngTimeCtrlInfoes.cs
*
* 功 能： N/A
* 类 名： tLatLngTimeCtrlInfoes
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:31   N/A    初版
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
	/// tLatLngTimeCtrlInfoes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tLatLngTimeCtrlInfoes
	{
		public tLatLngTimeCtrlInfoes()
		{}
		#region Model
		private string _sguid;
		private int? _iid;
		private int? _itimetype;
		private int? _ioffset;
		private int? _ienable;
		private decimal? _istate_command;
		private DateTime? _dcreatedate;
		private DateTime? _dupdatetime;
		private string _stagguid;
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
		public int? iTimeType
		{
			set{ _itimetype=value;}
			get{return _itimetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iOffset
		{
			set{ _ioffset=value;}
			get{return _ioffset;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iEnable
		{
			set{ _ienable=value;}
			get{return _ienable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iState_Command
		{
			set{ _istate_command=value;}
			get{return _istate_command;}
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
		public string sTagGUID
		{
			set{ _stagguid=value;}
			get{return _stagguid;}
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

