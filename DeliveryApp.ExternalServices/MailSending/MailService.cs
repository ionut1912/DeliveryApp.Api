using DeliveryApp.ExternalServices.MailSending.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace DeliveryApp.ExternalServices.MailSending;

public class MailService : IMailService
{
    private readonly MailSettings _mailSettings;

    public MailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }

    public async Task SendEmailAsync(MailRequest mailRequest)
    {
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        email.Subject = mailRequest.Subject;
        var builder = new BodyBuilder();
        if (mailRequest.Attachments != null)
            foreach (var file in mailRequest.Attachments.Where(file => file.Length > 0))
            {
                byte[] fileBytes;
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    fileBytes = ms.ToArray();
                }

                builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
            }

        builder.HtmlBody = mailRequest.Body;
        email.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }

    public async Task SendWelcomeEmailAsync(WelcomeRequest request)
    {
        const string filePath =
            "C:\\Users\\nites\\Desktop\\Projects\\Delivery\\DeliveryApp.Api\\DeliveryApp.ExternalServices\\MailSending\\Templates\\WelcomeTemplate.html";
        var str = new StreamReader(filePath);
        var mailText = await str.ReadToEndAsync();
        str.Close();
        mailText = mailText.Replace("[username]", request.UserName).Replace("[email]", request.ToEmail);
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        email.To.Add(MailboxAddress.Parse(request.ToEmail));
        email.Subject = $"Welcome {request.UserName}";
        var builder = new BodyBuilder
        {
            HtmlBody = mailText
        };
        email.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}