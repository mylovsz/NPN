using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using LumluxSSYDB.Model;
namespace LumluxSSYDB.BLL
{
	/// <summary>
	/// tPrjectSet
	/// </summary>
	public partial class tPrjectSet
	{
		
		#region  ExtensionMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LumluxSSYDB.Model.tPrjectSet GetModelByWhere(string prjectGUID,string skey)
        {

            return dal.GetModelByWhere(prjectGUID,skey);
        }

        public List<Model.tPrjectSet> GetModelListByWhere(string strwhere)
        {
            return GetModelList(strwhere);
        }

        public DataTable GetTableByWhere(string strwhere)
        {

            //string sql = "select * from tHostInfo where sProjectInfoGUID='"+prjectGUID+"'";
            string sql = "select * from tPrjectSet where " + strwhere;
            DataSet ds = dal.GetBySql(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

            //return dal.GetTableByWhere(prjectGUID,sKey);
        }
		#endregion  ExtensionMethod
	}
}

