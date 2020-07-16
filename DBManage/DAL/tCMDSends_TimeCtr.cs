/**  版本信息模板在安装目录下，可自行修改。
* tCMDSends.cs
*
* 功 能： N/A
* 类 名： tCMDSends
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:29   N/A    初版
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
	/// 数据访问类:tCMDSends
	/// </summary>
	public partial class tCMDSends_TimeCtr
    {
		public tCMDSends_TimeCtr()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sHostIDID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tCMDSends_TimeCtr");
			strSql.Append(" where sHostIDID=@sHostIDID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sHostIDID", SqlDbType.Char,36)			};
			parameters[0].Value = sHostIDID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(LumluxSSYDB.Model.tCMDSends model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tCMDSends_TimeCtr(");
			strSql.Append("sGUID,iContentType,sContent,iState,dCreateDate,dUpdateTime,iHostIDType,sHostIDAddr,sHostIDID,sHostIDSIM,sHostIDIP,sHostIDMAC)");
			strSql.Append(" values (");
			strSql.Append("@sGUID,@iContentType,@sContent,@iState,@dCreateDate,@dUpdateTime,@iHostIDType,@sHostIDAddr,@sHostIDID,@sHostIDSIM,@sHostIDIP,@sHostIDMAC)");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36),
					new SqlParameter("@iContentType", SqlDbType.Int,4),
					new SqlParameter("@sContent", SqlDbType.NVarChar,500),
					new SqlParameter("@iState", SqlDbType.Int,4),
					new SqlParameter("@dCreateDate", SqlDbType.DateTime),
					new SqlParameter("@dUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@iHostIDType", SqlDbType.Int,4),
					new SqlParameter("@sHostIDAddr", SqlDbType.NVarChar,100),
					new SqlParameter("@sHostIDID", SqlDbType.NVarChar,100),
					new SqlParameter("@sHostIDSIM", SqlDbType.NVarChar,100),
					new SqlParameter("@sHostIDIP", SqlDbType.NVarChar,100),
					new SqlParameter("@sHostIDMAC", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.sGUID;
			parameters[1].Value = model.iContentType;
			parameters[2].Value = model.sContent;
			parameters[3].Value = model.iState;
			parameters[4].Value = model.dCreateDate;
			parameters[5].Value = model.dUpdateTime;
			parameters[6].Value = model.iHostIDType;
			parameters[7].Value = model.sHostIDAddr;
			parameters[8].Value = model.sHostIDID;
			parameters[9].Value = model.sHostIDSIM;
			parameters[10].Value = model.sHostIDIP;
			parameters[11].Value = model.sHostIDMAC;

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
		public bool Update(LumluxSSYDB.Model.tCMDSends model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tCMDSends_TimeCtr set ");
            strSql.Append("sGUID=@sGUID,");
            strSql.Append("iContentType=@iContentType,");
			strSql.Append("sContent=@sContent,");
			strSql.Append("iState=@iState,");
			strSql.Append("dCreateDate=@dCreateDate,");
			strSql.Append("dUpdateTime=@dUpdateTime,");
			strSql.Append("iHostIDType=@iHostIDType,");
			strSql.Append("sHostIDAddr=@sHostIDAddr,");
			strSql.Append("sHostIDSIM=@sHostIDSIM,");
			strSql.Append("sHostIDIP=@sHostIDIP,");
			strSql.Append("sHostIDMAC=@sHostIDMAC");
			strSql.Append(" where sHostIDID=@sHostIDID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@sGUID", SqlDbType.Char,36),
                    new SqlParameter("@iContentType", SqlDbType.Int,4),
                    new SqlParameter("@sContent", SqlDbType.NVarChar,500),
                    new SqlParameter("@iState", SqlDbType.Int,4),
                    new SqlParameter("@dCreateDate", SqlDbType.DateTime),
                    new SqlParameter("@dUpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@iHostIDType", SqlDbType.Int,4),
                    new SqlParameter("@sHostIDAddr", SqlDbType.NVarChar,100),
                    new SqlParameter("@sHostIDSIM", SqlDbType.NVarChar,100),
                    new SqlParameter("@sHostIDIP", SqlDbType.NVarChar,100),
                    new SqlParameter("@sHostIDMAC", SqlDbType.NVarChar,100),
                    new SqlParameter("@sHostIDID", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.sGUID;
            parameters[1].Value = model.iContentType;
            parameters[2].Value = model.sContent;
            parameters[3].Value = model.iState;
            parameters[4].Value = model.dCreateDate;
            parameters[5].Value = model.dUpdateTime;
            parameters[6].Value = model.iHostIDType;
            parameters[7].Value = model.sHostIDAddr;
            parameters[8].Value = model.sHostIDSIM;
            parameters[9].Value = model.sHostIDIP;
            parameters[10].Value = model.sHostIDMAC;
            parameters[11].Value = model.sHostIDID;

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
		public bool Delete(string sHostIDID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tCMDSends_TimeCtr ");
			strSql.Append(" where sHostIDID=@sHostIDID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sHostIDID", SqlDbType.Char,36)			};
			parameters[0].Value = sHostIDID;

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
		public bool DeleteList(string sHostIDIDlist)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tCMDSends_TimeCtr ");
			strSql.Append(" where sHostIDID in (" + sHostIDIDlist + ")  ");
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
		public LumluxSSYDB.Model.tCMDSends GetModel(string sHostIDID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sGUID,iContentType,sContent,iState,dCreateDate,dUpdateTime,iHostIDType,sHostIDAddr,sHostIDID,sHostIDSIM,sHostIDIP,sHostIDMAC from tCMDSends_TimeCtr ");
			strSql.Append(" where sHostIDID=@sHostIDID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sHostIDID", SqlDbType.Char,36)			};
			parameters[0].Value = sHostIDID;

			LumluxSSYDB.Model.tCMDSends model=new LumluxSSYDB.Model.tCMDSends();
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
		public LumluxSSYDB.Model.tCMDSends DataRowToModel(DataRow row)
		{
			LumluxSSYDB.Model.tCMDSends model=new LumluxSSYDB.Model.tCMDSends();
			if (row != null)
			{
				if(row["sGUID"]!=null)
				{
					model.sGUID=row["sGUID"].ToString();
				}
				if(row["iContentType"]!=null && row["iContentType"].ToString()!="")
				{
					model.iContentType=int.Parse(row["iContentType"].ToString());
				}
				if(row["sContent"]!=null)
				{
					model.sContent=row["sContent"].ToString();
				}
				if(row["iState"]!=null && row["iState"].ToString()!="")
				{
					model.iState=int.Parse(row["iState"].ToString());
				}
				if(row["dCreateDate"]!=null && row["dCreateDate"].ToString()!="")
				{
					model.dCreateDate=DateTime.Parse(row["dCreateDate"].ToString());
				}
				if(row["dUpdateTime"]!=null && row["dUpdateTime"].ToString()!="")
				{
					model.dUpdateTime=DateTime.Parse(row["dUpdateTime"].ToString());
				}
				if(row["iHostIDType"]!=null && row["iHostIDType"].ToString()!="")
				{
					model.iHostIDType=int.Parse(row["iHostIDType"].ToString());
				}
				if(row["sHostIDAddr"]!=null)
				{
					model.sHostIDAddr=row["sHostIDAddr"].ToString();
				}
				if(row["sHostIDID"]!=null)
				{
					model.sHostIDID=row["sHostIDID"].ToString();
				}
				if(row["sHostIDSIM"]!=null)
				{
					model.sHostIDSIM=row["sHostIDSIM"].ToString();
				}
				if(row["sHostIDIP"]!=null)
				{
					model.sHostIDIP=row["sHostIDIP"].ToString();
				}
				if(row["sHostIDMAC"]!=null)
				{
					model.sHostIDMAC=row["sHostIDMAC"].ToString();
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
			strSql.Append("select sGUID,iContentType,sContent,iState,dCreateDate,dUpdateTime,iHostIDType,sHostIDAddr,sHostIDID,sHostIDSIM,sHostIDIP,sHostIDMAC ");
			strSql.Append(" FROM tCMDSends_TimeCtr ");
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
			strSql.Append(" sGUID,iContentType,sContent,iState,dCreateDate,dUpdateTime,iHostIDType,sHostIDAddr,sHostIDID,sHostIDSIM,sHostIDIP,sHostIDMAC ");
			strSql.Append(" FROM tCMDSends_TimeCtr ");
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
			strSql.Append("select count(1) FROM tCMDSends_TimeCtr ");
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
				strSql.Append("order by T.sHostIDID desc");
			}
			strSql.Append(")AS Row, T.*  from tCMDSends_TimeCtr T ");
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
			parameters[0].Value = "tCMDSends_TimeCtr";
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

