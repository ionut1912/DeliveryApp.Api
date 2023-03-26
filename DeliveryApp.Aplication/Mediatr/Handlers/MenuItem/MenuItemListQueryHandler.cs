using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Mediatr.Handlers.MenuItem;

public class
    MenuItemListQueryHandler : IQueryHandler<ListQuery<Domain.Models.MenuItem>, ResultT<List<Domain.Models.MenuItem>>>
{
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuItemListQueryHandler(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository ?? throw new ArgumentNullException(nameof(menuItemRepository));
    }

    public async Task<ResultT<List<Domain.Models.MenuItem>>> Handle(ListQuery<Domain.Models.MenuItem> request,
        CancellationToken cancellationToken)
    {
        var result = await _menuItemRepository.GetMenuItems(cancellationToken);
        return ResultT<List<Domain.Models.MenuItem>>.Success(result);
    }
}