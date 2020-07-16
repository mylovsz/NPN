using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL = LumluxSSYDB.BLL;
using Model = LumluxSSYDB.Model;

namespace AdminBLL
{
    public class HostInfoBLL
    {
        public List<HostInfo> GetModelByPrjGUID(string prjGUID)
        {
            List<Model.tHostInfo> list = new BLL.tHostInfo().GetModelListByPrjGUID(prjGUID);
            if(list != null && list.Count>0)
            {
                List<HostInfo> listHI = new List<HostInfo>();
                foreach(Model.tHostInfo hi in list)
                {
                    listHI.Add(new HostInfo(hi));
                }
                return listHI;
            }
            return null;
        }
    }
}
