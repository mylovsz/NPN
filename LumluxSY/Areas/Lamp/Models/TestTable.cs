using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LumluxSY.Areas.Lamp.Models
{
    public class TestTable
    {
        public double lat { get; set; } //纬度
        public double lng { get; set; }//经度
        public string title { get; set; }//标题
        public string surl { get; set; }//图片路径
        public int icount { get; set; }
    }
}