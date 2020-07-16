/**  版本信息模板在安装目录下，可自行修改。
* tLightInfoLightGroupInfoes.cs
*
* 功 能： N/A
* 类 名： tLightInfoLightGroupInfoes
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:32   N/A    初版
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
	/// tLightInfoLightGroupInfoes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tLightInfoLightGroupInfoes
	{
		public tLightInfoLightGroupInfoes()
		{}
		#region Model
		private string _sguid;
		private string _slightinfoguid;
		private string _slightgroupinfoguid;
		private DateTime? _dcreatetime;
		private DateTime? _dupdatetime;
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
		public string sLightInfoGUID
		{
			set{ _slightinfoguid=value;}
			get{return _slightinfoguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sLightGroupInfoGUID
		{
			set{ _slightgroupinfoguid=value;}
			get{return _slightgroupinfoguid;}
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
		#endregion Model

	}
}

