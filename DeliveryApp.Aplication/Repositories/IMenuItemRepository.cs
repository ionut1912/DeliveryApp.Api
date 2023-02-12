using DeliveryApp.Domain.DTO;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Repositories;

public interface IMenuItemRepository
{
    Task AddMenuItems(MenuItemDto menuItemDto,CancellationToken cancellationToken);

    Task<List<MenuItem>> GetMenuItems(CancellationToken cancellationToken);

    Task<MenuItem> GetMenuItem(Guid id,MenuItemDto menuItemDto,CancellationToken cancellationToken);

    Task<bool> EditMenuItem(Guid id, CancellationToken token);
}