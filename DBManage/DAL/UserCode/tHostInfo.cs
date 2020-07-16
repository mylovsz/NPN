using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace LumluxSSYDB.DAL
{
	/// <summary>
	/// 数据访问类:tHostInfo
	/// </summary>
	public partial class tHostInfo
	{
		#region  ExtensionMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataSet GetBySql(string strSql)
        {
            return DbHelperSQL.Query(strSql);
        }
		#endregion  ExtensionMethod
	}
}

