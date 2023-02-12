using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Commands.UserConfigs;

public class UserConfigsUpdateCommand : ICommand<ResultT<Unit>>
{
    public int Id { get; set; }
    public UserConfigDto Configs { get; set; }
}