/**  版本信息模板在安装目录下，可自行修改。
* tLightInfoes.cs
*
* 功 能： N/A
* 类 名： tLightInfoes
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
	/// 数据访问类:tLightInfoes
	/// </summary>
	public partial class tLightInfoes
	{
		public tLightInfoes()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sGUID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tLightInfoes");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36)			};
			parameters[0].Value = sGUID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(LumluxSSYDB.Model.tLightInfoes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tLightInfoes(");
			strSql.Append("sGUID,sName,sLightID,sLightPhyID,fLng,fLat,sAddr,iState_Command,iAlarmConfig_Config,dAlarmConfig_Start,dAlarmConfig_End,sAlarmConfig_Remark,iRealTimeAlarm_FaultState,iRealTimeAlarm_Fault,iRealTimeAlarm_CreateDateTime,sHostInfoGUID,sStateGUID,dCreateTime,dUpdateTime,sRemark,sHardware_Version,iHardware_Type,iEnable)");
			strSql.Append(" values (");
			strSql.Append("@sGUID,@sName,@sLightID,@sLightPhyID,@fLng,@fLat,@sAddr,@iState_Command,@iAlarmConfig_Config,@dAlarmConfig_Start,@dAlarmConfig_End,@sAlarmConfig_Remark,@iRealTimeAlarm_FaultState,@iRealTimeAlarm_Fault,@iRealTimeAlarm_CreateDateTime,@sHostInfoGUID,@sStateGUID,@dCreateTime,@dUpdateTime,@sRemark,@sHardware_Version,@iHardware_Type,@iEnable)");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36),
					new SqlParameter("@sName", SqlDbType.NVarChar,100),
					new SqlParameter("@sLightID", SqlDbType.NVarChar,100),
					new SqlParameter("@sLightPhyID", SqlDbType.NVarChar,50),
					new SqlParameter("@fLng", SqlDbType.Float,8),
					new SqlParameter("@fLat", SqlDbType.Float,8),
					new SqlParameter("@sAddr", SqlDbType.NVarChar,100),
					new SqlParameter("@iState_Command", SqlDbType.Int,4),
					new SqlParameter("@iAlarmConfig_Config", SqlDbType.Int,4),
					new SqlParameter("@dAlarmConfig_Start", SqlDbType.DateTime),
					new SqlParameter("@dAlarmConfig_End", SqlDbType.DateTime),
					new SqlParameter("@sAlarmConfig_Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@iRealTimeAlarm_FaultState", SqlDbType.Int,4),
					new SqlParameter("@iRealTimeAlarm_Fault", SqlDbType.Int,4),
					new SqlParameter("@iRealTimeAlarm_CreateDateTime", SqlDbType.DateTime),
					new SqlParameter("@sHostInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@sStateGUID", SqlDbType.Char,36),
					new SqlParameter("@dCreateTime", SqlDbType.DateTime),
					new SqlParameter("@dUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@sRemark", SqlDbType.NVarChar,500),
					new SqlParameter("@sHardware_Version", SqlDbType.NVarChar,200),
					new SqlParameter("@iHardware_Type", SqlDbType.Int,4),
					new SqlParameter("@iEnable", SqlDbType.Int,4)};
			parameters[0].Value = model.sGUID;
			parameters[1].Value = model.sName;
			parameters[2].Value = model.sLightID;
			parameters[3].Value = model.sLightPhyID;
			parameters[4].Value = model.fLng;
			parameters[5].Value = model.fLat;
			parameters[6].Value = model.sAddr;
			parameters[7].Value = model.iState_Command;
			parameters[8].Value = model.iAlarmConfig_Config;
			parameters[9].Value = model.dAlarmConfig_Start;
			parameters[10].Value = model.dAlarmConfig_End;
			parameters[11].Value = model.sAlarmConfig_Remark;
			parameters[12].Value = model.iRealTimeAlarm_FaultState;
			parameters[13].Value = model.iRealTimeAlarm_Fault;
			parameters[14].Value = model.iRealTimeAlarm_CreateDateTime;
			parameters[15].Value = model.sHostInfoGUID;
			parameters[16].Value = model.sStateGUID;
			parameters[17].Value = model.dCreateTime;
			parameters[18].Value = model.dUpdateTime;
			parameters[19].Value = model.sRemark;
			parameters[20].Value = model.sHardware_Version;
			parameters[21].Value = model.iHardware_Type;
			parameters[22].Value = model.iEnable;

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
		public bool Update(LumluxSSYDB.Model.tLightInfoes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tLightInfoes set ");
			strSql.Append("sName=@sName,");
			strSql.Append("sLightID=@sLightID,");
			strSql.Append("sLightPhyID=@sLightPhyID,");
			strSql.Append("fLng=@fLng,");
			strSql.Append("fLat=@fLat,");
			strSql.Append("sAddr=@sAddr,");
			strSql.Append("iState_Command=@iState_Command,");
			strSql.Append("iAlarmConfig_Config=@iAlarmConfig_Config,");
			strSql.Append("dAlarmConfig_Start=@dAlarmConfig_Start,");
			strSql.Append("dAlarmConfig_End=@dAlarmConfig_End,");
			strSql.Append("sAlarmConfig_Remark=@sAlarmConfig_Remark,");
			strSql.Append("iRealTimeAlarm_FaultState=@iRealTimeAlarm_FaultState,");
			strSql.Append("iRealTimeAlarm_Fault=@iRealTimeAlarm_Fault,");
			strSql.Append("iRealTimeAlarm_CreateDateTime=@iRealTimeAlarm_CreateDateTime,");
			strSql.Append("sHostInfoGUID=@sHostInfoGUID,");
			strSql.Append("sStateGUID=@sStateGUID,");
			strSql.Append("dCreateTime=@dCreateTime,");
			strSql.Append("dUpdateTime=@dUpdateTime,");
			strSql.Append("sRemark=@sRemark,");
			strSql.Append("sHardware_Version=@sHardware_Version,");
			strSql.Append("iHardware_Type=@iHardware_Type,");
			strSql.Append("iEnable=@iEnable");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sName", SqlDbType.NVarChar,100),
					new SqlParameter("@sLightID", SqlDbType.NVarChar,100),
					new SqlParameter("@sLightPhyID", SqlDbType.NVarChar,50),
					new SqlParameter("@fLng", SqlDbType.Float,8),
					new SqlParameter("@fLat", SqlDbType.Float,8),
					new SqlParameter("@sAddr", SqlDbType.NVarChar,100),
					new SqlParameter("@iState_Command", SqlDbType.Int,4),
					new SqlParameter("@iAlarmConfig_Config", SqlDbType.Int,4),
					new SqlParameter("@dAlarmConfig_Start", SqlDbType.DateTime),
					new SqlParameter("@dAlarmConfig_End", SqlDbType.DateTime),
					new SqlParameter("@sAlarmConfig_Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@iRealTimeAlarm_FaultState", SqlDbType.Int,4),
					new SqlParameter("@iRealTimeAlarm_Fault", SqlDbType.Int,4),
					new SqlParameter("@iRealTimeAlarm_CreateDateTime", SqlDbType.DateTime),
					new SqlParameter("@sHostInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@sStateGUID", SqlDbType.Char,36),
					new SqlParameter("@dCreateTime", SqlDbType.DateTime),
					new SqlParameter("@dUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@sRemark", SqlDbType.NVarChar,500),
					new SqlParameter("@sHardware_Version", SqlDbType.NVarChar,200),
					new SqlParameter("@iHardware_Type", SqlDbType.Int,4),
					new SqlParameter("@iEnable", SqlDbType.Int,4),
					new SqlParameter("@sGUID", SqlDbType.Char,36)};
			parameters[0].Value = model.sName;
			parameters[1].Value = model.sLightID;
			parameters[2].Value = model.sLightPhyID;
			parameters[3].Value = model.fLng;
			parameters[4].Value = model.fLat;
			parameters[5].Value = model.sAddr;
			parameters[6].Value = model.iState_Command;
			parameters[7].Value = model.iAlarmConfig_Config;
			parameters[8].Value = model.dAlarmConfig_Start;
			parameters[9].Value = model.dAlarmConfig_End;
			parameters[10].Value = model.sAlarmConfig_Remark;
			parameters[11].Value = model.iRealTimeAlarm_FaultState;
			parameters[12].Value = model.iRealTimeAlarm_Fault;
			parameters[13].Value = model.iRealTimeAlarm_CreateDateTime;
			parameters[14].Value = model.sHostInfoGUID;
			parameters[15].Value = model.sStateGUID;
			parameters[16].Value = model.dCreateTime;
			parameters[17].Value = model.dUpdateTime;
			parameters[18].Value = model.sRemark;
			parameters[19].Value = model.sHardware_Version;
			parameters[20].Value = model.iHardware_Type;
			parameters[21].Value = model.iEnable;
			parameters[22].Value = model.sGUID;

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
			strSql.Append("delete from tLightInfoes ");
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
			strSql.Append("delete from tLightInfoes ");
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
		public LumluxSSYDB.Model.tLightInfoes GetModel(string sGUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sGUID,sName,sLightID,sLightPhyID,fLng,fLat,sAddr,iState_Command,iAlarmConfig_Config,dAlarmConfig_Start,dAlarmConfig_End,sAlarmConfig_Remark,iRealTimeAlarm_FaultState,iRealTimeAlarm_Fault,iRealTimeAlarm_CreateDateTime,sHostInfoGUID,sStateGUID,dCreateTime,dUpdateTime,sRemark,sHardware_Version,iHardware_Type,iEnable from tLightInfoes ");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36)			};
			parameters[0].Value = sGUID;

			LumluxSSYDB.Model.tLightInfoes model=new LumluxSSYDB.Model.tLightInfoes();
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
		public LumluxSSYDB.Model.tLightInfoes DataRowToModel(DataRow row)
		{
			LumluxSSYDB.Model.tLightInfoes model=new LumluxSSYDB.Model.tLightInfoes();
			if (row != null)
			{
				if(row["sGUID"]!=null)
				{
					model.sGUID=row["sGUID"].ToString();
				}
				if(row["sName"]!=null)
				{
					model.sName=row["sName"].ToString();
				}
				if(row["sLightID"]!=null)
				{
					model.sLightID=row["sLightID"].ToString();
				}
				if(row["sLightPhyID"]!=null)
				{
					model.sLightPhyID=row["sLightPhyID"].ToString();
				}
				if(row["fLng"]!=null && row["fLng"].ToString()!="")
				{
					model.fLng=decimal.Parse(row["fLng"].ToString());
				}
				if(row["fLat"]!=null && row["fLat"].ToString()!="")
				{
					model.fLat=decimal.Parse(row["fLat"].ToString());
				}
				if(row["sAddr"]!=null)
				{
					model.sAddr=row["sAddr"].ToString();
				}
				if(row["iState_Command"]!=null && row["iState_Command"].ToString()!="")
				{
					model.iState_Command=int.Parse(row["iState_Command"].ToString());
				}
				if(row["iAlarmConfig_Config"]!=null && row["iAlarmConfig_Config"].ToString()!="")
				{
					model.iAlarmConfig_Config=int.Parse(row["iAlarmConfig_Config"].ToString());
				}
				if(row["dAlarmConfig_Start"]!=null && row["dAlarmConfig_Start"].ToString()!="")
				{
					model.dAlarmConfig_Start=DateTime.Parse(row["dAlarmConfig_Start"].ToString());
				}
				if(row["dAlarmConfig_End"]!=null && row["dAlarmConfig_End"].ToString()!="")
				{
					model.dAlarmConfig_End=DateTime.Parse(row["dAlarmConfig_End"].ToString());
				}
				if(row["sAlarmConfig_Remark"]!=null)
				{
					model.sAlarmConfig_Remark=row["sAlarmConfig_Remark"].ToString();
				}
				if(row["iRealTimeAlarm_FaultState"]!=null && row["iRealTimeAlarm_FaultState"].ToString()!="")
				{
					model.iRealTimeAlarm_FaultState=int.Parse(row["iRealTimeAlarm_FaultState"].ToString());
				}
				if(row["iRealTimeAlarm_Fault"]!=null && row["iRealTimeAlarm_Fault"].ToString()!="")
				{
					model.iRealTimeAlarm_Fault=int.Parse(row["iRealTimeAlarm_Fault"].ToString());
				}
				if(row["iRealTimeAlarm_CreateDateTime"]!=null && row["iRealTimeAlarm_CreateDateTime"].ToString()!="")
				{
					model.iRealTimeAlarm_CreateDateTime=DateTime.Parse(row["iRealTimeAlarm_CreateDateTime"].ToString());
				}
				if(row["sHostInfoGUID"]!=null)
				{
					model.sHostInfoGUID=row["sHostInfoGUID"].ToString();
				}
				if(row["sStateGUID"]!=null)
				{
					model.sStateGUID=row["sStateGUID"].ToString();
				}
				if(row["dCreateTime"]!=null && row["dCreateTime"].ToString()!="")
				{
					model.dCreateTime=DateTime.Parse(row["dCreateTime"].ToString());
				}
				if(row["dUpdateTime"]!=null && row["dUpdateTime"].ToString()!="")
				{
					model.dUpdateTime=DateTime.Parse(row["dUpdateTime"].ToString());
				}
				if(row["sRemark"]!=null)
				{
					model.sRemark=row["sRemark"].ToString();
				}
				if(row["sHardware_Version"]!=null)
				{
					model.sHardware_Version=row["sHardware_Version"].ToString();
				}
				if(row["iHardware_Type"]!=null && row["iHardware_Type"].ToString()!="")
				{
					model.iHardware_Type=int.Parse(row["iHardware_Type"].ToString());
				}
				if(row["iEnable"]!=null && row["iEnable"].ToString()!="")
				{
					model.iEnable=int.Parse(row["iEnable"].ToString());
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
			strSql.Append("select sGUID,sName,sLightID,sLightPhyID,fLng,fLat,sAddr,iState_Command,iAlarmConfig_Config,dAlarmConfig_Start,dAlarmConfig_End,sAlarmConfig_Remark,iRealTimeAlarm_FaultState,iRealTimeAlarm_Fault,iRealTimeAlarm_CreateDateTime,sHostInfoGUID,sStateGUID,dCreateTime,dUpdateTime,sRemark,sHardware_Version,iHardware_Type,iEnable ");
			strSql.Append(" FROM tLightInfoes ");
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
			strSql.Append(" sGUID,sName,sLightID,sLightPhyID,fLng,fLat,sAddr,iState_Command,iAlarmConfig_Config,dAlarmConfig_Start,dAlarmConfig_End,sAlarmConfig_Remark,iRealTimeAlarm_FaultState,iRealTimeAlarm_Fault,iRealTimeAlarm_CreateDateTime,sHostInfoGUID,sStateGUID,dCreateTime,dUpdateTime,sRemark,sHardware_Version,iHardware_Type,iEnable ");
			strSql.Append(" FROM tLightInfoes ");
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
			strSql.Append("select count(1) FROM tLightInfoes ");
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
			strSql.Append(")AS Row, T.*  from tLightInfoes T ");
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
			parameters[0].Value = "tLightInfoes";
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

