using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Aplication.Mediatr.Commands.UserConfigs;

public class UserConfigsUpdateCommand : ICommand<Result>
{
    public Guid Id { get; set; }
    public UserConfigDto Configs { get; set; }
}