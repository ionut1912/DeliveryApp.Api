﻿using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Repositories;

public interface IOrderRepository
{
    Task AddOrder(OrderForCreationDto orderForCreationDto, CancellationToken cancellationToken);

    Task<List<Order>> GetOrders(CancellationToken cancellationToken);
    Task<List<Order>> GetCurrentUserOrders(CancellationToken cancellationToken);

    Task<Order> GetOrder(Guid id, CancellationToken cancellationToken);
    Task<bool> EditOrder(Guid id, OrderForUpdateDto oreForUpdateDto, CancellationToken cancellationToken);
    Task<bool> DeleteOrder(Guid id, CancellationToken cancellationToken);
}