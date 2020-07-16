/**  版本信息模板在安装目录下，可自行修改。
* tBranchConfigs.cs
*
* 功 能： N/A
* 类 名： tBranchConfigs
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/6 8:18:54   N/A    初版
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
	/// 数据访问类:tBranchConfigs
	/// </summary>
	public partial class tBranchConfigs
	{
		public tBranchConfigs()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sGUID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tBranchConfigs");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36)			};
			parameters[0].Value = sGUID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(LumluxSSYDB.Model.tBranchConfigs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tBranchConfigs(");
			strSql.Append("sGUID,iID,sName,fCurrentHI,fCurrentLO,fCurrentZO,iCurrentSD,iVoltType,fRatio,iEnable,iState_Command,sMeasureConfigGUID,sRelayInfoGUID,sSwitchConfigGUID,dCreateTime,dUpdateTime,sDesc)");
			strSql.Append(" values (");
			strSql.Append("@sGUID,@iID,@sName,@fCurrentHI,@fCurrentLO,@fCurrentZO,@iCurrentSD,@iVoltType,@fRatio,@iEnable,@iState_Command,@sMeasureConfigGUID,@sRelayInfoGUID,@sSwitchConfigGUID,@dCreateTime,@dUpdateTime,@sDesc)");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36),
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@sName", SqlDbType.NVarChar,100),
					new SqlParameter("@fCurrentHI", SqlDbType.Float,8),
					new SqlParameter("@fCurrentLO", SqlDbType.Float,8),
					new SqlParameter("@fCurrentZO", SqlDbType.Float,8),
					new SqlParameter("@iCurrentSD", SqlDbType.Float,8),
					new SqlParameter("@iVoltType", SqlDbType.Int,4),
					new SqlParameter("@fRatio", SqlDbType.Float,8),
					new SqlParameter("@iEnable", SqlDbType.Int,4),
					new SqlParameter("@iState_Command", SqlDbType.Int,4),
					new SqlParameter("@sMeasureConfigGUID", SqlDbType.Char,36),
					new SqlParameter("@sRelayInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@sSwitchConfigGUID", SqlDbType.Char,36),
					new SqlParameter("@dCreateTime", SqlDbType.DateTime),
					new SqlParameter("@dUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@sDesc", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.sGUID;
			parameters[1].Value = model.iID;
			parameters[2].Value = model.sName;
			parameters[3].Value = model.fCurrentHI;
			parameters[4].Value = model.fCurrentLO;
			parameters[5].Value = model.fCurrentZO;
			parameters[6].Value = model.iCurrentSD;
			parameters[7].Value = model.iVoltType;
			parameters[8].Value = model.fRatio;
			parameters[9].Value = model.iEnable;
			parameters[10].Value = model.iState_Command;
			parameters[11].Value = model.sMeasureConfigGUID;
			parameters[12].Value = model.sRelayInfoGUID;
			parameters[13].Value = model.sSwitchConfigGUID;
			parameters[14].Value = model.dCreateTime;
			parameters[15].Value = model.dUpdateTime;
			parameters[16].Value = model.sDesc;

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
		public bool Update(LumluxSSYDB.Model.tBranchConfigs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tBranchConfigs set ");
			strSql.Append("iID=@iID,");
			strSql.Append("sName=@sName,");
			strSql.Append("fCurrentHI=@fCurrentHI,");
			strSql.Append("fCurrentLO=@fCurrentLO,");
			strSql.Append("fCurrentZO=@fCurrentZO,");
			strSql.Append("iCurrentSD=@iCurrentSD,");
			strSql.Append("iVoltType=@iVoltType,");
			strSql.Append("fRatio=@fRatio,");
			strSql.Append("iEnable=@iEnable,");
			strSql.Append("iState_Command=@iState_Command,");
			strSql.Append("sMeasureConfigGUID=@sMeasureConfigGUID,");
			strSql.Append("sRelayInfoGUID=@sRelayInfoGUID,");
			strSql.Append("sSwitchConfigGUID=@sSwitchConfigGUID,");
			strSql.Append("dCreateTime=@dCreateTime,");
			strSql.Append("dUpdateTime=@dUpdateTime,");
			strSql.Append("sDesc=@sDesc");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@sName", SqlDbType.NVarChar,100),
					new SqlParameter("@fCurrentHI", SqlDbType.Float,8),
					new SqlParameter("@fCurrentLO", SqlDbType.Float,8),
					new SqlParameter("@fCurrentZO", SqlDbType.Float,8),
					new SqlParameter("@iCurrentSD", SqlDbType.Float,8),
					new SqlParameter("@iVoltType", SqlDbType.Int,4),
					new SqlParameter("@fRatio", SqlDbType.Float,8),
					new SqlParameter("@iEnable", SqlDbType.Int,4),
					new SqlParameter("@iState_Command", SqlDbType.Int,4),
					new SqlParameter("@sMeasureConfigGUID", SqlDbType.Char,36),
					new SqlParameter("@sRelayInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@sSwitchConfigGUID", SqlDbType.Char,36),
					new SqlParameter("@dCreateTime", SqlDbType.DateTime),
					new SqlParameter("@dUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@sDesc", SqlDbType.NVarChar,500),
					new SqlParameter("@sGUID", SqlDbType.Char,36)};
			parameters[0].Value = model.iID;
			parameters[1].Value = model.sName;
			parameters[2].Value = model.fCurrentHI;
			parameters[3].Value = model.fCurrentLO;
			parameters[4].Value = model.fCurrentZO;
			parameters[5].Value = model.iCurrentSD;
			parameters[6].Value = model.iVoltType;
			parameters[7].Value = model.fRatio;
			parameters[8].Value = model.iEnable;
			parameters[9].Value = model.iState_Command;
			parameters[10].Value = model.sMeasureConfigGUID;
			parameters[11].Value = model.sRelayInfoGUID;
			parameters[12].Value = model.sSwitchConfigGUID;
			parameters[13].Value = model.dCreateTime;
			parameters[14].Value = model.dUpdateTime;
			parameters[15].Value = model.sDesc;
			parameters[16].Value = model.sGUID;

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
			strSql.Append("delete from tBranchConfigs ");
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
			strSql.Append("delete from tBranchConfigs ");
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
		public LumluxSSYDB.Model.tBranchConfigs GetModel(string sGUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sGUID,iID,sName,fCurrentHI,fCurrentLO,fCurrentZO,iCurrentSD,iVoltType,fRatio,iEnable,iState_Command,sMeasureConfigGUID,sRelayInfoGUID,sSwitchConfigGUID,dCreateTime,dUpdateTime,sDesc from tBranchConfigs ");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36)			};
			parameters[0].Value = sGUID;

			LumluxSSYDB.Model.tBranchConfigs model=new LumluxSSYDB.Model.tBranchConfigs();
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
		public LumluxSSYDB.Model.tBranchConfigs DataRowToModel(DataRow row)
		{
			LumluxSSYDB.Model.tBranchConfigs model=new LumluxSSYDB.Model.tBranchConfigs();
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
				if(row["fCurrentHI"]!=null && row["fCurrentHI"].ToString()!="")
				{
					model.fCurrentHI=decimal.Parse(row["fCurrentHI"].ToString());
				}
				if(row["fCurrentLO"]!=null && row["fCurrentLO"].ToString()!="")
				{
					model.fCurrentLO=decimal.Parse(row["fCurrentLO"].ToString());
				}
				if(row["fCurrentZO"]!=null && row["fCurrentZO"].ToString()!="")
				{
					model.fCurrentZO=decimal.Parse(row["fCurrentZO"].ToString());
				}
				if(row["iCurrentSD"]!=null && row["iCurrentSD"].ToString()!="")
				{
					model.iCurrentSD=decimal.Parse(row["iCurrentSD"].ToString());
				}
				if(row["iVoltType"]!=null && row["iVoltType"].ToString()!="")
				{
					model.iVoltType=int.Parse(row["iVoltType"].ToString());
				}
				if(row["fRatio"]!=null && row["fRatio"].ToString()!="")
				{
					model.fRatio=decimal.Parse(row["fRatio"].ToString());
				}
				if(row["iEnable"]!=null && row["iEnable"].ToString()!="")
				{
					model.iEnable=int.Parse(row["iEnable"].ToString());
				}
				if(row["iState_Command"]!=null && row["iState_Command"].ToString()!="")
				{
					model.iState_Command=int.Parse(row["iState_Command"].ToString());
				}
				if(row["sMeasureConfigGUID"]!=null)
				{
					model.sMeasureConfigGUID=row["sMeasureConfigGUID"].ToString();
				}
				if(row["sRelayInfoGUID"]!=null)
				{
					model.sRelayInfoGUID=row["sRelayInfoGUID"].ToString();
				}
				if(row["sSwitchConfigGUID"]!=null)
				{
					model.sSwitchConfigGUID=row["sSwitchConfigGUID"].ToString();
				}
				if(row["dCreateTime"]!=null && row["dCreateTime"].ToString()!="")
				{
					model.dCreateTime=DateTime.Parse(row["dCreateTime"].ToString());
				}
				if(row["dUpdateTime"]!=null && row["dUpdateTime"].ToString()!="")
				{
					model.dUpdateTime=DateTime.Parse(row["dUpdateTime"].ToString());
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
			strSql.Append("select sGUID,iID,sName,fCurrentHI,fCurrentLO,fCurrentZO,iCurrentSD,iVoltType,fRatio,iEnable,iState_Command,sMeasureConfigGUID,sRelayInfoGUID,sSwitchConfigGUID,dCreateTime,dUpdateTime,sDesc ");
			strSql.Append(" FROM tBranchConfigs ");
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
			strSql.Append(" sGUID,iID,sName,fCurrentHI,fCurrentLO,fCurrentZO,iCurrentSD,iVoltType,fRatio,iEnable,iState_Command,sMeasureConfigGUID,sRelayInfoGUID,sSwitchConfigGUID,dCreateTime,dUpdateTime,sDesc ");
			strSql.Append(" FROM tBranchConfigs ");
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
			strSql.Append("select count(1) FROM tBranchConfigs ");
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
			strSql.Append(")AS Row, T.*  from tBranchConfigs T ");
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
			parameters[0].Value = "tBranchConfigs";
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

