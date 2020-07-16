using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using LumluxSSYDB.Model;
namespace LumluxSSYDB.BLL
{
	/// <summary>
	/// tLightGroupInfoes
	/// </summary>
	public partial class tLightGroupInfoes
	{
		#region  ExtensionMethod

        /// <summary>
        /// 返回指定主机下的所有分组信息
        /// </summary>
        /// <param name="hostGUID"></param>
        /// <returns></returns>
        public List<Model.tLightGroupInfoes> GetModelListByHostGUID(string hostGUID)
        {
            if (hostGUID == null)
                return null;
            return GetModelList("sHostInfoGUID='" + hostGUID + "' order by sName");
        }

		#endregion  ExtensionMethod
	}
}

