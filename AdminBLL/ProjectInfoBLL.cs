using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL = LumluxSSYDB.BLL;
using Model = LumluxSSYDB.Model;

namespace AdminBLL
{
    public class ProjectInfoBLL
    {
        public ProjectInfo GetModel(string guid)
        {
            Model.tPrjectInfo pi = new BLL.tPrjectInfo().GetModel(guid);
            if (pi != null)
                return new ProjectInfo(pi);
            return null;
        }

        public bool Update(ProjectInfo pi)
        {
            if (pi != null)
                return new BLL.tPrjectInfo().Update(pi.T);
            return false;
        }
    }
}
