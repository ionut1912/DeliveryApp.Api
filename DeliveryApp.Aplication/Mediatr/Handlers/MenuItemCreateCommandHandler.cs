using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Handlers
{
    public class MenuItemCreateCommandHandler : ICommandHandler<MenuItemCreateCommand, Result<MenuItems>>
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemCreateCommandHandler(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository ?? throw new ArgumentNullException(nameof(menuItemRepository));
        }

        public async Task<Result<MenuItems>> Handle(MenuItemCreateCommand request, CancellationToken cancellationToken)
        {
            return await _menuItemRepository.AddMenuItems(request, cancellationToken);
        }
    }
}
