using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedTech.Web.Controllers
{
    public class TempController : ApiController
    {
        // GET api/temp
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/temp/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/temp
        public void Post([FromBody]string value)
        {
        }

        // PUT api/temp/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/temp/5
        public void Delete(int id)
        {
        }
    }
}
