using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model = LumluxSSYDB.Model;

namespace AdminModel
{
    public class ProjectSet
    {
        Model.tPrjectSet tPS;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ps">不能为NULL</param>
        public ProjectSet(Model.tPrjectSet ps)
        {
            tPS = ps;
        }

        public ProjectSet()
        {
            tPS = new Model.tPrjectSet();
        }

        public string GUID
        {
            get
            {
                if (string.IsNullOrEmpty(tPS.sGUID))
                    return "";
                return tPS.sGUID;
            }
        }

        public string Key
        {
            get
            {
                if(string.IsNullOrEmpty(tPS.sKey))
                {
                    return "";
                }
                return tPS.sKey;
            }
        }

        public string Value
        {
            get
            {
                if (string.IsNullOrEmpty(tPS.sValue))
                    return "";
                return tPS.sValue;
            }
        }

        public string Remark
        {
            get
            {
                if(string.IsNullOrEmpty(tPS.sDesc))
                {
                    return "";
                }
                return tPS.sDesc;
            }
        }
    }
}
