using DeliveryApp.Application.Mediatr.Commands.MenuItem;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Handlers.MenuItem;

public class MenuItemEditCommandHandler : ICommandHandler<MenuItemEditCommand, Result>
{
    private readonly IMenuItemRepository _menuItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public async Task<Result> Handle(MenuItemEditCommand request, CancellationToken cancellationToken)
    {
        var result = await _menuItemRepository.EditMenuItem(request.Id, request.MenuItemDto, cancellationToken);
        if (result is false) return Result.Failure($"Menu item with id {request.Id} can not be modified");

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success($"Menu item with id {request.Id} modified");
    }
}