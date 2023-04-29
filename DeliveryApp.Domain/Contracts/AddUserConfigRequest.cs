using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Domain.Contracts;

public class AddUserConfigRequest
{
    public string Language { get; set; }
    public UserConfigDto UserConfig { get; set; }
}