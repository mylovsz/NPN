using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL = LumluxSSYDB.BLL;
using Model = LumluxSSYDB.Model;

namespace AdminBLL
{
    public class LightInfoLightGroupInfoBLL
    {
        public bool Update(LightInfoLightGroupInfo l)
        {
            if(l != null)
            {
                return new BLL.tLightInfoLightGroupInfoes().Update(l.T);
            }
            return false;
        }

        public bool Add(LightInfoLightGroupInfo l)
        {
            if (l != null)
            {
                return new BLL.tLightInfoLightGroupInfoes().Add(l.T);
            }
            return false;
        }

        public List<LightInfoLightGroupInfo> GetByLightGUID(string lightGUID)
        {
            string where = "sLightInfoGUID ='"+lightGUID+"'";
            List<Model.tLightInfoLightGroupInfoes> list = new BLL.tLightInfoLightGroupInfoes().GetModelList(where);
            if(list != null && list.Count>0)
            {
                List<LightInfoLightGroupInfo> result = new List<LightInfoLightGroupInfo>();
                foreach(Model.tLightInfoLightGroupInfoes m in list)
                {
                    result.Add(new LightInfoLightGroupInfo(m));
                }
                return result;
            }
            return null;
        }
    }
}
