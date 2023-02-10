using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Commands.UserConfigs;

public class UserConfigsUpdateCommand : ICommand<Result<Unit>>
{
    public int Id { get; set; }
    public UserConfigForUpdate Configs { get; set; }
}