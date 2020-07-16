using System;
using System.Collections.Generic;
using System.Text;

namespace LumluxSSYDB.BLL
{
    public partial class tMeasurePowerInfoes
    {
                /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LumluxSSYDB.Model.tMeasurePowerInfoes GetModelByHostGuidAndIDAndTime(string MeasureInfoGuid, int iID)
        {
            return dal.GetModelByHostGuidAndIDAndTime(MeasureInfoGuid, iID);
        }
    }
}
