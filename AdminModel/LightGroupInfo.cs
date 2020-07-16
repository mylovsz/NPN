using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model = LumluxSSYDB.Model;

namespace AdminModel
{
    public class LightGroupInfo : Database
    {
        public LightGroupInfo(Model.tLightGroupInfoes lgi)
        {
            tLightGroupInfo = lgi;
        }

        public LightGroupInfo()
        {
            tLightGroupInfo = new Model.tLightGroupInfoes();
        }

        public Model.tLightGroupInfoes T
        {
            get
            {
                return tLightGroupInfo;
            }
        }

        public LightGroupInfo(bool isAll)
        {
            if (isAll)
                tLightGroupInfo = new Model.tLightGroupInfoes() { sGUID = "", sID = "", sName = "全部" };
            else
                tLightGroupInfo = new Model.tLightGroupInfoes();
        }

        /// <summary>
        /// 关联的数据库数据
        /// </summary>
        Model.tLightGroupInfoes tLightGroupInfo;

        public string ID
        {
            get
            {
                if (string.IsNullOrEmpty(tLightGroupInfo.sID))
                    return "";
                return tLightGroupInfo.sID;
            }
            set
            {
                tLightGroupInfo.sID = value;
            }
        }

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(tLightGroupInfo.sName))
                    return "";
                return tLightGroupInfo.sName;
            }
            set
            {
                if (tLightGroupInfo.sName != value)
                {
                    tLightGroupInfo.sName = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }

        public string GUID
        {
            get
            {
                if (string.IsNullOrEmpty(tLightGroupInfo.sGUID))
                    return "";
                return tLightGroupInfo.sGUID;
            }
            set
            {
                tLightGroupInfo.sGUID = value;
            }
        }

        public DateTime CreateTime
        {
            get
            {
                if (tLightGroupInfo.dCreateTime == null)
                    return new DateTime(1, 1, 1);
                return (DateTime)tLightGroupInfo.dCreateTime;
            }
            set
            {
                tLightGroupInfo.dCreateTime = value;
            }
        }

        public DateTime UpdateTime
        {
            get
            {
                if (tLightGroupInfo.dUpdateTime == null)
                    return new DateTime(1, 1, 1);
                return (DateTime)tLightGroupInfo.dUpdateTime;
            }
            set
            {
                tLightGroupInfo.dUpdateTime = value;
            }
        }

        public string HostGUID
        {
            get
            {
                if (string.IsNullOrEmpty(tLightGroupInfo.sHostInfoGUID))
                    return "";
                return tLightGroupInfo.sHostInfoGUID;
            }
            set
            {
                tLightGroupInfo.sHostInfoGUID = value;
            }
        }

        public string Remark
        {
            get
            {
                if (string.IsNullOrEmpty(tLightGroupInfo.sRemark))
                    return "";
                return tLightGroupInfo.sRemark;
            }
            set
            {
                tLightGroupInfo.sRemark = value;
            }
        }
    }
}
