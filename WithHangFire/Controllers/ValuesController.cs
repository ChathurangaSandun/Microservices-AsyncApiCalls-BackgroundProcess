using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using WithHangFire.Services;

namespace WithHangFire.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEmailService emailService;
        public ValuesController(IEmailService  emailService)
        {
            this.emailService = emailService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            //RecurringJob.AddOrUpdate(() => Console.WriteLine("Recurring!"), Cron.Minutely);

            // send email after 2 min
            var jobId = BackgroundJob.Schedule<IEmailService>(service => service.SendMail(),
                TimeSpan.FromMinutes(2));

            return jobId+ "";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
