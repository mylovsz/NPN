using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL = LumluxSSYDB.BLL;

namespace AdminBLL
{
    public class LightStateInfoBLL
    {
        public LightStateInfo GetModel(string guid)
        {
            if (guid == null)
                return null;
            LightStateInfo lsi = new LightStateInfo(new BLL.tLightStateInfoes().GetModel(guid));
            return lsi;
        }

        public bool Delete(DateTime dtStart, DateTime dtEnd)
        {
            if (dtEnd == null || dtStart == null)
                return false;
            return new BLL.tLightStateInfoes().DeleteWhere("dCreateDate >= '" + dtStart.ToString("yyyy-MM-dd HH:mm:ss") + "' and dCreateDate <= '" + dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + "'");
        }
    }
}
