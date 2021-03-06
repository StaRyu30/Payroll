﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Payroll.DataModel;

namespace Payroll.API
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string password)
        {
            using(var db = new PayrollContext())
            {
                return db.Users.Any(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);
            }
        }
    }
}