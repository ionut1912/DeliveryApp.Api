using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Commands;

public class UserConfigsUpdateCommand : ICommand<Result<Unit>>
{
    public int id { get; set; }
    public UserConfigForUpdate configs { get; set; }
}