using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Aplication.Mediatr.Commands.UserConfigs;

public class UserConfigCreateCommand : ICommand<Result<UserConfig>>
{
    public UserConfig UserConfigs { get; set; }
}