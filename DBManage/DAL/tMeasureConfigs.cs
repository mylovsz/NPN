/**  版本信息模板在安装目录下，可自行修改。
* tMeasureConfigs.cs
*
* 功 能： N/A
* 类 名： tMeasureConfigs
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:34   N/A    初版
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
	/// 数据访问类:tMeasureConfigs
	/// </summary>
	public partial class tMeasureConfigs
	{
		public tMeasureConfigs()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sGUID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tMeasureConfigs");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36)			};
			parameters[0].Value = sGUID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(LumluxSSYDB.Model.tMeasureConfigs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tMeasureConfigs(");
			strSql.Append("sGUID,fVoltHI,fVoltLO,iAlarmDelayTime,iMeasureNumber,iBranchNumber,iState_Command,dCreateDate,dUpdateTime,sHostInfoGUID,sDesc)");
			strSql.Append(" values (");
			strSql.Append("@sGUID,@fVoltHI,@fVoltLO,@iAlarmDelayTime,@iMeasureNumber,@iBranchNumber,@iState_Command,@dCreateDate,@dUpdateTime,@sHostInfoGUID,@sDesc)");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36),
					new SqlParameter("@fVoltHI", SqlDbType.Float,8),
					new SqlParameter("@fVoltLO", SqlDbType.Float,8),
					new SqlParameter("@iAlarmDelayTime", SqlDbType.Int,4),
					new SqlParameter("@iMeasureNumber", SqlDbType.Int,4),
					new SqlParameter("@iBranchNumber", SqlDbType.Char,10),
					new SqlParameter("@iState_Command", SqlDbType.Int,4),
					new SqlParameter("@dCreateDate", SqlDbType.DateTime),
					new SqlParameter("@dUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@sHostInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@sDesc", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.sGUID;
			parameters[1].Value = model.fVoltHI;
			parameters[2].Value = model.fVoltLO;
			parameters[3].Value = model.iAlarmDelayTime;
			parameters[4].Value = model.iMeasureNumber;
			parameters[5].Value = model.iBranchNumber;
			parameters[6].Value = model.iState_Command;
			parameters[7].Value = model.dCreateDate;
			parameters[8].Value = model.dUpdateTime;
			parameters[9].Value = model.sHostInfoGUID;
			parameters[10].Value = model.sDesc;

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
		public bool Update(LumluxSSYDB.Model.tMeasureConfigs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tMeasureConfigs set ");
			strSql.Append("fVoltHI=@fVoltHI,");
			strSql.Append("fVoltLO=@fVoltLO,");
			strSql.Append("iAlarmDelayTime=@iAlarmDelayTime,");
			strSql.Append("iMeasureNumber=@iMeasureNumber,");
			strSql.Append("iBranchNumber=@iBranchNumber,");
			strSql.Append("iState_Command=@iState_Command,");
			strSql.Append("dCreateDate=@dCreateDate,");
			strSql.Append("dUpdateTime=@dUpdateTime,");
			strSql.Append("sHostInfoGUID=@sHostInfoGUID,");
			strSql.Append("sDesc=@sDesc");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@fVoltHI", SqlDbType.Float,8),
					new SqlParameter("@fVoltLO", SqlDbType.Float,8),
					new SqlParameter("@iAlarmDelayTime", SqlDbType.Int,4),
					new SqlParameter("@iMeasureNumber", SqlDbType.Int,4),
					new SqlParameter("@iBranchNumber", SqlDbType.Char,10),
					new SqlParameter("@iState_Command", SqlDbType.Int,4),
					new SqlParameter("@dCreateDate", SqlDbType.DateTime),
					new SqlParameter("@dUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@sHostInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@sDesc", SqlDbType.NVarChar,500),
					new SqlParameter("@sGUID", SqlDbType.Char,36)};
			parameters[0].Value = model.fVoltHI;
			parameters[1].Value = model.fVoltLO;
			parameters[2].Value = model.iAlarmDelayTime;
			parameters[3].Value = model.iMeasureNumber;
			parameters[4].Value = model.iBranchNumber;
			parameters[5].Value = model.iState_Command;
			parameters[6].Value = model.dCreateDate;
			parameters[7].Value = model.dUpdateTime;
			parameters[8].Value = model.sHostInfoGUID;
			parameters[9].Value = model.sDesc;
			parameters[10].Value = model.sGUID;

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
			strSql.Append("delete from tMeasureConfigs ");
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
			strSql.Append("delete from tMeasureConfigs ");
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
		public LumluxSSYDB.Model.tMeasureConfigs GetModel(string sGUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sGUID,fVoltHI,fVoltLO,iAlarmDelayTime,iMeasureNumber,iBranchNumber,iState_Command,dCreateDate,dUpdateTime,sHostInfoGUID,sDesc from tMeasureConfigs ");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36)			};
			parameters[0].Value = sGUID;

			LumluxSSYDB.Model.tMeasureConfigs model=new LumluxSSYDB.Model.tMeasureConfigs();
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
		public LumluxSSYDB.Model.tMeasureConfigs DataRowToModel(DataRow row)
		{
			LumluxSSYDB.Model.tMeasureConfigs model=new LumluxSSYDB.Model.tMeasureConfigs();
			if (row != null)
			{
				if(row["sGUID"]!=null)
				{
					model.sGUID=row["sGUID"].ToString();
				}
				if(row["fVoltHI"]!=null && row["fVoltHI"].ToString()!="")
				{
					model.fVoltHI=decimal.Parse(row["fVoltHI"].ToString());
				}
				if(row["fVoltLO"]!=null && row["fVoltLO"].ToString()!="")
				{
					model.fVoltLO=decimal.Parse(row["fVoltLO"].ToString());
				}
				if(row["iAlarmDelayTime"]!=null && row["iAlarmDelayTime"].ToString()!="")
				{
					model.iAlarmDelayTime=int.Parse(row["iAlarmDelayTime"].ToString());
				}
				if(row["iMeasureNumber"]!=null && row["iMeasureNumber"].ToString()!="")
				{
					model.iMeasureNumber=int.Parse(row["iMeasureNumber"].ToString());
				}
				if(row["iBranchNumber"]!=null)
				{
					model.iBranchNumber=row["iBranchNumber"].ToString();
				}
				if(row["iState_Command"]!=null && row["iState_Command"].ToString()!="")
				{
					model.iState_Command=int.Parse(row["iState_Command"].ToString());
				}
				if(row["dCreateDate"]!=null && row["dCreateDate"].ToString()!="")
				{
					model.dCreateDate=DateTime.Parse(row["dCreateDate"].ToString());
				}
				if(row["dUpdateTime"]!=null && row["dUpdateTime"].ToString()!="")
				{
					model.dUpdateTime=DateTime.Parse(row["dUpdateTime"].ToString());
				}
				if(row["sHostInfoGUID"]!=null)
				{
					model.sHostInfoGUID=row["sHostInfoGUID"].ToString();
				}
				if(row["sDesc"]!=null)
				{
					model.sDesc=row["sDesc"].ToString();
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
			strSql.Append("select sGUID,fVoltHI,fVoltLO,iAlarmDelayTime,iMeasureNumber,iBranchNumber,iState_Command,dCreateDate,dUpdateTime,sHostInfoGUID,sDesc ");
			strSql.Append(" FROM tMeasureConfigs ");
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
			strSql.Append(" sGUID,fVoltHI,fVoltLO,iAlarmDelayTime,iMeasureNumber,iBranchNumber,iState_Command,dCreateDate,dUpdateTime,sHostInfoGUID,sDesc ");
			strSql.Append(" FROM tMeasureConfigs ");
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
			strSql.Append("select count(1) FROM tMeasureConfigs ");
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
			strSql.Append(")AS Row, T.*  from tMeasureConfigs T ");
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
			parameters[0].Value = "tMeasureConfigs";
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

