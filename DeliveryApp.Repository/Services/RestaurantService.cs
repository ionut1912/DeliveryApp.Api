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
        var menuItems = await _context.MenuItems.AsNoTracking()
            .Where(x => restaurantDto.menuItemsName.Contains(x.ItemName)).ToListAsync(cancellationToken);
        foreach (var menuItem in menuItems)
        {
            restaurant.MenuItemsRestaurants.Add(new MenuItemsRestaurants
            {
                MenuItemsId = menuItem.Id,
                RestaurantsId = restaurant.Id,
            });
        }
        await _context.Restaurants.AddAsync(restaurant, cancellationToken);
    }

    public async Task<List<Restaurant>> GetRestaurants(CancellationToken cancellationToken)
    {
        var restaurants = await _context.Restaurants.Include(x => x.Address)
            .Include(x => x.MenuItemsRestaurants)
            .ThenInclude(x=>x.MenuItems)
            .ThenInclude(x => x.Photos)
            .Include(x => x.RestaurantPhotos)
            .Include(x => x.Reviews)
            .ThenInclude(x => x.User)
            .ThenInclude(x => x.Photos)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<Restaurant>>(restaurants);
    }

    public async Task<Restaurant> GetRestaurant(Guid id, CancellationToken cancellationToken)
    {
        var restaurant =
            await _context.Restaurants.Include(x => x.Address)
                .Include(x => x.MenuItemsRestaurants)
                .ThenInclude(x=>x.MenuItems)
                .ThenInclude(x => x.Photos)
                .Include(x => x.MenuItemsRestaurants)
                .ThenInclude(x=>x.MenuItems)
                .ThenInclude(x => x.OfferMenuItems)
                .Include(x => x.RestaurantPhotos)
                .Include(x => x.Reviews)
                .ThenInclude(x => x.User)
                .ThenInclude(x => x.Photos)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return _mapper.Map<Restaurant>(restaurant);
    }

    public async Task<List<Restaurant>> GetRestaurantsByCity(string city, CancellationToken cancellationToken)
    {
        var restaurants =
            await _context.Restaurants.Include(x => x.Address)
                .Include(x => x.MenuItemsRestaurants)
                .ThenInclude(x=>x.MenuItems)
                .Include(x => x.RestaurantPhotos)
                .AsNoTracking()
                .Where(x => x.Address.City == city)
                .ToListAsync(cancellationToken);
        return _mapper.Map<List<Restaurant>>(restaurants);
    }

    public async Task<bool> EditRestaurant(Guid id, RestaurantDto restaurantDto, CancellationToken cancellationToken)
    {
        var restaurant = await _context.Restaurants.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id,cancellationToken);
        var address = await _context.RestaurantAddresses.AsNoTracking()
            .FirstOrDefaultAsync(x => x.RestaurantId == id, cancellationToken);
        
        if (restaurant == null) return false;
        var menuItems = await _context.MenuItems.AsNoTracking()
            .Where(x => restaurantDto.menuItemsName.Contains(x.ItemName)).ToListAsync(cancellationToken);
        var restaurantMenuItems = await _context.MenuItemsRestaurants.AsNoTracking()
            .Where(x => x.RestaurantsId == id).ToListAsync(cancellationToken);

        foreach (var restaurantMenuItem in restaurantMenuItems)
        {
            _context.MenuItemsRestaurants.Remove(restaurantMenuItem);

        }

        foreach (var menuItem in menuItems)
        {
          restaurant.MenuItemsRestaurants.Add(new MenuItemsRestaurants
          {
              MenuItemsId = menuItem.Id,
              RestaurantsId = id,
          });
        }

     
        var modifiedRestaurant = _mapper.Map(restaurantDto, restaurant);
        var modifiedAddress = _mapper.Map(restaurantDto.Address, address);
        modifiedAddress.RestaurantId = id;
        foreach (var restaurantMenuItem in modifiedRestaurant.MenuItemsRestaurants)
        {
            await _context.MenuItemsRestaurants.AddAsync(restaurantMenuItem, cancellationToken);
        }
        _context.Restaurants.Update(modifiedRestaurant);
       _context.RestaurantAddresses.Update(modifiedAddress);
       return true;
    }

    public async Task<bool> DeleteRestaurant(Guid id, CancellationToken cancellationToken)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);
        if (restaurant == null) return false;
        var menuItemsRestaurants = await _context.MenuItemsRestaurants.AsNoTracking().Where(x => x.RestaurantsId == id)
            .ToListAsync(cancellationToken);

        var restaurantPhotos = await _context.PhotosForRestaurant.AsNoTracking().Where(x => x.RestaurantsId == id)
            .ToListAsync(cancellationToken);

        foreach (var restaurantPhoto in restaurantPhotos)
        {
            _context.PhotosForRestaurant.Remove(restaurantPhoto);
        }
        foreach (var menuItemRestaurant in menuItemsRestaurants )
        {
            _context.MenuItemsRestaurants.Remove(menuItemRestaurant);

        }
        
        _context.Restaurants.Remove(restaurant);
        return true;
    }
}