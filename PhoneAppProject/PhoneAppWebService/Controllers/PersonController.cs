using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using ContactDAL;
using PhoneAppProject;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace PhoneAppWebService.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PersonController : ApiController
    {
        SQLFunctions peopleDB = new SQLFunctions();

        [HttpGet]
        public List<Person> Get()
        {
            var people = peopleDB.LoadIntoCollection();
            return people;
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]Person person)
        {
            if(person != null)
            {
                return Ok("Person Added Successfully!!");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
