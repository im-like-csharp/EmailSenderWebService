using EmailSenderWebService.Models;

namespace EmailSenderWebService.Services;

public interface IMailService
{
    Task SendEmailAsync(MailRequest mailRequest);
}