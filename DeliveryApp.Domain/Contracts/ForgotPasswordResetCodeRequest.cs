namespace DeliveryApp.Domain.Contracts;

public class ForgotPasswordResetCodeRequest
{
    public string Email { get; set; }
    public string Language { get; set; }
}