using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL = LumluxSSYDB.BLL;
using Model = LumluxSSYDB.Model;

namespace AdminBLL
{
    public class LightGroupInfoBLL
    {
        public bool Add(LightGroupInfo lgi)
        {
            if (lgi != null)
                return new BLL.tLightGroupInfoes().Add(lgi.T);
            return false;
        }

        public bool Update(LightGroupInfo lgi)
        {
            if (lgi != null)
                return new BLL.tLightGroupInfoes().Update(lgi.T);
            return false;
        }

        /// <summary>
        /// 根据主机的GUID获取所有的单灯分组信息
        /// </summary>
        /// <param name="hostGUID"></param>
        /// <returns></returns>
        public List<LightGroupInfo> GetAllLightGroupInfoByHostGUID(string hostGUID)
        {
            List<Model.tLightGroupInfoes> lgi = new BLL.tLightGroupInfoes().GetModelListByHostGUID(hostGUID);
            List<LightGroupInfo> result = new List<LightGroupInfo>();
            if(lgi != null && lgi.Count>0)
            {
                foreach(Model.tLightGroupInfoes t in lgi)
                {
                    result.Add(new LightGroupInfo(t));
                }
                return result;
            }
            return null;
        }
    }
}
