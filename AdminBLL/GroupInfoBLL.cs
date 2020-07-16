using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL = LumluxSSYDB.BLL;
using Model = LumluxSSYDB.Model;

namespace AdminBLL
{
    public class GroupInfoBLL
    {
        public bool Add(GroupInfo gi)
        {
            if (gi != null)
            {
                return new BLL.tGroupInfoes().Add(gi.T);
            }
            return false;
        }

        public bool Update(GroupInfo gi)
        {
            if(gi != null)
            {
                return new BLL.tGroupInfoes().Update(gi.T);
            }
            return false;
        }
    }
}
