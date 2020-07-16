using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL = LumluxSSYDB.BLL;
using Model = LumluxSSYDB.Model;

namespace AdminBLL
{
    public class LightInfoBLL
    {
        public bool Add(LightInfo li)
        {
            if(li != null)
            {
                return new BLL.tLightInfoes().Add(li.T);
            }
            return false;
        }

        public bool Update(LightInfo li)
        {
            if (li != null)
            {
                return new BLL.tLightInfoes().Update(li.T);
            }
            return false;
        }

        public List<LightInfo> GetModelByHost(HostInfo host)
        {
            List<Model.tLightInfoes> list = new BLL.tLightInfoes().GetModelListByHostGUID(host.GUID);
            LightStateInfoBLL lsiBLL = new LightStateInfoBLL();
            if (list != null && list.Count > 0)
            {
                List<LightInfo> result = new List<LightInfo>();
                foreach (Model.tLightInfoes l in list)
                {
                    LightStateInfo lsi = null;
                    if(!string.IsNullOrEmpty(l.sStateGUID.Trim()))
                    {
                        lsi = lsiBLL.GetModel(l.sStateGUID);
                    }
                    result.Add(new LightInfo(l, host.IDID) { LightStateInfo = lsi });
                }
                return result;
            }
            return null;
        }
    }
}
