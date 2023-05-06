using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Contracts;

namespace DeliveryApp.Application.Mediatr.Query.Account;

public class GetResetPasswordCodeQuery : IQuery<ResultT<UserCodeContract>>
{
    public string Email { get; set; }
}