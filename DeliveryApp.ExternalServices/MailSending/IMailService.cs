namespace DeliveryApp.ExternalServices.MailSending;

public interface IMailService
{
    Task SendEmailAsync(MailRequest mailRequest);
    Task SendWelcomeEmailAsync(WelcomeRequest request);
}