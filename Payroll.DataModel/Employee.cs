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
    
    public partial class Employee
    {
        public int Id { get; set; }
        public string BadgeId { get; set; }
        public int JobPositionId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public System.DateTime DateOfHire { get; set; }
        public Nullable<System.DateTime> DateOfResign { get; set; }
        public string PlaceOfBirth { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public bool IsActivated { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual JobPosition JobPosition { get; set; }
    }
}
