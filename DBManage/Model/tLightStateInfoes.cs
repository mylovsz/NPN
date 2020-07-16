/**  版本信息模板在安装目录下，可自行修改。
* tLightStateInfoes.cs
*
* 功 能： N/A
* 类 名： tLightStateInfoes
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:33   N/A    初版
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
	/// tLightStateInfoes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tLightStateInfoes
	{
		public tLightStateInfoes()
		{}
		#region Model
		private string _sguid;
		private decimal? _fvoltage;
		private decimal? _fcurrent;
		private decimal? _fpower;
		private int? _ifault;
		private DateTime? _dcreatedate;
		private DateTime? _dupdatetime;
		private string _slightinfoguid;
		private string _ssparefield1;
		private string _ssparefield2;
		private string _ssparefield3;
		private string _ssparefield4;
		private string _ssparefield5;
		private string _ssparefield6;
		private string _ssparefield7;
		private string _ssparefield8;
		private string _ssparefield9;
		private string _ssparefield10;
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
		public decimal? fVoltage
		{
			set{ _fvoltage=value;}
			get{return _fvoltage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fCurrent
		{
			set{ _fcurrent=value;}
			get{return _fcurrent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fPower
		{
			set{ _fpower=value;}
			get{return _fpower;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iFault
		{
			set{ _ifault=value;}
			get{return _ifault;}
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
		public string sLightInfoGUID
		{
			set{ _slightinfoguid=value;}
			get{return _slightinfoguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sSpareField1
		{
			set{ _ssparefield1=value;}
			get{return _ssparefield1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sSpareField2
		{
			set{ _ssparefield2=value;}
			get{return _ssparefield2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sSpareField3
		{
			set{ _ssparefield3=value;}
			get{return _ssparefield3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sSpareField4
		{
			set{ _ssparefield4=value;}
			get{return _ssparefield4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sSpareField5
		{
			set{ _ssparefield5=value;}
			get{return _ssparefield5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sSpareField6
		{
			set{ _ssparefield6=value;}
			get{return _ssparefield6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sSpareField7
		{
			set{ _ssparefield7=value;}
			get{return _ssparefield7;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sSpareField8
		{
			set{ _ssparefield8=value;}
			get{return _ssparefield8;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sSpareField9
		{
			set{ _ssparefield9=value;}
			get{return _ssparefield9;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sSpareField10
		{
			set{ _ssparefield10=value;}
			get{return _ssparefield10;}
		}
		#endregion Model

	}
}

