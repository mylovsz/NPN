using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace LumluxSSYDB.DAL
{
    /// <summary>
    /// 数据访问类:tPrjectSet
    /// </summary>
    public partial class tPrjectSet
    {

        #region  ExtensionMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LumluxSSYDB.Model.tPrjectSet GetModelByWhere(string prjectGUID, string sKey)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 sGUID,sKey,sValue,sPrjectGUID,sDesc,dCreateTime,dUpdateTime from tPrjectSet ");
            strSql.Append(" where sPrjectGUID=@sprjectGUID and sKey=@sKey");
            SqlParameter[] parameters = {
					 new SqlParameter("@sprjectGUID",SqlDbType.Char,36),
                     new SqlParameter("@sKey",SqlDbType.NVarChar,50)};
            parameters[0].Value = prjectGUID;
            parameters[1].Value = sKey;
            LumluxSSYDB.Model.tPrjectSet model = new LumluxSSYDB.Model.tPrjectSet();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
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

