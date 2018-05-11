using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class SellingHeaderViewModel
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public DateTime DateOfSelling { get; set; }
        public decimal SellingTotal { get; set; }
        public decimal Payment { get; set; }
        public bool IsActivated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public List<SellingDetailViewModel> Details { get; set; }
    }
}
