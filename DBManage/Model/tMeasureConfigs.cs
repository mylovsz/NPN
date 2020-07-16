/**  版本信息模板在安装目录下，可自行修改。
* tMeasureConfigs.cs
*
* 功 能： N/A
* 类 名： tMeasureConfigs
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
	/// tMeasureConfigs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tMeasureConfigs
	{
		public tMeasureConfigs()
		{}
		#region Model
		private string _sguid;
		private decimal? _fvolthi;
		private decimal? _fvoltlo;
		private int? _ialarmdelaytime;
		private int? _imeasurenumber;
		private string _ibranchnumber;
		private int? _istate_command;
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
		public decimal? fVoltHI
		{
			set{ _fvolthi=value;}
			get{return _fvolthi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fVoltLO
		{
			set{ _fvoltlo=value;}
			get{return _fvoltlo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iAlarmDelayTime
		{
			set{ _ialarmdelaytime=value;}
			get{return _ialarmdelaytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iMeasureNumber
		{
			set{ _imeasurenumber=value;}
			get{return _imeasurenumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string iBranchNumber
		{
			set{ _ibranchnumber=value;}
			get{return _ibranchnumber;}
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

