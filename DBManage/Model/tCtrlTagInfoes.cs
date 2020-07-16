/**  版本信息模板在安装目录下，可自行修改。
* tCtrlTagInfoes.cs
*
* 功 能： N/A
* 类 名： tCtrlTagInfoes
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
	/// tCtrlTagInfoes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tCtrlTagInfoes
	{
		public tCtrlTagInfoes()
		{}
		#region Model
		private string _sguid;
		private int? _itype;
		private string _srelaystate;
		private string _srelayinfo_guid;
		private string _slightgroupstate;
		private string _slightgroupguid;
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
		public int? iType
		{
			set{ _itype=value;}
			get{return _itype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sRelayState
		{
			set{ _srelaystate=value;}
			get{return _srelaystate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sRelayInfo_GUID
		{
			set{ _srelayinfo_guid=value;}
			get{return _srelayinfo_guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sLightGroupState
		{
			set{ _slightgroupstate=value;}
			get{return _slightgroupstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sLightGroupGUID
		{
			set{ _slightgroupguid=value;}
			get{return _slightgroupguid;}
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

