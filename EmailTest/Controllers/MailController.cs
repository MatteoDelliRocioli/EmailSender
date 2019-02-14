using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailTest.Models;
using EmailTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EmailTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MailController : Controller
    {
        private readonly IEmailService _emailService;

        public MailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        // GET: api/Mail
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Mail/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mail
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            //Papercut@papercut.com
            try
            {
                await _emailService.SendEmailAsync("others-email@gmail.com", "testEmail", "testMessage");
                return StatusCode(201);
            }
            catch(Exception e)
            {
                return StatusCode(400);
            }
        }

        // PUT: api/Mail/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
    }
}
