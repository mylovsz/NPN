using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL = LumluxSSYDB.BLL;
using Model = LumluxSSYDB.Model;

namespace AdminBLL
{
    public class CMDRevBLL
    {
        /// <summary>
        /// 增加回复命令
        /// </summary>
        /// <param name="cmdRev"></param>
        /// <returns></returns>
        public bool Add(CMDRev cmdRev)
        {
            if (cmdRev != null)
                return new BLL.tCMDRevs().Add(cmdRev.T);
            return false;
        }

        /// <summary>
        /// 更新回复命令
        /// </summary>
        /// <param name="cmdRev"></param>
        /// <returns></returns>
        public bool Update(CMDRev cmdRev)
        {
            if (cmdRev != null)
                return new BLL.tCMDRevs().Update(cmdRev.T);
            return false;
        }

        /// <summary>
        /// 获取规定的命令
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cmdType"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public List<CMDRev> GetModelByIDAndTime(string id, byte cmdType, int second, int state = 0)
        {
            DateTime dtNow = DateTime.Now.AddSeconds(second);
            string where = "sHostIDID = '" + id + "' and iContentType=" + cmdType + " and dCreateDate > '" + dtNow.ToString() + "' and iState=" + state;
            List<Model.tCMDRevs> list = new BLL.tCMDRevs().GetModelList(where);
            if(list != null && list.Count>0)
            {
                List<CMDRev> listRev = new List<CMDRev>();
                foreach(Model.tCMDRevs c in list)
                {
                    listRev.Add(new CMDRev(c));
                }
                return listRev;
            }
            return null;
        }

        /// <summary>
        /// 获取规定的命令
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cmdType"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public List<CMDRev> GetModelByIDAndTime(string id, int cmdType, int second, int state = 0)
        {
            DateTime dtNow = DateTime.Now.AddSeconds(second);
            string where = "sHostIDID = '" + id + "' and iContentType=" + cmdType + " and dCreateDate > '" + dtNow.ToString() + "' and iState=" + state;
            List<Model.tCMDRevs> list = new BLL.tCMDRevs().GetModelList(where);
            if (list != null && list.Count > 0)
            {
                List<CMDRev> listRev = new List<CMDRev>();
                foreach (Model.tCMDRevs c in list)
                {
                    listRev.Add(new CMDRev(c));
                }
                return listRev;
            }
            return null;
        }
    }
}
