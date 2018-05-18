using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payroll.MVC.Models
{
    public class Account
    {
        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string[] Roles
        {
            get;
            set;
        }
    }
}