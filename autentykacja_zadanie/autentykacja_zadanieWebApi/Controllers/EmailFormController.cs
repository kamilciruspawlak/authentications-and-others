using autentykacja_zadanieWebApi.Models;
using autentykacja_zadanieWebApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace autentykacja_zadanieWebApi.Controllers
{
    public class EmailFormController : ApiController
    {
        // GET: api/EmailForm
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EmailForm/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EmailForm
        [ResponseType(typeof(EmailForm))]
        public IHttpActionResult PostPerformance(EmailForm emailForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = new EmailService();
            service.SendEmail(emailForm);
          

            return Ok();
        }

        // PUT: api/EmailForm/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EmailForm/5
        public void Delete(int id)
        {
        }
    }
}
