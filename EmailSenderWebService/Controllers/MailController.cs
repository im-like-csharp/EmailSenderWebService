using EmailSenderWebService.Models;
using EmailSenderWebService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderWebService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MailController : Controller
{
    private readonly IMailService _mailService;

    public MailController(IMailService mailService)
    {
        _mailService = mailService;
    }
    
    [HttpPost]
    public async Task<IActionResult> SendEmail([FromBody]MailRequest request)
    {
        try
        {
            await _mailService.SendEmailAsync(request);
        }
        catch (Exception ex)
        {
            BadRequest(ex.Message);
        }
        
        return Ok();
    }
}