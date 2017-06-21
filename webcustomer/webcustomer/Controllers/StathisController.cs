using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stathis.Data;
using Stathis.Repository;

namespace webcustomer.Controllers
{
    [RoutePrefix("api/webcustomer")]
    public class StathisController : ApiController
    {
        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var customerRepo = new CustomerRepository();
            //return customerRepo.GetCustomers();
            return Request.CreateResponse(HttpStatusCode.OK, customerRepo.GetCustomers());
        }

        [Route("{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var customerRepo = new CustomerRepository();
            return Request.CreateResponse(HttpStatusCode.OK, customerRepo.GetById(id));

        }
    }
}
