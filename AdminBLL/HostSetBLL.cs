using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL = LumluxSSYDB.BLL;
using Model = LumluxSSYDB.Model;

namespace AdminBLL
{
    public class HostSetBLL
    {
        public bool Add(HostSet hs)
        {
            if (hs != null)
                return new BLL.tHostSet().Add(hs.T);
            return false;
        }

        public bool Update(HostSet hs)
        {
            if (hs != null)
                return new BLL.tHostSet().Update(hs.T);
            return false;
        }

        public HostSet GetAllByHostGUIDKey(string hostGUID, string key)
        {
            string where = "sHostGUID = '" + hostGUID + "' and sKey='" + key + "'";
            List<Model.tHostSet> list = new BLL.tHostSet().GetModelList(where);
            if (list != null && list.Count > 0)
                return new HostSet(list[0]);
            return null;
        }
    }
}
