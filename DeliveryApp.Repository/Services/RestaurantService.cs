using AutoMapper;
using DeliveryApp.Aplication.Mediatr.Commands.Restaurant;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Models;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository.Services;

public class RestaurantService : IRestaurantRepository
{
    private readonly DeliveryContext _context;
    private readonly IMapper _mapper;


    public RestaurantService(DeliveryContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<Unit>> EditRestaurant(RestaurantEditCommand command, CancellationToken cancellationToken)
    {
        var restaurant = await _context.Restaurants.FindAsync(command.Id);
        if (restaurant == null) return null;
        _mapper.Map(command.RestaurantForUpdate, restaurant);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        return !result ? Result<Unit>.Failure("Failed to update restaurant") : Result<Unit>.Success(Unit.Value);
    }

    public async Task<Result<Unit>> DeleteRestaurant(DeleteCommand query, CancellationToken cancellationToken)
    {
        var restaurant = await _context.Restaurants.FindAsync(query.Id);
        if (restaurant == null) return null;
        _context.Remove(restaurant);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        return !result ? Result<Unit>.Failure("Failed to delete restaurant") : Result<Unit>.Success(Unit.Value);
    }

    public async Task<Result<Restaurant>> AddRestaurant(RestaurantCreateCommand command,
        CancellationToken cancellationToken)
    {
        var restaurant =
            _mapper.Map<Restaurants>(command.RestaurantForCreation);
        restaurant.Address = _mapper.Map<RestaurantAddresses>(command.RestaurantForCreation.Address);
        restaurant.Id = Guid.NewGuid();
        restaurant.Address.AddressId = Guid.NewGuid();
        _context.Restaurants.Add(restaurant);


        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        var mapped = _mapper.Map<Restaurant>(restaurant);
        return result
            ? Result<Restaurant>.Success(mapped)
            : Result<Restaurant>.Failure(
                "Failed to create restaurant");
    }

    public async Task<Result<List<Restaurant>>> GetRestaurants(ListQuery<Restaurant> command,
        CancellationToken cancellationToken)
    {
        var restaurants = await _context.Restaurants.Include(x => x.Address)
            .ToListAsync(cancellationToken);
        var mapped = _mapper.Map<List<Restaurant>>(restaurants);
        return Result<List<Restaurant>>.Success(mapped);

    }

    public async Task<Result<Restaurant>> GetRestaurant(QueryItem<Restaurant> query,
        CancellationToken cancellationToken)
    {
        var restaurant =
            await _context.Restaurants.Include(x => x.Address)
                .FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
        if (restaurant == null)
            return Result<Restaurant>.Failure(
                "Restaurant not found");
        var mapped = _mapper.Map<Restaurant>(restaurant);
        return Result<Restaurant>.Success(mapped);
    }
}