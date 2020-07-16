/**  版本信息模板在安装目录下，可自行修改。
* tLightStateInfoes.cs
*
* 功 能： N/A
* 类 名： tLightStateInfoes
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:33   N/A    初版
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
	/// 数据访问类:tLightStateInfoes
	/// </summary>
	public partial class tLightStateInfoes
	{
		public tLightStateInfoes()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sGUID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tLightStateInfoes");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36)			};
			parameters[0].Value = sGUID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(LumluxSSYDB.Model.tLightStateInfoes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tLightStateInfoes(");
			strSql.Append("sGUID,fVoltage,fCurrent,fPower,iFault,dCreateDate,dUpdateTime,sLightInfoGUID,sSpareField1,sSpareField2,sSpareField3,sSpareField4,sSpareField5,sSpareField6,sSpareField7,sSpareField8,sSpareField9,sSpareField10)");
			strSql.Append(" values (");
			strSql.Append("@sGUID,@fVoltage,@fCurrent,@fPower,@iFault,@dCreateDate,@dUpdateTime,@sLightInfoGUID,@sSpareField1,@sSpareField2,@sSpareField3,@sSpareField4,@sSpareField5,@sSpareField6,@sSpareField7,@sSpareField8,@sSpareField9,@sSpareField10)");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36),
					new SqlParameter("@fVoltage", SqlDbType.Float,8),
					new SqlParameter("@fCurrent", SqlDbType.Float,8),
					new SqlParameter("@fPower", SqlDbType.Float,8),
					new SqlParameter("@iFault", SqlDbType.Int,4),
					new SqlParameter("@dCreateDate", SqlDbType.DateTime),
					new SqlParameter("@dUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@sLightInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@sSpareField1", SqlDbType.NVarChar,50),
					new SqlParameter("@sSpareField2", SqlDbType.NVarChar,50),
					new SqlParameter("@sSpareField3", SqlDbType.NVarChar,50),
					new SqlParameter("@sSpareField4", SqlDbType.NVarChar,50),
					new SqlParameter("@sSpareField5", SqlDbType.NVarChar,50),
					new SqlParameter("@sSpareField6", SqlDbType.NVarChar,50),
					new SqlParameter("@sSpareField7", SqlDbType.NVarChar,50),
					new SqlParameter("@sSpareField8", SqlDbType.NVarChar,50),
					new SqlParameter("@sSpareField9", SqlDbType.NVarChar,50),
					new SqlParameter("@sSpareField10", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.sGUID;
			parameters[1].Value = model.fVoltage;
			parameters[2].Value = model.fCurrent;
			parameters[3].Value = model.fPower;
			parameters[4].Value = model.iFault;
			parameters[5].Value = model.dCreateDate;
			parameters[6].Value = model.dUpdateTime;
			parameters[7].Value = model.sLightInfoGUID;
			parameters[8].Value = model.sSpareField1;
			parameters[9].Value = model.sSpareField2;
			parameters[10].Value = model.sSpareField3;
			parameters[11].Value = model.sSpareField4;
			parameters[12].Value = model.sSpareField5;
			parameters[13].Value = model.sSpareField6;
			parameters[14].Value = model.sSpareField7;
			parameters[15].Value = model.sSpareField8;
			parameters[16].Value = model.sSpareField9;
			parameters[17].Value = model.sSpareField10;

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
		public bool Update(LumluxSSYDB.Model.tLightStateInfoes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tLightStateInfoes set ");
			strSql.Append("fVoltage=@fVoltage,");
			strSql.Append("fCurrent=@fCurrent,");
			strSql.Append("fPower=@fPower,");
			strSql.Append("iFault=@iFault,");
			strSql.Append("dCreateDate=@dCreateDate,");
			strSql.Append("dUpdateTime=@dUpdateTime,");
			strSql.Append("sLightInfoGUID=@sLightInfoGUID,");
			strSql.Append("sSpareField1=@sSpareField1,");
			strSql.Append("sSpareField2=@sSpareField2,");
			strSql.Append("sSpareField3=@sSpareField3,");
			strSql.Append("sSpareField4=@sSpareField4,");
			strSql.Append("sSpareField5=@sSpareField5,");
			strSql.Append("sSpareField6=@sSpareField6,");
			strSql.Append("sSpareField7=@sSpareField7,");
			strSql.Append("sSpareField8=@sSpareField8,");
			strSql.Append("sSpareField9=@sSpareField9,");
			strSql.Append("sSpareField10=@sSpareField10");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@fVoltage", SqlDbType.Float,8),
					new SqlParameter("@fCurrent", SqlDbType.Float,8),
					new SqlParameter("@fPower", SqlDbType.Float,8),
					new SqlParameter("@iFault", SqlDbType.Int,4),
					new SqlParameter("@dCreateDate", SqlDbType.DateTime),
					new SqlParameter("@dUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@sLightInfoGUID", SqlDbType.Char,36),
					new SqlParameter("@sSpareField1", SqlDbType.NVarChar,50),
					new SqlParameter("@sSpareField2", SqlDbType.NVarChar,50),
					new SqlParameter("@sSpareField3", SqlDbType.NVarChar,50),
					new SqlParameter("@sSpareField4", SqlDbType.NVarChar,50),
					new SqlParameter("@sSpareField5", SqlDbType.NVarChar,50),
					new SqlParameter("@sSpareField6", SqlDbType.NVarChar,50),
					new SqlParameter("@sSpareField7", SqlDbType.NVarChar,50),
					new SqlParameter("@sSpareField8", SqlDbType.NVarChar,50),
					new SqlParameter("@sSpareField9", SqlDbType.NVarChar,50),
					new SqlParameter("@sSpareField10", SqlDbType.NVarChar,50),
					new SqlParameter("@sGUID", SqlDbType.Char,36)};
			parameters[0].Value = model.fVoltage;
			parameters[1].Value = model.fCurrent;
			parameters[2].Value = model.fPower;
			parameters[3].Value = model.iFault;
			parameters[4].Value = model.dCreateDate;
			parameters[5].Value = model.dUpdateTime;
			parameters[6].Value = model.sLightInfoGUID;
			parameters[7].Value = model.sSpareField1;
			parameters[8].Value = model.sSpareField2;
			parameters[9].Value = model.sSpareField3;
			parameters[10].Value = model.sSpareField4;
			parameters[11].Value = model.sSpareField5;
			parameters[12].Value = model.sSpareField6;
			parameters[13].Value = model.sSpareField7;
			parameters[14].Value = model.sSpareField8;
			parameters[15].Value = model.sSpareField9;
			parameters[16].Value = model.sSpareField10;
			parameters[17].Value = model.sGUID;

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
			strSql.Append("delete from tLightStateInfoes ");
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
			strSql.Append("delete from tLightStateInfoes ");
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
		public LumluxSSYDB.Model.tLightStateInfoes GetModel(string sGUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sGUID,fVoltage,fCurrent,fPower,iFault,dCreateDate,dUpdateTime,sLightInfoGUID,sSpareField1,sSpareField2,sSpareField3,sSpareField4,sSpareField5,sSpareField6,sSpareField7,sSpareField8,sSpareField9,sSpareField10 from tLightStateInfoes ");
			strSql.Append(" where sGUID=@sGUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sGUID", SqlDbType.Char,36)			};
			parameters[0].Value = sGUID;

			LumluxSSYDB.Model.tLightStateInfoes model=new LumluxSSYDB.Model.tLightStateInfoes();
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
		public LumluxSSYDB.Model.tLightStateInfoes DataRowToModel(DataRow row)
		{
			LumluxSSYDB.Model.tLightStateInfoes model=new LumluxSSYDB.Model.tLightStateInfoes();
			if (row != null)
			{
				if(row["sGUID"]!=null)
				{
					model.sGUID=row["sGUID"].ToString();
				}
				if(row["fVoltage"]!=null && row["fVoltage"].ToString()!="")
				{
					model.fVoltage=decimal.Parse(row["fVoltage"].ToString());
				}
				if(row["fCurrent"]!=null && row["fCurrent"].ToString()!="")
				{
					model.fCurrent=decimal.Parse(row["fCurrent"].ToString());
				}
				if(row["fPower"]!=null && row["fPower"].ToString()!="")
				{
					model.fPower=decimal.Parse(row["fPower"].ToString());
				}
				if(row["iFault"]!=null && row["iFault"].ToString()!="")
				{
					model.iFault=int.Parse(row["iFault"].ToString());
				}
				if(row["dCreateDate"]!=null && row["dCreateDate"].ToString()!="")
				{
					model.dCreateDate=DateTime.Parse(row["dCreateDate"].ToString());
				}
				if(row["dUpdateTime"]!=null && row["dUpdateTime"].ToString()!="")
				{
					model.dUpdateTime=DateTime.Parse(row["dUpdateTime"].ToString());
				}
				if(row["sLightInfoGUID"]!=null)
				{
					model.sLightInfoGUID=row["sLightInfoGUID"].ToString();
				}
				if(row["sSpareField1"]!=null)
				{
					model.sSpareField1=row["sSpareField1"].ToString();
				}
				if(row["sSpareField2"]!=null)
				{
					model.sSpareField2=row["sSpareField2"].ToString();
				}
				if(row["sSpareField3"]!=null)
				{
					model.sSpareField3=row["sSpareField3"].ToString();
				}
				if(row["sSpareField4"]!=null)
				{
					model.sSpareField4=row["sSpareField4"].ToString();
				}
				if(row["sSpareField5"]!=null)
				{
					model.sSpareField5=row["sSpareField5"].ToString();
				}
				if(row["sSpareField6"]!=null)
				{
					model.sSpareField6=row["sSpareField6"].ToString();
				}
				if(row["sSpareField7"]!=null)
				{
					model.sSpareField7=row["sSpareField7"].ToString();
				}
				if(row["sSpareField8"]!=null)
				{
					model.sSpareField8=row["sSpareField8"].ToString();
				}
				if(row["sSpareField9"]!=null)
				{
					model.sSpareField9=row["sSpareField9"].ToString();
				}
				if(row["sSpareField10"]!=null)
				{
					model.sSpareField10=row["sSpareField10"].ToString();
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
			strSql.Append("select sGUID,fVoltage,fCurrent,fPower,iFault,dCreateDate,dUpdateTime,sLightInfoGUID,sSpareField1,sSpareField2,sSpareField3,sSpareField4,sSpareField5,sSpareField6,sSpareField7,sSpareField8,sSpareField9,sSpareField10 ");
			strSql.Append(" FROM tLightStateInfoes ");
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
			strSql.Append(" sGUID,fVoltage,fCurrent,fPower,iFault,dCreateDate,dUpdateTime,sLightInfoGUID,sSpareField1,sSpareField2,sSpareField3,sSpareField4,sSpareField5,sSpareField6,sSpareField7,sSpareField8,sSpareField9,sSpareField10 ");
			strSql.Append(" FROM tLightStateInfoes ");
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
			strSql.Append("select count(1) FROM tLightStateInfoes ");
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
			strSql.Append(")AS Row, T.*  from tLightStateInfoes T ");
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
			parameters[0].Value = "tLightStateInfoes";
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

