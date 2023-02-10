using AutoMapper;
using DeliveryApp.Aplication.Mediatr.Commands.MenuItem;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Aplication.Services;

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
        var menuItem = _mapper.Map<MenuItems>(request.MenuItemForCreation);
        menuItem.Id = Guid.NewGuid();


        menuItem.Active = request.MenuItemForCreation.Quantity > 0;
        _context.MenuItems.Add(menuItem);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        return !result ? Result<MenuItems>.Failure("Menu Item not created") : Result<MenuItems>.Success(menuItem);
    }

    public async Task<Result<List<MenuItems>>> GetMenuItems(ListQuery<MenuItems> request,
        CancellationToken cancellationToken)
    {
        return Result<List<MenuItems>>.Success(await _context.MenuItems.Include(x => x.OfferMenuItems)
            .Include(x => x.Photos)
            .ToListAsync(cancellationToken));
    }

    public async Task<Result<MenuItems>> GetMenuItem(QueryItem<MenuItems> request, CancellationToken cancellationToken)
    {
        var menuItem = await _context.MenuItems.Include(x => x.Photos).Include(x => x.OfferMenuItems)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        return menuItem == null
            ? Result<MenuItems>.Failure("Menu item not found")
            : Result<MenuItems>.Success(menuItem);
    }

    public async Task<Result<Unit>> EditMenuItem(MenuItemEditCommand request, CancellationToken token)
    {
        var menuItem = await _context.MenuItems.FindAsync(request.Id);
        if (menuItem == null) return null;
        menuItem.Active = request.MenuItemForUpdate.Quantity > 0;

        _mapper.Map(request.MenuItemForUpdate, menuItem);
        var result = await _context.SaveChangesAsync(token) > 0;
        return !result ? Result<Unit>.Failure("Failed to update menu item") : Result<Unit>.Success(Unit.Value);
    }
}