namespace DeliveryApp.Domain.MailSender;

public class WelcomeRequest
{
    public string ToEmail { get; set; }
    public string UserName { get; set; }
}