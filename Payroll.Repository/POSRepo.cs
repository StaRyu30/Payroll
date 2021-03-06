﻿using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class POSRepo
    {
        public static POSResponses Update(SellingHeaderViewModel entities)
        {
            POSResponses result = new POSResponses();
            result.Reference = GetNewReference();
            try
            {
                using (var db = new PayrollContext())
                {
                    SellingHeader sh = new SellingHeader();
                    sh.Id = 0;
                    sh.DateOfSelling = entities.DateOfSelling;
                    sh.SellingTotal = entities.SellingTotal;
                    sh.Reference = result.Reference;
                    sh.Payment = entities.Payment;
                    sh.IsActivated = true;
                    sh.CreatedBy = entities.CreatedBy;
                    sh.CreatedDate = entities.DateOfSelling;
                    foreach (var item in entities.Details)
                    {
                        SellingDetail sd = new SellingDetail();
                        sd.SellingHeaderId = sh.Id;
                        sd.ItemId = item.ItemId;
                        sd.Quantity = item.Quantity;
                        sd.Price = item.Price;
                        sd.Amount = item.Amount;
                        sd.IsActivated = true;
                        sd.CreatedBy = entities.CreatedBy;
                        sd.CreatedDate = entities.DateOfSelling;

                        db.SellingDetail.Add(sd);
                    }
                    db.SellingHeader.Add(sh);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
            }
            return result;
        }

        public static string GetNewReference()
        {
            string newRef = string.Format("SLS-{0}{1}-",
                DateTime.Now.ToString("yy"),
                DateTime.Now.Month.ToString("D2")); //00
            int newIncrement = 1;
            using (var db = new PayrollContext())
            {
                var result = (from sh in db.SellingHeader
                              where sh.Reference.Contains(newRef)
                              select new { reference = sh.Reference })
                              .OrderByDescending(o => o.reference)
                              .FirstOrDefault();
                if (result != null)
                {
                    string[] oldRef = result.reference.Split('-');
                    newIncrement = int.Parse(oldRef[2]) + 1;
                }
            }
            newRef += newIncrement.ToString("D4"); //0000
            return newRef;
        }
    }

    public class POSResponses: Responses
    {
        public string Reference { get; set; }
    }
}
