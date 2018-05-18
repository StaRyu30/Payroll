using Payroll.MVC.Security;
using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Payroll.MVC.Controllers
{
    [CustomAuthorize(Roles = "Department")]
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }
        
        //GET LIST
        public ActionResult List()
        {
            return View("_List",DepartmentRepo.Get());
        }

        //GET create
        [CustomAuthorize(Roles = "Department", AccessLevel = "W")]
        public ActionResult Create()
        {
            ViewBag.DivisionList = new SelectList(DivisionRepo.Get(),"Id","Description");
            return View("_Create");
        }

        //POST create
        [HttpPost]
        [CustomAuthorize(Roles = "Department", AccessLevel = "W")]
        public ActionResult Create(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = (DepartmentRepo.Update(model));
                if (responses.Success)
                {
                    return Json(new { success = true}, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
        }

        //GET Edit
        [CustomAuthorize(Roles = "Department", AccessLevel = "W")]
        public ActionResult Edit(int Id)
        {
            ViewBag.DivisionList = new SelectList(DivisionRepo.Get(), "Id", "Description");
            return View("_Edit",DepartmentRepo.GetById(Id));
        }

        //POST EDIT
        [HttpPost]
        [CustomAuthorize(Roles = "Department", AccessLevel = "W")]
        public ActionResult Edit(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = (DepartmentRepo.Update(model));
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
        [CustomAuthorize(Roles = "Department", AccessLevel = "W")]
        public ActionResult Delete(int id)
        {            
            return View("_Delete", DepartmentRepo.GetById(id));
        }
        
        //POST DELETE
        [HttpPost]
        [CustomAuthorize(Roles = "Department", AccessLevel = "W")]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = (DepartmentRepo.Delete(id));
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            
            return Json(new { success = false, message = "Error Msg" }, JsonRequestBehavior.AllowGet);
        }
    }
}