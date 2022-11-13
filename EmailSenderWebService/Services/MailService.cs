using EmailSenderWebService.Data;
using EmailSenderWebService.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace EmailSenderWebService.Services;

public class MailService : IMailService
{
    private readonly MailSettings _mailSettings;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly OrganizationContext _organizationContext;

    public MailService(IOptions<MailSettings> mailSettings, IEmployeeRepository employeeRepository, 
        OrganizationContext organizationContext)
    {
        _mailSettings = mailSettings.Value;
        _employeeRepository = employeeRepository;
        _organizationContext = organizationContext;
    }

    public async Task SendEmailAsync(MailRequest mailRequest)
    {
        var managementGroupId = _organizationContext
            .Set<Group>()
            .FirstOrDefault(x => x.Name == "Руководство")?
            .Id;
        
        var emailsList = _employeeRepository.GetEmployeesEmailsByGroupId(managementGroupId ?? 0).ToArray();

        using (var smtp = new SmtpClient())
        {
            await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);

            foreach (var email in emailsList)
            {
                await smtp.SendAsync(new MimeMessage
                {
                    From = { new MailboxAddress("", _mailSettings.Mail) },
                    To = { new MailboxAddress("", email) },
                    Subject = mailRequest.Subject,
                    Body = new BodyBuilder
                    {
                        TextBody = mailRequest.Text
                    }.ToMessageBody()
                });
            }
            
            await smtp.DisconnectAsync(true);
        }
    }
}