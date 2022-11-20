using AutoMapper;
using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Aplication.Services
{
    public class MenuItemService : IMenuItemRepository
    {
        private readonly DeliveryContext _context;
        private readonly IMapper _mapper;

        public MenuItemService(DeliveryContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<MenuItems>> AddMenuItems(MenuItemCreateCommand request,
            CancellationToken cancellationToken)
        {
            var menuItem = _mapper.Map<MenuItems>(request.menuItemForCreation);
            menuItem.id = Guid.NewGuid();


            menuItem.active = request.menuItemForCreation.quantity > 0;
            _context.MenuItems.Add(menuItem);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return !result ? Result<MenuItems>.Failure("Menu Item not created") : Result<MenuItems>.Success(menuItem);
        }

        public async Task<Result<List<MenuItems>>> GetMenuItems(ListQuery<MenuItems> request,
            CancellationToken cancellationToken)
        {
            return Result<List<MenuItems>>.Success(await _context.MenuItems.Include(x => x.offerMenuItems)
                .Include(x => x.Photos)
                .ToListAsync(cancellationToken));
        }

        public async Task<Result<MenuItems>> GetMenuItem(QueryItem<MenuItems> request, CancellationToken cancellationToken)
        {
            var menuItem = await _context.MenuItems.Include(x => x.Photos).Include(x => x.offerMenuItems)
                .FirstOrDefaultAsync(x => x.id == request.id, cancellationToken);
            return menuItem == null
                ? Result<MenuItems>.Failure("Menu item not found")
                : Result<MenuItems>.Success(menuItem);
        }

        public async Task<Result<Unit>> EditMenuItem(MenuItemEditCommand request, CancellationToken token)
        {
            var menuItem = await _context.MenuItems.FindAsync(request.id);
            if (menuItem == null) return null;
            menuItem.active = request.menuItemForUpdate.quantity > 0;

            _mapper.Map(request.menuItemForUpdate, menuItem);
            var result = await _context.SaveChangesAsync(token) > 0;
            return !result ? Result<Unit>.Failure("Failed to update menu item") : Result<Unit>.Success(Unit.Value);
        }
    }
}
