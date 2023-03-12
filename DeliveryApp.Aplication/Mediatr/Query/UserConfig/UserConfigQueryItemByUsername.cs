using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Query.UserConfig;

public class UserConfigQueryItemByUsername : IQuery<ResultT<Domain.Models.UserConfig>>
{
    public string Username { get; set; }
}