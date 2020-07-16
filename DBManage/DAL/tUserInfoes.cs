/**  版本信息模板在安装目录下，可自行修改。
* tUserInfoes.cs
*
* 功 能： N/A
* 类 名： tUserInfoes
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:38   N/A    初版
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
	/// 数据访问类:tUserInfoes
	/// </summary>
	public partial class tUserInfoes
	{
		public tUserInfoes()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sGUID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tUserInfoes");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36)			};
			parameters[0].Value = sGUID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(LumluxSSYDB.Model.tUserInfoes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tUserInfoes(");
			strSql.Append("sGUID,sID,sUserName,sPassWord,iAuthorityGUID,sAlias,sPhone,sEmail,dCreateDate,dUpdateTime,sRemark,sPrjectInfoGUID)");
			strSql.Append(" values (");
			strSql.Append("@sGUID,@sID,@sUserName,@sPassWord,@iAuthorityGUID,@sAlias,@sPhone,@sEmail,@dCreateDate,@dUpdateTime,@sRemark,@sPrjectInfoGUID)");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36),
					new SqlParameter("@sID", SqlDbType.NVarChar,100),
					new SqlParameter("@sUserName", SqlDbType.NVarChar,100),
					new SqlParameter("@sPassWord", SqlDbType.NVarChar,200),
					new SqlParameter("@iAuthorityGUID", SqlDbType.Char,36),
					new SqlParameter("@sAlias", SqlDbType.NVarChar,100),
					new SqlParameter("@sPhone", SqlDbType.NVarChar,100),
					new SqlParameter("@sEmail", SqlDbType.NVarChar,100),
					new SqlParameter("@dCreateDate", SqlDbType.DateTime),
					new SqlParameter("@dUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@sRemark", SqlDbType.NVarChar,500),
					new SqlParameter("@sPrjectInfoGUID", SqlDbType.Char,36)};
			parameters[0].Value = model.sGUID;
			parameters[1].Value = model.sID;
			parameters[2].Value = model.sUserName;
			parameters[3].Value = model.sPassWord;
			parameters[4].Value = model.iAuthorityGUID;
			parameters[5].Value = model.sAlias;
			parameters[6].Value = model.sPhone;
			parameters[7].Value = model.sEmail;
			parameters[8].Value = model.dCreateDate;
			parameters[9].Value = model.dUpdateTime;
			parameters[10].Value = model.sRemark;
			parameters[11].Value = model.sPrjectInfoGUID;

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
		public bool Update(LumluxSSYDB.Model.tUserInfoes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tUserInfoes set ");
			strSql.Append("sID=@sID,");
			strSql.Append("sUserName=@sUserName,");
			strSql.Append("sPassWord=@sPassWord,");
			strSql.Append("iAuthorityGUID=@iAuthorityGUID,");
			strSql.Append("sAlias=@sAlias,");
			strSql.Append("sPhone=@sPhone,");
			strSql.Append("sEmail=@sEmail,");
			strSql.Append("dCreateDate=@dCreateDate,");
			strSql.Append("dUpdateTime=@dUpdateTime,");
			strSql.Append("sRemark=@sRemark,");
			strSql.Append("sPrjectInfoGUID=@sPrjectInfoGUID");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sID", SqlDbType.NVarChar,100),
					new SqlParameter("@sUserName", SqlDbType.NVarChar,100),
					new SqlParameter("@sPassWord", SqlDbType.NVarChar,200),
					new SqlParameter("@iAuthorityGUID", SqlDbType.Char,36),
					new SqlParameter("@sAlias", SqlDbType.NVarChar,100),
					new SqlParameter("@sPhone", SqlDbType.NVarChar,100),
					new SqlParameter("@sEmail", SqlDbType.NVarChar,100),
					new SqlParameter("@dCreateDate", SqlDbType.DateTime),
					new SqlParameter("@dUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@sRemark", SqlDbType.NVarChar,500),
					new SqlParameter("@sPrjectInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@sGUID", SqlDbType.Char,36)};
			parameters[0].Value = model.sID;
			parameters[1].Value = model.sUserName;
			parameters[2].Value = model.sPassWord;
			parameters[3].Value = model.iAuthorityGUID;
			parameters[4].Value = model.sAlias;
			parameters[5].Value = model.sPhone;
			parameters[6].Value = model.sEmail;
			parameters[7].Value = model.dCreateDate;
			parameters[8].Value = model.dUpdateTime;
			parameters[9].Value = model.sRemark;
			parameters[10].Value = model.sPrjectInfoGUID;
			parameters[11].Value = model.sGUID;

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
			strSql.Append("delete from tUserInfoes ");
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
			strSql.Append("delete from tUserInfoes ");
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
		public LumluxSSYDB.Model.tUserInfoes GetModel(string sGUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sGUID,sID,sUserName,sPassWord,iAuthorityGUID,sAlias,sPhone,sEmail,dCreateDate,dUpdateTime,sRemark,sPrjectInfoGUID from tUserInfoes ");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36)			};
			parameters[0].Value = sGUID;

			LumluxSSYDB.Model.tUserInfoes model=new LumluxSSYDB.Model.tUserInfoes();
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
		public LumluxSSYDB.Model.tUserInfoes DataRowToModel(DataRow row)
		{
			LumluxSSYDB.Model.tUserInfoes model=new LumluxSSYDB.Model.tUserInfoes();
			if (row != null)
			{
				if(row["sGUID"]!=null)
				{
					model.sGUID=row["sGUID"].ToString();
				}
				if(row["sID"]!=null)
				{
					model.sID=row["sID"].ToString();
				}
				if(row["sUserName"]!=null)
				{
					model.sUserName=row["sUserName"].ToString();
				}
				if(row["sPassWord"]!=null)
				{
					model.sPassWord=row["sPassWord"].ToString();
				}
				if(row["iAuthorityGUID"]!=null)
				{
					model.iAuthorityGUID=row["iAuthorityGUID"].ToString();
				}
				if(row["sAlias"]!=null)
				{
					model.sAlias=row["sAlias"].ToString();
				}
				if(row["sPhone"]!=null)
				{
					model.sPhone=row["sPhone"].ToString();
				}
				if(row["sEmail"]!=null)
				{
					model.sEmail=row["sEmail"].ToString();
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
				if(row["sPrjectInfoGUID"]!=null)
				{
					model.sPrjectInfoGUID=row["sPrjectInfoGUID"].ToString();
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
			strSql.Append("select sGUID,sID,sUserName,sPassWord,iAuthorityGUID,sAlias,sPhone,sEmail,dCreateDate,dUpdateTime,sRemark,sPrjectInfoGUID ");
			strSql.Append(" FROM tUserInfoes ");
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
			strSql.Append(" sGUID,sID,sUserName,sPassWord,iAuthorityGUID,sAlias,sPhone,sEmail,dCreateDate,dUpdateTime,sRemark,sPrjectInfoGUID ");
			strSql.Append(" FROM tUserInfoes ");
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
			strSql.Append("select count(1) FROM tUserInfoes ");
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
			strSql.Append(")AS Row, T.*  from tUserInfoes T ");
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
			parameters[0].Value = "tUserInfoes";
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

