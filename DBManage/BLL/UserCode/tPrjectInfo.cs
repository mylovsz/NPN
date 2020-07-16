using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using LumluxSSYDB.Model;
namespace LumluxSSYDB.BLL
{
	/// <summary>
	/// tPrjectInfo
	/// </summary>
	public partial class tPrjectInfo
	{
		#region  ExtensionMethod

        /// <summary>
        /// 返回所有的工程Model
        /// </summary>
        /// <returns></returns>
        public List<Model.tPrjectInfo> GetAllModel()
        {
            return GetModelList("1=1");
        }

        /// <summary>
        /// 判断该项目是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ExistsName(string name)
        {
            List<Model.tPrjectInfo> list = GetModelList("sName='"+name+"'");
            return (list != null && list.Count > 0) ? true : false;
        }

		#endregion  ExtensionMethod
	}
}

