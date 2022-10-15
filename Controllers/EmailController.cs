using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace SendEmailWithWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("richie.strosin@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("richie.strosin@ethereal.email"));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = body
            };

            using var smtp = new SmtpClient();

            smtp.Connect("smtp.ethereal.email",port:587, SecureSocketOptions.StartTls);
            smtp.Authenticate("daisy58@ethereal.email", "2btGgXwgCJSfrE3v1X");
            smtp.Send(email);

            smtp.Disconnect(true);

            return Ok();
        }
    }
}