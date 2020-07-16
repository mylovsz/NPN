using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace LumluxSSYDB.DAL
{
	/// <summary>
	/// 数据访问类:tUserInfoes
	/// </summary>
	public partial class tUserInfoes
	{
		#region  ExtensionMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsUserByPassword(string UIName, string UIPassword)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tUserInfoes");
            strSql.Append(" where sUserName=@UIName and sPassWord=@UIPassword ");
            SqlParameter[] parameters = {
					new SqlParameter("@UIName", SqlDbType.NVarChar,100),
                    new SqlParameter("@UIPassword", SqlDbType.NVarChar,200)};
            parameters[0].Value = UIName;
            parameters[1].Value = UIPassword;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LumluxSSYDB.Model.tUserInfoes GetUserMode(string UIName, string UIPassword)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from tUserInfoes ");
            strSql.Append(" where sUserName=@UIName and sPassWord=@UIPassword ");
            SqlParameter[] parameters = {
					new SqlParameter("@UIName", SqlDbType.NVarChar,50),			
                               new SqlParameter("@UIPassword", SqlDbType.NVarChar,50)         
                                        };
            parameters[0].Value = UIName;
            parameters[1].Value = UIPassword;

            LumluxSSYDB.Model.tUserInfoes model = new LumluxSSYDB.Model.tUserInfoes();
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
		#endregion  ExtensionMethod
	}
}

