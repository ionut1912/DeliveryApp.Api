using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Repository.Profiles;

public class ReviewForRestaurantProfile : BaseProfile
{
    public ReviewForRestaurantProfile()
    {
        CreateMap<ReviewForRestaurants, ReviewForRestaurant>().ReverseMap();
        CreateMap<ReviewForRestaurants, ReviewForRestaurantDto>().ReverseMap();
    }
}