using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LumluxSSYDB.DAL
{
    public partial class tMeasureCurrentInfoes
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LumluxSSYDB.Model.tMeasureCurrentInfoes GetModelByHostGuidAndIDAndTime(string sMeasureInfoGUID, int iID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 sGUID,iID,fValue,iAlarm,sMeasureInfoGUID,dCreateTime,dUpdateTime,sDesc from tMeasureCurrentInfoes ");
            strSql.Append(" where sMeasureInfoGUID=@sMeasureInfoGUID and iID=@iID");
            SqlParameter[] parameters = {
					new SqlParameter("@sMeasureInfoGUID", SqlDbType.Char,36),
                    new SqlParameter("@iID", SqlDbType.Int)			};
            parameters[0].Value = sMeasureInfoGUID;
            parameters[0].Value = iID;

            LumluxSSYDB.Model.tMeasureCurrentInfoes model = new LumluxSSYDB.Model.tMeasureCurrentInfoes();
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
    }
}
