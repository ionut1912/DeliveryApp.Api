using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Commands.Order;

public class OrderCreateCommand : ICommand<Result<Orders>>
{
    public OrderForCreation Order { get; set; }
}