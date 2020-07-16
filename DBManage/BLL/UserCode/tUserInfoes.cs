using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using LumluxSSYDB.Model;
using System.Text;
using System.Data.SqlClient;
namespace LumluxSSYDB.BLL
{
	/// <summary>
	/// tUserInfoes
	/// </summary>
	public partial class tUserInfoes
	{
		#region  ExtensionMethod
        public int UpdatePassWord(string Guid,string OldPassword,string NewPassword)
        {
            /*0: 未发现该主机
             *1：主机原始密码错误
             *2: 主机修改新密码失败，数据库错误
             *3：主机修改新密码成功
            */
            Model.tUserInfoes usermod = new Model.tUserInfoes();
            if ((usermod=dal.GetModel(Guid))!=null)
            {
                if (usermod.sPassWord == OldPassword)
                {
                    usermod.sPassWord = NewPassword;
                    if (dal.Update(usermod))
                    {
                        return 3;
                    }
                    else
                        return 2;
                }
                else 
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsUserByPassword(string UIName, string UIPassword)
        {
            return dal.ExistsUserByPassword(UIName, UIPassword);
        }

        public LumluxSSYDB.Model.tUserInfoes GetUserMode(string UIName, string UIPassword)
        {
            return dal.GetUserMode(UIName, UIPassword);
        }

        public List<Model.tUserInfoes> GetUserByPrj(string prjGUID)
        {
            return GetModelList("sPrjectInfoGUID='" + prjGUID + "'");
        }

        public bool ExistsName(string name)
        {
            List<Model.tUserInfoes> list = GetModelList("sUserName = '" + name + "'");
            return (list != null && list.Count > 0) ? true : false;
        }
		#endregion  ExtensionMethod
	}
}

