using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model = LumluxSSYDB.Model;

namespace AdminModel
{
    public class UserInfo : Database
    {
        public UserInfo(Model.tUserInfoes ui)
        {
            tUserInfo = ui;
        }

        public string ProjectGUID
        {
            get
            {
                return tUserInfo.sPrjectInfoGUID;
            }
        }

        /// <summary>
        /// 关联的数据库数据
        /// </summary>
        public Model.tUserInfoes tUserInfo;

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(tUserInfo.sAlias))
                    return "Alias";
                return tUserInfo.sAlias;
            }
        }
    }
}
