using AutoMapper;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
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

    public async Task AddMenuItems(MenuItemDto menuItemDto, CancellationToken cancellationToken)
    {
        var menuItem = _mapper.Map<MenuItems>(menuItemDto);
        menuItem.Id = Guid.NewGuid();

        menuItem.Active = menuItemDto.Quantity > 0;
        await _context.MenuItems.AddAsync(menuItem);
    }

    public async Task<List<MenuItem>> GetMenuItems(CancellationToken cancellationToken)
    {
        var menuItems = await _context.MenuItems.Include(x => x.OfferMenuItems)
            .Include(x => x.Photos)
            .ToListAsync(cancellationToken);
        return _mapper.Map<List<MenuItem>>(menuItems);
    }

    public async Task<MenuItem> GetMenuItem(Guid id, CancellationToken cancellationToken)
    {
        var menuItem = await _context.MenuItems.Include(x => x.Photos).Include(x => x.OfferMenuItems)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return _mapper.Map<MenuItem>(menuItem);
    }

    public async Task<bool> EditMenuItem(Guid id, MenuItemDto menuItemDto, CancellationToken token)
    {
        var menuItem = await _context.MenuItems.FindAsync(id);
        if (menuItem == null) return false;
        var modifiedMenuItem = _mapper.Map(menuItemDto, menuItem);
        modifiedMenuItem.Active = menuItemDto.Quantity > 0;

        _context.MenuItems.Update(modifiedMenuItem);
        return true;
    }
}