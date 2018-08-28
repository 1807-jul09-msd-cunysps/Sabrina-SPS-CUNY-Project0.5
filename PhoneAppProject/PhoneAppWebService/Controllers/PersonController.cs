using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using Newtonsoft.Json;
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
        [Route("api/Person")]
        public List<Person> Get()
        {
            var people = peopleDB.LoadIntoCollection();
            return people;
        }

        [HttpPost]
        [Route("api/Person")]
        public IHttpActionResult Post([FromBody]Person person)
        {

            try
            {
                peopleDB.writePersonToDB(person);
                return Ok("Person inserted");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Message")]
        public List<Message> GetMessage()
        {
            var messages = peopleDB.loadMessageFromDB();
            return messages;
        }


        [HttpPost]
        [Route("api/Message")]
        public IHttpActionResult PostMessage([FromBody]Message message)
        {
            try
            {
                peopleDB.writeMessageToDB(message);
                return Ok("Message Inserted");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }
    }
}
