using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Aplication.Mediatr.Handlers.MenuItem;

public class MenuItemListQueryHandler : IQueryHandler<ListQuery<Domain.Models.MenuItemDto>, ResultT<List<Domain.Models.MenuItemDto>>>
{
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuItemListQueryHandler(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository ?? throw new ArgumentNullException(nameof(menuItemRepository));
    }

    public async Task<ResultT<List<Domain.Models.MenuItemDto>>> Handle(ListQuery<Domain.Models.MenuItemDto> request,
        CancellationToken cancellationToken)
    {
        return await _menuItemRepository.GetMenuItems(request, cancellationToken);
    }
}