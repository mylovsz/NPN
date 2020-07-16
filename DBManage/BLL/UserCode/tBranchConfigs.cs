/**  版本信息模板在安装目录下，可自行修改。
* tBranchConfigs.cs
*
* 功 能： N/A
* 类 名： tBranchConfigs
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:28   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using LumluxSSYDB.Model;
namespace LumluxSSYDB.BLL
{
	/// <summary>
	/// tBranchConfigs
	/// </summary>
	public partial class tBranchConfigs
	{
		#region  ExtensionMethod
        public List<Model.tBranchConfigs> GetModelByMeasureConfigGUID(string guid)
        {
            string where = "sMeasureConfigGUID='" + guid + "'";
            return GetModelList(where);
        }
		#endregion  ExtensionMethod
	}
}

