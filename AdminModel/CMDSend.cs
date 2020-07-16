using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model = LumluxSSYDB.Model;

namespace AdminModel
{
    public class CMDSend
    {
        Model.tCMDSends cmdSend = new Model.tCMDSends();

        public Model.tCMDSends T
        {
            get
            {
                return cmdSend;
            }
        }

        public string GUID
        {
            get
            {
                if (string.IsNullOrEmpty(cmdSend.sGUID))
                    return "";
                return cmdSend.sGUID;
            }
            set
            {
                cmdSend.sGUID = value;
            }
        }

        public int State
        {
            get
            {
                if (cmdSend.iState == null)
                    return 0;
                return (int)cmdSend.iState;
            }
            set
            {
                cmdSend.iState = value;
            }
        }

        public int ContentType
        {
            get
            {
                if (cmdSend.iContentType == null)
                    return 0;
                return (int)cmdSend.iContentType;
            }
            set
            {
                cmdSend.iContentType = value;
            }
        }

        public string Content
        {
            get
            {
                if (string.IsNullOrEmpty(cmdSend.sContent))
                    return "";
                return cmdSend.sContent;
            }
            set
            {
                cmdSend.sContent = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                if (cmdSend.dCreateDate == null)
                    return new DateTime(1, 1, 1);
                return (DateTime)cmdSend.dCreateDate;
            }
            set
            {
                cmdSend.dCreateDate = value;
            }
        }

        public DateTime UpdateDate
        {
            get
            {
                if (cmdSend.dUpdateTime == null)
                    return new DateTime(1, 1, 1);
                return (DateTime)cmdSend.dUpdateTime;
            }
            set
            {
                cmdSend.dUpdateTime = value;
            }
        }

        public string ID
        {
            get
            {
                if (string.IsNullOrEmpty(cmdSend.sHostIDID))
                    return "";
                return cmdSend.sHostIDID;
            }
            set
            {
                cmdSend.sHostIDID = value;
            }
        }

        public string Addr
        {
            get
            {
                if (string.IsNullOrEmpty(cmdSend.sHostIDAddr))
                    return "";
                return cmdSend.sHostIDAddr;
            }
            set
            {
                cmdSend.sHostIDAddr = value;
            }
        }
    }
}
