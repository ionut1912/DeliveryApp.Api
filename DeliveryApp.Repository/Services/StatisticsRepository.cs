using DeliveryApp.Application.Repositories;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository.Services;

public class StatisticsRepository : IStatisticsRepository
{
    private readonly DeliveryContext _deliveryContext;

    public StatisticsRepository(DeliveryContext deliveryContext)
    {
        _deliveryContext = deliveryContext ?? throw new ArgumentNullException(nameof(deliveryContext));
    }

    public async Task<List<MenuItemCountModel>> GetMenuItemCount(CancellationToken cancellationToken)
    {
        var menuItems = await _deliveryContext.MenuItems.AsNoTracking().ToListAsync(cancellationToken);

        return menuItems.Select(menuItem => new MenuItemCountModel
            { MenuItemName = menuItem.ItemName, MenuItemCount = menuItem.Quantity }).ToList();
    }

    public async Task<List<MenuItemInOrderCountModel>> GetMenuItemInOrderCount(CancellationToken cancellationToken)
    {
        return await _deliveryContext.Orders
            .Include(x => x.MenuItems)
            .AsNoTracking()
            .SelectMany(x => x.MenuItems, (order, menuItem) => new { OrderId = order.Id, MenuItemId = menuItem.Id })
            .GroupBy(x => x.MenuItemId)
            .Select(g => new { MenuItemId = g.Key, OrderCount = g.Count() })
            .Join(_deliveryContext.MenuItems,
                order => order.MenuItemId,
                menuItem => menuItem.Id,
                (order, menuItem) => new { menuItem.ItemName, order.OrderCount })
            .Select(x => new MenuItemInOrderCountModel { MenuItemName = x.ItemName, OrderMenuItemCount = x.OrderCount })
            .ToListAsync(cancellationToken);
    }

    public async Task<OrderDetailStatistic> GetOrderFromLastDays(int numberOfDays, CancellationToken cancellationToken)
    {
        var date = DateTime.Now.AddDays(numberOfDays);
        var orders = await _deliveryContext.Orders.AsNoTracking()
            .Where(x => x.ReceivedTime >= date && x.ReceivedTime <= DateTime.Now).ToListAsync(cancellationToken);
        var totalPrice = orders.Sum(order => order.FinalPrice);

        return new OrderDetailStatistic
        {
            TotalPrice = totalPrice,
            OrdersCount = orders.Count()
        };
    }
}