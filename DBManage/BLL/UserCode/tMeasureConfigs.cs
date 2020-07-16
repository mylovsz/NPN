using System;
using System.Collections.Generic;
using System.Text;

namespace LumluxSSYDB.BLL
{
    public partial class tMeasureConfigs
    {
        /// <summary>
        /// 通过主机得到一个对象实体
        /// </summary>
        public LumluxSSYDB.Model.tMeasureConfigs GetModelByHostGuid(string sHostInfoGUID)
        {
            return dal.GetModelByHostGuid(sHostInfoGUID);
        }
    }
}
