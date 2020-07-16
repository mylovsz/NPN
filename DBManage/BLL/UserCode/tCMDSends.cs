using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using LumluxSSYDB.Model;
namespace LumluxSSYDB.BLL
{
	/// <summary>
	/// tCMDSends
	/// </summary>
	public partial class tCMDSends
	{
		#region  ExtensionMethod
        /// <summary>
        /// 获取要发送的命令
        /// </summary>
        /// <param name="second">有效的时间</param>
        /// <returns></returns>
        public List<Model.tCMDSends> GetCMDSending(int second)
        {
            DateTime dtNow = DateTime.Now.AddSeconds(-second);
            string where = "iState = 0 and dCreateDate > '" + dtNow.ToString() + "'";
            return GetModelList(where);
        }
		#endregion  ExtensionMethod
	}
}

