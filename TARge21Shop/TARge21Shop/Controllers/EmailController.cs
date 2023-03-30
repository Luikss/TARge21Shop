using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;

namespace TARge21Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailServices _emailServices;

        public EmailController(IEmailServices emailServices)
        {
            _emailServices = emailServices;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailServices.SendEmail(request);
            return Ok();
        }
    }
}
