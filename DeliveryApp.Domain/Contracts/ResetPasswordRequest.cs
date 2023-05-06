namespace DeliveryApp.Domain.Contracts;

public class ResetPasswordRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Language { get; set; }
}