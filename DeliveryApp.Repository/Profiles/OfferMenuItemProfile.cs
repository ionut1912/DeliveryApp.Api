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
                    DateTime.ParseExact(src.DateActiveTo, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)))
            .ForMember(option => option.OfferMenuItems, opt => opt.MapFrom(src => src.OfferMenuItems));
        CreateMap<Offer, OfferDtoForCreation>().ReverseMap()
            .ForMember(option => option.DateActiveFrom,
                o => o.MapFrom(src =>
                    DateTime.ParseExact(src.DateActiveFrom, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)))
            .ForMember(option => option.DateActiveTo,
                o => o.MapFrom(src =>
                    DateTime.ParseExact(src.DateActiveTo, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)));
        CreateMap<Offers, OfferDtoForCreation>().ReverseMap()
            .ForMember(option => option.DateActiveFrom,
                o => o.MapFrom(src =>
                    DateTime.ParseExact(src.DateActiveFrom, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)))
            .ForMember(option => option.DateActiveTo,
                o => o.MapFrom(src =>
                    DateTime.ParseExact(src.DateActiveTo, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)));
        CreateMap<Offers, OfferDtoForEdit>().ReverseMap();
        CreateMap<MenuItem, MenuItems>()
            .ReverseMap()
            .ForMember(x => x.OfferMenuItems, opt => opt.MapFrom(src => src.OfferMenuItems));

        CreateMap<MenuItems, MenuItemDto>()
            .ReverseMap();
        CreateMap<OfferMenuItems, OfferMenuItem>().ReverseMap();
        CreateMap<UserDto, Users>().ReverseMap()
            .ForMember(src => src.Image, opt => opt.MapFrom(dest => dest.Photos.FirstOrDefault(x => x.IsMain).Url));
    }
}