using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Repository.Profiles;

public class RestaurantProfile : BaseProfile
{
    public RestaurantProfile()
    {
        CreateMap<Restaurants, Restaurant>().ReverseMap()
            .ForMember(x => x.MenuItems, o => o.MapFrom(x => x.MenuItems));
        CreateMap<Restaurants, RestaurantDto>().ReverseMap();
    }
}