/**  版本信息模板在安装目录下，可自行修改。
* tBranchConfigs.cs
*
* 功 能： N/A
* 类 名： tBranchConfigs
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/6 8:18:54   N/A    初版
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
	/// tBranchConfigs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tBranchConfigs
	{
		public tBranchConfigs()
		{}
		#region Model
		private string _sguid;
		private int? _iid;
		private string _sname;
		private decimal? _fcurrenthi;
		private decimal? _fcurrentlo;
		private decimal? _fcurrentzo;
		private decimal? _icurrentsd;
		private int? _ivolttype;
		private decimal? _fratio;
		private int? _ienable;
		private int? _istate_command;
		private string _smeasureconfigguid;
		private string _srelayinfoguid;
		private string _sswitchconfigguid;
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
		public string sName
		{
			set{ _sname=value;}
			get{return _sname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fCurrentHI
		{
			set{ _fcurrenthi=value;}
			get{return _fcurrenthi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fCurrentLO
		{
			set{ _fcurrentlo=value;}
			get{return _fcurrentlo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fCurrentZO
		{
			set{ _fcurrentzo=value;}
			get{return _fcurrentzo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iCurrentSD
		{
			set{ _icurrentsd=value;}
			get{return _icurrentsd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iVoltType
		{
			set{ _ivolttype=value;}
			get{return _ivolttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fRatio
		{
			set{ _fratio=value;}
			get{return _fratio;}
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
		public int? iState_Command
		{
			set{ _istate_command=value;}
			get{return _istate_command;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sMeasureConfigGUID
		{
			set{ _smeasureconfigguid=value;}
			get{return _smeasureconfigguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sRelayInfoGUID
		{
			set{ _srelayinfoguid=value;}
			get{return _srelayinfoguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sSwitchConfigGUID
		{
			set{ _sswitchconfigguid=value;}
			get{return _sswitchconfigguid;}
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

