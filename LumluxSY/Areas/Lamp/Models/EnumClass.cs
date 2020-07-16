using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LumluxSY.Areas.Lamp.Models
{
    public static class EnumClass
    {
        public enum HWType
        {
            eLoop,
            eGroup,
        }
        public enum SYType
        {
            eThreeLoop=0,
            eSixLoop=1,
        }
    }
}