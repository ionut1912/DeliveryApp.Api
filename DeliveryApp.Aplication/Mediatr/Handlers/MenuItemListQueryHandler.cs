using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Handlers;

public class MenuItemListQueryHandler : IQueryHandler<ListQuery<MenuItems>, Result<List<MenuItems>>>
{
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuItemListQueryHandler(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository ?? throw new ArgumentNullException(nameof(menuItemRepository));
    }

    public async Task<Result<List<MenuItems>>> Handle(ListQuery<MenuItems> request,
        CancellationToken cancellationToken)
    {
        return await _menuItemRepository.GetMenuItems(request, cancellationToken);
    }
}