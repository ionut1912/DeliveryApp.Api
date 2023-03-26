﻿using System.Globalization;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Repository.Profiles;

public class OfferMenuItemProfile : BaseProfile
{
    public OfferMenuItemProfile()
    {
        CreateMap<Offers, Offer>().ReverseMap()
            .ForMember(option => option.DateActiveFrom,
                o => o.MapFrom(src =>
                    DateTime.ParseExact(src.DateActiveFrom, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)))
            .ForMember(option => option.DateActiveTo,
                o => o.MapFrom(src =>
                    DateTime.ParseExact(src.DateActiveTo, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)));
        CreateMap<Offer, OfferDto>().ReverseMap()
            .ForMember(option => option.DateActiveFrom,
                o => o.MapFrom(src =>
                    DateTime.ParseExact(src.DateActiveFrom, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)))
            .ForMember(option => option.DateActiveTo,
                o => o.MapFrom(src =>
                    DateTime.ParseExact(src.DateActiveTo, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)));
        CreateMap<MenuItem, MenuItems>()
            .ReverseMap();
        CreateMap<MenuItems, MenuItemDto>()
            .ReverseMap();
        CreateMap<UserDto, Users>().ReverseMap()
            .ForMember(src => src.Image, opt => opt.MapFrom(dest => dest.Photos.FirstOrDefault(x => x.IsMain).Url));
    }
}