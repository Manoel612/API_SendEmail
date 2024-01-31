using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using SendEmail.Interfaces;
using SendEmail.Models;

namespace SendEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Emails : ControllerBase
    {
        /*
            ewell.boehm@ethereal.email
            NwG923gxcRfeT4cvqv
            smtp.ethereal.email
        */

        private readonly IEmailService _emailService;

        public Emails(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(MessageModel request)
        {
            _emailService.SendEmail(request);
            return Ok();
        }
    }
}
