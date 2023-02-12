using AutoMapper;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using Microsoft.EntityFrameworkCore;
namespace DeliveryApp.Repository.Services;

public class OrderService : IOrderRepository
{
    private readonly DeliveryContext _context;
    private readonly IMapper _mapper;

    public OrderService(DeliveryContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }




    public async Task AddOrder(OrderForCreationDto orderForCreationDto, CancellationToken cancellationToken)
    {
        var restaurant = await _context.Restaurants
            .Include(x => x.Address)
            .FirstOrDefaultAsync(x => x.Name == orderForCreationDto.Restaurant.Name, cancellationToken);
        var user = await _context.Users
            .Include(x => x.UserAddress)
            .FirstOrDefaultAsync(x => x.UserName == orderForCreationDto.Username, cancellationToken);
        var order = _mapper.Map<Orders>(orderForCreationDto);
        order.Id = Guid.NewGuid();
        order.Restaurant = restaurant;
        order.User = user;
        var menuItems = await _context.MenuItems
            .Include(x => x.OfferMenuItems)
            .Include(x => x.Photos)
            .Where(x => orderForCreationDto.MenuItemNames.Contains(x.ItemName))
            .ToListAsync(cancellationToken);
        order.MenuItems = menuItems;
        var price = menuItems.Sum(menuItem =>
            menuItem.OfferMenuItems.Any(x => x.Offer.Active)
                ? menuItem.OfferMenuItems
                    .Where(x => x.Offer.Active)
                    .Sum(x => x.Offer.Discount == 0
                        ? menuItem.Price
                        : menuItem.Price - menuItem.Price * (x.Offer.Discount / 100))
                : menuItem.Price);
        order.FinalPrice = price;
        order.Status = "received";
        await _context.Orders.AddAsync(order, cancellationToken);

    }

    public async Task<List<Order>> GetOrders(CancellationToken cancellationToken)
    {
        var orders = await _context.Orders.Include(x => x.Restaurant).Include(x => x.User).Include(x => x.MenuItems)
            .ToListAsync(cancellationToken);
        return _mapper.Map<List<Order>>(orders);
    }

    public async Task<Order> GetOrder(Guid id, CancellationToken cancellationToken)
    {
        var order =
            await _context.Orders.Include(x => x.Restaurant).Include(x => x.User).Include(x => x.MenuItems)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return _mapper.Map<Order>(order);
    }

    public async Task<bool> EditOrder(Guid id,OrderForUpdateDto orderForUpdateDto, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (order == null) return false;
        var modifiedOrder=_mapper.Map(orderForUpdateDto,order);
        _context.Orders.Update(modifiedOrder);
        return true;
    }

    public async Task<bool> DeleteOrder(Guid id, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (order == null) return false;
        _context.Orders.Remove(order);
        return true;
    }
}