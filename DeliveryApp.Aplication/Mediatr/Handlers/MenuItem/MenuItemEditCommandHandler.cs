using DeliveryApp.Aplication.Mediatr.Commands.MenuItem;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Handlers.MenuItem;

public class MenuItemEditCommandHandler : ICommandHandler<MenuItemEditCommand, ResultT<Unit>>
{
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuItemEditCommandHandler(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository ?? throw new ArgumentNullException(nameof(menuItemRepository));
    }

    public async Task<ResultT<Unit>> Handle(MenuItemEditCommand request, CancellationToken cancellationToken)
    {
        return await _menuItemRepository.EditMenuItem(request, cancellationToken);
    }
}