using LumluxSY.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LumluxSY.Areas.Lamp.Controllers
{
    public class DialogController : ControllerBaseHelper
    {
        public ActionResult GetUserProjectInfo()
        {
            if (!string.IsNullOrWhiteSpace(this.UserID))
            {
                LumluxSSYDB.BLL.tUserInfoes bllUser = new LumluxSSYDB.BLL.tUserInfoes();
                LumluxSSYDB.Model.tUserInfoes modelUser = new LumluxSSYDB.Model.tUserInfoes();
                LumluxSSYDB.BLL.tPrjectInfo bllProject = new LumluxSSYDB.BLL.tPrjectInfo();
                LumluxSSYDB.Model.tPrjectInfo modelProject = new LumluxSSYDB.Model.tPrjectInfo();
                modelUser = bllUser.GetModel(this.UserID);
                if ((modelUser!=null)&&(!string.IsNullOrWhiteSpace(modelUser.sPrjectInfoGUID)))
                {
                     modelProject = bllProject.GetModel(modelUser.sPrjectInfoGUID);
                    return View();
                }
                else
	            {
                    return View();
	            }
               
            }
            else
            {
                return View();
            }
        }
        //
        // GET: /Lamp/Dialog/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Lamp/Dialog/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Lamp/Dialog/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Lamp/Dialog/Create

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
        // GET: /Lamp/Dialog/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Lamp/Dialog/Edit/5

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
        // GET: /Lamp/Dialog/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Lamp/Dialog/Delete/5

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
