using DeliveryApp.Aplication.Mediatr.Commands.MenuItem;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Aplication.Mediatr.Handlers.MenuItem;

public class MenuItemCreateCommandHandler : ICommandHandler<MenuItemCreateCommand, Result<Domain.Models.MenuItem>>
{
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuItemCreateCommandHandler(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository ?? throw new ArgumentNullException(nameof(menuItemRepository));
    }

    public async Task<Result<Domain.Models.MenuItem>> Handle(MenuItemCreateCommand request,
        CancellationToken cancellationToken)
    {
        return await _menuItemRepository.AddMenuItems(request, cancellationToken);
    }
}