using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Commands.UserConfigs;

public class UserConfigCreateCommand : ICommand<ResultT<JsonResponse>>
{
    public UserConfigDto UserConfigs { get; set; }
}