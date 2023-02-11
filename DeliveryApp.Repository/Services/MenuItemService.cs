using AutoMapper;
using DeliveryApp.Aplication.Mediatr.Commands.MenuItem;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository.Services;

public class MenuItemService : IMenuItemRepository
{
    private readonly DeliveryContext _context;
    private readonly IMapper _mapper;

    public MenuItemService(DeliveryContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<MenuItem>> AddMenuItems(MenuItemCreateCommand request,
        CancellationToken cancellationToken)
    {
        var menuItem = _mapper.Map<MenuItems>(request.MenuItemForCreation);
        menuItem.Id = Guid.NewGuid();


        menuItem.Active = request.MenuItemForCreation.Quantity > 0;
        await _context.MenuItems.AddAsync(menuItem);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        var mapped = _mapper.Map<MenuItem>(menuItem);
        return !result ? Result<MenuItem>.Failure("Menu Item not created") : Result<MenuItem>.Success(mapped);
    }

    public async Task<Result<List<MenuItem>>> GetMenuItems(ListQuery<MenuItem> request,
        CancellationToken cancellationToken)
    {
        var menuItems = await _context.MenuItems.Include(x => x.OfferMenuItems)
            .Include(x => x.Photos)
            .ToListAsync(cancellationToken);
        var mapped = _mapper.Map<List<MenuItem>>(menuItems);
        return Result<List<MenuItem>>.Success(mapped);
    }

    public async Task<Result<MenuItem>> GetMenuItem(QueryItem<MenuItem> request, CancellationToken cancellationToken)
    {
        var menuItem = await _context.MenuItems.Include(x => x.Photos).Include(x => x.OfferMenuItems)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        var mapped = _mapper.Map<MenuItem>(menuItem);
        return mapped == null
            ? Result<MenuItem>.Failure("Menu item not found")
            : Result<MenuItem>.Success(mapped);
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