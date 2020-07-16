using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model = LumluxSSYDB.Model;

namespace AdminModel
{
    public class CMDRev
    {
        Model.tCMDRevs cmdRev = new Model.tCMDRevs();

        public CMDRev(Model.tCMDRevs t)
        {
            cmdRev = t;
        }

        public Model.tCMDRevs T
        {
            get
            {
                return cmdRev;
            }
        }

        public string GUID
        {
            get
            {
                if (string.IsNullOrEmpty(cmdRev.sGUID))
                    return "";
                return cmdRev.sGUID;
            }
            set
            {
                cmdRev.sGUID = value;
            }
        }

        public int ContentType
        {
            get
            {
                if (cmdRev.iContentType == null)
                    return 0;
                return (int)cmdRev.iContentType;
            }
            set
            {
                cmdRev.iContentType = value;
            }
        }

        public int State
        {
            get
            {
                if (cmdRev.iState == null)
                    return 0;
                return (int)cmdRev.iState;
            }
            set
            {
                cmdRev.iState = value;
            }
        }

        public string Content
        {
            get
            {
                if (string.IsNullOrEmpty(cmdRev.sContent))
                    return "";
                return cmdRev.sContent;
            }
            set
            {
                cmdRev.sContent = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                if (cmdRev.dCreateDate == null)
                    return new DateTime(1, 1, 1);
                return (DateTime)cmdRev.dCreateDate;
            }
            set
            {
                cmdRev.dCreateDate = value;
            }
        }

        public DateTime UpdateDate
        {
            get
            {
                if (cmdRev.dUpdateTime == null)
                    return new DateTime(1, 1, 1);
                return (DateTime)cmdRev.dUpdateTime;
            }
            set
            {
                cmdRev.dUpdateTime = value;
            }
        }

        public string ID
        {
            get
            {
                if (string.IsNullOrEmpty(cmdRev.sHostIDID))
                    return "";
                return cmdRev.sHostIDID;
            }
            set
            {
                cmdRev.sHostIDID = value;
            }
        }
    }
}
