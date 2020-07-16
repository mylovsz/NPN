using System;
using System.Collections.Generic;
using System.Text;

namespace LumluxSSYDB.DBUtility
{
    public class Utility
    {
        ///// <summary>
        ///// 对字符串进行不可逆MD5加密
        ///// </summary>
        ///// <param name="str"></param>
        ///// <returns></returns>
        public static string MD5(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
        }
    }
}
