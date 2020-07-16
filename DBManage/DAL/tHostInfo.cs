/**  版本信息模板在安装目录下，可自行修改。
* tHostInfo.cs
*
* 功 能： N/A
* 类 名： tHostInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/8 13:36:39   N/A    初版
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
	/// 数据访问类:tHostInfo
	/// </summary>
	public partial class tHostInfo
	{
		public tHostInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sGUID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tHostInfo");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36)			};
			parameters[0].Value = sGUID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(LumluxSSYDB.Model.tHostInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tHostInfo(");
			strSql.Append("sGUID,sName,fLng,fLat,iIDType,sID_ID,sID_Addr,sID_IP,sID_MAC,sID_SIM,sHardware_Version,iHardware_Type,iState_Online,iState_Alarm,iState_Enable,iState_Command,sGroupInfoGUID,sProjectInfoGUID,dCreateDate,dUpdateTime,sRemark,sHostInfoStateGUID)");
			strSql.Append(" values (");
			strSql.Append("@sGUID,@sName,@fLng,@fLat,@iIDType,@sID_ID,@sID_Addr,@sID_IP,@sID_MAC,@sID_SIM,@sHardware_Version,@iHardware_Type,@iState_Online,@iState_Alarm,@iState_Enable,@iState_Command,@sGroupInfoGUID,@sProjectInfoGUID,@dCreateDate,@dUpdateTime,@sRemark,@sHostInfoStateGUID)");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36),
					new SqlParameter("@sName", SqlDbType.NVarChar,100),
					new SqlParameter("@fLng", SqlDbType.Float,8),
					new SqlParameter("@fLat", SqlDbType.Float,8),
					new SqlParameter("@iIDType", SqlDbType.Int,4),
					new SqlParameter("@sID_ID", SqlDbType.VarChar,20),
					new SqlParameter("@sID_Addr", SqlDbType.NVarChar,100),
					new SqlParameter("@sID_IP", SqlDbType.NVarChar,100),
					new SqlParameter("@sID_MAC", SqlDbType.NVarChar,100),
					new SqlParameter("@sID_SIM", SqlDbType.NVarChar,100),
					new SqlParameter("@sHardware_Version", SqlDbType.NVarChar,100),
					new SqlParameter("@iHardware_Type", SqlDbType.Int,4),
					new SqlParameter("@iState_Online", SqlDbType.Int,4),
					new SqlParameter("@iState_Alarm", SqlDbType.Int,4),
					new SqlParameter("@iState_Enable", SqlDbType.Int,4),
					new SqlParameter("@iState_Command", SqlDbType.Int,4),
					new SqlParameter("@sGroupInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@sProjectInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@dCreateDate", SqlDbType.DateTime),
					new SqlParameter("@dUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@sRemark", SqlDbType.NVarChar,500),
					new SqlParameter("@sHostInfoStateGUID", SqlDbType.Char,36)};
			parameters[0].Value = model.sGUID;
			parameters[1].Value = model.sName;
			parameters[2].Value = model.fLng;
			parameters[3].Value = model.fLat;
			parameters[4].Value = model.iIDType;
			parameters[5].Value = model.sID_ID;
			parameters[6].Value = model.sID_Addr;
			parameters[7].Value = model.sID_IP;
			parameters[8].Value = model.sID_MAC;
			parameters[9].Value = model.sID_SIM;
			parameters[10].Value = model.sHardware_Version;
			parameters[11].Value = model.iHardware_Type;
			parameters[12].Value = model.iState_Online;
			parameters[13].Value = model.iState_Alarm;
			parameters[14].Value = model.iState_Enable;
			parameters[15].Value = model.iState_Command;
			parameters[16].Value = model.sGroupInfoGUID;
			parameters[17].Value = model.sProjectInfoGUID;
			parameters[18].Value = model.dCreateDate;
			parameters[19].Value = model.dUpdateTime;
			parameters[20].Value = model.sRemark;
			parameters[21].Value = model.sHostInfoStateGUID;

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
		public bool Update(LumluxSSYDB.Model.tHostInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tHostInfo set ");
			strSql.Append("sName=@sName,");
			strSql.Append("fLng=@fLng,");
			strSql.Append("fLat=@fLat,");
			strSql.Append("iIDType=@iIDType,");
			strSql.Append("sID_ID=@sID_ID,");
			strSql.Append("sID_Addr=@sID_Addr,");
			strSql.Append("sID_IP=@sID_IP,");
			strSql.Append("sID_MAC=@sID_MAC,");
			strSql.Append("sID_SIM=@sID_SIM,");
			strSql.Append("sHardware_Version=@sHardware_Version,");
			strSql.Append("iHardware_Type=@iHardware_Type,");
			strSql.Append("iState_Online=@iState_Online,");
			strSql.Append("iState_Alarm=@iState_Alarm,");
			strSql.Append("iState_Enable=@iState_Enable,");
			strSql.Append("iState_Command=@iState_Command,");
			strSql.Append("sGroupInfoGUID=@sGroupInfoGUID,");
			strSql.Append("sProjectInfoGUID=@sProjectInfoGUID,");
			strSql.Append("dCreateDate=@dCreateDate,");
			strSql.Append("dUpdateTime=@dUpdateTime,");
			strSql.Append("sRemark=@sRemark,");
			strSql.Append("sHostInfoStateGUID=@sHostInfoStateGUID");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sName", SqlDbType.NVarChar,100),
					new SqlParameter("@fLng", SqlDbType.Float,8),
					new SqlParameter("@fLat", SqlDbType.Float,8),
					new SqlParameter("@iIDType", SqlDbType.Int,4),
					new SqlParameter("@sID_ID", SqlDbType.VarChar,20),
					new SqlParameter("@sID_Addr", SqlDbType.NVarChar,100),
					new SqlParameter("@sID_IP", SqlDbType.NVarChar,100),
					new SqlParameter("@sID_MAC", SqlDbType.NVarChar,100),
					new SqlParameter("@sID_SIM", SqlDbType.NVarChar,100),
					new SqlParameter("@sHardware_Version", SqlDbType.NVarChar,100),
					new SqlParameter("@iHardware_Type", SqlDbType.Int,4),
					new SqlParameter("@iState_Online", SqlDbType.Int,4),
					new SqlParameter("@iState_Alarm", SqlDbType.Int,4),
					new SqlParameter("@iState_Enable", SqlDbType.Int,4),
					new SqlParameter("@iState_Command", SqlDbType.Int,4),
					new SqlParameter("@sGroupInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@sProjectInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@dCreateDate", SqlDbType.DateTime),
					new SqlParameter("@dUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@sRemark", SqlDbType.NVarChar,500),
					new SqlParameter("@sHostInfoStateGUID", SqlDbType.Char,36),
					new SqlParameter("@sGUID", SqlDbType.Char,36)};
			parameters[0].Value = model.sName;
			parameters[1].Value = model.fLng;
			parameters[2].Value = model.fLat;
			parameters[3].Value = model.iIDType;
			parameters[4].Value = model.sID_ID;
			parameters[5].Value = model.sID_Addr;
			parameters[6].Value = model.sID_IP;
			parameters[7].Value = model.sID_MAC;
			parameters[8].Value = model.sID_SIM;
			parameters[9].Value = model.sHardware_Version;
			parameters[10].Value = model.iHardware_Type;
			parameters[11].Value = model.iState_Online;
			parameters[12].Value = model.iState_Alarm;
			parameters[13].Value = model.iState_Enable;
			parameters[14].Value = model.iState_Command;
			parameters[15].Value = model.sGroupInfoGUID;
			parameters[16].Value = model.sProjectInfoGUID;
			parameters[17].Value = model.dCreateDate;
			parameters[18].Value = model.dUpdateTime;
			parameters[19].Value = model.sRemark;
			parameters[20].Value = model.sHostInfoStateGUID;
			parameters[21].Value = model.sGUID;

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
			strSql.Append("delete from tHostInfo ");
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
			strSql.Append("delete from tHostInfo ");
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
		public LumluxSSYDB.Model.tHostInfo GetModel(string sGUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sGUID,sName,fLng,fLat,iIDType,sID_ID,sID_Addr,sID_IP,sID_MAC,sID_SIM,sHardware_Version,iHardware_Type,iState_Online,iState_Alarm,iState_Enable,iState_Command,sGroupInfoGUID,sProjectInfoGUID,dCreateDate,dUpdateTime,sRemark,sHostInfoStateGUID from tHostInfo ");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36)			};
			parameters[0].Value = sGUID;

			LumluxSSYDB.Model.tHostInfo model=new LumluxSSYDB.Model.tHostInfo();
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
		public LumluxSSYDB.Model.tHostInfo DataRowToModel(DataRow row)
		{
			LumluxSSYDB.Model.tHostInfo model=new LumluxSSYDB.Model.tHostInfo();
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
				if(row["fLng"]!=null && row["fLng"].ToString()!="")
				{
					model.fLng=decimal.Parse(row["fLng"].ToString());
				}
				if(row["fLat"]!=null && row["fLat"].ToString()!="")
				{
					model.fLat=decimal.Parse(row["fLat"].ToString());
				}
				if(row["iIDType"]!=null && row["iIDType"].ToString()!="")
				{
					model.iIDType=int.Parse(row["iIDType"].ToString());
				}
				if(row["sID_ID"]!=null)
				{
					model.sID_ID=row["sID_ID"].ToString();
				}
				if(row["sID_Addr"]!=null)
				{
					model.sID_Addr=row["sID_Addr"].ToString();
				}
				if(row["sID_IP"]!=null)
				{
					model.sID_IP=row["sID_IP"].ToString();
				}
				if(row["sID_MAC"]!=null)
				{
					model.sID_MAC=row["sID_MAC"].ToString();
				}
				if(row["sID_SIM"]!=null)
				{
					model.sID_SIM=row["sID_SIM"].ToString();
				}
				if(row["sHardware_Version"]!=null)
				{
					model.sHardware_Version=row["sHardware_Version"].ToString();
				}
				if(row["iHardware_Type"]!=null && row["iHardware_Type"].ToString()!="")
				{
					model.iHardware_Type=int.Parse(row["iHardware_Type"].ToString());
				}
				if(row["iState_Online"]!=null && row["iState_Online"].ToString()!="")
				{
					model.iState_Online=int.Parse(row["iState_Online"].ToString());
				}
				if(row["iState_Alarm"]!=null && row["iState_Alarm"].ToString()!="")
				{
					model.iState_Alarm=int.Parse(row["iState_Alarm"].ToString());
				}
				if(row["iState_Enable"]!=null && row["iState_Enable"].ToString()!="")
				{
					model.iState_Enable=int.Parse(row["iState_Enable"].ToString());
				}
				if(row["iState_Command"]!=null && row["iState_Command"].ToString()!="")
				{
					model.iState_Command=int.Parse(row["iState_Command"].ToString());
				}
				if(row["sGroupInfoGUID"]!=null)
				{
					model.sGroupInfoGUID=row["sGroupInfoGUID"].ToString();
				}
				if(row["sProjectInfoGUID"]!=null)
				{
					model.sProjectInfoGUID=row["sProjectInfoGUID"].ToString();
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
				if(row["sHostInfoStateGUID"]!=null)
				{
					model.sHostInfoStateGUID=row["sHostInfoStateGUID"].ToString();
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
			strSql.Append("select sGUID,sName,fLng,fLat,iIDType,sID_ID,sID_Addr,sID_IP,sID_MAC,sID_SIM,sHardware_Version,iHardware_Type,iState_Online,iState_Alarm,iState_Enable,iState_Command,sGroupInfoGUID,sProjectInfoGUID,dCreateDate,dUpdateTime,sRemark,sHostInfoStateGUID ");
			strSql.Append(" FROM tHostInfo ");
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
			strSql.Append(" sGUID,sName,fLng,fLat,iIDType,sID_ID,sID_Addr,sID_IP,sID_MAC,sID_SIM,sHardware_Version,iHardware_Type,iState_Online,iState_Alarm,iState_Enable,iState_Command,sGroupInfoGUID,sProjectInfoGUID,dCreateDate,dUpdateTime,sRemark,sHostInfoStateGUID ");
			strSql.Append(" FROM tHostInfo ");
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
			strSql.Append("select count(1) FROM tHostInfo ");
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
			strSql.Append(")AS Row, T.*  from tHostInfo T ");
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
			parameters[0].Value = "tHostInfo";
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

