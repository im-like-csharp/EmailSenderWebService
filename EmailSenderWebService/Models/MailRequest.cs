namespace EmailSenderWebService.Models;

public class MailRequest
{
    public string Subject { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
}