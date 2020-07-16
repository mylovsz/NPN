using System;
using System.Collections.Generic;
using System.Text;

namespace LumluxSSYDB.BLL
{
    public partial class tMeasureInfoes
    {
        /// <summary>
        /// 通过主机guid,编码，时间得到一个对象实体
        /// </summary>
        public LumluxSSYDB.Model.tMeasureInfoes GetModelByHostGuidAndIdAndTime(string sHostInfoGUID, int iID, DateTime dCreateDate)
        {
            return dal.GetModelByHostGuidAndIdAndTime(sHostInfoGUID, iID, dCreateDate);
        }
    }
}
