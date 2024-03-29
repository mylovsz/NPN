﻿/**  版本信息模板在安装目录下，可自行修改。
* tHostSet.cs
*
* 功 能： N/A
* 类 名： tHostSet
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/10/12 15:34:44   N/A    初版
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
	/// tHostSet
	/// </summary>
	public partial class tHostSet
	{
		#region  ExtensionMethod
        public Model.tHostSet GetAllByHostGUIDKey(string hostGUID, string key)
        {
            string where = "sHostGUID = '" + hostGUID + "' and sKey='" + key + "'";
            List<Model.tHostSet> list = GetModelList(where);
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
		#endregion  ExtensionMethod
	}
}

