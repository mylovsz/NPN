using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL = LumluxSSYDB.BLL;
using Model = LumluxSSYDB.Model;

namespace AdminBLL
{
    public class ProjectSetBLL
    {
        public List<ProjectSet> GetListByPrjGUID(string prjGUID)
        {
            if (prjGUID == null)
                return null;

            string where = "sPrjectGUID = '" + prjGUID + "'";
            List<Model.tPrjectSet> list = new BLL.tPrjectSet().GetModelList(where);
            if(list != null && list.Count>0)
            {
                List<ProjectSet> result = new List<ProjectSet>();
                foreach(Model.tPrjectSet p in list)
                {
                    result.Add(new ProjectSet(p));
                }
                return result;
            }
            return null;
        }
    }
}
