using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model = LumluxSSYDB.Model;

namespace AdminModel
{
    public class ProjectInfo : Database
    {
        /// <summary>
        /// 关联的数据库数据
        /// </summary>
        public Model.tPrjectInfo tProjectInfo;

        public ProjectInfo(Model.tPrjectInfo p)
        {
            tProjectInfo = p;
        }

        public double Lat
        {
            get
            {
                if (tProjectInfo.fLat == null)
                    return 31.02;
                return (double)tProjectInfo.fLat;
            }
            set
            {
                tProjectInfo.fLat = (decimal)value;
            }
        }

        public double Lng
        {
            get
            {
                if (tProjectInfo.fLng == null)
                    return 120.6;
                return (double)tProjectInfo.fLng;
            }
            set
            {
                tProjectInfo.fLng = (decimal)value;
            }
        }

        public Model.tPrjectInfo T
        {
            get
            {
                return tProjectInfo;
            }
        }
    }
}
