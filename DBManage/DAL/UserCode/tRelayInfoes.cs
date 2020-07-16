/**  版本信息模板在安装目录下，可自行修改。
* tRelayInfoes.cs
*
* 功 能： N/A
* 类 名： tRelayInfoes
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:36   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace LumluxSSYDB.DAL
{
	/// <summary>
	/// 数据访问类:tRelayInfoes
	/// </summary>
	public partial class tRelayInfoes
	{


		#region  ExtensionMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistLoop(string sHostGUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tRelayInfoes");
            strSql.Append(" where sHostInfoGUID=@sHostGUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@sHostGUID", SqlDbType.Char,36)			};
            parameters[0].Value = sHostGUID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
		#endregion  ExtensionMethod
	}
}

