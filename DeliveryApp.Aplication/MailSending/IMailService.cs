using DeliveryApp.Domain.MailSender;

namespace DeliveryApp.Aplication.MailSending
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        Task SendWelcomeEmailAsync(WelcomeRequest request);
    }
}
