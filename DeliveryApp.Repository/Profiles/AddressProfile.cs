using DeliveryApp.Commons.Models;

namespace DeliveryApp.Repository.Profiles;

public class AddressProfile : BaseProfile
{
    public AddressProfile()
    {
        CreateMap<RestaurantAddresses, RestaurantAddressesForCreation>().ReverseMap();
        CreateMap<RestaurantAddresses, RestaurantAddressesForUpdate>().ReverseMap();
        CreateMap<UserAddresses, UserAddressesForCreation>().ReverseMap();
    }
}