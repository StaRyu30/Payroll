//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Payroll.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeSalary
    {
        public int Id { get; set; }
        public string BadgeId { get; set; }
        public int PayrollPeriodId { get; set; }
        public decimal BasicValue { get; set; }
        public decimal FinalValue { get; set; }
        public bool IsActivated { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public int SalaryComponentId { get; set; }
    
        public virtual PayrollPeriod PayrollPeriod { get; set; }
        public virtual SalaryComponent SalaryComponent { get; set; }
    }
}
