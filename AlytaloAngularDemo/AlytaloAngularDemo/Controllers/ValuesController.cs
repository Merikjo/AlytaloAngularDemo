using AlytaloAngularDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AlytaloAngularDemo.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        [HttpGet]
        [Route("api/Values/OrderCount")]
        public int OrderCount()
        {
            NorthwindDemoEntities entities = new NorthwindDemoEntities();
            int orderCount = entities.Orders.Count();
            entities.Dispose();
            return orderCount;
        }

        [HttpGet]
        [Route("api/Values/LastNOrders/{id:int}")]
        public List<string> LastNOrders(int id)
        {
            NorthwindDemoEntities entities = new NorthwindDemoEntities();
            int numberOfOrdersToReturn = id;
            List<Orders> lastOrders = 
                (from o in entities.Orders orderby o.OrderDate descending select o).Take(numberOfOrdersToReturn).ToList();
            List<string> customerNames =
                lastOrders.Select(o => o.Customers.CompanyName).ToList();
            entities.Dispose();
            return customerNames;
        }
    }
}
