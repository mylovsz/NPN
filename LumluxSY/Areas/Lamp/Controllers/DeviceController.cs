using LumluxSY.Areas.Lamp.Models;
using LumluxSY.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BLL = LumluxSSYDB.BLL;
using Model = LumluxSSYDB.Model;

namespace LumluxSY.Areas.Lamp.Controllers
{
    public class DeviceController : ControllerBaseHelper
    {
        //
        // GET: /Lamp/Device/

        public ActionResult Index()
        {
            DeviceViewModel dvm = new DeviceViewModel();
            dvm.MapCenterLat = "31.298886";
            dvm.MapCenterLng = "120.58531600000003";
            return View(dvm);
        }
        #region 全部数据（包括分组等）
        //public ActionResult GetDeviceTreeForJson()
        //{
        //    string prjGUID = this.PrjGUID;
        //    if (string.IsNullOrEmpty(prjGUID))
        //        return null;
        //    BLL.tLightGroupInfoes lgiBLL = new BLL.tLightGroupInfoes();
        //    BLL.tLightInfoLightGroupInfoes ligiBLL = new BLL.tLightInfoLightGroupInfoes();
        //    BLL.tGroupInfoes giBLL = new BLL.tGroupInfoes();
        //    BLL.tHostInfo hiBLL = new BLL.tHostInfo();
        //    BLL.tLightInfoes liBLL = new BLL.tLightInfoes();
        //    List<Model.tLightGroupInfoes> lgiList;
        //    List<Model.tHostInfo> hiList = hiBLL.GetModelListByPrjGUID(prjGUID);
        //    List<Model.tLightInfoes> liList;
        //    List<Model.tGroupInfoes> giList = giBLL.GetModelListByPrjGUID(prjGUID);
        //    List<Model.tLightInfoLightGroupInfoes> ligiList;
        //    if (hiList.Count == 0)
        //        return null;
        //    StringBuilder result = new StringBuilder();

        //    result.Append("[");
        //    for (int m = 0; m < giList.Count; m++)
        //    {
        //        Model.tGroupInfoes gi = giList[m];
        //        // 主机分组显示
        //        result.Append("{\"id\":\"" + gi.sGUID + "\",");
        //        result.Append("\"text\":\"" + gi.sName + "\",");
        //        result.Append("\"icon\":\"" + "fa fa-warning icon-state-danger" + "\",");
        //        result.Append("\"state\":{\"opened\": false},");
        //        result.Append("\"children\":[");  // 下面是子节点，注意]关闭
        //        List<Model.tHostInfo> l = hiList.Where(t => t.sGroupInfoGUID == gi.sGUID).ToList();
        //        for (int i = 0; i < l.Count; i++)
        //        {
        //            Model.tHostInfo hi = hiList[i];
        //            // 主机显示
        //            result.Append("{\"id\":\"" + hi.sGUID + "\",");
        //            result.Append("\"text\":\"" + hi.sName + "\",");
        //            result.Append("\"icon\":\"" + "fa fa-warning icon-state-danger" + "\",");
        //            result.Append("\"state\":{\"opened\": false},");
        //            result.Append("\"children\":[");  // 下面是子节点，注意]关闭
        //            liList = liBLL.GetModelListByHostGUID(hi.sGUID);
        //            lgiList = lgiBLL.GetModelListByHostGUID(hi.sGUID);
        //            for (int n = 0; n < lgiList.Count;n++ )
        //            {
        //                 Model.tLightGroupInfoes lgi = lgiList[n];
        //                // 单灯分组显示
        //                result.Append("{\"id\":\"" + lgi.sGUID + "\",");
        //                result.Append("\"text\":\"" + lgi.sName + "\",");
        //                result.Append("\"icon\":\"" + "fa fa-warning icon-state-danger" + "\",");
        //                result.Append("\"state\":{\"opened\": false},");
        //                result.Append("\"children\":[");  // 下面是子节点，注意]关闭
        //                ligiList = ligiBLL.GetModelListByLightGroupGUID(lgi.sGUID);

        //                for (int j = 0; j < ligiList.Count; j++)
        //                {
        //                    Model.tLightInfoes li = liList.FirstOrDefault(t=>t.sGUID == ligiList[j].sLightInfoGUID);
        //                    if (li != null)
        //                    {
        //                        result.Append("{\"id\":\"" + li.sGUID + "\",");
        //                        result.Append("\"text\":\"" + li.sName + "\",");
        //                        result.Append("\"icon\":\"" + "fa fa-warning icon-state-danger" + "\"}");
        //                        if (j < ligiList.Count - 1)
        //                            result.Append(",");
        //                    }
        //                }
        //                result.Append("]}");

        //                if (n < lgiList.Count - 1)
        //                    result.Append(",");
        //            }
        //            result.Append("]}");

        //            if (i < l.Count - 1)
        //                result.Append(",");
        //        }
        //        result.Append("]}");

        //        if (m < giList.Count - 1)
        //            result.Append(",");
        //    }

        //    hiList = hiList.Where(t => t.sGroupInfoGUID == "").ToList();
        //    if(hiList.Count >0)
        //        result.Append(",");
        //    for (int i = 0; i < hiList.Count; i++)
        //    {
        //        Model.tHostInfo hi = hiList[i];
        //        // 主机显示
        //        result.Append("{\"id\":\"" + hi.sGUID + "\",");
        //        result.Append("\"text\":\"" + hi.sName + "\",");
        //        result.Append("\"icon\":\"" + "fa fa-warning icon-state-danger" + "\",");
        //        result.Append("\"state\":{\"opened\": false},");
        //        result.Append("\"children\":[");  // 下面是子节点，注意]关闭
        //        liList = liBLL.GetModelListByHostGUID(hi.sGUID);
        //        lgiList = lgiBLL.GetModelListByHostGUID(hi.sGUID);
        //        for (int n = 0; n < lgiList.Count; n++)
        //        {
        //            Model.tLightGroupInfoes lgi = lgiList[n];
        //            // 单灯分组显示
        //            result.Append("{\"id\":\"" + lgi.sGUID + "\",");
        //            result.Append("\"text\":\"" + lgi.sName + "\",");
        //            result.Append("\"icon\":\"" + "fa fa-warning icon-state-danger" + "\",");
        //            result.Append("\"state\":{\"opened\": false},");
        //            result.Append("\"children\":[");  // 下面是子节点，注意]关闭
        //            ligiList = ligiBLL.GetModelListByLightGroupGUID(lgi.sGUID);

        //            for (int j = 0; j < ligiList.Count; j++)
        //            {
        //                Model.tLightInfoes li = liList.FirstOrDefault(t => t.sGUID == ligiList[j].sLightInfoGUID);
        //                if (li != null)
        //                {
        //                    result.Append("{\"id\":\"" + li.sGUID + "\",");
        //                    result.Append("\"text\":\"" + li.sName + "\",");
        //                    result.Append("\"icon\":\"" + "fa fa-warning icon-state-danger" + "\"}");
        //                    if (j < ligiList.Count - 1)
        //                        result.Append(",");
        //                }
        //            }
        //            result.Append("]}");

        //            if (n < lgiList.Count - 1)
        //                result.Append(",");
        //        }
        //        result.Append("]}");

        //        if (i < hiList.Count - 1)
        //            result.Append(",");
        //    }
        //    result.Append("]");
        //    return Content(result.ToString());
        //}
        #endregion 全部数据（包括分组等）

        /// <summary>
        /// 根据主机GUID，获取整个主机的信息
        /// </summary>
        /// <param name="hostGUID"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetHostInfoByHostGUID(string hostGUID)
        {
            Model.tHostInfo hi = new BLL.tHostInfo().GetModel(hostGUID);
            if (hi != null)
            {
                return Json(hi);
            }
            return null;
        }

        /// <summary>
        /// 根据主机GUID，获取整个主机的编辑视图页面
        /// </summary>
        /// <param name="hostGUID"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditHostInfo(string hostGUID)
        {
            Model.tHostInfo hi = new BLL.tHostInfo().GetModel(hostGUID);
            if (hi != null)
            {
                return PartialView(hi);
            }
            return null;
        }

        [HttpPost]
        public ActionResult GetHostInfos()
        {
            string prjGUID = this.PrjGUID;
            if (string.IsNullOrEmpty(prjGUID))
                return null;
            List<Model.tHostInfo> hiList = new BLL.tHostInfo().GetModelListByPrjGUID(prjGUID);
            return Json(hiList);
        }

        public ActionResult GetDeviceTreeForJson()
        {
            string prjGUID = this.PrjGUID;
            if (string.IsNullOrEmpty(prjGUID))
                return null;
            BLL.tHostInfo hiBLL = new BLL.tHostInfo();
            BLL.tLightInfoes liBLL = new BLL.tLightInfoes();
            List<Model.tHostInfo> hiList = hiBLL.GetModelListByPrjGUID(prjGUID);
            List<Model.tLightInfoes> liList;
            if (hiList.Count == 0)
                return null;
            StringBuilder result = new StringBuilder();
            result.Append("[");
            for (int i = 0; i < hiList.Count; i++)
            {
                Model.tHostInfo hi = hiList[i];

                result.Append("{\"id\":\"" + hi.sGUID + "\",");
                result.Append("\"text\":\"" + hi.sName + "\",");
                result.Append("\"icon\":\"" + "fa fa-warning icon-state-danger" + "\",");
                result.Append("\"state\":{\"opened\": false},");
                result.Append("\"children\":[");  // 下面是子节点，注意]关闭
                liList = liBLL.GetModelListByHostGUID(hi.sGUID);
                for (int j = 0; j < liList.Count; j++)
                {
                    Model.tLightInfoes li = liList[j];

                    result.Append("{\"id\":\"" + li.sGUID + "\",");
                    result.Append("\"text\":\"" + li.sName + "\",");
                    result.Append("\"icon\":\"" + "fa fa-warning icon-state-danger" + "\"}");
                    if (j < liList.Count - 1)
                        result.Append(",");
                }
                result.Append("]}");
                if (i < hiList.Count - 1)
                    result.Append(",");
            }
            result.Append("]");
            return Content(result.ToString());
        }

        //
        // GET: /Lamp/Device/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Lamp/Device/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Lamp/Device/Create

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
        // GET: /Lamp/Device/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Lamp/Device/Edit/5

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
        // GET: /Lamp/Device/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Lamp/Device/Delete/5

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
