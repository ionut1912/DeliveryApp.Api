using System.Globalization;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Repository.Profiles
{
    public class OfferMenuItemProfile : BaseProfile
    {
        public OfferMenuItemProfile()
        {
            CreateMap<Offers, OfferForCreation>().ReverseMap()
                .ForMember(option => option.dateActiveFrom,
                    o => o.MapFrom(src =>
                        DateTime.ParseExact(src.dateActiveFrom, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture)))
                .ForMember(option => option.dateActiveTo,
                    o => o.MapFrom(src =>
                        DateTime.ParseExact(src.dateActiveTo, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture)));
            CreateMap<Offers, OfferForUpdate>().ReverseMap()
                .ForMember(option => option.dateActiveFrom,
                    o => o.MapFrom(src =>
                        DateTime.ParseExact(src.dateActiveFrom, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture)))
                .ForMember(option => option.dateActiveTo,
                    o => o.MapFrom(src =>
                        DateTime.ParseExact(src.dateActiveTo, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture)));

            CreateMap<MenuItems, MenuItemForCreation>().ReverseMap();
            CreateMap<MenuItems, MenuItemForUpdate>().ReverseMap();
        }
    }
}
