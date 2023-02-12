using DeliveryApp.Domain.DTO;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Repository.Profiles;

public class RestaurantProfile : BaseProfile
{
    public RestaurantProfile()
    {
        CreateMap<Restaurants, Restaurant>().ReverseMap();
        CreateMap<Restaurants, RestaurantDto>().ReverseMap();
    }
}