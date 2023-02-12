using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Aplication.Repositories;

public interface IMenuItemRepository
{
    Task AddMenuItems(MenuItemDto menuItemDto, CancellationToken cancellationToken);

    Task<List<MenuItem>> GetMenuItems(CancellationToken cancellationToken);

    Task<MenuItem> GetMenuItem(Guid id, CancellationToken cancellationToken);

    Task<bool> EditMenuItem(Guid id, MenuItemDto menuItemDto, CancellationToken token);
}