using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Aplication.Mediatr.Commands.UserConfigs;

public class UserConfigCreateCommand : ICommand<ResultT<UserConfigDto>>
{
    public UserConfigDto UserConfigs { get; set; }
}