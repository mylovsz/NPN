using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL = LumluxSSYDB.BLL;
using Model = LumluxSSYDB.Model;

namespace AdminBLL
{
    public class UserBLL
    {
        public UserInfo GetModelByNamePsd(string name, string psd)
        {
            psd = LumluxSSYDB.DBUtility.Utility.MD5(psd);
            string where = "sUserName='"+name+"' and sPassWord='"+psd+"'";
            List<Model.tUserInfoes> uiList = new BLL.tUserInfoes().GetModelList(where);
            if (uiList != null && uiList.Count > 0)
                return new UserInfo(uiList[0]);
            return null;
        }
    }
}
