using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Repositories;

public interface IStatisticsRepository
{
    Task<List<MenuItemCountModel>> GetMenuItemCount(CancellationToken cancellationToken);
    Task<List<MenuItemInOrderCountModel>> GetMenuItemInOrderCount(CancellationToken cancellationToken);
    Task<OrderDetailStatistic> GetOrderFromLastDays(int numberOfDays, CancellationToken cancellationToken);
}