using AutoMapper;
using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Aplication.Services
{
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
            var restaurant = await _context.Restaurants.Include(x => x.address)
                .FirstOrDefaultAsync(x => x.Name == command.order.restaurantName);
            var user = await _context.Users.Include(x => x.userAddress)
                .FirstOrDefaultAsync(x => x.UserName == command.order.username);
            var order = _mapper.Map<Orders>(command.order);
            order.id = Guid.NewGuid();
            order.restaurant = restaurant;
            order.user = user;
            foreach (var menuItemName in command.order.menuItemNames)
            {
                var orderMenuItem = await _context.MenuItems.Include(x => x.offerMenuItems).Include(x => x.Photos)
                    .FirstOrDefaultAsync(x => x.itemName == menuItemName);
                order.menuItems.Add(orderMenuItem);
            }

            float price = 0;
            foreach (var menuItem in order.menuItems)
                if (menuItem.offerMenuItems.Any(x => x.offer.active))
                {
                    foreach (var offerMenuItem in menuItem.offerMenuItems)
                        if (offerMenuItem.offer.active)
                        {
                            var discount = offerMenuItem.offer.discount;
                            if (discount != 0)
                            {
                                var percentage = discount / 100;
                                var discountPrice = menuItem.price - percentage * menuItem.price;
                                price += discountPrice;
                            }
                            else
                            {
                                price += menuItem.price;
                            }
                        }
                }
                else
                {
                    price += menuItem.price;
                }

            order.finalPrice = price;
            order.status = "received";
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
                await _context.Orders.Include(x => x.restaurant).Include(x => x.user).Include(x => x.menuItems)
                    .ToListAsync(cancellationToken));
        }

        public async Task<Result<Orders>> GetOrder(QueryItem<Orders> query, CancellationToken cancellationToken)
        {
            var order =
                await _context.Orders.Include(x => x.restaurant).Include(x => x.user).Include(x => x.menuItems)
                    .FirstOrDefaultAsync(x => x.id == query.id, cancellationToken);
            if (order == null)
                return Result<Orders>.Failure(
                    "Order not found");

            return Result<Orders>.Success(order);
        }

        public async Task<Result<Unit>> EditOrder(OrderEditCommand command, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.id == command.id);
            if (order == null) return null;
            _mapper.Map(command.orderForUpdate, order);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return !result ? Result<Unit>.Failure("Failed to update order") : Result<Unit>.Success(Unit.Value);
        }

        public async Task<Result<Unit>> DeleteOrder(DeleteCommand query, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.id == query.id);
            if (order == null) return null;

            _context.Orders.Remove(order);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return !result ? Result<Unit>.Failure("Failed to delete order") : Result<Unit>.Success(Unit.Value);
        }
    }
}
