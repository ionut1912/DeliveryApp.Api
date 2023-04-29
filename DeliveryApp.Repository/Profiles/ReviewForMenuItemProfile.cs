using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Repository.Profiles;

public class ReviewForMenuItemProfile : BaseProfile
{
    public ReviewForMenuItemProfile()
    {
        CreateMap<ReviewForMenuItem, ReviewForMenuItems>().ReverseMap();
        CreateMap<ReviewForMenuItems, ReviewForMenuItemDto>().ReverseMap();
    }
}