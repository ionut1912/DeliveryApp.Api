﻿using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Commands.Order;

public class OrderEditCommand : ICommand<Result>
{
    public Guid Id { get; set; }
    public OrderForUpdateDto OrderForUpdate { get; set; }
}