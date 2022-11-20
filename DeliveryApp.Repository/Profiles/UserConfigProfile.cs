using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Repository.Profiles
{
    public class UserConfigProfile : BaseProfile
    {
        public UserConfigProfile()
        {
            CreateMap<UserConfigs, UserConfigForCreation>().ReverseMap();
            CreateMap<UserConfigs, UserConfigForUpdate>().ReverseMap();
        }
    }
}
