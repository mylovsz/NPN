using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LumluxSSYDB.DAL
{
    /// <summary>
    /// 数据访问类:tCMDRevs
    /// </summary>
    public partial class tCMDRevs
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


        /// <summary>
        /// 获得某类型的返回数据
        /// </summary>
        /// <param name="ContentType">数据类型</param>
        /// <param name="hostidid">主机idid</param>
        /// <param name="second">提前的时间</param>
        /// <returns></returns>
        public Model.tCMDRevs GetCMDRecive(int? ContentType, string hostidid, int second)
        {
            DateTime dtNow = DateTime.Now.AddSeconds(-second);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 sGUID,iContentType,sContent,iState,dCreateDate,dUpdateTime,iHostIDType,sHostIDAddr,sHostIDID,sHostIDSIM,sHostIDIP,sHostIDMAC from tCMDRevs ");
            strSql.Append(" where iState = 0 and dCreateDate > '" + dtNow.ToString() + "' and sHostIDID = '" + hostidid + "' and iContentType = '" + ContentType.ToString() + "'");

            LumluxSSYDB.Model.tCMDRevs model = new LumluxSSYDB.Model.tCMDRevs();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        #endregion  ExtensionMethod
    }
}
