﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class SalaryComponentViewModel
    {
        public SalaryComponentViewModel()
        {
            IsActivated = true;
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public string Period { get; set; }

        [Display(Name = "Period")]
        public string PeriodName
        {
            get
            {
                if (Period == "M")
                {
                    return "Monthly";
                }
                else if (Period == "D")
                {
                    return "Daily";
                }
                else
                {
                    return "Unknown";
                }
            }
        }

        public string Type { get; set; }
        public bool IsActivated { get; set; }
    }

}
