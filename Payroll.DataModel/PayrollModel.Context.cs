﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PayrollContext : DbContext
    {
        public PayrollContext()
            : base("name=PayrollContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeSalary> EmployeeSalary { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<JobPosition> JobPosition { get; set; }
        public virtual DbSet<PayrollPeriod> PayrollPeriod { get; set; }
        public virtual DbSet<SalaryComponent> SalaryComponent { get; set; }
        public virtual DbSet<SalaryDefaultValue> SalaryDefaultValue { get; set; }
        public virtual DbSet<SellingDetail> SellingDetail { get; set; }
        public virtual DbSet<SellingHeader> SellingHeader { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<AccessControl> AccessControl { get; set; }
        public virtual DbSet<TrPosition> TrPosition { get; set; }
        public virtual DbSet<TrUserAccess> TrUserAccess { get; set; }
    }
}
