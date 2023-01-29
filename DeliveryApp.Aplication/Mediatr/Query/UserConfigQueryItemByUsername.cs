using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Query;

public class UserConfigQueryItemByUsername : IQuery<Result<UserConfigs>>
{
    public string Username { get; set; }
}