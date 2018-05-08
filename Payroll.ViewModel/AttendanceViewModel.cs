using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{   
    public class AttendanceViewModel
    {
        public int Id { get; set; }

        public string BadgeId { get; set; }

        [Display(Name = "Check In"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}"), Required]
        public DateTime CheckIn { get; set; }

        [Display(Name = "Check Out"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}"), Required]
        public DateTime CheckOut { get; set; }

        public bool IsActivated { get; set; }
    }
}
