using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PinkMind.Controllers
{
    public class IssueAPIController : ApiController
    {
        // GET: api/IssueAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/IssueAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/IssueAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/IssueAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/IssueAPI/5
        public void Delete(int id)
        {
        }
    }
}
