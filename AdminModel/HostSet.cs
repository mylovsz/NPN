using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model = LumluxSSYDB.Model;
using BLL = LumluxSSYDB.BLL;

namespace AdminModel
{
    public class HostSet
    {
        Model.tHostSet hostSet;

        public HostSet()
        {
            hostSet = new Model.tHostSet();
        }

        public HostSet(Model.tHostSet hs)
        {
            hostSet = hs;
        }

        public Model.tHostSet T
        {
            get
            {
                return hostSet;
            }
        }

        public string GUID
        {
            get
            {
                if (string.IsNullOrEmpty(hostSet.sGUID))
                    return "";
                return hostSet.sGUID;
            }
            set
            {
                hostSet.sGUID = value;
            }
        }

        public string Key
        {
            get
            {
                if (string.IsNullOrEmpty(hostSet.sKey))
                    return "";
                return hostSet.sKey;
            }
            set
            {
                hostSet.sKey = value;
            }
        }

        public string Value
        {
            get
            {
                if (string.IsNullOrEmpty(hostSet.sValue))
                    return "";
                return hostSet.sValue;
            }
            set
            {
                hostSet.sValue = value;
            }
        }

        public string Desc
        {
            get
            {
                if (string.IsNullOrEmpty(hostSet.sDesc))
                    return "";
                return hostSet.sDesc;
            }
            set
            {
                hostSet.sDesc = value;
            }
        }

        public string HostGUID
        {
            get
            {
                if (string.IsNullOrEmpty(hostSet.sHostGUID))
                    return "";
                return hostSet.sHostGUID;
            }
            set
            {
                hostSet.sHostGUID = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                if (hostSet.dCreateDate == null)
                    return new DateTime(1, 1, 1);
                return (DateTime)hostSet.dCreateDate;
            }
            set
            {
                hostSet.dCreateDate = value;
            }
        }

        public DateTime UpdateDate
        {
            get
            {
                if (hostSet.dUpdateDate == null)
                    return new DateTime(1, 1, 1);
                return (DateTime)hostSet.dUpdateDate;
            }
            set
            {
                hostSet.dUpdateDate = value;
            }
        }
    }
}
