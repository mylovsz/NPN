using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using LumluxSSYDB.Model;
namespace LumluxSSYDB.BLL
{
	/// <summary>
	/// tGroupInfoes
	/// </summary>
	public partial class tGroupInfoes
	{
		#region  ExtensionMethod

        /// <summary>
        /// 返回该项目下的所有分组信息
        /// </summary>
        /// <param name="prjGUID"></param>
        /// <returns></returns>
        public List<Model.tGroupInfoes> GetModelListByPrjGUID(string prjGUID)
        {
            if (prjGUID == null)
                return null;
            return GetModelList("sProjectInfoGUID='" + prjGUID + "'");
        }

		#endregion  ExtensionMethod
	}
}

