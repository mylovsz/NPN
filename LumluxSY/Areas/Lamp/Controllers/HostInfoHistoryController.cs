using LumluxSY.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LumluxSY.Areas.Lamp.Controllers
{
    public class HostInfoHistoryController : ControllerBaseHelper
    {
        //
        // GET: /Lamp/HostInfoHistory/

        public ActionResult Index()
        {
            return View();
        }

        public struct HostState
        {
            public string hostname;
            public string statetype;
            public string state;
            public string starttime;
            public string stoptime;
            public string guid;
            public List<LightState> lightstate;
        }
        public struct LightState
        {
            public string lightname;
            public string voltage;
            public string current;
            public string power;
            public string phase;
            public string time;
            public string state;
        }

        public struct HostStateList
        {
            public List<HostState> data;
        }

        public ActionResult Returnjsonresult()
        {
            string guid = Request.QueryString["guid"];
            HostStateList data = new HostStateList();
            data.data = new List<HostState>();
            for (int i = 0; i < 10; i++)
            {
                HostState a = new HostState { guid = Guid.NewGuid().ToString(), hostname = "干将中路", starttime = DateTime.Now.ToString(), stoptime = DateTime.Now.ToString() ,state="正常",statetype="状态"};
                a.lightstate = new List<LightState>();
                for (int j = 0; j < 10; j++)
                {
                    LightState ls = new LightState { lightname = "回路" + j, current = "1.0", phase = "A", power = "220", time = DateTime.Now.ToString(), voltage = "220", state = "正常" };
                    a.lightstate.Add(ls);
                }
                data.data.Add(a);
            }
            var c=JsonDate(data);
            return c; 
        }


        //public struct Data
        //{
        //    public string year;
        //    public string value;
        //}

        public struct WholeData
        {
            public string label;
            public string[,] data;
        }

        public ActionResult GetJsonData()
        {
            WholeData data = new WholeData();
            data.data = new string[10000,2];
            for (int i = 0; i < 10000; i++)
            {
                int d = 2010;
                double jk = 2.3;
                data.data[i, 0] = (d+i).ToString();
                data.data[i, 1] = (jk + i).ToString() ;
            }
            data.label = "苟宇航";
            var c = JsonDate(data);
            return c; 
        }

        public ActionResult Returnjsonresult1()
        {
            List<LightState> data = new List<LightState>();
            for (int i = 0; i < 10; i++)
            {
                LightState a = new LightState {lightname="回路"+i,current="1.0",phase="A",power="220",time=DateTime.Now.ToString(),voltage="220",state="正常"};
                data.Add(a);
            }
            var c = JsonDate(data);
            return c; 
        }

        //
        // GET: /Lamp/HostInfoHistory/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Lamp/HostInfoHistory/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Lamp/HostInfoHistory/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Lamp/HostInfoHistory/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Lamp/HostInfoHistory/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Lamp/HostInfoHistory/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Lamp/HostInfoHistory/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
