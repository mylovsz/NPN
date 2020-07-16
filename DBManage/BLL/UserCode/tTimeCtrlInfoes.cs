/**  版本信息模板在安装目录下，可自行修改。
* tTimeCtrlInfoes.cs
*
* 功 能： N/A
* 类 名： tTimeCtrlInfoes
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 20:01:37   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using LumluxSSYDB.Model;
namespace LumluxSSYDB.BLL
{
	/// <summary>
	/// tTimeCtrlInfoes
	/// </summary>
	public partial class tTimeCtrlInfoes
	{

		#region  ExtensionMethod
        public DataTable GetTimeCtrlInfo(string hostGUID, int startCount, int endCount)
        {
            //string sql = "select * from tHostInfo where sProjectInfoGUID='"+prjectGUID+"'";
            //string sql = "select * from tTimeCtrlInfoes where sHostInfoGUID='" + hostGUID + "' and  iID  between '" + startCount + "' and '" + endCount + "'";
            //string sql = "SELECT   dbo.tTimeCtrlInfoes.sGUID, dbo.tTimeCtrlInfoes.iID, dbo.tTimeCtrlInfoes.dTime, dbo.tTimeCtrlInfoes.iEnable,dbo.tTimeCtrlInfoes.iState_Command, dbo.tTimeCtrlInfoes.dCreateDate, dbo.tTimeCtrlInfoes.dUpdateTime,dbo.tTimeCtrlInfoes.sHostInfoGUID, dbo.tTimeCtrlInfoes.sTagGUID, dbo.tTimeCtrlInfoes.sDesc, dbo.tHostInfo.sName,dbo.tHostInfo.iHardware_Type FROM      dbo.tTimeCtrlInfoes INNER JOIN dbo.tHostInfo ON dbo.tTimeCtrlInfoes.sHostInfoGUID = dbo.tHostInfo.sGUID WHERE   (dbo.tTimeCtrlInfoes.sHostInfoGUID = '" + hostGUID + "') AND (dbo.tTimeCtrlInfoes.iID BETWEEN '" + startCount + "' AND '" + endCount + "')";
            string sql = "SELECT   dbo.tTimeCtrlInfoes.sGUID, dbo.tTimeCtrlInfoes.iID, dbo.tTimeCtrlInfoes.dTime, dbo.tTimeCtrlInfoes.iEnable,dbo.tTimeCtrlInfoes.iState_Command, dbo.tTimeCtrlInfoes.dCreateDate, dbo.tTimeCtrlInfoes.dUpdateTime,dbo.tTimeCtrlInfoes.sHostInfoGUID, dbo.tTimeCtrlInfoes.sTagGUID, dbo.tTimeCtrlInfoes.sDesc,dbo.tCtrlTagInfoes.sRelayState, dbo.tCtrlTagInfoes.sRelayInfo_GUID, dbo.tCtrlTagInfoes.sLightGroupState,dbo.tCtrlTagInfoes.sLightGroupGUID, dbo.tCtrlTagInfoes.iType, dbo.tHostInfo.sName,dbo.tHostInfo.iHardware_Type FROM      dbo.tTimeCtrlInfoes LEFT OUTER JOIN dbo.tCtrlTagInfoes ON dbo.tTimeCtrlInfoes.sTagGUID = dbo.tCtrlTagInfoes.sGUID INNER JOIN dbo.tHostInfo ON dbo.tTimeCtrlInfoes.sHostInfoGUID = dbo.tHostInfo.sGUID WHERE   (dbo.tTimeCtrlInfoes.sHostInfoGUID = '" + hostGUID + "') AND (dbo.tTimeCtrlInfoes.iID BETWEEN  '" + startCount + "' AND '" + endCount + "')";
            
            DataSet ds = dal.GetBySql(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        public DataTable GetTimeCtrlInfoByOne(string sGUID)
        {
            //string sql = "select * from tHostInfo where sProjectInfoGUID='"+prjectGUID+"'";
            //string sql = "select * from tTimeCtrlInfoes where sGUID='" + sGUID + "'";
            //string sql = "SELECT   dbo.tTimeCtrlInfoes.sGUID, dbo.tTimeCtrlInfoes.iID, dbo.tTimeCtrlInfoes.dTime, dbo.tTimeCtrlInfoes.iEnable,dbo.tTimeCtrlInfoes.iState_Command, dbo.tTimeCtrlInfoes.dCreateDate, dbo.tTimeCtrlInfoes.dUpdateTime,dbo.tTimeCtrlInfoes.sHostInfoGUID, dbo.tTimeCtrlInfoes.sTagGUID, dbo.tTimeCtrlInfoes.sDesc, dbo.tHostInfo.sName,dbo.tHostInfo.iHardware_Type FROM      dbo.tTimeCtrlInfoes INNER JOIN dbo.tHostInfo ON dbo.tTimeCtrlInfoes.sHostInfoGUID = dbo.tHostInfo.sGUID WHERE   (dbo.tTimeCtrlInfoes.sGUID = '" + sGUID + "')";
            string sql = "SELECT   dbo.tTimeCtrlInfoes.sGUID, dbo.tTimeCtrlInfoes.iID, dbo.tTimeCtrlInfoes.dTime, dbo.tTimeCtrlInfoes.iEnable,dbo.tTimeCtrlInfoes.iState_Command, dbo.tTimeCtrlInfoes.dCreateDate, dbo.tTimeCtrlInfoes.dUpdateTime,dbo.tTimeCtrlInfoes.sHostInfoGUID, dbo.tTimeCtrlInfoes.sTagGUID, dbo.tTimeCtrlInfoes.sDesc,dbo.tCtrlTagInfoes.sRelayState, dbo.tCtrlTagInfoes.sRelayInfo_GUID, dbo.tCtrlTagInfoes.sLightGroupState,dbo.tCtrlTagInfoes.sLightGroupGUID, dbo.tCtrlTagInfoes.iType, dbo.tHostInfo.sName,dbo.tHostInfo.iHardware_Type FROM      dbo.tTimeCtrlInfoes LEFT OUTER JOIN dbo.tCtrlTagInfoes ON dbo.tTimeCtrlInfoes.sTagGUID = dbo.tCtrlTagInfoes.sGUID INNER JOIN dbo.tHostInfo ON dbo.tTimeCtrlInfoes.sHostInfoGUID = dbo.tHostInfo.sGUID WHERE   (dbo.tTimeCtrlInfoes.sGUID = '" + sGUID + "')";
            DataSet ds = dal.GetBySql(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
		#endregion  ExtensionMethod
	}
}

