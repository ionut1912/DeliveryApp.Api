using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Mediatr.Handlers.MenuItem;

public class
    MenuItemListQueryHandler : IQueryHandler<ListQuery<MenuItemWithImage>, ResultT<List<MenuItemWithImage>>>
{
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuItemListQueryHandler(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository ?? throw new ArgumentNullException(nameof(menuItemRepository));
    }

    public async Task<ResultT<List<MenuItemWithImage>>> Handle(ListQuery<MenuItemWithImage> request,
        CancellationToken cancellationToken)
    {
        var result = await _menuItemRepository.GetMenuItems(cancellationToken);
        return ResultT<List<MenuItemWithImage>>.Success(result);
    }
}