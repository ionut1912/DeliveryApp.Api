using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Query.Account;

public class GetCurrentUserQuery : IQuery<ResultT<UserDto>>
{
    public string Username { get; set; }
}