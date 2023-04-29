using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Contracts;

namespace DeliveryApp.Application.Mediatr.Commands.UserConfigs;

public class UserConfigsUpdateCommand : ICommand<ResultT<JsonResponse>>
{
    public Guid Id { get; set; }
    public EditUserConfigRequest Request { get; set; }
}