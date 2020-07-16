using System;
using System.Collections.Generic;
using System.Text;

namespace LumluxSSYDB.BLL
{
        public partial class tMeasureCurrentInfoes
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
            public LumluxSSYDB.Model.tMeasureCurrentInfoes GetModelByHostGuidAndIDAndTime(string sMeasureInfoGUID, int iID)
            {
                return dal.GetModelByHostGuidAndIDAndTime(sMeasureInfoGUID,iID);
            }
    }
}
