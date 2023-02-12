using DeliveryApp.Domain.DTO;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Repository.Profiles;

public class UserConfigProfile : BaseProfile
{
    public UserConfigProfile()
    {
        CreateMap<UserConfigs, UserConfig>().ReverseMap();
        CreateMap<UserConfigs, UserConfigDto>().ReverseMap();
    }
}