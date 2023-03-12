using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Mediatr.Query.UserConfig;

public class UserConfigQueryItemByUsername : IQuery<ResultT<Domain.Models.UserConfig>>
{
    public string Username { get; set; }
}