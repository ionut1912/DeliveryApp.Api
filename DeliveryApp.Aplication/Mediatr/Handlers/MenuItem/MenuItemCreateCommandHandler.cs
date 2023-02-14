using DeliveryApp.Application.Mediatr.Commands.MenuItem;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Handlers.MenuItem;

public class MenuItemCreateCommandHandler : ICommandHandler<MenuItemCreateCommand, Result>
{
    private readonly IMenuItemRepository _menuItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MenuItemCreateCommandHandler(IMenuItemRepository menuItemRepository, IUnitOfWork unitOfWork)
    {
        _menuItemRepository = menuItemRepository ?? throw new ArgumentNullException(nameof(menuItemRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Result> Handle(MenuItemCreateCommand request,
        CancellationToken cancellationToken)
    {
        await _menuItemRepository.AddMenuItems(request.MenuItemDto, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success("Menu item created succesfully");
    }
}