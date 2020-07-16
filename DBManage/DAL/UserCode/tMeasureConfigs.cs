using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LumluxSSYDB.DAL
{
    public partial class tMeasureConfigs
    {
        /// <summary>
        /// 通过主机guid得到一个对象实体
        /// </summary>
        public LumluxSSYDB.Model.tMeasureConfigs GetModelByHostGuid(string sHostInfoGUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 sGUID,fVoltHI,fVoltLO,iAlarmDelayTime,iMeasureNumber,iBranchNumber,iState_Command,dCreateDate,dUpdateTime,sHostInfoGUID,sDesc from tMeasureConfigs ");
            strSql.Append(" where sHostInfoGUID=@sHostInfoGUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@sHostInfoGUID", SqlDbType.Char,36)			};
            parameters[0].Value = sHostInfoGUID;

            LumluxSSYDB.Model.tMeasureConfigs model = new LumluxSSYDB.Model.tMeasureConfigs();
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
