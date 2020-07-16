using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LumluxSSYDB.DAL
{
    public partial class tMeasureInfoes
    {
        /// <summary>
        /// 通过主机guid,编码，时间得到一个对象实体
        /// </summary>
        public LumluxSSYDB.Model.tMeasureInfoes GetModelByHostGuidAndIdAndTime(string sHostInfoGUID, int iID, DateTime dCreateDate)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 sGUID,iID,fVlotA,fVlotB,fVlotC,iAlarmVlotA,iAlarmVlotB,iAlarmVlotC,dCreateDate,dUpdateTime,sHostInfoGUID,sDesc from tMeasureInfoes ");
            strSql.Append(" where sHostInfoGUID=@sHostInfoGUID and iID=@iID and dCreateDate > @dCreateDate");
            SqlParameter[] parameters = {
					new SqlParameter("@sHostInfoGUID", SqlDbType.Char,36),new SqlParameter("@iID", SqlDbType.Int),new SqlParameter("@dCreateDate", SqlDbType.DateTime)			};
            parameters[0].Value = sHostInfoGUID;
            parameters[1].Value = iID;
            parameters[2].Value = dCreateDate;

            LumluxSSYDB.Model.tMeasureInfoes model = new LumluxSSYDB.Model.tMeasureInfoes();
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
