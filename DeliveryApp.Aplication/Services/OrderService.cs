using AutoMapper;
using DeliveryApp.Aplication.Mediatr.Commands.Order;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Aplication.Services;

public class OrderService : IOrderRepository
{
    private readonly DeliveryContext _context;
    private readonly IMapper _mapper;

    public OrderService(DeliveryContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<Orders>> AddOrder(OrderCreateCommand command, CancellationToken cancellationToken)
    {
        var restaurant = await _context.Restaurants.Include(x => x.Address)
            .FirstOrDefaultAsync(x => x.Name == command.Order.RestaurantName);
        var user = await _context.Users.Include(x => x.UserAddress)
            .FirstOrDefaultAsync(x => x.UserName == command.Order.Username);
        var order = _mapper.Map<Orders>(command.Order);
        order.Id = Guid.NewGuid();
        order.Restaurant = restaurant;
        order.User = user;
        foreach (var menuItemName in command.Order.MenuItemNames)
        {
            var orderMenuItem = await _context.MenuItems.Include(x => x.OfferMenuItems).Include(x => x.Photos)
                .FirstOrDefaultAsync(x => x.ItemName == menuItemName);
            order.MenuItems.Add(orderMenuItem);
        }

        float price = 0;
        foreach (var menuItem in order.MenuItems)
            if (menuItem.OfferMenuItems.Any(x => x.Offer.Active))
            {
                foreach (var offerMenuItem in menuItem.OfferMenuItems)
                    if (offerMenuItem.Offer.Active)
                    {
                        var discount = offerMenuItem.Offer.Discount;
                        if (discount != 0)
                        {
                            var percentage = discount / 100;
                            var discountPrice = menuItem.Price - percentage * menuItem.Price;
                            price += discountPrice;
                        }
                        else
                        {
                            price += menuItem.Price;
                        }
                    }
            }
            else
            {
                price += menuItem.Price;
            }

        order.FinalPrice = price;
        order.Status = "received";
        _context.Orders.Add(order);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        return result
            ? Result<Orders>.Success(order)
            : Result<Orders>.Failure(
                "Failed to create order");
    }

    public async Task<Result<List<Orders>>> GetOrders(ListQuery<Orders> command, CancellationToken cancellationToken)
    {
        return Result<List<Orders>>.Success(
            await _context.Orders.Include(x => x.Restaurant).Include(x => x.User).Include(x => x.MenuItems)
                .ToListAsync(cancellationToken));
    }

    public async Task<Result<Orders>> GetOrder(QueryItem<Orders> query, CancellationToken cancellationToken)
    {
        var order =
            await _context.Orders.Include(x => x.Restaurant).Include(x => x.User).Include(x => x.MenuItems)
                .FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
        if (order == null)
            return Result<Orders>.Failure(
                "Order not found");

        return Result<Orders>.Success(order);
    }

    public async Task<Result<Unit>> EditOrder(OrderEditCommand command, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == command.Id);
        if (order == null) return null;
        _mapper.Map(command.OrderForUpdate, order);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        return !result ? Result<Unit>.Failure("Failed to update order") : Result<Unit>.Success(Unit.Value);
    }

    public async Task<Result<Unit>> DeleteOrder(DeleteCommand query, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == query.Id);
        if (order == null) return null;

        _context.Orders.Remove(order);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        return !result ? Result<Unit>.Failure("Failed to delete order") : Result<Unit>.Success(Unit.Value);
    }
}