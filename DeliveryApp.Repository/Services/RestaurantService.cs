using AutoMapper;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Models;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
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

    public async Task AddRestaurant(RestaurantDto restaurantDto, CancellationToken cancellationToken)
    {
        var restaurant =
            _mapper.Map<Restaurants>(restaurantDto);
        restaurant.Address = _mapper.Map<RestaurantAddresses>(restaurantDto.Address);
        restaurant.Id = Guid.NewGuid();
        restaurant.Address.AddressId = Guid.NewGuid();
        foreach (var itemName in restaurantDto.menuItemsName)
            restaurant.MenuItems.Add(
                await _context.MenuItems.FirstOrDefaultAsync(x => x.ItemName.Contains(itemName), cancellationToken));
        await _context.Restaurants.AddAsync(restaurant, cancellationToken);
    }

    public async Task<List<Restaurant>> GetRestaurants(CancellationToken cancellationToken)
    {
        var restaurants = await _context.Restaurants.Include(x => x.Address)
            .Include(x => x.MenuItems)
            .ThenInclude(x => x.Photos)
            .Include(x => x.RestaurantPhotos)
            .Include(x => x.Reviews)
            .ThenInclude(x => x.User)
            .ThenInclude(x => x.Photos)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<Restaurant>>(restaurants);
    }

    public async Task<Restaurant> GetRestaurant(Guid id, CancellationToken cancellationToken)
    {
        var restaurant =
            await _context.Restaurants.Include(x => x.Address)
                .Include(x => x.MenuItems)
                .ThenInclude(x => x.Photos)
                .Include(x => x.RestaurantPhotos)
                .Include(x => x.Reviews)
                .ThenInclude(x => x.User)
                .ThenInclude(x => x.Photos)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return  _mapper.Map<Restaurant>(restaurant);
     
    }

    public async Task<List<Restaurant>> GetRestaurantsByCity(string city, CancellationToken cancellationToken)
    {
        var restaurants =
            await _context.Restaurants.Include(x => x.Address)
                .Include(x => x.MenuItems)
                .Include(x => x.RestaurantPhotos)
                .Where(x => x.Address.City == city)
                .ToListAsync(cancellationToken);
        return _mapper.Map<List<Restaurant>>(restaurants);
    }

    public async Task<bool> EditRestaurant(Guid id, RestaurantDto restaurantDto, CancellationToken cancellationToken)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);
        if (restaurant == null) return false;

        var modifiedRestaurant = _mapper.Map(restaurantDto, restaurant);
        modifiedRestaurant.MenuItems = await _context.MenuItems
            .Where(x => restaurantDto.menuItemsName.Contains(x.ItemName)).ToListAsync(cancellationToken);
        _context.Restaurants.Update(modifiedRestaurant);
        return true;
    }

    public async Task<bool> DeleteRestaurant(Guid id, CancellationToken cancellationToken)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);
        if (restaurant == null) return false;
        _context.Remove(restaurant);
        return true;
    }
}