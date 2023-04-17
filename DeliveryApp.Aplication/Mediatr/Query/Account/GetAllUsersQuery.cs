using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Mediatr.Query.Account;

public class GetAllUsersQuery : IQuery<ResultT<List<User>>>
{
}