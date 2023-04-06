using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Models.Email;

namespace TARge21Shop.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailServices _emailServices;

        public EmailController(IEmailServices emailServices)
        {
            _emailServices = emailServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(EmailViewModel request)
        {
            var dto = new EmailDto()
            {
                To = request.To,
                Subject = request.Subject,
                Body = request.Body,
            };

            _emailServices.SendEmail(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
