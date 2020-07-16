using System;
using System.Collections.Generic;
using System.Text;

namespace LumluxSSYDB.BLL
{
    /// <summary>
    /// tCMDRevs
    /// </summary>
    public partial class tCMDRevs
    {
        #region  ExtensionMethod
        /// <summary>
        /// 获得某类型的返回数据
        /// </summary>
        /// <param name="ContentType">数据类型</param>
        /// <param name="hostidid">主机idid</param>
        /// <param name="second">提前的时间</param>
        /// <returns></returns>
        public Model.tCMDRevs GetCMDRecive(int? ContentType,string hostidid, int second)
        {
           return dal.GetCMDRecive(ContentType, hostidid, second);
        }
        #endregion  ExtensionMethod
    }
}
