using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Repositories;

public interface IMenuItemRepository
{
    Task AddMenuItems(MenuItemDto menuItemDto, CancellationToken cancellationToken);

    Task<List<MenuItemWithImage>> GetMenuItems(CancellationToken cancellationToken);

    Task<MenuItemWithImages> GetMenuItem(Guid id, CancellationToken cancellationToken);

    Task<bool> EditMenuItem(Guid id, MenuItemDto menuItemDto, CancellationToken token);
}