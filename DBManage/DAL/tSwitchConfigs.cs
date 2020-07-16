/**  版本信息模板在安装目录下，可自行修改。
* tSwitchConfigs.cs
*
* 功 能： N/A
* 类 名： tSwitchConfigs
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
	/// 数据访问类:tSwitchConfigs
	/// </summary>
	public partial class tSwitchConfigs
	{
		public tSwitchConfigs()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sGUID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tSwitchConfigs");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36)			};
			parameters[0].Value = sGUID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(LumluxSSYDB.Model.tSwitchConfigs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tSwitchConfigs(");
			strSql.Append("sGUID,iID,sName,iStateCommand,iAlarmEnable,sHostInfoGUID,dCreateDate,dUpdateTime,sRemark)");
			strSql.Append(" values (");
			strSql.Append("@sGUID,@iID,@sName,@iStateCommand,@iAlarmEnable,@sHostInfoGUID,@dCreateDate,@dUpdateTime,@sRemark)");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36),
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@sName", SqlDbType.NVarChar,100),
					new SqlParameter("@iStateCommand", SqlDbType.Int,4),
					new SqlParameter("@iAlarmEnable", SqlDbType.Int,4),
					new SqlParameter("@sHostInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@dCreateDate", SqlDbType.DateTime),
					new SqlParameter("@dUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@sRemark", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.sGUID;
			parameters[1].Value = model.iID;
			parameters[2].Value = model.sName;
			parameters[3].Value = model.iStateCommand;
			parameters[4].Value = model.iAlarmEnable;
			parameters[5].Value = model.sHostInfoGUID;
			parameters[6].Value = model.dCreateDate;
			parameters[7].Value = model.dUpdateTime;
			parameters[8].Value = model.sRemark;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(LumluxSSYDB.Model.tSwitchConfigs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tSwitchConfigs set ");
			strSql.Append("iID=@iID,");
			strSql.Append("sName=@sName,");
			strSql.Append("iStateCommand=@iStateCommand,");
			strSql.Append("iAlarmEnable=@iAlarmEnable,");
			strSql.Append("sHostInfoGUID=@sHostInfoGUID,");
			strSql.Append("dCreateDate=@dCreateDate,");
			strSql.Append("dUpdateTime=@dUpdateTime,");
			strSql.Append("sRemark=@sRemark");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@sName", SqlDbType.NVarChar,100),
					new SqlParameter("@iStateCommand", SqlDbType.Int,4),
					new SqlParameter("@iAlarmEnable", SqlDbType.Int,4),
					new SqlParameter("@sHostInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@dCreateDate", SqlDbType.DateTime),
					new SqlParameter("@dUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@sRemark", SqlDbType.NVarChar,500),
					new SqlParameter("@sGUID", SqlDbType.Char,36)};
			parameters[0].Value = model.iID;
			parameters[1].Value = model.sName;
			parameters[2].Value = model.iStateCommand;
			parameters[3].Value = model.iAlarmEnable;
			parameters[4].Value = model.sHostInfoGUID;
			parameters[5].Value = model.dCreateDate;
			parameters[6].Value = model.dUpdateTime;
			parameters[7].Value = model.sRemark;
			parameters[8].Value = model.sGUID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string sGUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tSwitchConfigs ");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36)			};
			parameters[0].Value = sGUID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string sGUIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tSwitchConfigs ");
			strSql.Append(" where sGUID in ("+sGUIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LumluxSSYDB.Model.tSwitchConfigs GetModel(string sGUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sGUID,iID,sName,iStateCommand,iAlarmEnable,sHostInfoGUID,dCreateDate,dUpdateTime,sRemark from tSwitchConfigs ");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36)			};
			parameters[0].Value = sGUID;

			LumluxSSYDB.Model.tSwitchConfigs model=new LumluxSSYDB.Model.tSwitchConfigs();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LumluxSSYDB.Model.tSwitchConfigs DataRowToModel(DataRow row)
		{
			LumluxSSYDB.Model.tSwitchConfigs model=new LumluxSSYDB.Model.tSwitchConfigs();
			if (row != null)
			{
				if(row["sGUID"]!=null)
				{
					model.sGUID=row["sGUID"].ToString();
				}
				if(row["iID"]!=null && row["iID"].ToString()!="")
				{
					model.iID=int.Parse(row["iID"].ToString());
				}
				if(row["sName"]!=null)
				{
					model.sName=row["sName"].ToString();
				}
				if(row["iStateCommand"]!=null && row["iStateCommand"].ToString()!="")
				{
					model.iStateCommand=int.Parse(row["iStateCommand"].ToString());
				}
				if(row["iAlarmEnable"]!=null && row["iAlarmEnable"].ToString()!="")
				{
					model.iAlarmEnable=int.Parse(row["iAlarmEnable"].ToString());
				}
				if(row["sHostInfoGUID"]!=null)
				{
					model.sHostInfoGUID=row["sHostInfoGUID"].ToString();
				}
				if(row["dCreateDate"]!=null && row["dCreateDate"].ToString()!="")
				{
					model.dCreateDate=DateTime.Parse(row["dCreateDate"].ToString());
				}
				if(row["dUpdateTime"]!=null && row["dUpdateTime"].ToString()!="")
				{
					model.dUpdateTime=DateTime.Parse(row["dUpdateTime"].ToString());
				}
				if(row["sRemark"]!=null)
				{
					model.sRemark=row["sRemark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select sGUID,iID,sName,iStateCommand,iAlarmEnable,sHostInfoGUID,dCreateDate,dUpdateTime,sRemark ");
			strSql.Append(" FROM tSwitchConfigs ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" sGUID,iID,sName,iStateCommand,iAlarmEnable,sHostInfoGUID,dCreateDate,dUpdateTime,sRemark ");
			strSql.Append(" FROM tSwitchConfigs ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tSwitchConfigs ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.sGUID desc");
			}
			strSql.Append(")AS Row, T.*  from tSwitchConfigs T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tSwitchConfigs";
			parameters[1].Value = "sGUID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

