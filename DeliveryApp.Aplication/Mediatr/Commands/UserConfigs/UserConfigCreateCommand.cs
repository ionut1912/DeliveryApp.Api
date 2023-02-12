using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Aplication.Mediatr.Commands.UserConfigs;

public class UserConfigCreateCommand : ICommand<Result>
{
    public UserConfigDto UserConfigs { get; set; }
}