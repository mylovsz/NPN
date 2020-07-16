using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using LumluxSSYDB.Model;
namespace LumluxSSYDB.BLL
{
	/// <summary>
	/// tLightInfoLightGroupInfoes
	/// </summary>
	public partial class tLightInfoLightGroupInfoes
	{
		#region  ExtensionMethod

        /// <summary>
        /// 返回与指定分组相关的所有单灯信息
        /// </summary>
        /// <param name="lgGUID"></param>
        /// <returns></returns>
        public List<Model.tLightInfoLightGroupInfoes> GetModelListByLightGroupGUID(string lgGUID)
        {
            if (lgGUID == null)
                return null;
            return GetModelList("sLightGroupInfoGUID='" + lgGUID + "'");
        }

		#endregion  ExtensionMethod
	}
}

