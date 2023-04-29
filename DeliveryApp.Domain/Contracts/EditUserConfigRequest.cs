using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Domain.Contracts;

public class EditUserConfigRequest
{
    public string Language { get; set; }
    public UserConfigDto Configs { get; set; }
}