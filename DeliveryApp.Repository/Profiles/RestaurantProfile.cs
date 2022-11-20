using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Repository.Profiles
{
    public class RestaurantProfile:BaseProfile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurants, RestaurantForCreation>().ReverseMap();
            CreateMap<Restaurants, RestaurantForUpdate>().ReverseMap();
        }
    }
}
