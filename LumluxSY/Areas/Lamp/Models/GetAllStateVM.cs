using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LumluxSY.Areas.Lamp.Models
{
    public class CircuitStateVM
    {
        /// <summary>
        /// 回路ID
        /// </summary>
        public string ID;

        /// <summary>
        /// 回路电流
        /// </summary>
        public string Current;

        /// <summary>
        /// 回路功率
        /// </summary>
        public string Power;

        /// <summary>
        /// 回路状态，是否电流报警
        /// </summary>
        public string State;

        /// <summary>
        /// 回路相位
        /// </summary>
        public string Phase;
    }

    public class MeasureState
    {
        /// <summary>
        /// 回路集合
        /// </summary>
        public List<CircuitStateVM> CircuitList;

        /// <summary>
        /// A相电压值
        /// </summary>
        public string Avoltage;

        /// <summary>
        /// B相电压值
        /// </summary>
        public string Bvoltage;

        /// <summary>
        /// C相电压值
        /// </summary>
        public string Cvoltage;

        /// <summary>
        /// A相状态
        /// </summary>
        public string AState;

        /// <summary>
        /// B相状态
        /// </summary>
        public string BState;

        /// <summary>
        /// C相状态
        /// </summary>
        public string CState;
    }

    public class GetAllStateVM
    {
        /// <summary>
        /// 主机guid
        /// </summary>
        public string guid;

        /// <summary>
        /// 测量板个数
        /// </summary>
        public int MesureCount;

       /// <summary>
       /// 测量板1回路状态
       /// </summary>
        public MeasureState OneCircuitList;

        /// <summary>
        /// 测量板2回路状态
        /// </summary>
        public MeasureState TwoCircuitList;

        /// <summary>
        /// 测量板3回路状态
        /// </summary>
        public MeasureState ThreeCircuitList;

        /// <summary>
        /// 项目名
        /// </summary>
       public string Name;

        /// <summary>
        /// 更新时间
        /// </summary>
       public string UpdateTime;
    }
}