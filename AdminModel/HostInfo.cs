using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model = LumluxSSYDB.Model;
using BLL = LumluxSSYDB.BLL;

namespace AdminModel
{
    /// <summary>
    /// 主机信息
    /// </summary>
    [Serializable]
    public class HostInfo : Database
    {
        public HostInfo()
        {
            tHostInfo = new Model.tHostInfo();
        }

        public HostInfo(Model.tHostInfo hi)
        {
            tHostInfo = hi;
        }

        /// <summary>
        /// 关联的数据库数据
        /// </summary>
        public Model.tHostInfo tHostInfo;

        public override string ToString()
        {
            return tHostInfo.sName;
        }

        public string GUID
        {
            get
            {
                if(string.IsNullOrEmpty(tHostInfo.sGUID))
                    return "";
                return tHostInfo.sGUID;
            }
            set
            {
                tHostInfo.sGUID = value;
            }
        }

        public string Name
        {
            get
            {
                if(string.IsNullOrEmpty(tHostInfo.sName))
                    return "";
                return tHostInfo.sName;
            }
            set
            {
                if (tHostInfo.sName != value)
                {
                    tHostInfo.sName = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }

        public double Lat
        {
            get
            {
                if (tHostInfo.fLat == null)
                    return 0;
                return (double)tHostInfo.fLat;
            }
            set
            {
                tHostInfo.fLat = (decimal)value;
            }
        }

        public double Lng
        {
            get
            {
                if (tHostInfo.fLng == null)
                    return 0;
                return (double)tHostInfo.fLng;
            }
            set
            {
                tHostInfo.fLng = (decimal)value;
            }
        }

        public string IDID
        {
            get
            {
                if (string.IsNullOrEmpty(tHostInfo.sID_ID))
                    return "";
                return tHostInfo.sID_ID;
            }
            set
            {
                tHostInfo.sID_ID = value;
            }
        }

        public string Addr
        {
            get
            {
                if (string.IsNullOrEmpty(tHostInfo.sID_Addr))
                    return "";
                return tHostInfo.sID_Addr;
            }
            set
            {
                tHostInfo.sID_Addr = value;
            }
        }

        public string Remark
        {
            get
            {
                if (string.IsNullOrEmpty(tHostInfo.sRemark))
                    return "";
                return tHostInfo.sRemark;
            }
            set
            {
                tHostInfo.sRemark = value;
            }
        }

        public bool Enable
        {
            get
            {
                if (tHostInfo.iState_Enable == null)
                    return false;
                return tHostInfo.iState_Enable == 0 ? false : true;
            }
            set
            {
                tHostInfo.iState_Enable = value == false ? 0 : 1;
            }
        }

        public string GroupInfoGUID
        {
            get
            {
                if (string.IsNullOrEmpty(tHostInfo.sGroupInfoGUID))
                    return "";
                return tHostInfo.sGroupInfoGUID;
            }
            set
            {
                tHostInfo.sGroupInfoGUID = value;
            }
        }

        public string ProjectInfoGUID
        {
            get
            {
                if (string.IsNullOrEmpty(tHostInfo.sProjectInfoGUID))
                    return "";
                return tHostInfo.sProjectInfoGUID;
            }
            set
            {
                tHostInfo.sProjectInfoGUID = value;
            }
        }

        public int Online
        {
            get
            {
                if (tHostInfo.iState_Online == null)
                    return 0;
                return (int)tHostInfo.iState_Online;
            }
            set
            {
                if(tHostInfo.iState_Online != value)
                {
                    tHostInfo.iState_Online = value;
                    this.RaisePropertyChanged("Online");
                }
            }
        }

        public bool Update()
        {
            return new BLL.tHostInfo().Update(tHostInfo);
        }

        public bool Add()
        {
            return new BLL.tHostInfo().Add(tHostInfo);
        }
    }
}
