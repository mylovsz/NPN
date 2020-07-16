using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL = LumluxSSYDB.BLL;

namespace AdminBLL
{
    public class CMDSendBLL
    {
        public bool Add(CMDSend cmdSend)
        {
            if (cmdSend != null)
                return new BLL.tCMDSends().Add(cmdSend.T);
            return false;
        }

        public bool Update(CMDSend cmdSend)
        {
            if (cmdSend != null)
                return new BLL.tCMDSends().Update(cmdSend.T);
            return false;
        }
    }
}
