using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LumluxSY.Areas.Lamp.Models
{
    public class PrjectSetInfoVM
    {
        /// <summary>
        /// 项目GUID
        /// </summary>
        public string GUID = Guid.Empty.ToString();
        /// <summary>
        /// key
        /// </summary>
        public string sKey= "";
        /// <summary>
        /// value
        /// </summary>
        public string sValue = "";
        /// <summary>
        /// 备注
        /// </summary>
        public string sDesc = "";
    }
}