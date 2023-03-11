using System.Globalization;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Repository.Profiles;

public class OrderProfile : BaseProfile
{
    public OrderProfile()
    {
        CreateMap<Orders, Order>().ReverseMap()
            .ForMember(option => option.ReciviedTime,
                o => o.MapFrom(src =>
                    DateTime.ParseExact(src.ReceivedTime, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)));
        CreateMap<Orders, OrderForCreationDto>().ReverseMap()
            .ForMember(option => option.ReciviedTime,
                o => o.MapFrom(src =>
                    DateTime.ParseExact(src.ReceivedTime, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)));
        CreateMap<Orders, OrderForUpdateDto>().ReverseMap();
    }
}