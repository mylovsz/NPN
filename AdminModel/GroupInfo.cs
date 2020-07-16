using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model = LumluxSSYDB.Model;

namespace AdminModel
{
    /// <summary>
    /// 主机分组信息
    /// </summary>
    public class GroupInfo : Database
    {
        public GroupInfo(Model.tGroupInfoes gi)
        {
            tGroupInfo = gi;
        }

        public GroupInfo()
        {
            tGroupInfo = new Model.tGroupInfoes();
        }

        public string ProjectGUID
        {
            get
            {
                if (string.IsNullOrEmpty(tGroupInfo.sProjectInfoGUID))
                    return "";
                return tGroupInfo.sProjectInfoGUID;
            }
            set
            {
                tGroupInfo.sProjectInfoGUID = value;
            }
        }

        public Model.tGroupInfoes T
        {
            get
            {
                return tGroupInfo;
            }
        }

        /// <summary>
        /// 关联的数据库Model
        /// </summary>
        public Model.tGroupInfoes tGroupInfo;

        public string GUID
        {
            get
            {
                return tGroupInfo.sGUID;
            }
            set
            {
                tGroupInfo.sGUID = value;
            }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(tGroupInfo.sName))
                    return "";
                return tGroupInfo.sName;
            }
            set
            {
                if (tGroupInfo.sName != value)
                {
                    tGroupInfo.sName = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate
        {
            get
            {
                if (tGroupInfo.dCreateDate == null)
                    return new DateTime(1, 1, 1);
                return (DateTime)tGroupInfo.dCreateDate;
            }
            set
            {
                tGroupInfo.dCreateDate = value;
            }
        }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateDate
        {
            get
            {
                if (tGroupInfo.dUpdateTime == null)
                    return new DateTime(1, 1, 1);
                return (DateTime)tGroupInfo.dUpdateTime;
            }
            set
            {
                tGroupInfo.dUpdateTime = value;
            }
        }

        public string ID
        {
            get
            {
                if (string.IsNullOrEmpty(tGroupInfo.sID))
                    return "";
                return tGroupInfo.sID;
            }
            set
            {
                tGroupInfo.sID = value;
            }
        }

        public override string ToString()
        {
            return "111";
        }
    }
}
