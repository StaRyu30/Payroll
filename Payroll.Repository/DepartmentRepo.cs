﻿using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class DepartmentRepo
    {
        public static List<DepartmentViewModel> Get()
        {
            List<DepartmentViewModel> result = new List<DepartmentViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Department
                          join div in db.Division on 
                          d.DivisionId equals div.Id
                          select new DepartmentViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              DivisionId = d.DivisionId,
                              DivisionCode = div.Code,
                              DivisionName = div.Description,
                              Description = d.Description,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }

        public static DepartmentViewModel GetById(int id)
        {
            DepartmentViewModel result = new DepartmentViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Department
                          //join div in db.Division on
                          //d.DivisionId equals div.Id
                          where d.Id == id
                          select new DepartmentViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              DivisionId = d.DivisionId,
                              //DivisionCode = div.Code,
                              //DivisionName = div.Description,
                              Description = d.Description,
                              IsActivated = d.IsActivated
                          }).FirstOrDefault();
            }
            return result;
        }

        public static List<DepartmentViewModel> GetByDivId(int divId)
        {
            List<DepartmentViewModel> result = new List<DepartmentViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from div in db.Division
                          join dep in db.Department on
                          div.Id equals dep.DivisionId
                          where div.Id == divId
                          select new DepartmentViewModel
                          {
                              Id = dep.Id,
                              Code = dep.Code,
                              Description = dep.Description,
                              DivisionId = div.Id,
                              DivisionCode = div.Code,
                              DivisionName = div.Description,
                              IsActivated = dep.IsActivated
                          }).ToList();
            }
            return result;
        }

        public static Responses Update(DepartmentViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        Department department = db.Department.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (department != null)
                        {
                            department.Code = entity.Code;
                            department.DivisionId = entity.DivisionId;
                            department.Description = entity.Description;
                            department.IsActivated = entity.IsActivated;
                            department.ModifiedBy = "Ryan";
                            department.ModifiedDate = DateTime.Now;
                            db.SaveChanges();
                        }
                        
                    }
                    else
                    {
                        Department department = new Department();
                        department.Code = entity.Code;
                        department.DivisionId = entity.DivisionId;
                        department.Description = entity.Description;
                        department.IsActivated = entity.IsActivated;
                        department.CreatedBy = "Ryan";
                        department.CreatedDate = DateTime.Now;
                        db.Department.Add(department);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
            }
            return result;
        }

        public static Responses Delete(int id)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    Department department = db.Department.Where(o => o.Id == id).FirstOrDefault();
                    if (department != null)
                    {
                        db.Department.Remove(department);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
            }
            return result;
        }
    }
}
