using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model = LumluxSSYDB.Model;

namespace AdminModel
{
    [Serializable]
    public class LightInfoLightGroupInfo :Database
    {
        Model.tLightInfoLightGroupInfoes tLightInfoLightGroupInfo = null;

        public Model.tLightInfoLightGroupInfoes T
        {
            get
            {
                return tLightInfoLightGroupInfo;
            }
        }

        public LightInfoLightGroupInfo()
        {
            tLightInfoLightGroupInfo = new Model.tLightInfoLightGroupInfoes();
        }

        public LightInfoLightGroupInfo(Model.tLightInfoLightGroupInfoes t)
        {
            tLightInfoLightGroupInfo = t;
        }

        public string LightInfoGUID
        {
            get
            {
                if (string.IsNullOrEmpty(tLightInfoLightGroupInfo.sLightInfoGUID))
                    return "";
                return tLightInfoLightGroupInfo.sLightInfoGUID;
            }
            set
            {
                tLightInfoLightGroupInfo.sLightInfoGUID = value;
            }
        }

        public string LightGroupInfoGUID
        {
            get
            {
                if (string.IsNullOrEmpty(tLightInfoLightGroupInfo.sLightGroupInfoGUID))
                    return "";
                return tLightInfoLightGroupInfo.sLightGroupInfoGUID;
            }
            set
            {
                tLightInfoLightGroupInfo.sLightGroupInfoGUID = value;
            }
        }

        public string GUID
        {
            get
            {
                if (string.IsNullOrEmpty(tLightInfoLightGroupInfo.sGUID))
                    return "";
                return tLightInfoLightGroupInfo.sGUID;
            }
            set
            {
                tLightInfoLightGroupInfo.sGUID = value;
            }
        }

        public DateTime CreateTime
        {
            get
            {
                if (tLightInfoLightGroupInfo.dCreateTime == null)
                    return new DateTime(1,1,1);
                return (DateTime)tLightInfoLightGroupInfo.dCreateTime;
            }
            set
            {
                tLightInfoLightGroupInfo.dCreateTime = value;
            }
        }

        public DateTime UpdateTime
        {
            get
            {
                if (tLightInfoLightGroupInfo.dUpdateTime == null)
                    return new DateTime(1, 1, 1);
                return (DateTime)tLightInfoLightGroupInfo.dUpdateTime;
            }
            set
            {
                tLightInfoLightGroupInfo.dUpdateTime = value;
            }
        }
    }
}
