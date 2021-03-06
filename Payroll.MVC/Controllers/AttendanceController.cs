﻿using Payroll.MVC.Security;
using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll.MVC.Controllers
{
    [CustomAuthorize(Roles = "Attendance")]
    public class AttendanceController : Controller
    {
        // GET: Attendance
        public ActionResult Index()
        {
            return View();
        }

        //GET LIST
        public ActionResult List()
        {
            return View("_List", AttendanceRepo.Get());
        }

        //GET CREATE
        public ActionResult Create()
        {
            return View("_Create");
        }

        //POST create
        [HttpPost]
        public ActionResult Create(AttendanceViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = (AttendanceRepo.Update(model));
                if (responses.Success)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
        }

        //GET Edit
        public ActionResult Edit(int Id)
        {            
            return View("_Edit", AttendanceRepo.GetById(Id));
        }

        //POST EDIT
        [HttpPost]
        public ActionResult Edit(AttendanceViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = (AttendanceRepo.Update(model));
                if (responses.Success)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
        }

        //GET DELETE
        public ActionResult Delete(int id)
        {
            return View("_Delete", AttendanceRepo.GetById(id));
        }

        //POST DELETE
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = (AttendanceRepo.Delete(id));
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, message = "Error Msg" }, JsonRequestBehavior.AllowGet);
        }
    }
}