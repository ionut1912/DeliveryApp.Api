using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Repository.Profiles;

public class RestaurantProfile : BaseProfile
{
    public RestaurantProfile()
    {
        CreateMap<RestaurantWithImage, Restaurants>().ReverseMap()
            .ForMember(x => x.MenuItems, o => o.MapFrom(x => x.MenuItems))
            .ForMember(x => x.Image, opt => opt.MapFrom(src => src.RestaurantPhotos.FirstOrDefault(x => x.IsMain).Url));
        CreateMap<RestaurantWithImages, Restaurants>().ReverseMap()
            .ForMember(x => x.MenuItems, o => o.MapFrom(x => x.MenuItems));
        CreateMap<Restaurants, RestaurantDto>().ReverseMap();
        CreateMap<UserDto, Users>().ReverseMap()
            .ForMember(src => src.Image, opt => opt.MapFrom(dest => dest.Photos.FirstOrDefault(x => x.IsMain).Url));
    }
}