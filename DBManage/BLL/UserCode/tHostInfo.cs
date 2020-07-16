using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using LumluxSSYDB.Model;
namespace LumluxSSYDB.BLL
{
	/// <summary>
	/// tHostInfo
	/// </summary>
	public partial class tHostInfo
	{
		#region  ExtensionMethod
        public DataTable GetHostInfo(string strwhere)
        {
            //string sql = "select * from tHostInfo where sProjectInfoGUID='"+prjectGUID+"'";
            string sql = "SELECT   dbo.tGroupInfoes.sName AS GroupName, dbo.tPrjectInfo.sName AS PrjectName, dbo.tHostInfo.sGUID,dbo.tHostInfo.sName, dbo.tHostInfo.fLng, dbo.tHostInfo.fLat, dbo.tHostInfo.iIDType, dbo.tHostInfo.sID_Addr,dbo.tHostInfo.sID_IP, dbo.tHostInfo.sID_MAC, dbo.tHostInfo.sID_SIM, dbo.tHostInfo.sHardware_Version, dbo.tHostInfo.iHardware_Type, dbo.tHostInfo.iState_Online, dbo.tHostInfo.iState_Alarm, dbo.tHostInfo.iState_Enable,dbo.tHostInfo.iState_Command, dbo.tHostInfo.sGroupInfoGUID, dbo.tHostInfo.sProjectInfoGUID,dbo.tHostInfo.dCreateDate, dbo.tHostInfo.dUpdateTime, dbo.tHostInfo.sRemark,dbo.tHostInfo.sID_ID FROM dbo.tHostInfo LEFT JOIN dbo.tGroupInfoes ON dbo.tHostInfo.sGroupInfoGUID = dbo.tGroupInfoes.sGUID INNER JOIN dbo.tPrjectInfo ON dbo.tHostInfo.sProjectInfoGUID = dbo.tPrjectInfo.sGUID where dbo.tHostInfo.iState_Enable=1 and " + strwhere;
            DataSet ds = dal.GetBySql(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// 根据主机的ID获取相关的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.tHostInfo GetHostInfoByID(string id)
        {
            if (id == null)
                return null;
            string where = "sID_ID = '" + id + "'";
            List<Model.tHostInfo> list;
            list = GetModelList(where);
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        /// <summary>
        /// 根据项目所关联的所有主机信息
        /// </summary>
        /// <param name="prjGUID"></param>
        /// <returns></returns>
        public List<Model.tHostInfo> GetModelListByPrjGUID(string prjGUID)
        {
            if(string.IsNullOrEmpty(prjGUID))
                return null;
            return GetModelList("sProjectInfoGUID='" + prjGUID + "'");
        }
		#endregion  ExtensionMethod
	}
}

