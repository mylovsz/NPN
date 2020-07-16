/**  版本信息模板在安装目录下，可自行修改。
* tLightInfoLightGroupInfoes.cs
*
* 功 能： N/A
* 类 名： tLightInfoLightGroupInfoes
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:32   N/A    初版
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
	/// 数据访问类:tLightInfoLightGroupInfoes
	/// </summary>
	public partial class tLightInfoLightGroupInfoes
	{
		public tLightInfoLightGroupInfoes()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sGUID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tLightInfoLightGroupInfoes");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36)			};
			parameters[0].Value = sGUID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(LumluxSSYDB.Model.tLightInfoLightGroupInfoes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tLightInfoLightGroupInfoes(");
			strSql.Append("sGUID,sLightInfoGUID,sLightGroupInfoGUID,dCreateTime,dUpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@sGUID,@sLightInfoGUID,@sLightGroupInfoGUID,@dCreateTime,@dUpdateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36),
					new SqlParameter("@sLightInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@sLightGroupInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@dCreateTime", SqlDbType.DateTime),
					new SqlParameter("@dUpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.sGUID;
			parameters[1].Value = model.sLightInfoGUID;
			parameters[2].Value = model.sLightGroupInfoGUID;
			parameters[3].Value = model.dCreateTime;
			parameters[4].Value = model.dUpdateTime;

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
		public bool Update(LumluxSSYDB.Model.tLightInfoLightGroupInfoes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tLightInfoLightGroupInfoes set ");
			strSql.Append("sLightInfoGUID=@sLightInfoGUID,");
			strSql.Append("sLightGroupInfoGUID=@sLightGroupInfoGUID,");
			strSql.Append("dCreateTime=@dCreateTime,");
			strSql.Append("dUpdateTime=@dUpdateTime");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sLightInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@sLightGroupInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@dCreateTime", SqlDbType.DateTime),
					new SqlParameter("@dUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@sGUID", SqlDbType.Char,36)};
			parameters[0].Value = model.sLightInfoGUID;
			parameters[1].Value = model.sLightGroupInfoGUID;
			parameters[2].Value = model.dCreateTime;
			parameters[3].Value = model.dUpdateTime;
			parameters[4].Value = model.sGUID;

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
			strSql.Append("delete from tLightInfoLightGroupInfoes ");
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
			strSql.Append("delete from tLightInfoLightGroupInfoes ");
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
		public LumluxSSYDB.Model.tLightInfoLightGroupInfoes GetModel(string sGUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sGUID,sLightInfoGUID,sLightGroupInfoGUID,dCreateTime,dUpdateTime from tLightInfoLightGroupInfoes ");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36)			};
			parameters[0].Value = sGUID;

			LumluxSSYDB.Model.tLightInfoLightGroupInfoes model=new LumluxSSYDB.Model.tLightInfoLightGroupInfoes();
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
		public LumluxSSYDB.Model.tLightInfoLightGroupInfoes DataRowToModel(DataRow row)
		{
			LumluxSSYDB.Model.tLightInfoLightGroupInfoes model=new LumluxSSYDB.Model.tLightInfoLightGroupInfoes();
			if (row != null)
			{
				if(row["sGUID"]!=null)
				{
					model.sGUID=row["sGUID"].ToString();
				}
				if(row["sLightInfoGUID"]!=null)
				{
					model.sLightInfoGUID=row["sLightInfoGUID"].ToString();
				}
				if(row["sLightGroupInfoGUID"]!=null)
				{
					model.sLightGroupInfoGUID=row["sLightGroupInfoGUID"].ToString();
				}
				if(row["dCreateTime"]!=null && row["dCreateTime"].ToString()!="")
				{
					model.dCreateTime=DateTime.Parse(row["dCreateTime"].ToString());
				}
				if(row["dUpdateTime"]!=null && row["dUpdateTime"].ToString()!="")
				{
					model.dUpdateTime=DateTime.Parse(row["dUpdateTime"].ToString());
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
			strSql.Append("select sGUID,sLightInfoGUID,sLightGroupInfoGUID,dCreateTime,dUpdateTime ");
			strSql.Append(" FROM tLightInfoLightGroupInfoes ");
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
			strSql.Append(" sGUID,sLightInfoGUID,sLightGroupInfoGUID,dCreateTime,dUpdateTime ");
			strSql.Append(" FROM tLightInfoLightGroupInfoes ");
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
			strSql.Append("select count(1) FROM tLightInfoLightGroupInfoes ");
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
			strSql.Append(")AS Row, T.*  from tLightInfoLightGroupInfoes T ");
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
			parameters[0].Value = "tLightInfoLightGroupInfoes";
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

