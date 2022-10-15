using Microsoft.AspNetCore.Mvc;

namespace SendEmailWithWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            this._emailService = emailService;
            
        }
        [HttpPost]
        public IActionResult SendEmail(Email body)
        {
            _emailService.SendEmail(body);

            return Ok();
        }
    }
}