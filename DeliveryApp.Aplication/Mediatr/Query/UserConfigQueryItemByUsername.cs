using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Aplication.Mediatr.Query;

public class UserConfigQueryItemByUsername : IQuery<Result<UserConfig>>
{
    public string Username { get; set; }
}