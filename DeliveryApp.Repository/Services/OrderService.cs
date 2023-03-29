using AutoMapper;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository.Services;

public class OrderService : IOrderRepository
{
    private readonly DeliveryContext _context;
    private readonly IMapper _mapper;
    private readonly IUserAccessor _userAccessor;

    public OrderService(DeliveryContext context, IMapper mapper, IUserAccessor userAccessor)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _userAccessor = userAccessor ?? throw new ArgumentException(nameof(userAccessor));
    }


    public async Task AddOrder(OrderForCreationDto orderForCreationDto, CancellationToken cancellationToken)
    {
        List<Restaurants> restaurants = new();

        foreach (var restaurantName in orderForCreationDto.RestaurantNames)
        {
            var restaurant = await _context.Restaurants
                .Include(x => x.Address)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == restaurantName, cancellationToken);
            restaurants.Add(restaurant);
        }

        var user = await _context.Users.AsNoTracking()
            .Include(x => x.UserAddress)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername(), cancellationToken);
        var order = _mapper.Map<Orders>(orderForCreationDto);
        order.MenuItems = new();
        order.Id = Guid.NewGuid();
        order.Restaurants = restaurants;
    
        order.User = user;
        foreach (var menuItem in orderForCreationDto.MenuItems)
        {
            var dbItem = await _context.MenuItems.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == menuItem.Id, cancellationToken);
            
            if (menuItem.Quantity > dbItem.Quantity)
                throw new Exception("The quantity that is requested is bigger than the available quantity");
            order.MenuItems.Add(dbItem);
        }

        order.ReceivedTime = DateTime.Now;

        double price = 0f;
        foreach (var menuItem in orderForCreationDto.MenuItems)
            if (menuItem.OfferMenuItems.Any())
            {
                var offerId = menuItem.OfferMenuItems.FirstOrDefault(x => x.MenuItemId == menuItem.Id).OfferId;
                var dbOffer = await _context.Offers.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == offerId, cancellationToken);
                var discountedPrice = price + menuItem.Price - dbOffer.Discount / 100.0 * menuItem.Price;
                price += discountedPrice * menuItem.Quantity;
            }
            else
            {
                price += menuItem.Price * menuItem.Quantity;
            }

        order.FinalPrice = price;
        order.Status = "Received";
        
        user.Orders.Add(order);

        foreach (var  menuItem in order.MenuItems)
        {
            menuItem.Quantity--;
            _context.MenuItems.Update(menuItem);

        }
        _context.Users.Update(user);
        await _context.Orders.AddAsync(order, cancellationToken);
    }

    public async Task<List<Order>> GetOrders(CancellationToken cancellationToken)
    {
        var orders = await _context.Orders.Include(x => x.Restaurants).Include(x => x.User).Include(x => x.MenuItems)
            .ToListAsync(cancellationToken);
        return _mapper.Map<List<Order>>(orders);
    }

    public async Task<Order> GetOrder(Guid id, CancellationToken cancellationToken)
    {
        var order =
            await _context.Orders.Include(x => x.Restaurants).Include(x => x.User).Include(x => x.MenuItems)
               
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return _mapper.Map<Order>(order);
    }

    public async Task<bool> EditOrder(Guid id, OrderForUpdateDto orderForUpdateDto, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (order == null) return false;
        var modifiedOrder = _mapper.Map(orderForUpdateDto, order);
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