﻿using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Payroll.API.Controllers
{
    
    public class ItemsController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public IEnumerable<ItemViewModel> Get(string search)
        {
            return ItemRepo.GetTen(search);
        }

        // GET api/<controller>/5
        public ItemViewModel Get(int id)
        {
            return ItemRepo.GetById(id);
        }

        // POST api/<controller>
        public Responses Post([FromBody]ItemViewModel entity)
        {
            return ItemRepo.Update(entity);
        }

        // PUT api/<controller>/5
        public Responses Put(int id, [FromBody]ItemViewModel entity)
        {
            entity.Id = id;
            return ItemRepo.Update(entity);
        }

        // DELETE api/<controller>/5
        public Responses Delete(int id)
        {
            return ItemRepo.Delete(id);
        }
    }
}