using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Handlers
{
    public class MenuItemEditCommandHandler : ICommandHandler<MenuItemEditCommand, Result<Unit>>
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemEditCommandHandler(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository ?? throw new ArgumentNullException(nameof(menuItemRepository));
        }

        public async Task<Result<Unit>> Handle(MenuItemEditCommand request, CancellationToken cancellationToken)
        {
            return await _menuItemRepository.EditMenuItem(request, cancellationToken);
        }
    }
}
