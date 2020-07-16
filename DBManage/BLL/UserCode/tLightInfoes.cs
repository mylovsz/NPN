using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using LumluxSSYDB.Model;
namespace LumluxSSYDB.BLL
{
	/// <summary>
	/// tLightInfoes
	/// </summary>
	public partial class tLightInfoes
	{
		#region  ExtensionMethod
        public List<Model.tLightInfoes> GetModelListByHostGUID(string hostGUID)
        {
            if (string.IsNullOrEmpty(hostGUID))
                return null;
            return GetModelList("sHostInfoGUID='" + hostGUID + "' and iEnable=1 order by sName");
        }
        public DataTable GetLightByWhereInfo(string strwhere)
        {
            string sql = "select row_number() over (order by h.sName, ls.dUpdateTime, li.sName) as iNum,h.sName as hostName, li.sGUID as lightGUID, li.sName as lightName,li.sLightID,li.sLightPhyID,li.fLng,li.fLat,li.sAddr,li.iState_Command, li.iAlarmConfig_Config,li.dAlarmConfig_Start,li.dAlarmConfig_End,li.sAlarmConfig_Remark,li.iRealTimeAlarm_FaultState,li.iRealTimeAlarm_Fault,li.iRealTimeAlarm_CreateDateTime,li.sHostInfoGUID,li.dCreateTime as lightCreateTime,li.dUpdateTime as lightUpadateTime ,li.sRemark,li.sHardware_Version,li.iHardware_Type as iHType,li.iEnable,ls.sGUID as lightStateGUID,ls.fVoltage,ls.fCurrent,ls.fPower,ls.iFault,ls.dCreateDate as lightStateCreateTime,ls.dUpdateTime as lightStateUpdateTime,ls.sLightInfoGUID,ls.sSpareField1,ls.sSpareField2,ls.sSpareField3,ls.sSpareField4,ls.sSpareField5,ls.sSpareField6,ls.sSpareField7,ls.sSpareField8,ls.sSpareField9,ls.sSpareField10   from tLightInfoes as li left join tLightStateInfoes  as ls on li.sStateGUID=ls.sGUID inner join tHostInfo as h on li.sHostInfoGUID=h.sGUID where " + strwhere;
            DataSet ds = dal.GetBySql(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        public DataTable GetAllLightAlarmByWhereInfo(string prjGUID, DateTime startTime, DateTime endTime, int iCount, int iSize,string LightName)
        {

            string sql = "SELECT TOP 10 *,(select count(1) from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID inner join tHostInfo as h on li.sHostInfoGUID=h.sGUID  where " + LightName + "  h.sProjectInfoGUID='" + prjGUID + "' and ls.dUpdateTime >='" + startTime + "' and ls.dUpdateTime <= '" + endTime + "' ) as scount  FROM (select row_number() over (order by h.sName, ls.dUpdateTime, li.sName) as iNum,h.sName as hostName, li.sGUID as lightGUID, li.sName as lightName,li.sLightID,li.sLightPhyID,li.iHardware_Type as iHType,li.fLng,li.fLat,li.sAddr,li.iState_Command, li.iAlarmConfig_Config,li.dAlarmConfig_Start,li.dAlarmConfig_End,li.sAlarmConfig_Remark,li.iRealTimeAlarm_FaultState,li.iRealTimeAlarm_Fault,li.iRealTimeAlarm_CreateDateTime,li.sHostInfoGUID,li.dCreateTime as lightCreateTime,li.dUpdateTime as lightUpadateTime ,li.sRemark,li.sHardware_Version,li.iEnable,ls.sGUID as lightStateGUID,ls.fVoltage,ls.fCurrent,ls.fPower,ls.iFault,ls.dCreateDate as lightStateCreateTime,ls.dUpdateTime as lightStateUpdateTime,ls.sLightInfoGUID,ls.sSpareField1,ls.sSpareField2,ls.sSpareField3,ls.sSpareField4,ls.sSpareField5,ls.sSpareField6,ls.sSpareField7,ls.sSpareField8,ls.sSpareField9,ls.sSpareField10   from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID inner join tHostInfo as h on li.sHostInfoGUID=h.sGUID  where " + LightName + " li.iEnable=1 and h.sProjectInfoGUID='" + prjGUID + "' and ls.dUpdateTime >='" + startTime + "' and ls.dUpdateTime <= '" + endTime + "')   as A WHERE iNum > " + iCount + "*(" + iSize + "-1) order by iNum ";
            //string sql = "select row_number() over (order by ls.dUpdateTime) as iNum, li.sGUID as lightGUID, li.sName as lightName,li.sLightID,li.sLightPhyID,li.fLng,li.fLat,li.sAddr,li.iState_Command, li.iAlarmConfig_Config,li.dAlarmConfig_Start,li.dAlarmConfig_End,li.sAlarmConfig_Remark,li.iRealTimeAlarm_FaultState,li.iRealTimeAlarm_Fault,li.iRealTimeAlarm_CreateDateTime,li.sHostInfoGUID,li.dCreateTime as lightCreateTime,li.dUpdateTime as lightUpadateTime ,li.sRemark,ls.sGUID as lightStateGUID,ls.fVoltage,ls.fCurrent,ls.fPower,ls.iFault,ls.dCreateDate as lightStateCreateTime,ls.dUpdateTime as lightStateUpdateTime,ls.sLightInfoGUID,ls.sSpareField1,ls.sSpareField2,ls.sSpareField3,ls.sSpareField4,ls.sSpareField5,ls.sSpareField6,ls.sSpareField7,ls.sSpareField8,ls.sSpareField9,ls.sSpareField10   from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID where " + strwhere;
            DataSet ds = dal.GetBySql(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        public DataTable GetAllLightAlarmByWhereInfo(string prjGUID, string sHostGUID, DateTime startTime, DateTime endTime, int iCount, int iSize,string LightName)
        {

            string sql = "SELECT TOP 10 *,(select count(1) from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID inner join tHostInfo as h on li.sHostInfoGUID=h.sGUID  where " + LightName + "  h.sProjectInfoGUID='" + prjGUID + "' and sHostInfoGUID='" + sHostGUID + "' and ls.dUpdateTime >='" + startTime + "' and ls.dUpdateTime <= '" + endTime + "' ) as scount FROM (select row_number() over ( order byh.sName, ls.dUpdateTime, li.sName) as iNum,h.sName as hostName, li.sGUID as lightGUID, li.sName as lightName,li.sLightID,li.sLightPhyID as iHType,li.fLng,li.fLat,li.sAddr,li.iState_Command, li.iAlarmConfig_Config,li.dAlarmConfig_Start,li.dAlarmConfig_End,li.sAlarmConfig_Remark,li.iRealTimeAlarm_FaultState,li.iRealTimeAlarm_Fault,li.iRealTimeAlarm_CreateDateTime,li.sHostInfoGUID,li.dCreateTime as lightCreateTime,li.dUpdateTime as lightUpadateTime ,li.sRemark,li.sHardware_Version,li.iHardware_Type,li.iEnable,ls.sGUID as lightStateGUID,ls.fVoltage,ls.fCurrent,ls.fPower,ls.iFault,ls.dCreateDate as lightStateCreateTime,ls.dUpdateTime as lightStateUpdateTime,ls.sLightInfoGUID,ls.sSpareField1,ls.sSpareField2,ls.sSpareField3,ls.sSpareField4,ls.sSpareField5,ls.sSpareField6,ls.sSpareField7,ls.sSpareField8,ls.sSpareField9,ls.sSpareField10   from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID inner join tHostInfo as h on li.sHostInfoGUID=h.sGUID  where " + LightName + " li.iEnable=1 and h.sProjectInfoGUID='" + prjGUID + "' and sHostInfoGUID='" + sHostGUID + "' and ls.dUpdateTime >='" + startTime + "' and ls.dUpdateTime <= '" + endTime + "')   as A WHERE iNum > " + iCount + "*(" + iSize + "-1) order by iNum";
            //string sql = "select row_number() over (order by ls.dUpdateTime) as iNum, li.sGUID as lightGUID, li.sName as lightName,li.sLightID,li.sLightPhyID,li.fLng,li.fLat,li.sAddr,li.iState_Command, li.iAlarmConfig_Config,li.dAlarmConfig_Start,li.dAlarmConfig_End,li.sAlarmConfig_Remark,li.iRealTimeAlarm_FaultState,li.iRealTimeAlarm_Fault,li.iRealTimeAlarm_CreateDateTime,li.sHostInfoGUID,li.dCreateTime as lightCreateTime,li.dUpdateTime as lightUpadateTime ,li.sRemark,ls.sGUID as lightStateGUID,ls.fVoltage,ls.fCurrent,ls.fPower,ls.iFault,ls.dCreateDate as lightStateCreateTime,ls.dUpdateTime as lightStateUpdateTime,ls.sLightInfoGUID,ls.sSpareField1,ls.sSpareField2,ls.sSpareField3,ls.sSpareField4,ls.sSpareField5,ls.sSpareField6,ls.sSpareField7,ls.sSpareField8,ls.sSpareField9,ls.sSpareField10   from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID where " + strwhere;
            DataSet ds = dal.GetBySql(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        public DataTable GetAllLightAlarmByWhereInfo(string prjGUID, string sHostGUID, string AlarmWhere, DateTime startTime, DateTime endTime, int iCount, int iSize,string LightName)
        {

            string sql = "SELECT TOP 10 * ,(select count(1) from tLightStateInfoes where  " + LightName + "  ) as scount FROM (select row_number() over (order by h.sName, ls.dUpdateTime,li.sName) as iNum,h.sName as hostName,li.sGUID as lightGUID, li.sName as lightName,li.sLightID,li.sLightPhyID,li.iHardware_Type as iHType,li.fLng,li.fLat,li.sAddr,li.iState_Command, li.iAlarmConfig_Config,li.dAlarmConfig_Start,li.dAlarmConfig_End,li.sAlarmConfig_Remark,li.iRealTimeAlarm_FaultState,li.iRealTimeAlarm_Fault,li.iRealTimeAlarm_CreateDateTime,li.sHostInfoGUID,li.dCreateTime as lightCreateTime,li.dUpdateTime as lightUpadateTime ,li.sRemark,ls.sGUID as lightStateGUID,ls.fVoltage,ls.fCurrent,ls.fPower,ls.iFault,ls.dCreateDate as lightStateCreateTime,ls.dUpdateTime as lightStateUpdateTime,ls.sLightInfoGUID,ls.sSpareField1,ls.sSpareField2,ls.sSpareField3,ls.sSpareField4,ls.sSpareField5,ls.sSpareField6,ls.sSpareField7,ls.sSpareField8,ls.sSpareField9,ls.sSpareField10   from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID inner join tHostInfo as h on li.sHostInfoGUID=h.sGUID  where " + LightName + " h.sProjectInfoGUID='" + prjGUID + "'(" + AlarmWhere + ") and sHostInfoGUID='" + sHostGUID + "' and ls.dUpdateTime >='" + startTime + "' and ls.dUpdateTime <= '" + endTime + "')   as A WHERE iNum > " + iCount + "*(" + iSize + "-1) order by iNum";
            //string sql = "select row_number() over (order by ls.dUpdateTime) as iNum, li.sGUID as lightGUID, li.sName as lightName,li.sLightID,li.sLightPhyID,li.fLng,li.fLat,li.sAddr,li.iState_Command, li.iAlarmConfig_Config,li.dAlarmConfig_Start,li.dAlarmConfig_End,li.sAlarmConfig_Remark,li.iRealTimeAlarm_FaultState,li.iRealTimeAlarm_Fault,li.iRealTimeAlarm_CreateDateTime,li.sHostInfoGUID,li.dCreateTime as lightCreateTime,li.dUpdateTime as lightUpadateTime ,li.sRemark,ls.sGUID as lightStateGUID,ls.fVoltage,ls.fCurrent,ls.fPower,ls.iFault,ls.dCreateDate as lightStateCreateTime,ls.dUpdateTime as lightStateUpdateTime,ls.sLightInfoGUID,ls.sSpareField1,ls.sSpareField2,ls.sSpareField3,ls.sSpareField4,ls.sSpareField5,ls.sSpareField6,ls.sSpareField7,ls.sSpareField8,ls.sSpareField9,ls.sSpareField10   from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID where " + strwhere;
            DataSet ds = dal.GetBySql(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        public DataTable GetAllLightAlarmByTAndWhere(string prjGUID, string strWhere, DateTime startTime, DateTime endTime, int iCount, int iSize,string LightName)
        {
            string sql = "SELECT TOP 10 * ,(select count(1) from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID inner join tHostInfo as h on li.sHostInfoGUID=h.sGUID where " + LightName + "  h.sProjectInfoGUID='" + prjGUID + "' and " + strWhere + " and ls.dUpdateTime >='" + startTime + "' and ls.dUpdateTime <= '" + endTime + "') as scount FROM (select row_number() over ( order by h.sName, ls.dUpdateTime, li.sName) as iNum,h.sName as hostName,li.sGUID as lightGUID, li.sName as lightName,li.sLightID,li.sLightPhyID,li.iHardware_Type as iHType,li.fLng,li.fLat,li.sAddr,li.iState_Command, li.iAlarmConfig_Config,li.dAlarmConfig_Start,li.dAlarmConfig_End,li.sAlarmConfig_Remark,li.iRealTimeAlarm_FaultState,li.iRealTimeAlarm_Fault,li.iRealTimeAlarm_CreateDateTime,li.sHostInfoGUID,li.dCreateTime as lightCreateTime,li.dUpdateTime as lightUpadateTime ,li.sRemark,li.sHardware_Version,li.iEnable,ls.sGUID as lightStateGUID,ls.fVoltage,ls.fCurrent,ls.fPower,ls.iFault,ls.dCreateDate as lightStateCreateTime,ls.dUpdateTime as lightStateUpdateTime,ls.sLightInfoGUID,ls.sSpareField1,ls.sSpareField2,ls.sSpareField3,ls.sSpareField4,ls.sSpareField5,ls.sSpareField6,ls.sSpareField7,ls.sSpareField8,ls.sSpareField9,ls.sSpareField10   from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID inner join tHostInfo as h on li.sHostInfoGUID=h.sGUID  where " + LightName + " li.iEnable=1 and h.sProjectInfoGUID='" + prjGUID + "' and " + strWhere + " and ls.dUpdateTime >='" + startTime + "' and ls.dUpdateTime <= '" + endTime + "')   as A WHERE iNum > " + iCount + "*(" + iSize + "-1) order by iNum";
            //string sql = "select row_number() over (order by ls.dUpdateTime) as iNum, li.sGUID as lightGUID, li.sName as lightName,li.sLightID,li.sLightPhyID,li.fLng,li.fLat,li.sAddr,li.iState_Command, li.iAlarmConfig_Config,li.dAlarmConfig_Start,li.dAlarmConfig_End,li.sAlarmConfig_Remark,li.iRealTimeAlarm_FaultState,li.iRealTimeAlarm_Fault,li.iRealTimeAlarm_CreateDateTime,li.sHostInfoGUID,li.dCreateTime as lightCreateTime,li.dUpdateTime as lightUpadateTime ,li.sRemark,ls.sGUID as lightStateGUID,ls.fVoltage,ls.fCurrent,ls.fPower,ls.iFault,ls.dCreateDate as lightStateCreateTime,ls.dUpdateTime as lightStateUpdateTime,ls.sLightInfoGUID,ls.sSpareField1,ls.sSpareField2,ls.sSpareField3,ls.sSpareField4,ls.sSpareField5,ls.sSpareField6,ls.sSpareField7,ls.sSpareField8,ls.sSpareField9,ls.sSpareField10   from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID where " + strwhere;
            DataSet ds = dal.GetBySql(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        public DataTable GetAllLightAlarmByTAndWhere(string prjGUID, string sHostGUID, string strWhere, DateTime startTime, DateTime endTime, int iCount, int iSize ,string LightName)
        {
            string sql = "SELECT TOP 10 * ,(select count(1) from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID inner join tHostInfo as h on li.sHostInfoGUID=h.sGUID where " + LightName + "   h.sProjectInfoGUID='" + prjGUID + "' and " + strWhere + " and sHostInfoGUID='" + sHostGUID + "' and ls.dUpdateTime >='" + startTime + "' and ls.dUpdateTime <= '" + endTime + "') as scount FROM (select row_number() over (order by h.sName, ls.dUpdateTime, li.sName) as iNum,h.sName as hostName,li.sGUID as lightGUID, li.sName as lightName,li.sLightID,li.sLightPhyID,li.iHardware_Type as iHType,li.fLng,li.fLat,li.sAddr,li.iState_Command, li.iAlarmConfig_Config,li.dAlarmConfig_Start,li.dAlarmConfig_End,li.sAlarmConfig_Remark,li.iRealTimeAlarm_FaultState,li.iRealTimeAlarm_Fault,li.iRealTimeAlarm_CreateDateTime,li.sHostInfoGUID,li.dCreateTime as lightCreateTime,li.dUpdateTime as lightUpadateTime ,li.sRemark,li.sHardware_Version,li.iEnable,ls.sGUID as lightStateGUID,ls.fVoltage,ls.fCurrent,ls.fPower,ls.iFault,ls.dCreateDate as lightStateCreateTime,ls.dUpdateTime as lightStateUpdateTime,ls.sLightInfoGUID,ls.sSpareField1,ls.sSpareField2,ls.sSpareField3,ls.sSpareField4,ls.sSpareField5,ls.sSpareField6,ls.sSpareField7,ls.sSpareField8,ls.sSpareField9,ls.sSpareField10   from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID inner join tHostInfo as h on li.sHostInfoGUID=h.sGUID  where " + LightName + " li.iEnable=1 and h.sProjectInfoGUID='" + prjGUID + "' and " + strWhere + " and sHostInfoGUID='" + sHostGUID + "'  and ls.dUpdateTime >='" + startTime + "' and ls.dUpdateTime <= '" + endTime + "')   as A WHERE iNum > " + iCount + "*(" + iSize + "-1) order by iNum";
            //string sql = "select row_number() over (order by ls.dUpdateTime) as iNum, li.sGUID as lightGUID, li.sName as lightName,li.sLightID,li.sLightPhyID,li.fLng,li.fLat,li.sAddr,li.iState_Command, li.iAlarmConfig_Config,li.dAlarmConfig_Start,li.dAlarmConfig_End,li.sAlarmConfig_Remark,li.iRealTimeAlarm_FaultState,li.iRealTimeAlarm_Fault,li.iRealTimeAlarm_CreateDateTime,li.sHostInfoGUID,li.dCreateTime as lightCreateTime,li.dUpdateTime as lightUpadateTime ,li.sRemark,ls.sGUID as lightStateGUID,ls.fVoltage,ls.fCurrent,ls.fPower,ls.iFault,ls.dCreateDate as lightStateCreateTime,ls.dUpdateTime as lightStateUpdateTime,ls.sLightInfoGUID,ls.sSpareField1,ls.sSpareField2,ls.sSpareField3,ls.sSpareField4,ls.sSpareField5,ls.sSpareField6,ls.sSpareField7,ls.sSpareField8,ls.sSpareField9,ls.sSpareField10   from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID where " + strwhere;
            DataSet ds = dal.GetBySql(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        public DataTable GetFailureByWhereInfo(string prjGUID, DateTime startTime, DateTime endTime)
        {
            string sql = "SELECT  count(*) from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID inner join tHostInfo as h on li.sHostInfoGUID=h.sGUID  where li.iEnable=1 and h.sProjectInfoGUID='" + prjGUID + "' and ls.dUpdateTime >='" + startTime + "' and ls.dUpdateTime <= '" + endTime + "'";
            //string sql = "select row_number() over (order by ls.dUpdateTime) as iNum, li.sGUID as lightGUID, li.sName as lightName,li.sLightID,li.sLightPhyID,li.fLng,li.fLat,li.sAddr,li.iState_Command, li.iAlarmConfig_Config,li.dAlarmConfig_Start,li.dAlarmConfig_End,li.sAlarmConfig_Remark,li.iRealTimeAlarm_FaultState,li.iRealTimeAlarm_Fault,li.iRealTimeAlarm_CreateDateTime,li.sHostInfoGUID,li.dCreateTime as lightCreateTime,li.dUpdateTime as lightUpadateTime ,li.sRemark,ls.sGUID as lightStateGUID,ls.fVoltage,ls.fCurrent,ls.fPower,ls.iFault,ls.dCreateDate as lightStateCreateTime,ls.dUpdateTime as lightStateUpdateTime,ls.sLightInfoGUID,ls.sSpareField1,ls.sSpareField2,ls.sSpareField3,ls.sSpareField4,ls.sSpareField5,ls.sSpareField6,ls.sSpareField7,ls.sSpareField8,ls.sSpareField9,ls.sSpareField10   from tLightInfoes as li left join tLightStateInfoes  as ls on li.sGUID=ls.sLightInfoGUID where " + strwhere;
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

