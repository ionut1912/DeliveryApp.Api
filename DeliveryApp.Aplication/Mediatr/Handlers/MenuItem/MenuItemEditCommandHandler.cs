using DeliveryApp.Application.Mediatr.Commands.MenuItem;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.MenuItem;

public class MenuItemEditCommandHandler : ICommandHandler<MenuItemEditCommand, Result>
{
    private readonly IMenuItemRepository _menuItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MenuItemEditCommandHandler(IMenuItemRepository menuItemRepository, IUnitOfWork unitOfWork)
    {
        _menuItemRepository = menuItemRepository ?? throw new ArgumentNullException(nameof(menuItemRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Result> Handle(MenuItemEditCommand request, CancellationToken cancellationToken)
    {
        var result = await _menuItemRepository.EditMenuItem(request.Id, request.MenuItemDto, cancellationToken);
        if (result is false) return Result.Failure(DomainMessages.MenuItem.CanNotEditMenuItem(request.Id));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(DomainMessages.MenuItem.MenuItemEditedSuccessfully(request.Id));
    }
}