using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Commands.Order;

public class OrderEditCommand : ICommand<Result<Unit>>
{
    public Guid Id { get; set; }
    public OrderForUpdate OrderForUpdate { get; set; }
}